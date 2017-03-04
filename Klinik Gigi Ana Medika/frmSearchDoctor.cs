using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Klinik_Gigi_Ana_Medika
{
    public partial class frmSearchDoctor : Form
    {
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();
        string doctorId;
        string doctorName;
        string doctorSIP;
        public frmTrx parent;
        public frmSearchDoctor()
        {
            InitializeComponent();
            loadDoc();
            setDoctorID("");
            setDoctorName("");
        }
        public string getDoctorId()
        {
            return this.doctorId;
        }
        public string getDoctorName()
        {
            return this.doctorName;
        }
        public string getDoctorSIP()
        {
            return this.doctorSIP;
        }
        public void setDoctorID(string d)
        {
            doctorId = d;
        }
        public void setDoctorName(string d)
        {
            doctorName = d;
        }
        public void setDoctorSIP(string s)
        {
            doctorSIP = s;
        }

        void loadDoc()
        {
            var loadQuery = from msDoctor in conn.msDoctors
                            select new {msDoctor.DoctorId, msDoctor.SIP, msDoctor.Name };
            dgDoctor.DataSource = loadQuery;
        }

        void selDoc()
        {
            setDoctorID(dgDoctor.CurrentRow.Cells[0].Value.ToString());
            setDoctorName(dgDoctor.CurrentRow.Cells[2].Value.ToString());

        }
        void scrDoc()
        {
            var scrQuery = from msDoctor in conn.msDoctors
                           where (msDoctor.Name.Contains(sName.Text))
                           select new { msDoctor.DoctorId, msDoctor.SIP, msDoctor.Name};
            dgDoctor.DataSource = scrQuery;
        }

        private void btnScr_Click(object sender, EventArgs e)
        {
            scrDoc();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgDoctor.CurrentCell != null)
            {
                selDoc();
                parent.setSelectedDoctor(doctorId, doctorName, doctorSIP);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select the doctor first");
            }
        }

        private void dgDoctor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selDoc();
        }

        private void dgDoctor_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDoctor.CurrentCell != null)
            {
                selDoc();
                parent.setSelectedDoctor(doctorId, doctorName, doctorSIP);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select the doctor first");
            }
        }

        private void frmSearchDoctor_Load(object sender, EventArgs e)
        {
            loadDoc();
        }

        private void dgDoctor_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDoctor.CurrentCell != null)
            {
                selDoc();
                sName.Text = doctorName;
            }
        }

        private void dgDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (dgDoctor.CurrentCell != null)
                {
                    selDoc();
                    parent.setSelectedDoctor(doctorId, doctorName, doctorSIP);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please select the doctor first");
                }
            }
        }

        private void sName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.Enter)
            {
                scrDoc();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadDoc();
        }
    }
}
