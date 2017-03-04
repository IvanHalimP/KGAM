using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinik_Gigi_Ana_Medika
{
    public partial class frmTrx : Form
    {
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();

        CultureInfo indoCultureInfo = CultureInfo.CreateSpecificCulture("id-ID");
        string trtName = "";
        int trtPrice = 0;
        int trtSubTot = 0;
        int Total = 0;
        int Adm = 0;
        int isCreditable = 0;

        string trxid = DateTime.Now.ToString("yyyyMMddHHmmss");

        frmTransactions frmhdrTrx;

        List<trxDetails> trxDets = new List<trxDetails>();
        List<detPayment> lastDetPaymentList;

        int totalAmount = 0;
        int paid = 0;
        int rest = 0;
        int pay = 0;
        int change = 0;

        int allowedCredit = 0;
        int shouldPay = 0;

        string selectedRekamMedik = "";
        string selectedSIP = "";

        void getAdmin() {
            var admAmount = (from msTax in conn.msTaxes
                            where msTax.Name == "Admin"
                            select msTax.Amount).ToList().First().ToString();
            Adm = int.Parse(admAmount);
        }

        public void setSelectedPatient(string id,string name, string RMedik)
        {
            txtPatientID.Text = id;
            txtPatientName.Text = name;
            selectedRekamMedik = RMedik;
        }

        public void setSelectedDoctor(string id,string name, string SIP)
        {
            txtDoctorId.Text = id;
            txtDoctorName.Text = name;
            selectedSIP = SIP;
        }

        public void setSelectedTreat(string ID, string name, int price, int isCredit) {
            txtTreatmentID.Text = ID;
            trtName = name;
            trtPrice =price;
            isCreditable = isCredit;
        }

        private bool validTreatmentID(string trtid)
        {
            int valid = (from x in conn.msTreatments
                         where (x.TreatmentId == trtid)
                         select x).Count();
            return (valid==1);
        }
        
        public int getCurrentDetId()
        {
            var query = from x in conn.detTransactions
                        orderby x.detTrxId descending
                        select x.detTrxId;
            return Int32.Parse(query.FirstOrDefault().ToString());
        }

        int getTrPrice() {
            var pQuery = (from msTreatment in conn.msTreatments
                         where msTreatment.TreatmentId == txtTreatmentID.Text
                         select new { msTreatment.Price, msTreatment.Name }).ToList();
            if (pQuery != null)
            {
                trtName = pQuery.First().Name;
                return int.Parse(pQuery.First().Price.ToString());
            }
            else {
                return 0;
            }
        }

        public void getTrxHist(string TrxID) {
            lastDetPaymentList = new List<detPayment>();
            var getTrxHist = (from detPayment in conn.detPayments
                              //join detAdm in conn.detAdms on detPayment.TrxDate equals detAdm.TrxDate
                              where detPayment.TrxId == TrxID
                              select new {detPayment.detId, detPayment.detTrxId, detPayment.TrxDate, detPayment.Amount, detPayment.PaymentType, detPayment.Remnant /*Adm=detAdm.Amount*/}).ToList();
            dgPayDet.DataSource = getTrxHist;
            if (getTrxHist!=null)
            {
                string lastPayment = (getTrxHist.Last().TrxDate).ToString();
                var lastDetPayment = getTrxHist.Where(trxHist=>trxHist.TrxDate==lastPayment);

                foreach(var item in lastDetPayment)
                {
                    detPayment tmpLastPay = new detPayment();
                    tmpLastPay.detId = item.detId;
                    tmpLastPay.detTrxId = item.detTrxId;
                    tmpLastPay.TrxDate = item.TrxDate;
                    tmpLastPay.Amount = item.Amount;
                    tmpLastPay.Remnant = item.Remnant;
                    tmpLastPay.PaymentType = item.PaymentType;
                    lastDetPaymentList.Add(tmpLastPay);
                }

                txtPaid.Text = (lastDetPayment.Sum(lastTrx => lastTrx.Amount)).ToString();
                txtRest.Text = (lastDetPayment.Sum(lastTrx => lastTrx.Remnant)).ToString();
                
                rest = int.Parse(txtRest.Text);
                if (rest == 0)
                {
                    txtRest.Text = "0";
                    btnPay.Enabled = false;
                }
                else
                {
                    if (chkAdm.Checked)
                    {
                        txtRest.Text = (rest + Adm).ToString();
                    }
                    else
                    {
                        txtRest.Text = (rest).ToString();
                    }
                }
                Total = (int.Parse(txtPaid.Text) + rest);
                txtTotalAmount.Text = Total.ToString();
            }
        }

        public void getTrxDet(string TrxID) {
            var getTrxDet = (from detTransaction in conn.detTransactions
                             join msTreatment in conn.msTreatments on detTransaction.TrtId equals msTreatment.TreatmentId
                             where detTransaction.TrxId==TrxID
                             select new { detTransaction.TrtId, msTreatment.Name, msTreatment.Price, detTransaction.Qty, detTransaction.Disc, SubTot=0}).ToList();
            for (int i = 0; i < getTrxDet.Count(); i++)
            {
                dgDetTrx.Rows.Add(getTrxDet[i].TrtId, getTrxDet[i].Name, getTrxDet[i].Price, getTrxDet[i].Qty, getTrxDet[i].Disc, getTrxDet[i].SubTot);
                dgDetTrx.Rows[i].Cells[5].Value = calcSubTot(int.Parse(dgDetTrx.Rows[i].Cells[2].Value.ToString()), int.Parse(dgDetTrx.Rows[i].Cells[3].Value.ToString()), float.Parse(dgDetTrx.Rows[i].Cells[4].Value.ToString()));
            }
        }
        
        public void getTrxHdr(string TrxID)
        {
            var getTrxHdr = (from hdrTransaction in conn.hdrTransactions
                             join msPatient in conn.msPatients on hdrTransaction.PtnId equals msPatient.PatientId
                             join msDoctor in conn.msDoctors on hdrTransaction.DocId equals msDoctor.DoctorId
                             where hdrTransaction.TrxId == TrxID
                             select new { PName = msPatient.Name, msPatient.PatientId, DName=msDoctor.Name, msDoctor.DoctorId}).ToList();
            trxid = TrxID;
            lblTrx.Text = TrxID;
            txtPatientID.Text = getTrxHdr.First().PatientId;
            txtPatientName.Text = getTrxHdr.First().PName;
            txtDoctorId.Text = getTrxHdr.First().DoctorId;
            txtDoctorName.Text = getTrxHdr.First().DName;
        }
        public int calcSubTot(int trPrice, int Qty, float Dsc)
        {
            float disc = (trPrice * (Dsc / 100));
            trtSubTot = (trPrice - (int)disc) * Qty;
            return trtSubTot;
        }

        void calcGrandTotal() {
            Total = 0;
            foreach (trxDetails t in trxDets)
            {
                Total += t.subTot;
            }
            txtGTotal.Text = Total.ToString();
        }

        void CalculateChange()
        {
            if (chkAdm.Checked)
            {
                if (pay > rest+Adm)
                {
                    change = pay - (rest+Adm);
                    txtRest.Text = "0";
                }
                else
                {
                    change = 0;
                    txtRest.Text = ((rest+Adm) - pay).ToString();
                }
            }
            else {
                if (pay > rest)
                {
                    change = pay - rest;
                    txtRest.Text = "0";
                }
                else
                {
                    change = 0;
                    txtRest.Text = (rest - pay).ToString();
                }
            }
            txtChange.Text = change.ToString();
        }

        private void insertHdrTrxToDB()
        {
            hdrTransaction ht = new hdrTransaction();
            ht.TrxId = trxid;
            ht.DocId = txtDoctorId.Text;
            ht.PtnId = txtPatientID.Text;
            ht.PaymentStatus = "Incomplete";
            try
            {
                conn.hdrTransactions.InsertOnSubmit(ht);
                conn.SubmitChanges();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void insertDetTrxToDB()
        {
            foreach (trxDetails det in trxDets)
            {
                detTransaction dt = new detTransaction();
                dt.TrxId = trxid;
                dt.TrtId = det.trtID;
                dt.detTrxId = getCurrentDetId();
                dt.Qty = det.qty;
                dt.Disc = det.disc;
                dt.LabPrice = det.labPrice;
                dt.Status = "Incomplete";
                try
                {
                    conn.detTransactions.InsertOnSubmit(dt);
                    conn.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }
       
        void updateTrxPayment(int dettrxid) {
            var getTrxDets = (from detTransaction in conn.detTransactions
                             where (detTransaction.TrxId == trxid && detTransaction.detTrxId == dettrxid)
                             select detTransaction).ToList().First();
            getTrxDets.Status = "Completed";
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        List<int> getDetTrxId(String trxId)
        {
            var loadDetTrxId = (from detTransaction in conn.detTransactions
                              where detTransaction.TrxId == trxId
                              select detTransaction.detTrxId).ToList();
            return loadDetTrxId;
        }

        void insertDetPayment(string trxID, int detTrxID, int payamount, int restamount, string payType)
        {
            detPayment dPay = new detPayment();

            dPay.Amount = payamount;
            dPay.Remnant = restamount;
            dPay.TrxId = trxID;
            dPay.TrxDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            dPay.PaymentType = payType;
            dPay.detTrxId = detTrxID;

            conn.detPayments.InsertOnSubmit(dPay);
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void insertPaymenttoDB(string trxID, int payamount, int restamount, string payType)
        {
            /*
             * cek dulu si detTrx ada yang harus lunas?
             * kalo ada di totalin, terus payamount-=yang harus lunas
             * sisanya distribute ke yang bisa cicil
            */
            int PayVal = payamount;
            var creditables = (from detTransaction in conn.detTransactions
                               join msTreatment in conn.msTreatments on detTransaction.TrtId equals msTreatment.TreatmentId
                               where detTransaction.TrxId==trxID
                               select new { detTransaction.detTrxId, msTreatment.isCreditable, subTot=calcSubTot((int)msTreatment.Price, (int)detTransaction.Qty, (int)detTransaction.Disc), detTransaction.Status}).ToList();

            if (lastDetPaymentList == null)
            {
                foreach (var item in creditables)
                {
                    if (item.isCreditable == 0 && item.Status == "Incomplete")
                    {
                        insertDetPayment(trxID, item.detTrxId, item.subTot, 0, payType);
                        PayVal -= item.subTot;
                        updateTrxPayment(item.detTrxId);
                    }
                }
                foreach (var item in creditables)
                {
                    if (item.isCreditable == 1 && item.Status == "Incomplete")
                    {
                        if (PayVal < item.subTot)
                        {
                            insertDetPayment(trxID, item.detTrxId, PayVal, item.subTot - PayVal, payType);
                            PayVal = 0;
                        }
                        else
                        {
                            insertDetPayment(trxID, item.detTrxId, item.subTot, 0, payType);
                            PayVal -= item.subTot;
                            updateTrxPayment(item.detTrxId);
                        }
                    }
                }
            }else
            {
                foreach (var item in creditables)
                {
                    if (item.isCreditable == 1 && item.Status == "Incomplete")
                    {
                        var itemRemnant = (from rem in lastDetPaymentList
                                           where rem.detTrxId == item.detTrxId
                                           select rem).ToList().First();
                        if (PayVal < item.subTot)
                        {
                            insertDetPayment(trxID, item.detTrxId, PayVal, Int32.Parse(itemRemnant.Remnant.ToString()) - PayVal, payType);
                            PayVal = 0;
                        }
                        else
                        {
                            insertDetPayment(trxID, item.detTrxId, Int32.Parse(itemRemnant.Remnant.ToString()), 0, payType);
                            PayVal -= Int32.Parse(itemRemnant.Remnant.ToString());
                            updateTrxPayment(item.detTrxId);
                        }
                    }
                }
            }
        }

        void insertAdminFee(int admFee)
        {
            detAdm dAdm = new detAdm();
            dAdm.TrxDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            dAdm.Amount = admFee;
            conn.detAdms.InsertOnSubmit(dAdm);
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void updPaymentStatus(string trxID) {
            try
            {
                var updQuery = (from hdrTransaction in conn.hdrTransactions
                                where (hdrTransaction.TrxId == trxID)
                                select hdrTransaction).ToList().First();
                updQuery.PaymentStatus = "Completed";
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public frmTrx()
        {
            //trtId = getCurrentTrxId();
            InitializeComponent();
        }

        private void frmTrx_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("F", indoCultureInfo);
            lblTrx.Text = trxid = DateTime.Now.ToString("yyyyMMddHHmmss");
            cbPayType.SelectedIndex = 0;
            getAdmin();
        }
        
        private void btnSearchPat_Click(object sender, EventArgs e)
        {
            frmSearchPatient srcPat = new frmSearchPatient();
            srcPat.parent = this;
            srcPat.Show();
        }

        private void btnSearchDoc_Click(object sender, EventArgs e)
        {
            frmSearchDoctor srcDoc = new frmSearchDoctor();
            srcDoc.parent = this;
            srcDoc.Show();
        }

        private void btnScrTreatments_Click(object sender, EventArgs e)
        {
            frmSearchTreatment srcTrt = new frmSearchTreatment();
            srcTrt.parent = this;
            srcTrt.Show();
        }

        private void txtTreatmentID_TextChanged(object sender, EventArgs e)
        {
            if ((txtTreatmentID.Text.Length == 4 && validTreatmentID(txtTreatmentID.Text)))
            {
                trtPrice = getTrPrice();
                if (trtPrice > 0)
                {
                    numQty.Enabled = true;
                    trtSubTot = trtPrice * int.Parse(numQty.Value.ToString());
                }
                else
                {
                    numQty.Enabled = false;
                    trtName = "";
                }
                if (txtTreatmentID.Text.StartsWith("00") || txtTreatmentID.Text.StartsWith("16"))
                {
                    txtDiscount.Enabled = false;
                }
                else
                {
                    txtDiscount.Enabled = true;
                }
            }
            else
            {
                numQty.Value = 1;
                numQty.Enabled = false;
                trtName = "";
            }
            txtSubTotal.Text = calcSubTot(trtPrice, (int)numQty.Value, float.Parse(txtDiscount.Text)).ToString();
        }

        private void numQty_ValueChanged(object sender, EventArgs e)
        {
            txtSubTotal.Text = calcSubTot(trtPrice, (int)numQty.Value, float.Parse(txtDiscount.Text)).ToString();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text.Length > 0 && txtDiscount.Text.Length <= 3)
            {
                if (Int32.Parse(txtDiscount.Text) <= 100)
                {
                    if ((txtDiscount.Text != "") && (System.Text.RegularExpressions.Regex.IsMatch(txtDiscount.Text, "^[0-9]+$")))
                    {
                        txtSubTotal.Text = calcSubTot(trtPrice, (int)numQty.Value, float.Parse(txtDiscount.Text)).ToString();
                    }
                    else
                    {
                        txtDiscount.Text = "0";
                    }
                }
            }
        }

        private void btnAddTrx_Click(object sender, EventArgs e)
        {
            if (txtTreatmentID.Text.Length == 4)
            {
                trxDetails trxDet = new trxDetails();
                trxDet.trtID = txtTreatmentID.Text;
                trxDet.qty = int.Parse(numQty.Value.ToString());
                trxDet.disc = int.Parse(txtDiscount.Text);
                trxDet.subTot = trtSubTot;
                trxDet.isCredit = isCreditable;
                trxDets.Add(trxDet);
                if (isCreditable==0)
                {
                    shouldPay += trtSubTot;
                }
                dgDetTrx.Rows.Add(txtTreatmentID.Text, trtName, trtPrice, numQty.Value, txtDiscount.Text, trtSubTot);

                calcGrandTotal();

                txtTreatmentID.Text = "";
                numQty.Value = 1;
                txtDiscount.Text = "0";
                txtSubTotal.Text = "0";
            }
        }

        private void btnDelTrx_Click(object sender, EventArgs e)
        {
            shouldPay -= (trxDets[dgDetTrx.CurrentRow.Index].subTot);
            trxDets.RemoveAt(dgDetTrx.CurrentRow.Index);
            dgDetTrx.Rows.Remove(dgDetTrx.CurrentRow);
            calcGrandTotal();
        }

        private void btnFinTrx_Click(object sender, EventArgs e)
        {
            grInput.Enabled = false;

            txtTotalAmount.Text = Total.ToString();
            txtPaid.Text = "0";
            txtRest.Text = (Total+Adm).ToString();
            txtPay.Text = "0";
            txtChange.Text = "0";

            totalAmount = Total;
            paid = Int32.Parse(txtPaid.Text);
            rest = Total;
            pay = Int32.Parse(txtPay.Text);
            change = Int32.Parse(txtChange.Text);

            insertHdrTrxToDB();
            insertDetTrxToDB();

            btnFinTrx.Enabled = false;             
        }

        private void chkAdm_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdm.Checked == false)
            {
                txtRest.Text = (int.Parse(txtRest.Text) - Adm).ToString();
            }
            else
            {
                txtRest.Text = (int.Parse(txtRest.Text) + Adm).ToString();
            }
        }

        private void txtPay_TextChanged(object sender, EventArgs e)
        {
            if (txtPay.Text == "" || !System.Text.RegularExpressions.Regex.IsMatch(txtPay.Text, "^[-]?[0-9]+$"))
            {
                txtPay.Text = "0";
            }
            
            pay = int.Parse(txtPay.Text);

            CalculateChange();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (chkAdm.Checked)
            {
                if (shouldPay+Adm<=pay)
                {
                    insertAdminFee(Adm);
                    if ((rest + Adm) > pay)
                    {
                        insertPaymenttoDB(trxid, pay - Adm, (rest + Adm) - pay, cbPayType.Text);
                    }
                    else
                    {
                        insertPaymenttoDB(trxid, rest, 0, cbPayType.Text);
                        updPaymentStatus(trxid);
                    }
                    getTrxHist(trxid);
                    shouldPay = 0;
                }   
                else
                {
                    MessageBox.Show("Pay amount not sufficient");
                }
            }else
            {
                if (shouldPay<=pay)
                {
                    insertAdminFee(0);
                    if (rest > pay)
                    {
                        insertPaymenttoDB(trxid, pay, rest - pay, cbPayType.Text);
                    }
                    else
                    {
                        insertPaymenttoDB(trxid, rest, 0, cbPayType.Text);
                        updPaymentStatus(trxid);
                    }
                    getTrxHist(trxid);
                    shouldPay = 0;
                }
                else
                {
                    MessageBox.Show("Pay amount not sufficient");
                }
            }
        }

        private void btnLoadTrx_Click(object sender, EventArgs e)
        {
            frmhdrTrx = new frmTransactions();
            frmhdrTrx.parent = this;
            frmhdrTrx.Show();
        }

        private void btnReloadPayment_Click(object sender, EventArgs e)
        {
            getTrxHist(trxid);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printReceiptDialog.Document = printReceiptDoc;
            printReceiptDoc.PrintPage += printReceiptDoc_PrintPage;

            if (printReceiptDialog.ShowDialog() == DialogResult.OK)
            {
                printReceiptDoc.Print();
            }
        }

        string numToCurrency(string num)
        {
            string res = "";
            if(num == "" || num == "0")
            {
                return "0";
            }
            for (int i = num.Length - 1, j = 0; i >= 0; i--, j++)
            {
                if (j % 3 == 0 && j > 0)
                {
                    res = "." + res;
                }
                res = num[i] + res;
            }
            return res;
        }

        private void printDoctorInfo(Graphics g)
        {
            using (Font font1 = new Font("Arial", 9))
            {
                g.DrawString("Nomor Transaksi", font1, new SolidBrush(Color.Black), 100, 200);
                g.DrawString(": " + trxid, font1, new SolidBrush(Color.Black), 200, 200);

                g.DrawString("Nama Dokter", font1, new SolidBrush(Color.Black), 100, 220);
                g.DrawString(": " + txtDoctorName.Text, font1, new SolidBrush(Color.Black), 200, 220);
                g.DrawString("No. SIP Dokter", font1, new SolidBrush(Color.Black), 100, 240);
                g.DrawString(": " + selectedSIP, font1, new SolidBrush(Color.Black), 200, 240);
            }
        }
        private void printPatientInfo(Graphics g)
        {
            using (Font font1 = new Font("Arial", 9))
            {
                g.DrawString("Waktu", font1, new SolidBrush(Color.Black), 407, 200);
                g.DrawString(": " + convertTrxidToDate(trxid), font1, new SolidBrush(Color.Black), 507, 200);

                g.DrawString("Nama Pasien", font1, new SolidBrush(Color.Black), 407, 220);
                g.DrawString(": " + txtPatientName.Text, font1, new SolidBrush(Color.Black), 507, 220);
                g.DrawString("No. Rekam Medik", font1, new SolidBrush(Color.Black), 407, 240);
                g.DrawString(": " + selectedRekamMedik, font1, new SolidBrush(Color.Black), 507, 240);

            }

        }
        private void printReceiptDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Num2Words n2w = new Num2Words();
            Graphics pgGraph = e.Graphics;
            Font font = new Font("Arial", 9);
            float fontHeight = font.GetHeight();

            printDoctorInfo(pgGraph);
            printPatientInfo(pgGraph);

            int beginY1 = 260;
            int startX1 = 100;

            int totalDisc = 0;
            int totalNoDisc = 0;

            StringFormat rightAlign = new StringFormat();
            rightAlign.Alignment = StringAlignment.Far;

            StringFormat centerAlign = new StringFormat();
            centerAlign.Alignment = StringAlignment.Center;

            string[] headers = new string[] { "No.", "Treatment Name", "Price", "Qty", "Subtotal" };
            int[] distanceIncrement = new int[5] { 60, 350, 80, 30, 80 };

            //print header
            int beginX1 = startX1;

            pgGraph.DrawLine(new Pen(Color.Black, 2), beginX1, beginY1, beginX1 + 600, beginY1);
            beginY1 += 9;

            for (int i = 0; i < 5; i++)
            {
                pgGraph.DrawString(headers[i], font, new SolidBrush(Color.Black), beginX1, beginY1);
                beginX1 += distanceIncrement[i];
            }

            int treatmentCount = 1;
            //print line
            beginX1 = startX1;
            beginY1 += 18;
            pgGraph.DrawLine(new Pen(Color.Black, 2), beginX1, beginY1, beginX1 + 600, beginY1);
            beginY1 += 9;

            //print admin
            if (chkAdm.Checked)
            {
                beginX1 = startX1;
                pgGraph.DrawString(treatmentCount.ToString(), font, new SolidBrush(Color.Black), beginX1, beginY1);

                beginX1 += distanceIncrement[0];

                pgGraph.DrawString("Administrasi", font, new SolidBrush(Color.Black), beginX1, beginY1);
                beginX1 += distanceIncrement[1];

                beginX1 += distanceIncrement[2];
                pgGraph.DrawString(numToCurrency("20000"), font, new SolidBrush(Color.Black), beginX1, beginY1, rightAlign);
                beginX1 += distanceIncrement[3];

                pgGraph.DrawString("1", font, new SolidBrush(Color.Black), beginX1, beginY1, rightAlign);

                beginX1 += distanceIncrement[4];
                pgGraph.DrawString(numToCurrency("20000"), font, new SolidBrush(Color.Black), beginX1, beginY1, rightAlign);

                beginY1 += 18;
                treatmentCount++;
            }

            //print rows
            foreach (DataGridViewRow r in dgDetTrx.Rows)
            {
                beginX1 = startX1;
                pgGraph.DrawString(treatmentCount.ToString(), font, new SolidBrush(Color.Black), beginX1, beginY1);
                beginX1 += distanceIncrement[0];

                //Treatment Name
                pgGraph.DrawString(r.Cells[1].Value.ToString(), font, new SolidBrush(Color.Black), beginX1, beginY1);
                beginX1 += distanceIncrement[1];

                //Price
                pgGraph.DrawString(numToCurrency(r.Cells[2].Value.ToString()), font, new SolidBrush(Color.Black), beginX1 + distanceIncrement[2], beginY1, rightAlign);
                beginX1 += distanceIncrement[2];

                //Qty
                pgGraph.DrawString(r.Cells[3].Value.ToString(), font, new SolidBrush(Color.Black), beginX1 + distanceIncrement[3], beginY1, rightAlign);
                beginX1 += distanceIncrement[3];

                //Subtotal
                totalNoDisc += Int32.Parse(r.Cells[3].Value.ToString()) * Int32.Parse(r.Cells[2].Value.ToString());
                pgGraph.DrawString(numToCurrency(
                    (Int32.Parse(r.Cells[3].Value.ToString()) * Int32.Parse(r.Cells[2].Value.ToString())).ToString()
                ), font, new SolidBrush(Color.Black), beginX1 + distanceIncrement[4], beginY1, rightAlign);

                //Diskon
                totalDisc += Int32.Parse(r.Cells[3].Value.ToString()) * Int32.Parse(r.Cells[2].Value.ToString()) - Int32.Parse(r.Cells[5].Value.ToString());

                beginY1 += 18;
                treatmentCount++;
            }

            //line
            beginX1 = startX1;
            beginY1 = 420;
            pgGraph.DrawLine(new Pen(Color.Black, 2), beginX1, beginY1, beginX1 + 600, beginY1);

            //Total
            beginX1 = startX1 + distanceIncrement[0] + distanceIncrement[1] + distanceIncrement[2];
            beginY1 += 9;

            pgGraph.DrawString("Subtotal", font, new SolidBrush(Color.Black), beginX1 + distanceIncrement[3], beginY1, rightAlign);
            beginX1 += distanceIncrement[3];

            if (chkAdm.Checked)
            {
                pgGraph.DrawString(numToCurrency((totalNoDisc + 20000).ToString()), font, new SolidBrush(Color.Black), beginX1 + distanceIncrement[4], beginY1, rightAlign);
            }
            else
            {
                pgGraph.DrawString(numToCurrency(totalNoDisc.ToString()), font, new SolidBrush(Color.Black), beginX1 + distanceIncrement[4], beginY1, rightAlign);
            }

            //discount
            beginX1 = startX1 + distanceIncrement[0] + distanceIncrement[1] + distanceIncrement[2];
            beginY1 += 18;

            pgGraph.DrawString("Discount (-)", font, new SolidBrush(Color.Black), beginX1 + distanceIncrement[3], beginY1, rightAlign);
            beginX1 += distanceIncrement[3];

            pgGraph.DrawString(numToCurrency(totalDisc.ToString()), font, new SolidBrush(Color.Black), beginX1 + distanceIncrement[4], beginY1, rightAlign);

            //grand total
            beginX1 = startX1 + distanceIncrement[0] + distanceIncrement[1] + distanceIncrement[2];
            beginY1 += 18;
            pgGraph.DrawString("Grand Total", font, new SolidBrush(Color.Black), beginX1 + distanceIncrement[3], beginY1, rightAlign);

            beginX1 += distanceIncrement[3];

            if (chkAdm.Checked)
            {
                pgGraph.DrawString(numToCurrency((totalNoDisc + 20000 - totalDisc).ToString()), font, new SolidBrush(Color.Black), beginX1 + distanceIncrement[4], beginY1, rightAlign);
            }
            else
            {
                pgGraph.DrawString(numToCurrency((totalNoDisc - totalDisc).ToString()), font, new SolidBrush(Color.Black), beginX1 + distanceIncrement[4], beginY1, rightAlign);
            }

            //paid amount
            beginX1 = startX1 + distanceIncrement[0] + distanceIncrement[1] + distanceIncrement[2];
            beginY1 += 18;

            pgGraph.DrawString("Total Terbayar", font, new SolidBrush(Color.Black), beginX1 + distanceIncrement[3], beginY1, rightAlign);
            beginX1 += distanceIncrement[3];

            if (chkAdm.Checked)
            {
                pgGraph.DrawString(numToCurrency((Int32.Parse(txtPaid.Text.ToString()) + 20000).ToString()), font, new SolidBrush(Color.Black), beginX1 + distanceIncrement[4], beginY1, rightAlign);
            }
            else
            {
                pgGraph.DrawString(numToCurrency(txtPaid.Text.ToString()), font, new SolidBrush(Color.Black), beginX1 + distanceIncrement[4], beginY1, rightAlign);
            }

            //rest
            beginX1 = startX1 + distanceIncrement[0] + distanceIncrement[1] + distanceIncrement[2];
            beginY1 += 18;

            pgGraph.DrawString("Sisa Pembayaran", font, new SolidBrush(Color.Black), beginX1 + distanceIncrement[3], beginY1, rightAlign);
            beginX1 += distanceIncrement[3];

            pgGraph.DrawString(numToCurrency(txtRest.Text.ToString()), font, new SolidBrush(Color.Black), beginX1 + distanceIncrement[4], beginY1, rightAlign);

            //footer
            beginX1 = startX1;
            beginY1 = 549;
            if (txtPaid.Text == "0")
            {
                pgGraph.DrawString("Terbilang: nol rupiah", font, new SolidBrush(Color.Black), beginX1, beginY1);
            }
            else if (chkAdm.Checked)
            {
                pgGraph.DrawString("Terbilang: " + (n2w.convert(numToCurrency((Int32.Parse(txtPaid.Text.ToString()) + 20000).ToString()))) + "rupiah", font, new SolidBrush(Color.Black), beginX1, beginY1);
            }
            else
            {
                pgGraph.DrawString("Terbilang: " + (n2w.convert(numToCurrency(txtPaid.Text.ToString()))) + "rupiah", font, new SolidBrush(Color.Black), beginX1, beginY1);
            }
            beginX1 = startX1;
            beginY1 += 15;
            pgGraph.DrawLine(new Pen(Color.Black, 1), beginX1, beginY1, beginX1 + 600, beginY1);

            beginX1 = startX1 + 325;
            beginY1 = 576;
            pgGraph.DrawString("Bukti pembayaran ini sah sebagai kwitansi tanpa tanda tangan atau cap.", font, new SolidBrush(Color.Black), beginX1, beginY1, centerAlign);

            beginX1 = startX1 + 325;
            beginY1 = 594;
            pgGraph.DrawString("Semoga lekas sembuh.", font, new SolidBrush(Color.Black), beginX1, beginY1, centerAlign);
        }

        private void txtDoctorId_TextChanged(object sender, EventArgs e)
        {
            var loadQuery = from msDoctor in conn.msDoctors
                            where msDoctor.DoctorId == txtDoctorId.Text
                            select new { msDoctor.DoctorId, msDoctor.SIP, msDoctor.Name };
            var result = loadQuery.First();

            setSelectedDoctor(result.DoctorId, result.Name, result.SIP);
        }

        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {
            var loadQuery = from msPatient in conn.msPatients
                            where msPatient.PatientId == txtPatientID.Text
                            select new { msPatient.PatientId, msPatient.RekamMedik, msPatient.Name };
            var result = loadQuery.First();

            setSelectedPatient(result.PatientId, result.Name, result.RekamMedik);
        }

        private string convertTrxidToDate(string trxid)
        {
            string formatString = "yyyyMMddHHmmss";
            return DateTime.ParseExact(trxid, formatString, null).ToString("F", indoCultureInfo);
        }
    }
}
