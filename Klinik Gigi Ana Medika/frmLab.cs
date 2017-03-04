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
    public partial class frmLab : Form
    {
        String selectedTrxId = "";
        int selectedDetTrxId = 0;
        String selectedDetLabId = "";
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();

        void loadHdrTrx() {
            var scrQuery = (from hdrTransaction in conn.hdrTransactions
                            join Patient in conn.msPatients on hdrTransaction.PtnId equals Patient.PatientId
                            join Doctor in conn.msDoctors on hdrTransaction.DocId equals Doctor.DoctorId
                            select new { TransactionDate = hdrTransaction.TrxId, PatientName = Patient.Name, DoctorName = Doctor.Name, Status = hdrTransaction.PaymentStatus }).ToList();
            dgHdrTrx.DataSource = scrQuery;
        }

        void loadHdrTrx(String trxId, String docName, String ptName) {
            var scrQuery = (from hdrTransaction in conn.hdrTransactions
                            join Patient in conn.msPatients on hdrTransaction.PtnId equals Patient.PatientId
                            join Doctor in conn.msDoctors on hdrTransaction.DocId equals Doctor.DoctorId
                            where (Patient.Name.Contains(ptName) && Doctor.Name.Contains(docName) && hdrTransaction.TrxId.Contains(trxId))
                            select new { TransactionDate = hdrTransaction.TrxId, PatientName = Patient.Name, DoctorName = Doctor.Name, Status = hdrTransaction.PaymentStatus }).ToList();
            dgHdrTrx.DataSource = scrQuery;
        }

        void loadDetTrx(String trxId)
        {
            var loadDetTrx = from trxDetails in conn.detTransactions
                             join msTreatment in conn.msTreatments on trxDetails.TrtId equals msTreatment.TreatmentId
                             where trxDetails.TrxId == trxId
                             select new { trxDetails.detTrxId, trxDetails.TrxId, msTreatment.Name, trxDetails.Qty, trxDetails.Disc, trxDetails.Status};
            dgDetTrx.DataSource = loadDetTrx;
        }

        void loadDetLab(int selcDetTrxId){
            var loadDetLab = from detLab in conn.detLabs
                             where detLab.detTrxId == selcDetTrxId
                             select detLab;
            dgDetLab.DataSource = loadDetLab;
        }

        void inputLab(String item, int cost) {
            var newLab = new detLab
            {
                detLabId= DateTime.Now.ToString("yyyyMMddHHmmss"),
                detTrxId = selectedDetTrxId,
                Item = item,
                Amount = cost
            };

            conn.detLabs.InsertOnSubmit(newLab);

            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void updLab(String item, int cost) {
            var queryUpd = (from detLab in conn.detLabs
                            where (detLab.detLabId == selectedDetLabId)
                            select detLab).ToList().First();
            queryUpd.Item = item;
            queryUpd.Amount = cost;
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void delLab() {
            var delQuery = (from detLab in conn.detLabs
                            where (detLab.detLabId == selectedDetLabId)
                            select detLab).ToList().First();
            conn.detLabs.DeleteOnSubmit(delQuery);
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public frmLab()
        {
            InitializeComponent();
        }

        private void frmLab_Load(object sender, EventArgs e)
        {
            loadHdrTrx();
        }

        private void btnTrxReload_Click(object sender, EventArgs e)
        {
            loadHdrTrx();
        }

        private void btnTrxSearch_Click(object sender, EventArgs e)
        {
            loadHdrTrx(txtTrxId.Text, txtDoctor.Text, txtPatient.Text);
        }

        private void btnDetTrxReload_Click(object sender, EventArgs e)
        {
            loadDetTrx(selectedTrxId);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtLabItem.Text == "")
            {
                MessageBox.Show("Item name must be filled");
            }
            else if (txtLabPrice.Text == "")
            {
                MessageBox.Show("Price must be filled");
            }
            else
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtLabPrice.Text, "^[-]?[0-9]+$"))
                {
                    inputLab(txtLabItem.Text, int.Parse(txtLabPrice.Text));
                    loadDetLab(selectedDetTrxId);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgDetLab.RowCount == 0)
            {
                MessageBox.Show("No data available");
            }
            else if (dgDetLab.CurrentRow.Cells[0].Value.ToString() != null)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtLabPrice.Text, "^[-]?[0-9]+$"))
                {
                    updLab(txtLabItem.Text, int.Parse(txtLabPrice.Text));
                    loadDetLab(selectedDetTrxId);
                }
            }
            else
            {
                MessageBox.Show("Select the item first");
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgDetLab.RowCount > 0)
            {
                if (dgDetLab.CurrentRow.Cells[0].Value.ToString() != null)
                {
                    delLab();
                    loadDetLab(selectedDetTrxId);
                }
                else
                {
                    MessageBox.Show("No selected data");
                }
            }
            else
            {
                MessageBox.Show("No data available");
            }
        }

        private void dgHdrTrx_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgHdrTrx.CurrentRow.Cells[0].Value.ToString() != null)
            {
                selectedTrxId=txtTrxId.Text = dgHdrTrx.CurrentRow.Cells[0].Value.ToString();
                txtDoctor.Text = dgHdrTrx.CurrentRow.Cells[2].Value.ToString();
                txtPatient.Text = dgHdrTrx.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnSelcTrx_Click(object sender, EventArgs e)
        {
            if (dgHdrTrx.CurrentRow.Cells[0].Value.ToString() != null)
            {
                loadDetTrx(dgHdrTrx.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void dgDetTrx_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetTrx.CurrentRow.Cells[0].Value.ToString() != null)
            {
                txtDetTrxId.Text=dgDetTrx.CurrentRow.Cells[0].Value.ToString();
                txtTreatmentName.Text= dgDetTrx.CurrentRow.Cells[2].Value.ToString();
                txtTrxStatus.Text = dgDetTrx.CurrentRow.Cells[5].Value.ToString();
                selectedDetTrxId = int.Parse(dgDetTrx.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void btnDetTrxSelect_Click(object sender, EventArgs e)
        {
            if (dgDetTrx.CurrentRow.Cells[0].Value.ToString() != null)
            {
                loadDetLab(selectedDetTrxId);
            }
        }

        private void dgDetLab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetLab.CurrentRow.Cells[0].Value.ToString() != null)
            {
                txtDetLabId.Text=selectedDetLabId = dgDetLab.CurrentRow.Cells[0].Value.ToString();
                txtLabItem.Text= dgDetLab.CurrentRow.Cells[2].Value.ToString();
                txtLabPrice.Text = dgDetLab.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void txtTrxId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                loadHdrTrx(txtTrxId.Text, txtDoctor.Text, txtPatient.Text);
            }
        }

        private void txtDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                loadHdrTrx(txtTrxId.Text, txtDoctor.Text, txtPatient.Text);
            }
        }

        private void txtPatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                loadHdrTrx(txtTrxId.Text, txtDoctor.Text, txtPatient.Text);
            }
        }

        private void dgHdrTrx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                selectedTrxId = txtTrxId.Text = dgHdrTrx.CurrentRow.Cells[0].Value.ToString();
                txtDoctor.Text = dgHdrTrx.CurrentRow.Cells[2].Value.ToString();
                txtPatient.Text = dgHdrTrx.CurrentRow.Cells[1].Value.ToString();
                if (dgHdrTrx.CurrentRow.Cells[0].Value.ToString() != null)
                {
                    loadDetTrx(dgHdrTrx.CurrentRow.Cells[0].Value.ToString());
                    dgDetTrx.Focus();
                }
            }
        }

        private void dgDetTrx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtDetTrxId.Text = dgDetTrx.CurrentRow.Cells[0].Value.ToString();
                txtTreatmentName.Text = dgDetTrx.CurrentRow.Cells[2].Value.ToString();
                txtTrxStatus.Text = dgDetTrx.CurrentRow.Cells[5].Value.ToString();
                selectedDetTrxId = int.Parse(dgDetTrx.CurrentRow.Cells[0].Value.ToString());
                if (dgDetTrx.CurrentRow.Cells[0].Value.ToString() != null)
                {
                    loadDetLab(selectedDetTrxId);
                }
            }
        }

        private void dgDetLab_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDetLab.CurrentRow.Cells[0].Value.ToString() != null)
            {
                txtDetLabId.Text = selectedDetLabId = dgDetLab.CurrentRow.Cells[0].Value.ToString();
                txtLabItem.Text = dgDetLab.CurrentRow.Cells[2].Value.ToString();
                txtLabPrice.Text = dgDetLab.CurrentRow.Cells[3].Value.ToString();
            }
        }
    }
}
