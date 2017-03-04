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
    public partial class frmRefund : Form
    {
        frmSearchTreatment frmScrTreat;
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();

        void loadTransactions() {
            var loadQuery = (from hdrTransaction in conn.hdrTransactions
                             join Patient in conn.msPatients on hdrTransaction.PtnId equals Patient.PatientId
                             join Doctor in conn.msDoctors on hdrTransaction.DocId equals Doctor.DoctorId
                             //join Payment in conn.detPayments on hdrTransaction.TrxId equals Payment.TrxDate
                             select new { TransactionDate = hdrTransaction.TrxId, PatientDoB = Patient.PatientId, PatientName = Patient.Name, DoctorName = Doctor.Name, Status = hdrTransaction.PaymentStatus }).ToList();

            dgHdrTrx.DataSource = loadQuery;
        }
        
        void searchTransactions(String TrxId, String PatName, String DocName)
        {
            var scrQuery = (from hdrTransaction in conn.hdrTransactions
                            join Patient in conn.msPatients on hdrTransaction.PtnId equals Patient.PatientId
                            join Doctor in conn.msDoctors on hdrTransaction.DocId equals Doctor.DoctorId
                            where (Patient.Name.Contains(PatName) && Doctor.Name.Contains(DocName) && hdrTransaction.TrxId.Contains(TrxId))
                            select new { TransactionDate = hdrTransaction.TrxId, PatientDoB = Patient.PatientId, PatientName = Patient.Name, DoctorName = Doctor.Name, Status = hdrTransaction.PaymentStatus }).ToList();
            dgHdrTrx.DataSource = scrQuery;
        }

        void loadDetTransactions(String TrxId)
        {
        }

        void loadDetPayments(String TrxId)
        {

        }

        public frmRefund()
        {
            InitializeComponent();
        }

        private void frmRefund_Load(object sender, EventArgs e)
        {
            loadTransactions();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadTransactions();
        }

        private void btnScrTreatments_Click(object sender, EventArgs e)
        {
            frmScrTreat = new frmSearchTreatment();
        }
    }
}
