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
    public partial class frmSearchPatient : Form
    {
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();
        string patientID;
        string patientName;
        string patientRM;
        public frmTrx parent;

        public frmSearchPatient()
        {
            InitializeComponent();
        }
        public string getPatientID()
        {
            return this.patientID;
        }

        public void setPatientID(string p)
        {
            patientID = p;
        }

        public string getPatientName()
        {
            return this.patientName;
        }

        public void setPatientName(string p)
        {
            patientName = p;
        }

        public string getPatientRM()
        {
            return this.patientRM;
        }
        public void setPatientRM(string rm)
        {
            patientRM = rm;
        }
        void searchPatient()
        {
            var scrQuery = from msPatient in conn.msPatients
                           where (msPatient.PatientId.Contains(sDoB.Text) && msPatient.Name.Contains(sName.Text))
                           select msPatient;
            dgPatient.DataSource = scrQuery;
        }

        void loadPatients()
        {
            var scrQuery = from msPatient in conn.msPatients
                           select msPatient;
            dgPatient.DataSource = scrQuery;
        }
        
        private void dgPatient_SelectionChanged(object sender, EventArgs e)
        {
            if (dgPatient.CurrentCell != null)
            {
                selectPatient();
                //sName.Text = patientName;
            }
        }
        void selectPatient()
        {
            setPatientID(dgPatient.CurrentRow.Cells[0].Value.ToString());
            setPatientRM(dgPatient.CurrentRow.Cells[1].Value.ToString());
            setPatientName(dgPatient.CurrentRow.Cells[2].Value.ToString());
        }

        private void btnScr_Click(object sender, EventArgs e)
        {
            searchPatient();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgPatient.CurrentCell != null)
            {
                selectPatient();
                parent.setSelectedPatient(patientID, patientName, patientRM);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a patient first");
            }
        }

        private void frmSearchPatient_Load(object sender, EventArgs e)
        {
            loadPatients();
        }

        private void dgPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectPatient();
        }

        private void dgPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectPatient();
        }

        private void dgPatient_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            selectPatient();
            parent.setSelectedPatient(patientID, patientName, patientRM);
            this.Close();
        }

        private void dgPatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                selectPatient();
                parent.setSelectedPatient(patientID, patientName, patientRM);
                this.Close();
            }
        }

        private void sName_KeyDown(object sender, KeyEventArgs e)
        {
            searchPatient();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadPatients();
        }
    }
}
