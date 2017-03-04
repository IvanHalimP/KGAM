using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinik_Gigi_Ana_Medika
{
    public partial class frmTrxHist : Form
    {
        String trxId = "";
        String trxDate = "";

        int Remnant = 0;
        int pay = 0;
        int Adm = 0;
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();

        detPayment dPay;
        List<detPayment> dPays = new List<detPayment>();

        public frmTrxHist()
        {
            InitializeComponent();
        }
        void getAdmin()
        {
            var admAmount = (from msTax in conn.msTaxes
                             where msTax.Name == "Admin"
                             select msTax.Amount).ToList().First().ToString();
            Adm = int.Parse(admAmount);
            Remnant += Adm;
        }

        public void setTrxHist(String trxid) {
            trxId = trxid;
            var LoadTrxHis = (from hdrTransaction in conn.hdrTransactions
                              join detPayment in conn.detPayments on hdrTransaction.TrxId equals detPayment.TrxId
                              where hdrTransaction.TrxId == trxid
                              select new {
                                 TransactionId = hdrTransaction.TrxId,
                                 TransactionDate = detPayment.TrxDate,
                                 detTrxId = detPayment.detTrxId,
                                 Amount =detPayment.Amount,
                                 Remnant=detPayment.Remnant,
                                 PaymentType=detPayment.PaymentType,
                             }).ToList();
            dgTrxHist.DataSource = LoadTrxHis;
            //Remnant = int.Parse((LoadTrxHis[LoadTrxHis.Count-1].Remnant).ToString());

            var shouldPay = LoadTrxHis.GroupBy(t => t.TransactionDate)
                            .Select(group => new { TrxDate = group.Key, payments = group.OrderBy(rem => rem.Remnant) })
                            .OrderBy(group => group.payments.First().TransactionDate);

            foreach (var group in shouldPay) {
                Remnant = 0;
                dPays.Clear();
                
                Console.WriteLine(group.TrxDate);
                //trxDate = group.TrxDate;
                foreach (var payments in group.payments) {
                    
                    Console.WriteLine(payments.detTrxId+" "+ payments.Amount+" "+payments.Remnant);
                    Remnant += payments.Remnant.Value;
                    if (payments.Remnant.Value != 0)
                    {
                        dPay = new detPayment();
                        dPay.TrxId = payments.TransactionId;
                        dPay.detTrxId = payments.detTrxId;
                        dPay.Amount = payments.Amount;
                        dPay.Remnant = payments.Remnant;
                        
                        dPays.Add(dPay);
                    }
                }
            }

            if (Remnant == 0)
            {
                btnPay.Enabled = false;
            }
            else {
                if (chkAdm.Checked)
                {
                    Remnant += Adm;
                }
            }
        }

        public void updDetTrxPaymentStatus(int detId)
        {
            try
            {
                var updQuery = (from detTransaction in conn.detTransactions
                                where (detTransaction.detTrxId == detId)
                                select detTransaction).ToList().First();
                updQuery.Status = "Completed";
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void insertPaymenttoDB(detPayment dpay)
        {
            conn.detPayments.InsertOnSubmit(dpay);
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void CalculatePayment()
        {
            int rest = 0;
            int change = 0;
            pay = 0;
            pay = int.Parse(txtPay.Text);
            if (pay > Remnant)
            {
                change = pay - Remnant;
                txtChange.Text = change.ToString();
                txtRest.Text = "0";
            }
            else
            {
                rest = Remnant - pay;
                txtRest.Text = rest.ToString();
                txtChange.Text = "0";
            }
        }

        void insertAdm() {
            detAdm dAdm = new detAdm();
            dAdm.TrxDate = trxDate;
            dAdm.Amount = Adm;
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
        void updPaymentStatus()
        {
            try
            {
                var updQuery = (from hdrTransaction in conn.hdrTransactions
                                where (hdrTransaction.TrxId == trxId)
                                select hdrTransaction).ToList().First();
                updQuery.PaymentStatus = "Completed";
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void frmTrxHist_Load(object sender, EventArgs e)
        {
            cbPayType.SelectedIndex = 0;
            getAdmin();
            txtRemnant.Text = Remnant.ToString();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            trxDate= DateTime.Now.ToString("yyyyMMddHHmmss");
            pay = int.Parse(txtPay.Text);
            if (pay>Remnant/2)
            {
                if (chkAdm.Checked)
                {
                    pay-=Adm;
                    
                }

                if (txtRest.Text=="0")
                {
                    for(int i = 0; i<dPays.Count; i++)
                    {
                        dPays[i].Amount += dPays[i].Remnant;
                        dPays[i].Remnant = 0;
                        dPays[i].PaymentType = cbPayType.Text;
                        dPays[i].TrxDate= trxDate;
                        insertPaymenttoDB(dPays[i]);
                        updDetTrxPaymentStatus(dPays[i].detTrxId);
                        updPaymentStatus();
                    }
                }
                else
                {
                    while (pay>0)
                    {
                        for (int i = 0; i < dPays.Count; i++)
                        {
                            if (dPays[i].Remnant >= pay)
                            {
                                dPays[i].Amount += pay;
                                dPays[i].Remnant -= pay;
                                dPays[i].PaymentType = cbPayType.Text;
                                dPays[i].TrxDate = trxDate;
                                Console.WriteLine(dPays[i].TrxDate);
                                pay = 0;
                            }else if (dPays[i].Remnant < pay)
                            {
                                dPays[i].Amount += dPays[i].Remnant;
                                pay -= dPays[i].Remnant.Value;
                                dPays[i].Remnant = 0;
                                dPays[i].PaymentType = cbPayType.Text;
                                dPays[i].TrxDate = trxDate;
                            }

                            if (pay <= 0)
                            {
                                break;
                            }
                        }
                        
                    }
                    int countComplete = 0;
                    for (int i = 0; i < dPays.Count; i++)
                    {
                        insertPaymenttoDB(dPays[i]);
                        if (dPays[i].Remnant == 0)
                        {
                            updDetTrxPaymentStatus(dPays[i].detTrxId);
                            countComplete++;
                        }
                    }
                    if (countComplete == dPays.Count)
                    {
                        updPaymentStatus();
                    }
                }
                
                setTrxHist(trxId);
                
                txtRemnant.Text = Remnant.ToString();
                
            }
            else
            {
                MessageBox.Show("Paid amount have to cover at least half the total remnant amount");
            }
        }
        
        private void txtPay_TextChanged(object sender, EventArgs e)
        {
            if (txtPay.Text == "")
            {
                txtPay.Text = "0";
                CalculatePayment();
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtPay.Text, "^[-]?[0-9]+$"))
                {
                    txtPay.Text = "0";
                }
                else
                {
                    CalculatePayment();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            setTrxHist(trxId);
        }

        private void chkAdm_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdm.Checked == false)
            {
                Remnant -= Adm;
            }else
            {
                Remnant += Adm;
            }
            txtRemnant.Text = Remnant.ToString();
            CalculatePayment();
        }
    }
}
