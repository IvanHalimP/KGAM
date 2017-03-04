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
    public partial class frmTransactions : Form
    {
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();
        public frmTrx parent;

        public frmTransactions()
        {
            InitializeComponent();
        }

        void loadTransaction()
        {
            var loadQuery = (from hdrTransaction in conn.hdrTransactions
                             join Patient in conn.msPatients on hdrTransaction.PtnId equals Patient.PatientId
                             join Doctor in conn.msDoctors on hdrTransaction.DocId equals Doctor.DoctorId
                             //join Payment in conn.detPayments on hdrTransaction.TrxId equals Payment.TrxDate
                             select new { TransactionDate = hdrTransaction.TrxId, PatientDoB = Patient.PatientId, PatientName = Patient.Name, DoctorName = Doctor.Name, Status = hdrTransaction.PaymentStatus }).ToList();

            dgTransactions.DataSource = loadQuery;
        }

        void searchTransaction(String name, String dob, String docName) {
            var scrQuery = (from hdrTransaction in conn.hdrTransactions
                           join Patient in conn.msPatients on hdrTransaction.PtnId equals Patient.PatientId
                           join Doctor in conn.msDoctors on hdrTransaction.DocId equals Doctor.DoctorId
                           where (Patient.Name.Contains(name) && Doctor.Name.Contains(docName)&&Patient.PatientId.Contains(dob))
                           select new { TransactionDate = hdrTransaction.TrxId, PatientDoB = Patient.PatientId, PatientName = Patient.Name, DoctorName = Doctor.Name, Status = hdrTransaction.PaymentStatus }).ToList();
            dgTransactions.DataSource = scrQuery;
        }

        void returnTrxHis(String trxId)
        {
            parent.getTrxHist(trxId);
            parent.getTrxDet(trxId);
            parent.getTrxHdr(trxId);
            parent.btnFinTrx.Enabled = false;
            parent.grInput.Enabled = false;
            this.Close();
        }

        private void frmTransactions_Load(object sender, EventArgs e)
        {
            loadTransaction();
        }

        private void btnSelectTrx_Click(object sender, EventArgs e)
        {
            if (dgTransactions.CurrentRow.Cells[0].Value.ToString()!=null)
            {
                returnTrxHis(dgTransactions.CurrentRow.Cells[0].Value.ToString());
            }
        }
        
        private void dgTransactions_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            returnTrxHis(dgTransactions.CurrentRow.Cells[0].Value.ToString());
        }

        private void btnScr_Click(object sender, EventArgs e)
        {
            searchTransaction(txtPtn.Text, txtDOB.Text, txtDoc.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadTransaction();
        }

        private void dgTransactions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.Enter){
                returnTrxHis(dgTransactions.CurrentRow.Cells[0].Value.ToString());
            }
        }
    }
}
