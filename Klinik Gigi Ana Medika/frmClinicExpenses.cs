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
    public partial class frmClinicExpenses : Form
    {
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();
        string ExpId = DateTime.Now.ToString("yyyyMMddHHmmss");
        string selectedExp = "";

        void loadExp()
        {
            var loadQuery = from detExpense in conn.detExpenses
                            select detExpense;
            dgExpense.DataSource = loadQuery;
        }
        void selExp()
        {
            selectedExp = dgExpense.CurrentRow.Cells[0].Value.ToString();
            txtItems.Text = dgExpense.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = dgExpense.CurrentRow.Cells[2].Value.ToString();
        }

        void insExp()
        {
            var newExp = new detExpense
            {
                TrxDate = DateTime.Now.ToString("yyyyMMddHHmmss"),
                Item = txtItems.Text,
                Price = int.Parse(txtPrice.Text),
                Category = cbCategory.Text
            };

            conn.detExpenses.InsertOnSubmit(newExp);

            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void updExp()
        {
            var queryUpd = (from detExp in conn.detExpenses 
                            where (detExp.TrxDate == selectedExp)
                            select detExp).ToList().First();
            queryUpd.Item = txtItems.Text;
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

        void delExp()
        {
            var delQuery = (from detExp in conn.detExpenses
                            where (detExp.TrxDate == selectedExp)
                            select detExp).ToList().First();
            conn.detExpenses.DeleteOnSubmit(delQuery);
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public frmClinicExpenses()
        {
            InitializeComponent();
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            insExp();
            loadExp();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            updExp();
            loadExp();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            delExp();
            loadExp();
        }

        private void dgExpense_SelectionChanged(object sender, EventArgs e)
        {
            if (dgExpense.SelectedCells!=null)
            {
                selExp();
            }
        }

        private void frmClinicExpenses_Load(object sender, EventArgs e)
        {
            loadExp();
        }
    }
}
