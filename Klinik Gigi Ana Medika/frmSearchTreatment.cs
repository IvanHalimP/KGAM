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
    public partial class frmSearchTreatment : Form
    {
        public frmTrx parent;
        public frmSearchTreatment()
        {
            InitializeComponent();
        }

        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();
        string trId, name;
        int price, isCredit;

        void loadTreatments() {
            var loadQuery = from msTreatment in conn.msTreatments
                            select msTreatment;
            dgTreatments.DataSource = loadQuery;
        }

        void SearchTreatment()
        {
            var scrQuery = from msTreatment in conn.msTreatments
                           where (msTreatment.TreatmentId.Contains(txtCode.Text) && msTreatment.Name.Contains(txtName.Text))
                           select msTreatment;
            dgTreatments.DataSource = scrQuery;
        }

        private void frmSearchTreatment_Load(object sender, EventArgs e)
        {
            loadTreatments();
        }

        private void btnRld_Click(object sender, EventArgs e)
        {
            loadTreatments();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchTreatment();
        }

        private void btnSelectTreatment_Click(object sender, EventArgs e)
        {
            returnTreatment();
        }

        private void dgTreatments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.Enter)
            {
                returnTreatment();
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.Enter)
            {
                SearchTreatment();
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SearchTreatment();
            }
        }

        private void dgTreatments_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            returnTreatment();
        }

        void returnTreatment() {
            if (dgTreatments.CurrentCell != null)
            {
                trId = dgTreatments.CurrentRow.Cells[0].Value.ToString();
                name = dgTreatments.CurrentRow.Cells[1].Value.ToString();
                price = int.Parse(dgTreatments.CurrentRow.Cells[2].Value.ToString());
                isCredit = int.Parse(dgTreatments.CurrentRow.Cells[3].Value.ToString());
                parent.setSelectedTreat(trId, name, price, isCredit);

                this.Close();
            }
        }
    }
}
