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
    public partial class frmHonor : Form
    {
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();
        public frmHonor()
        {
            InitializeComponent();
        }

        void loadHonor() {
            var loadQuery = from msHonor in conn.msHonors
                            select msHonor;
            dgHonor.DataSource = loadQuery;
        }
        void insHonor() {
            var newHonor = new msHonor
            {
                Id = int.Parse(txtId.Text),
                Clinics = int.Parse(txtHClinic.Text),
                Doctors=int.Parse(txtHDoc.Text)
            };

            conn.msHonors.InsertOnSubmit(newHonor);

            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void updHonor()
        {
            var queryUpd = (from msHonor in conn.msHonors
                            where (msHonor.Id == int.Parse(txtId.Text))
                            select msHonor).ToList().First();
            //queryUpd.Id = txtId.Text;
            queryUpd.Clinics = int.Parse(txtHClinic.Text); ;
            queryUpd.Doctors = int.Parse(txtHDoc.Text);
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void delHonor() {
            var delQuery = (from msHonor in conn.msHonors
                            where (msHonor.Id == int.Parse(txtId.Text))
                            select msHonor).ToList().First();
            conn.msHonors.DeleteOnSubmit(delQuery);
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void selcHonor() {
            txtId.Text = dgHonor.CurrentRow.Cells[0].Value.ToString();
            txtHClinic.Text = dgHonor.CurrentRow.Cells[1].Value.ToString();
            txtHDoc.Text=dgHonor.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            insHonor();
            loadHonor();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            updHonor();
            loadHonor();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            delHonor();
            loadHonor();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadHonor();
        }

        private void frmHonor_Load(object sender, EventArgs e)
        {
            loadHonor();
        }

        private void dgHonor_SelectionChanged(object sender, EventArgs e)
        {
            if (dgHonor.CurrentCell != null)
            {
                selcHonor();
            }
        }
    }
}
