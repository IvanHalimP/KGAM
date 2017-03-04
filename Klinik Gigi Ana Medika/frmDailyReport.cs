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
    public partial class frmDailyReport : Form
    {
        private AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();
        private int debit;
        private int master;
        private int visa;
        private int cash;
        private int taken;
        private int totalCash;
        private int totalInc;

        DateTime datenow;
        List<DataTable> datatable = new List<DataTable>();
        string now_yyyymmdd;
        DailyReportGenerator report = new DailyReportGenerator();

        public frmDailyReport()
        {
            InitializeComponent();
        }
        
        private int getDebit()
        {
            var query = conn.detPayments
                .Where(x => x.TrxId.Substring(0, 8) == now_yyyymmdd && x.PaymentType == "Debit")
                .Sum(x => x.Amount);
            lblDebit.Text = (query == null ? 0 : query).ToString();
            return Int32.Parse(lblDebit.Text);
        }

        private int getMaster()
        {
            var query = conn.detPayments
                .Where(x => x.TrxId.Substring(0, 8) == now_yyyymmdd && x.PaymentType == "MasterCard")
                .Sum(x => x.Amount);
            lblMaster.Text = (query == null ? 0 : query).ToString();
            return Int32.Parse(lblMaster.Text);
        }

        private int getVisa()
        {
            var query = conn.detPayments
                .Where(x => x.TrxId.Substring(0, 8) == now_yyyymmdd && x.PaymentType == "Visa")
                .Sum(x => x.Amount);
            lblVisa.Text = (query == null ? 0 : query).ToString();
            return Int32.Parse(lblVisa.Text);
        }

        private int getCash()
        {
            var query = conn.detPayments
                .Where(x => x.TrxId.Substring(0, 8) == now_yyyymmdd && x.PaymentType == "Cash")
                .Sum(x => x.Amount);
            lblCash.Text = (query == null ? 0 : query).ToString();
            return Int32.Parse(lblCash.Text);
        }

        private int getTaken()
        {
            var query = conn.detExpenses
                .Where(x => x.TrxDate.Substring(0, 8) == now_yyyymmdd)
                .Sum(x => x.Price);
            lblTaken.Text = (query == null ? 0 : query).ToString();
            return Int32.Parse(lblTaken.Text);
        }

        private void refresh_dgExpense()
        {
            var query = (from x in conn.detExpenses
                        where x.TrxDate.Substring(0, 8) == now_yyyymmdd
                         select x);
            dgExpense.DataSource = query;
        }
        private void cal_DateSelected(object sender, DateRangeEventArgs e)
        {
            refreshData();
            refresh_dgExpense();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshData();
            refresh_dgExpense();
        }

        private void refreshData()
        {
            datenow = cal.SelectionRange.Start;
            now_yyyymmdd = datenow.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
            debit = getDebit();
            master = getMaster();
            visa = getVisa();
            cash = getCash();
            taken = getTaken();

            totalCash = debit + master + visa + cash;
            totalInc = totalCash - taken;
            lblTotalCash.Text = (totalCash).ToString();
            lblTotalInc.Text = (totalInc).ToString();
            
        }

        private void putToDataTable()
        {
            datatable.Clear();
            DataTable dt = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Category";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Total Amount";
            dt.Columns.Add(column);

            DataRow row = dt.NewRow();
            row["Category"] = "Kas Awal";
            row["Total Amount"] = 0;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Category"] = "Debit";
            row["Total Amount"] = debit;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Category"] = "Cash";
            row["Total Amount"] = cash;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Category"] = "Master Card";
            row["Total Amount"] = master;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Category"] = "Visa";
            row["Total Amount"] = visa;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Category"] = "----------------";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Category"] = "Saldo Akhir";
            row["Total Amount"] = totalCash;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Category"] = "Pengambilan";
            row["Total Amount"] = taken;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Category"] = "----------------";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Category"] = "Saldo Akhir";
            row["Total Amount"] = totalInc;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Category"] = "Kas Akhir";
            row["Total Amount"] = cash - taken;
            dt.Rows.Add(row);
            datatable.Add(dt);
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDailyDialog.Document = printDailyDocument;
            printDailyDocument.PrintPage += printDailyDocument_PrintPage;

            if (printDailyDialog.ShowDialog() == DialogResult.OK)
            {
                printDailyDocument.Print();
            }
        }

        private void frmDailyReport_Load(object sender, EventArgs e)
        {

        }

        string numToCurrency(string num)
        {
            string res = "";
            if (num == "" || num == "0")
            {
                return "0";
            }
            for (int i = num.Length - 1, j = 0; i >= 0; i--, j++)
            {
                if (j % 3 == 0 && j > 0)
                {
                    res = "." + res;
                }
                res = num[i] + res;
            }
            return res;
        }
        private void printDailyDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics pgGraph = e.Graphics;
            Font font = new Font("Arial", 9);

            StringFormat rightAlign = new StringFormat();
            rightAlign.Alignment = StringAlignment.Far;

            int beginX = 10;
            int beginY = 100;
            pgGraph.DrawString("Kas Awal", font, new SolidBrush(Color.Black), beginX, beginY);
            pgGraph.DrawString(numToCurrency("0"), font, new SolidBrush(Color.Black), beginX + 200, beginY, rightAlign);
            beginY += 18;

            pgGraph.DrawString("Debit", font, new SolidBrush(Color.Black), beginX, beginY);
            pgGraph.DrawString(numToCurrency(debit.ToString()), font, new SolidBrush(Color.Black), beginX + 200, beginY, rightAlign);
            beginY += 18;

            pgGraph.DrawString("Cash", font, new SolidBrush(Color.Black), beginX, beginY);
            pgGraph.DrawString(numToCurrency(cash.ToString()), font, new SolidBrush(Color.Black), beginX + 200, beginY, rightAlign);
            beginY += 18;

            pgGraph.DrawString("Master Card", font, new SolidBrush(Color.Black), beginX, beginY);
            pgGraph.DrawString(numToCurrency(master.ToString()), font, new SolidBrush(Color.Black), beginX + 200, beginY, rightAlign);
            beginY += 18;

            pgGraph.DrawString("Visa", font, new SolidBrush(Color.Black), beginX, beginY);
            pgGraph.DrawString(numToCurrency(visa.ToString()), font, new SolidBrush(Color.Black), beginX + 200, beginY, rightAlign);
            beginY += 18;

            pgGraph.DrawString("------------", font, new SolidBrush(Color.Black), beginX, beginY);
            beginY += 18;

            pgGraph.DrawString("Saldo Akhir", font, new SolidBrush(Color.Black), beginX, beginY);
            pgGraph.DrawString(numToCurrency(totalCash.ToString()), font, new SolidBrush(Color.Black), beginX + 200, beginY, rightAlign);
            beginY += 18;

            pgGraph.DrawString("Pengambilan", font, new SolidBrush(Color.Black), beginX, beginY);
            pgGraph.DrawString(numToCurrency(taken.ToString()), font, new SolidBrush(Color.Black), beginX + 200, beginY, rightAlign);
            beginY += 18;

            pgGraph.DrawString("------------", font, new SolidBrush(Color.Black), beginX, beginY);
            beginY += 18;

            pgGraph.DrawString("Saldo Akhir", font, new SolidBrush(Color.Black), beginX, beginY);
            pgGraph.DrawString(numToCurrency(totalInc.ToString()), font, new SolidBrush(Color.Black), beginX + 200, beginY, rightAlign);
            beginY += 18;

            pgGraph.DrawString("Kas Akhir", font, new SolidBrush(Color.Black), beginX, beginY);
            pgGraph.DrawString(numToCurrency((cash - taken).ToString()), font, new SolidBrush(Color.Black), beginX + 200, beginY, rightAlign);
            beginY += 18;

        }
    }
}
