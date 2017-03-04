using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinik_Gigi_Ana_Medika
{
    public partial class frmMonthlyIncomeReport : Form
    {
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();
        List<DataTable> datatable = new List<DataTable>();
        IncomeReportGenerator report = new IncomeReportGenerator();
        public frmMonthlyIncomeReport()
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
        
        private void frmMonthlyCreditReport_Load(object sender, EventArgs e)
        {
            
        }
        private DataTable generateMonthlyIncomeReport(int month, int year)
        {
            string dateEnd = generateDate(year, month, 20);
            
            if (month == 1)
            {
                year -= 1;
            }
            string dateStart = generateDate(year, month - 1, 21);
            var queryGroupDate =
                (from det in conn.detPayments
                 let datetrx = det.TrxId.Substring(0, 4) + "/" + det.TrxId.Substring(4, 2) + "/" + det.TrxId.Substring(6, 2)
                 where (datetrx.CompareTo(dateStart) >= 0) && (datetrx.CompareTo(dateEnd) <= 0)
                 group det by new
                 {
                     date = datetrx,
                     type = det.PaymentType
                 } into g
                 orderby g.Key.date
                 select new
                 {
                     date = g.Key.date,
                     amount = g.Sum(x => x.Amount),
                     paymentType = g.Key.type
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
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Cash";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Debit";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Credit";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Bunga 1.9%";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Total Amount";
            dt.Columns.Add(column);

            for (DateTime dateiter = startDate; dateiter <= endDate; dateiter = dateiter.AddDays(1.0))
            {
                string datenow = dateiter.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
                int cashQuery = Convert.ToInt32(queryGroupDate.Where(x => x.date == datenow && x.paymentType == "Cash").Sum(x => x.amount));
                int debitQuery = Convert.ToInt32(queryGroupDate.Where(x => x.date == datenow && x.paymentType == "Debit").Sum(x => x.amount));
                int creditQuery = Convert.ToInt32(queryGroupDate.Where(x => x.date == datenow && (x.paymentType == "Visa" || x.paymentType == "MasterCard")).Sum(x => x.amount));
                var bunga = 
                        (from x in conn.msTaxes
                         where x.Name == "CreditCard"
                         select new { amount = x.Amount }).FirstOrDefault().amount;
                int bungacredit = Convert.ToInt32(bunga * Convert.ToDouble(creditQuery) / 100.0);
                DataRow row = dt.NewRow();
                row["Date"] = dateiter.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                row["Cash"] = cashQuery;
                row["Debit"] = debitQuery;
                row["Credit"] = creditQuery;
                row["Bunga 1.9%"] = bungacredit;
                row["Total Amount"] = cashQuery + debitQuery + creditQuery - bungacredit;
                dt.Rows.Add(row);
            }
            dgPreviewRecap.DataSource = dt;
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbDateRange.Text == "")
            {
                MessageBox.Show("Select Month Period of Report");
            }
            else
            {
                generateMonthlyIncomeReport(cbDateRange.SelectedIndex + 1, Convert.ToInt32(numericUpDown1.Value));
                if (dgPreviewRecap.Rows.Count == 0)
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
                datatable.Add(generateMonthlyIncomeReport(cbDateRange.SelectedIndex + 1, Convert.ToInt32(numericUpDown1.Value)));
                if (dgPreviewRecap.Rows.Count == 0)
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
