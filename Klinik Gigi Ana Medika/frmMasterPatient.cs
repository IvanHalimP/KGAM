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
    public partial class frmMasterPatient : Form
    {
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();
        void loadPatients() {
            var loadQuery = from msPatient in conn.msPatients
                            select msPatient;
            dgPatient.DataSource = loadQuery;
        }

        void insPatient(char gender)
        {
            string MNum = "";
            if ((cbMonth.SelectedIndex + 1) < 10)
            {
                MNum = "0" + (cbMonth.SelectedIndex + 1).ToString();
            }
            else {
                MNum = (cbMonth.SelectedIndex + 1).ToString();
            }
            string dt = DateTime.Now.ToShortDateString();
            var newPatient = new msPatient
            {
                PatientId = cbDate.SelectedItem + MNum + cbYear.SelectedItem + txtContact.Text.Substring(txtContact.Text.Length-5,5),
                RekamMedik=txtRMedik.Text,
                Name = txtName.Text,
                Gender = gender,
                Address = txtAddr.Text,
                Contact = txtContact.Text,
                
            };

            conn.msPatients.InsertOnSubmit(newPatient);

            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void updPatient() {
            string MNum = "";
            if ((cbMonth.SelectedIndex + 1) < 10)
            {
                MNum = "0" + (cbMonth.SelectedIndex + 1).ToString();
            }
            else {
                MNum = (cbMonth.SelectedIndex + 1).ToString();
            }
            var queryUpd = (from msPatient in conn.msPatients
                            where (msPatient.PatientId == dgPatient.CurrentRow.Cells[0].Value.ToString())
                            select msPatient).ToList().First();
            queryUpd.Name = txtName.Text;
            queryUpd.RekamMedik = txtRMedik.Text;
            if (rbMale.Checked)
            {
                queryUpd.Gender = 'M';
            }
            else if (rbFemale.Checked)
            {
                queryUpd.Gender = 'F';
            }
            //queryUpd.PatientId = cbDate.SelectedItem + MNum + cbYear.SelectedItem + dgPatient.CurrentRow.Cells[0].Value.ToString().Substring(8, 14);
            queryUpd.Address = txtAddr.Text;
            queryUpd.Contact = txtContact.Text;

            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void selectPatient() {
            txtRMedik.Text = dgPatient.CurrentRow.Cells[1].Value.ToString();
            txtName.Text = dgPatient.CurrentRow.Cells[2].Value.ToString();
            txtAddr.Text = dgPatient.CurrentRow.Cells[4].Value.ToString();
            txtContact.Text = dgPatient.CurrentRow.Cells[5].Value.ToString();
            if (dgPatient.CurrentRow.Cells[3].Value.ToString() == "M")
            {
                rbMale.Checked = true;
            }
            else if (dgPatient.CurrentRow.Cells[3].Value.ToString() == "F")
            {
                rbFemale.Checked = true;
            }
            cbDate.SelectedIndex = int.Parse(dgPatient.CurrentRow.Cells[0].Value.ToString().Substring(0, 2))-1;
            cbMonth.SelectedIndex = int.Parse(dgPatient.CurrentRow.Cells[0].Value.ToString().Substring(2, 2))-1;
            cbYear.Text = (dgPatient.CurrentRow.Cells[0].Value.ToString().Substring(4, 4));
        }

        void delPatient() {
            var delQuery = (from msPatient in conn.msPatients
                            where (msPatient.PatientId == dgPatient.CurrentRow.Cells[0].Value.ToString())
                            select msPatient).ToList().First();
            conn.msPatients.DeleteOnSubmit(delQuery);
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void searchPatient() {
            var scrQuery = from msPatient in conn.msPatients
                           where (msPatient.PatientId.Contains(sDoB.Text) && msPatient.Name.Contains(sName.Text))
                           select msPatient;
            dgPatient.DataSource = scrQuery;
        }

        public frmMasterPatient()
        {
            InitializeComponent();
            
            for (int i=DateTime.Now.Year; i> DateTime.Now.Year-100; i--) {
                cbYear.Items.Add(i);
            }
            //MessageBox.Show(DateTime.Now.ToString("ddMMyyyy"));
            loadPatients();
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            char sex='-';
            if (rbMale.Checked)
            {
                sex = 'M';
            }
            else if(rbFemale.Checked)
            {
                sex = 'F';
            }
            insPatient(sex);
            
            loadPatients();
        }

        private void dgPatient_SelectionChanged(object sender, EventArgs e)
        {
            if (dgPatient.CurrentCell!=null) {
                selectPatient();
            }
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            updPatient();
            loadPatients();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            delPatient();
            loadPatients();
        }

        private void btnScr_Click(object sender, EventArgs e)
        {
            searchPatient();
        }

        private void btnRld_Click(object sender, EventArgs e)
        {
            loadPatients();
        }

        private void sName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                searchPatient();
            }
        }

        private void sDoB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                searchPatient();
            }
        }
    }
}
