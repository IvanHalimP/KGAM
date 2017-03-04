using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinik_Gigi_Ana_Medika
{
    public partial class frmMonthlyExpenses : Form
    {
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();
        List<DataTable> datatable = new List<DataTable>();
        ExpenseReportGenerator report = new ExpenseReportGenerator();
        public frmMonthlyExpenses()
        {
            InitializeComponent();
        }
        private string generateDate(int year, int month, int day)
        {
            string y = year.ToString();
            string m = month.ToString();
            if (m.Length == 1)
            {
                m = "0" + m;
            }
            string d = day.ToString();
            if (d.Length == 1)
            {
                d = "0" + d;
            }
            return y + "/" + m + "/" + d;
        }
        private string generateDate(string year, string month, string day)
        {
            return year + "/" + month + "/" + day;
        }

        private DataTable generateMonthlyExpense(int month, int year)
        {
            string dateEnd = generateDate(year, month, 20);

            if (month == 1)
            {
                year -= 1;
            }
            string dateStart = generateDate(year, month - 1, 21);
            var queryGroupDate =
                (from det in conn.detExpenses
                 let datetrx = det.TrxDate.Substring(0, 4) + "/" + det.TrxDate.Substring(4, 2) + "/" + det.TrxDate.Substring(6, 2)
                 where (datetrx.CompareTo(dateStart) >= 0) && (datetrx.CompareTo(dateEnd) <= 0) && (det.Category.CompareTo("Material Gigi") !=0)
                 orderby datetrx
                 select new
                 {
                     date = datetrx,
                     item = det.Item,
                     Price = det.Price,
                 });
            //Separate Cash, Debit and Credit
            DateTime startDate = Convert.ToDateTime(dateStart);
            DateTime endDate = Convert.ToDateTime(dateEnd);
            DataTable dt = new DataTable();

            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Date";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Nama Barang";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Harga(Rupiah)";
            dt.Columns.Add(column);

            foreach(var docs in queryGroupDate)
            {
                DataRow row = dt.NewRow();
                row["Date"] = docs.date;
                row["Nama Barang"] = docs.item;
                row["Harga(Rupiah)"] = docs.Price;
                dt.Rows.Add(row);
            }
            dgPreviewExpenses.DataSource = dt;
            return dt;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (cbDateRange.Text == "")
            {
                MessageBox.Show("Select Month Period of Report");
            }
            else
            {
                generateMonthlyExpense(cbDateRange.SelectedIndex + 1, Convert.ToInt32(numericUpDown1.Value));
                if (dgPreviewExpenses.Rows.Count == 0)
                {
                    MessageBox.Show("No transaction records found");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbDateRange.Text == "")
            {
                MessageBox.Show("Select Month Period of Report");
            }
            else
            {
                datatable.Add(generateMonthlyExpense(cbDateRange.SelectedIndex + 1, Convert.ToInt32(numericUpDown1.Value)));
                if (dgPreviewExpenses.Rows.Count == 0)
                {
                    MessageBox.Show("No transaction records found");
                }
                report.generateReport(datatable, cbDateRange.Text, Convert.ToInt32(numericUpDown1.Value));
                MessageBox.Show("Report Generated!");
                datatable.Clear();
            }
        }
    }
}
