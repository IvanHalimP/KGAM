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
    public partial class frmMasterDoctor : Form
    {
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();

        void loadDoc() {
            var loadQuery = from msDoctor in conn.msDoctors
                            select msDoctor;
            dgDoctor.DataSource = loadQuery;
        }

        void selDoc() {
            txtID.Text = dgDoctor.CurrentRow.Cells[0].Value.ToString();
            txtSIP.Text = dgDoctor.CurrentRow.Cells[1].Value.ToString();
            txtName.Text = dgDoctor.CurrentRow.Cells[2].Value.ToString();
            txtAddr.Text = dgDoctor.CurrentRow.Cells[3].Value.ToString();
            txtContact.Text = dgDoctor.CurrentRow.Cells[4].Value.ToString();
            txtHonor.Text = dgDoctor.CurrentRow.Cells[5].Value.ToString();
            
        }

        void insDoc() {
            var newDoc = new msDoctor
            {
                DoctorId = txtID.Text,
                SIP = txtSIP.Text,
                Name = txtName.Text,
                Address = txtAddr.Text,
                Contact = txtContact.Text,
                Honor=int.Parse(txtHonor.Text)
            };

            conn.msDoctors.InsertOnSubmit(newDoc);

            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void updDoc() {
            var queryUpd = (from msDoctor in conn.msDoctors
                            where (msDoctor.DoctorId == txtID.Text)
                            select msDoctor).ToList().First();
            queryUpd.Name = txtName.Text;
            queryUpd.SIP = txtSIP.Text;
            queryUpd.DoctorId = txtID.Text;
            queryUpd.Address = txtAddr.Text;
            queryUpd.Contact = txtContact.Text;
            queryUpd.Honor = int.Parse(txtHonor.Text);
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void delDoc() {
            var delQuery = (from msDoctor in conn.msDoctors
                            where (msDoctor.DoctorId == txtID.Text)
                            select msDoctor).ToList().First();
            conn.msDoctors.DeleteOnSubmit(delQuery);
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void scrDoc() {
            var scrQuery = from msDoctor in conn.msDoctors
                           where (msDoctor.Name.Contains(sName.Text))
                           select msDoctor;
            dgDoctor.DataSource = scrQuery;
        }

        public frmMasterDoctor()
        {
            InitializeComponent();
            loadDoc();
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            insDoc();
            loadDoc();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            updDoc();
            loadDoc();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            delDoc();
            loadDoc();
        }

        private void btnScr_Click(object sender, EventArgs e)
        {
            scrDoc();
        }

        private void btnRld_Click(object sender, EventArgs e)
        {
            loadDoc();
        }

        private void dgDoctor_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDoctor.CurrentCell!=null) {
                selDoc();
            }
        }

        private void sName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                scrDoc();
            }
        }
    }
}
