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
    public partial class frmTax : Form
    {
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();
        public frmTax()
        {
            InitializeComponent();
        }

        void loadTax()
        {
            var loadQuery = from msTax in conn.msTaxes
                            select msTax;
            dgTax.DataSource = loadQuery;
        }
        void selTax()
        {
            txtType.Text = dgTax.CurrentRow.Cells[0].Value.ToString();
            txtAmount.Text = dgTax.CurrentRow.Cells[1].Value.ToString();
        }

        void insTax()
        {
            var newTax = new msTax
            {
                Name = txtType.Text,
                Amount = float.Parse(txtAmount.Text)
            };

            conn.msTaxes.InsertOnSubmit(newTax);

            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void updTax()
        {
            var queryUpd = (from msTax in conn.msTaxes
                            where (msTax.Name == txtType.Text)
                            select msTax).ToList().First();
            queryUpd.Name = txtType.Text;
            queryUpd.Amount = float.Parse(txtAmount.Text);
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void delTax()
        {
            var delQuery = (from msTax in conn.msTaxes
                            where (msTax.Name == txtType.Text)
                            select msTax).ToList().First();
            conn.msTaxes.DeleteOnSubmit(delQuery);
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            //if (!System.Text.RegularExpressions.Regex.IsMatch(txtAmount.Text, "^[0-9]*([.]*[0-9])?")) { 
                insTax();
            //}
            loadTax();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            //if (!System.Text.RegularExpressions.Regex.IsMatch(txtAmount.Text, "^(?:\\d{1,2})?(?:\\.\\d{1,2})?$"))
            //{
                updTax();
            //}
            loadTax();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            delTax();
            loadTax();
        }

        private void frmTax_Load(object sender, EventArgs e)
        {
            loadTax();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadTax();
        }

        private void dgTax_SelectionChanged(object sender, EventArgs e)
        {
            if (dgTax.CurrentCell != null)
            {
                selTax();
            }
        }
    }
}
