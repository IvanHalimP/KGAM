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
    public partial class frmMonthlyDoctorReport : Form
    {
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();
        List<DataTable> datatable = new List<DataTable>();
        DoctorReportGenerator report = new DoctorReportGenerator();
        private int admin;
        private int rontgen;
        private int sales;
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
        public frmMonthlyDoctorReport()
        {
            InitializeComponent();
        }
        private DataTable generateMonthlyDoctorIncome(int month, int year)
        {
            string dateEnd = generateDate(year, month, 20);

            if (month == 1)
            {
                year -= 1;
            }
            string dateStart = generateDate(year, month - 1, 21);

            string dateNow = DateTime.Today.ToString("yyyy/MM/dd");
            var queryRec =
                (from hdrtrx in conn.hdrTransactions
                 join detpay in conn.detPayments on hdrtrx.TrxId equals detpay.TrxId
                 join dettrx in conn.detTransactions on hdrtrx.TrxId equals dettrx.TrxId
                 join doc in conn.msDoctors on hdrtrx.DocId equals doc.DoctorId
                 join honor in conn.msHonors on doc.Honor equals honor.Id
                 join trt in conn.msTreatments on dettrx.TrtId equals trt.TreatmentId
                 let datetrx = hdrtrx.TrxId.Substring(0, 4) + "/" + hdrtrx.TrxId.Substring(4, 2) + "/" + hdrtrx.TrxId.Substring(6, 2)
                 where (datetrx.CompareTo(dateStart) >= 0) && (datetrx.CompareTo(dateEnd) <= 0)
                 group new { hdrtrx, detpay, dettrx, doc, honor } by new {
                     trx = dettrx.TrxId,
                     name = doc.Name,
                     chonor = honor.Clinics,
                     dhonor = honor.Doctors,
                     amount = detpay.Amount,
                     lab = dettrx.LabPrice
                 } into g
                 select new
                 {
                     Doctor = g.Key.name,
                     Gross = g.Key.amount,
                     Lab = g.Key.lab,
                     ClinicRatio = g.Key.chonor,
                     DoctorRatio = g.Key.dhonor
                 });
            var queryRecap = (from x in queryRec
                              group queryRec by new {
                                  name = x.Doctor,
                                  chonor = x.ClinicRatio,
                                  dhonor = x.DoctorRatio
                              } into g select new {
                                  Doctor = g.Key.name,
                                  Gross = queryRec.Where(x=> x.Doctor == g.Key.name).Sum(x => x.Gross),
                                  Lab = queryRec.Where(x => x.Doctor == g.Key.name).Sum(x => x.Lab),
                                  ClinicRatio = g.Key.chonor,
                                  DoctorRatio = g.Key.dhonor
                              });
            admin = conn.detAdms
                .Where(x => x.TrxDate.Substring(0, 8).CompareTo(dateStart.Replace("/", "")) >= 0 && x.TrxDate.Substring(0, 8).CompareTo(dateEnd.Replace("/", "")) <= 0)
                .Sum(x => x.Amount).Value;

            var tempRontgen= (from hdrtrx in conn.hdrTransactions
                       join detpay in conn.detPayments on hdrtrx.TrxId equals detpay.TrxId
                       join dettrx in conn.detTransactions on hdrtrx.TrxId equals dettrx.TrxId
                       join trt in conn.msTreatments on dettrx.TrtId equals trt.TreatmentId
                       let datetrx = hdrtrx.TrxId.Substring(0, 4) + "/" + hdrtrx.TrxId.Substring(4, 2) + "/" + hdrtrx.TrxId.Substring(6, 2)
                       where (datetrx.CompareTo(dateStart) >= 0) && (datetrx.CompareTo(dateEnd) <= 0 && trt.TreatmentId == "1601")
                       select new
                       {
                           Amount = trt.Price
                       });
            if (tempRontgen.Count() == 0)
            {
                rontgen = 0;
            }
            else
            {
                rontgen = tempRontgen.Sum(x => x.Amount).Value;
            }
            sales = 0;
            DataTable dt = new DataTable();
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "No.";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Pendapatan Dept";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Gross";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Lab";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Klinik";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Dokter";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Potongan Pph";
            dt.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Honor Dokter Netto";
            dt.Columns.Add(column);

            int count = 0;
            foreach (var docs in queryRecap)
            {
                count++;
                DataRow dr = dt.NewRow();
                int gross = Convert.ToInt32(docs.Gross);
                int lab = Convert.ToInt32(docs.Lab);
                int r_klinik = Convert.ToInt32(docs.ClinicRatio);
                int r_dokter = Convert.ToInt32(docs.DoctorRatio);
                int klinik = (gross - lab) / (r_klinik + r_dokter) * (r_klinik);
                int dokter = (gross - lab) / (r_klinik + r_dokter) * (r_dokter);
                var pph = 
                        (from x in conn.msTaxes
                         where x.Name.CompareTo("PPh") == 0
                         select new { amount = x.Amount }).FirstOrDefault().amount;
                int potongan_pph = Convert.ToInt32(pph * Convert.ToDouble(dokter) / 100.00);

                dr["No."] = count; 
                dr["Pendapatan Dept"] = docs.Doctor;
                dr["Gross"] = gross;
                dr["Lab"] = lab;
                dr["Klinik"] = klinik;
                dr["Dokter"] = dokter;
                dr["Potongan Pph"] = potongan_pph;
                dr["Honor Dokter Netto"] = dokter - potongan_pph;
                dt.Rows.Add(dr);
            }
            dgPreviewRecap.DataSource = dt;
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
                generateMonthlyDoctorIncome(cbDateRange.SelectedIndex + 1, Convert.ToInt32(numericUpDown1.Value));
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
                datatable.Add(generateMonthlyDoctorIncome(cbDateRange.SelectedIndex + 1, Convert.ToInt32(numericUpDown1.Value)));
                if (dgPreviewRecap.Rows.Count == 0)
                {
                    MessageBox.Show("No transaction records found");
                }
                report.generateReport(datatable, cbDateRange.Text, Convert.ToInt32(numericUpDown1.Value), admin, rontgen, sales);
                MessageBox.Show("Report Generated!");
                datatable.Clear();
            }
        }
        
    }
}
