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
    public partial class frmMonthlyRecap : Form
    {
        public frmMonthlyRecap()
        {
            InitializeComponent();
        }
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();
        List<DataTable> datatable = new List<DataTable>();
        RecapReportGenerator report = new RecapReportGenerator();
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
        private void generateMonthlyRecap(int month, int year, string doctorName)
        {
            string dateEnd = generateDate(year, month, 20);

            if (month == 1)
            {
                year -= 1;
            }
            string dateStart = generateDate(year, month - 1, 21);

            string dateNow = DateTime.Today.ToString("dd/MM/yyyy");
            List<string> doctorNames =
                (from docs in conn.msDoctors
                 orderby docs.DoctorId
                 select docs.Name).ToList<string>();

            DateTime startDate = Convert.ToDateTime(dateStart);
            DateTime endDate = Convert.ToDateTime(dateEnd);

            foreach (string docName in doctorNames)
            {
                var queryRecap =
                    (from hdrtrx in conn.hdrTransactions
                     join pat in conn.msPatients on hdrtrx.PtnId equals pat.PatientId
                     join dettrx in conn.detTransactions on hdrtrx.TrxId equals dettrx.TrxId
                     join detpay in conn.detPayments on dettrx.detTrxId equals detpay.detTrxId
                     join doc in conn.msDoctors on hdrtrx.DocId equals doc.DoctorId
                     join trt in conn.msTreatments on dettrx.TrtId equals trt.TreatmentId
                     let datetrx = hdrtrx.TrxId.Substring(0, 4) + "/" + hdrtrx.TrxId.Substring(4, 2) + "/" + hdrtrx.TrxId.Substring(6, 2)
                     where (datetrx.CompareTo(dateStart) >= 0) && (datetrx.CompareTo(dateEnd) <= 0) && (doc.Name == docName) && dettrx.TrtId != "1601"
                     orderby datetrx
                     select new
                     {
                         Date = hdrtrx.TrxId.Substring(0, 4) + "/" + hdrtrx.TrxId.Substring(4, 2) + "/" + hdrtrx.TrxId.Substring(6, 2),
                         DetTrxId = detpay.detTrxId,
                         TrxDate = detpay.TrxDate,
                         PatientName = pat.Name,
                         OldNew = (hdrtrx.TrxId.Substring(0, 8) == pat.PatientId.Substring(0, 8) ? "B" : "L"),
                         Quantity = dettrx.Qty,
                         Treatment = dettrx.TrtId,
                         TreatmentPrice = trt.Price,
                         Discount = dettrx.Disc,
                         Amount = detpay.Amount,
                         Remnant = detpay.Remnant,
                         Lab = dettrx.LabPrice,
                         Doctor = doc.Name
                     });
                if (queryRecap != null)
                {
                    DataTable dt = new DataTable();
                    DataColumn column;

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.String");
                    column.ColumnName = "Date";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.String");
                    column.ColumnName = "Nama Pasien";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.String");
                    column.ColumnName = "Pasien Lama / Baru";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.String");
                    column.ColumnName = "Jenis Perawatan";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.Int32");
                    column.ColumnName = "Lab";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.Int32");
                    column.ColumnName = "Dokter";
                    dt.Columns.Add(column);

                    for (DateTime dateiter = startDate; dateiter <= endDate; dateiter = dateiter.AddDays(1.0))
                    {
                        string dateiterStr = dateiter.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
                        var queryPerDay =
                            (from rec in queryRecap
                             where rec.Date == dateiterStr
                             select rec);
                        string rowDate = dateiter.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                        if (queryPerDay.Count() == 0)
                        {
                            if (dateiter.DayOfWeek == DayOfWeek.Sunday)
                            {
                                DataRow row = dt.NewRow();
                                row["Date"] = rowDate;
                                row["Nama Pasien"] = "Libur / Minggu";
                                row["Pasien Lama / Baru"] = "";
                                row["Jenis Perawatan"] = "";
                                row["Dokter"] = 0;
                                dt.Rows.Add(row);
                            }
                            else
                            {
                                DataRow row = dt.NewRow();
                                row["Date"] = rowDate;
                                row["Nama Pasien"] = "xxxx";
                                row["Pasien Lama / Baru"] = "";
                                row["Jenis Perawatan"] = "";
                                row["Dokter"] = 0;
                                dt.Rows.Add(row);
                            }
                        }
                        else
                        {
                            foreach (var recap in queryPerDay)
                            {
                                string trt = (recap.Quantity > 1 ? (recap.Quantity.ToString() + "x") : "");
                                trt += recap.Treatment;
                                if (recap.Discount > 0)
                                {
                                    trt += ", Disc. " + recap.Discount.ToString() + "%";
                                }
                                if (recap.Remnant > 0)
                                {
                                    trt += ", DP";
                                }
                                else if (recap.Amount < (recap.Quantity * recap.TreatmentPrice / 100 * (100 - recap.Discount))){
                                    trt += ", Pelunasan";
                                }
                                DataRow row = dt.NewRow();
                                row["Date"] = rowDate;
                                row["Nama Pasien"] = recap.PatientName;
                                row["Pasien Lama / Baru"] = recap.OldNew;
                                row["Jenis Perawatan"] = trt;
                                row["Dokter"] = Convert.ToInt32(recap.Amount.Value);
                                dt.Rows.Add(row);
                            }
                        }
                    }
                    datatable.Add(dt);
                    if (docName == cbDoctorName.SelectedValue.ToString()) dgPreviewRecap.DataSource = dt;
                }
            }
        }

        private void frmMonthlyRecap_Load(object sender, EventArgs e)
        {
            cbDoctorName.DataSource = conn.msDoctors.Select(x => x.Name);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (cbDateRange.Text == "")
            {
                MessageBox.Show("Select Month Period of Report");
            }
            else if (cbDoctorName.SelectedIndex < 0)
            {
                MessageBox.Show("Select Doctor");
            }
            else
            {
                datatable.Clear();
                generateMonthlyRecap(cbDateRange.SelectedIndex + 1, Convert.ToInt32(numericUpDown1.Value), cbDoctorName.SelectedItem.ToString());
                if (dgPreviewRecap.Rows.Count == 0)
                {
                    MessageBox.Show("No records found");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbDateRange.Text == "")
            {
                MessageBox.Show("Select Month Period of Report");
            }
            else if (cbDoctorName.SelectedIndex < 0)
            {
                MessageBox.Show("Select Doctor");
            }
            else
            {
                datatable.Clear();
                generateMonthlyRecap(cbDateRange.SelectedIndex + 1, Convert.ToInt32(numericUpDown1.Value), cbDoctorName.SelectedItem.ToString());
                if (dgPreviewRecap.Rows.Count == 0)
                {
                    MessageBox.Show("No records found");
                }
                report.generateReport(datatable, cbDateRange.SelectedItem.ToString(), Convert.ToInt32(numericUpDown1.Value));
                
                MessageBox.Show("Report Generated!");
                datatable.Clear();
            }
        }
    }
}
