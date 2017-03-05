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
    public partial class frmMasterTreatment : Form
    {
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();
        public frmMasterTreatment()
        {
            InitializeComponent();
        }

        void LoadTreatments() {
            var loadQuery = from msTreatment in conn.msTreatments
                            select msTreatment;
            dgTreatment.DataSource = loadQuery;
        }

        void UpdateTreatment() {
            var queryUpd = (from msTreatment in conn.msTreatments
                            where (msTreatment.TreatmentId == txtId.Text)
                            select msTreatment).ToList().First();
            queryUpd.Name = txtDesc.Text;
            queryUpd.TreatmentId = txtId.Text;
            queryUpd.Price = int.Parse(txtPrice.Text);

            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void InsertTreatment() {
            int creditVal = 0;
            if (rbFalse.Checked)
            {
                creditVal = 0;
            }else
            {
                creditVal = 1;
            }
            var newTreatment = new msTreatment {
                TreatmentId = txtId.Text,
                Name = txtDesc.Text,
                Price = int.Parse(txtPrice.Text),
                isCreditable = creditVal
            };

            conn.msTreatments.InsertOnSubmit(newTreatment);

            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void DeleteTreatment() {
            var delQuery = (from msTreatment in conn.msTreatments
                            where (msTreatment.TreatmentId == txtId.Text)
                            select msTreatment).ToList().First();
            conn.msTreatments.DeleteOnSubmit(delQuery);
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void SearchTreatment() {
            var scrQuery = from msTreatment in conn.msTreatments
                           where (msTreatment.TreatmentId.Contains(sId.Text) && msTreatment.Name.Contains(sDesc.Text))
                           select msTreatment;
            dgTreatment.DataSource = scrQuery;
        }

        void selectCategory() {
            txtId.Text = dgTreatment.CurrentRow.Cells[0].Value.ToString();
            txtDesc.Text = dgTreatment.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = dgTreatment.CurrentRow.Cells[2].Value.ToString();
            switch (txtId.Text.Substring(0, 2))
            {
                case "00":
                    break;
                case "01":
                    txtCategory.Text = "Restorative Adult";
                    break;
                case "02":
                    txtCategory.Text = "Restorative Child";
                    break;
                case "03":
                    txtCategory.Text = "Extraction";
                    break;
                case "04":
                    txtCategory.Text = "Endodontic Child";
                    break;
                case "06":
                    txtCategory.Text = "Periodontology";
                    break;
                case "07":
                    txtCategory.Text = "Surgical";
                    break;
                case "08":
                    txtCategory.Text = "Orthodontic(Removable)";
                    break;
                case "11":
                    txtCategory.Text = "Crown Denture";
                    break;
                case "12":
                    txtCategory.Text = "Impression/Cementing";
                    break;
                case "13":
                    txtCategory.Text = "Reparation Denture";
                    break;
                case "14":
                    txtCategory.Text = "Post Core";
                    break;
                case "15":
                    txtCategory.Text = "Esthetic";
                    break;
                case "16":
                    txtCategory.Text = "Rontgen";
                    break;
                default:
                    if (txtId.Text.Substring(0, 2) == "05")
                    {
                        if (int.Parse(txtId.Text.Substring(2, 2)) < 16)
                        {
                            txtCategory.Text = "Endodontic Specialist";
                        }
                        else {
                            txtCategory.Text = "Endodontic General Dentist";
                        }
                    }
                    else if (txtId.Text.Substring(0, 2) == "10")
                    {
                        if (int.Parse(txtId.Text.Substring(2, 2)) < 12)
                        {
                            txtCategory.Text = "Removable Partial Denture";
                        }
                        else {
                            txtCategory.Text = "Removable Full Denture";
                        }
                    }
                    else {
                        txtCategory.Text = "";
                    }
                    break;
            }
        }

        private void frmMasterTreatment_Load(object sender, EventArgs e)
        {
            LoadTreatments();
        }

        private void dgTreatment_SelectionChanged(object sender, EventArgs e)
        {
            if (dgTreatment.CurrentCell!=null) {
                selectCategory();
            }
        }

        private void btnTrtScr_Click(object sender, EventArgs e)
        {
            SearchTreatment();
        }

        private void btnRld_Click(object sender, EventArgs e)
        {
            LoadTreatments();
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            InsertTreatment();
            LoadTreatments();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            UpdateTreatment();
            LoadTreatments();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteTreatment();
            LoadTreatments();
        }

        private void sId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SearchTreatment();
            }
        }

        private void sDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SearchTreatment();
            }
        }
    }
}
