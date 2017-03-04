using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace Klinik_Gigi_Ana_Medika
{
    class reportGenerator
    {
        protected AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();

        protected Excel.Application app;
        protected Excel._Workbook wb;
        protected Excel._Worksheet ws;
        protected string period;
        protected int year;
        protected int iRow;
        protected int iCol;

        public virtual void generateReport(List<System.Data.DataTable> dt, string period, int year){ }
        protected virtual void configureColumns(){ }
        protected virtual void configureHeader() { }
        protected virtual void sumUpTotal(){ }

        protected void createFile(string filename)
        {
            app = new Excel.Application();
            wb = app.Workbooks.Add();
            
            var file = new FileInfo(filename);
            file.Directory.Create();
        }
        protected void saveFile(string filename)
        {
            object missing = System.Reflection.Missing.Value;
            wb.SaveAs(filename, Excel.XlFileFormat.xlOpenXMLWorkbook,
                missing, missing, missing, missing, Excel.XlSaveAsAccessMode.xlNoChange,
                missing, missing, missing, missing, missing);

            wb.Close(false, Type.Missing, Type.Missing);
            app.Quit();
        }
        protected void writeReport(System.Data.DataTable dt, string sheetName, int startRow)
        {
            iRow = startRow;
            ws.Name = sheetName;
            iCol = 0;
            foreach (System.Data.DataColumn c in dt.Columns)
            {
                iCol++;
                ws.Cells[iRow, iCol] = c.ColumnName;
            }
            foreach (System.Data.DataRow r in dt.Rows)
            {
                iRow++;
                // add each row's cell data...
                iCol = 0;
                foreach (System.Data.DataColumn c in dt.Columns)
                {
                    iCol++;
                    ws.Cells[iRow + 1, iCol] = r[c.ColumnName];
                }
            }
        }
    }
    class DoctorReportGenerator: reportGenerator
    {
        
        public  void generateReport(List<System.Data.DataTable> dt, string period, int year, int admin, int  rontgen, int sales)
        {
            this.period = period;
            this.year = year;

            string filename = Environment.CurrentDirectory + @"\Data\Doctor\Doctor_" + year + "_" + period.Replace(" ", "") + ".xlsx";
            createFile(filename);
            foreach (System.Data.DataTable d in dt)
            {
                configureColumns();
                configureHeader();
                writeReport(d, "Doctor_" + year + "_" + period.Replace(" ", ""), 3);
                iRow += 2;
                addAdminRontgenSalesPPh(admin, rontgen, sales);
            }
            saveFile(filename);
        }
        private void addAdminRontgenSalesPPh(int admin, int rontgen, int sales)
        {
            ws.Cells[iRow, 2] = "Admin";
            ws.Cells[iRow++, 3] = admin;

            ws.Cells[iRow, 2] = "Rontgen";
            ws.Cells[iRow++, 3] = rontgen;

            ws.Cells[iRow, 2] = "Penjualan";
            ws.Cells[iRow++, 3] = sales;
            
            ws.Cells[iRow + 2, 2] = "Total";
            ws.Cells[iRow + 2, 3].Formula = string.Format("=SUM(C1:C" + iRow + ")");
            ws.Cells[iRow + 2, 4].Formula = string.Format("=SUM(D1:D" + iRow + ")");
            ws.Cells[iRow + 2, 5].Formula = string.Format("=SUM(E1:E" + iRow + ")");
            ws.Cells[iRow + 2, 6].Formula = string.Format("=SUM(F1:F" + iRow + ")");
            ws.Cells[iRow + 2, 8].Formula = string.Format("=SUM(H1:H" + iRow + ")");

            ws.Cells[iRow, 2] = "PPh Pasal 4 ayat (2)";
            ws.Cells[iRow, 7] = ws.Cells[iRow + 2, 3].Value2 / 100;
            ws.Cells[iRow + 2, 7].Formula = string.Format("=SUM(G1:G" + iRow + ")");
        }
        protected override void configureColumns()
        {
            ws = wb.Worksheets.Add();
            ws.Columns["A:A"].ColumnWidth = 3.00;
            ws.Columns["A:A"].NumberFormat = "@";
            ws.Columns["B:H"].ColumnWidth = 15.00;
        }
        protected override void configureHeader()
        {
            ws.Range["A1:H1"].Merge();
            ws.Cells[1, 1] = "Rekapitulasi Honor Dokter Klinik Gigi Ana Medika" +
                             "(CV Ana Budimulya) per " + this.period + " " + this.year;

            ws.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
        }
    }
    class IncomeReportGenerator: reportGenerator
    {
        public override void generateReport(List<System.Data.DataTable> dt, string period, int year)
        {
            this.period = period;
            this.year = year;

            string filename = Environment.CurrentDirectory + @"\Data\Income\Income_" + year + "_" + period.Replace(" ", "") + ".xlsx";
            createFile(filename);
            foreach (System.Data.DataTable d in dt)
            {
                configureColumns();
                configureHeader();
                writeReport(d, "Income_" + year + "_" + period.Replace(" ", ""), 3);
                iRow += 2;
                sumUpTotal();
            }
            saveFile(filename);
        }
        protected override void configureColumns()
        {
            ws = wb.Worksheets.Add();
            ws.Columns["A:A"].ColumnWidth = 12.00;
            ws.Columns["A:A"].NumberFormat = "@";
            ws.Columns["B:F"].ColumnWidth = 15.00;
            ws.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;

        }
        protected override void configureHeader()
        {
            ws.Range["A1:F1"].Merge();
            ws.Cells[1, 1] = "Rekapitulasi Pemasukan Klinik Gigi Ana Medika" +
                             "(CV Ana Budimulya) per " + this.period + " " + this.year;
        }
        protected override void sumUpTotal()
        {
            base.sumUpTotal();
            ws.Cells[iRow, 1] = "Total";
            ws.Cells[iRow, 2].Formula = string.Format("=SUM(B1:B" + (iRow-1) + ")");
            ws.Cells[iRow, 3].Formula = string.Format("=SUM(C1:C" + (iRow-1) + ")");
            ws.Cells[iRow, 4].Formula = string.Format("=SUM(D1:D" + (iRow-1) + ")");
            ws.Cells[iRow, 5].Formula = string.Format("=SUM(E1:E" + (iRow-1) + ")");
            ws.Cells[iRow, 6].Formula = string.Format("=SUM(F1:F" + (iRow-1) + ")");
            iRow++;
            ws.Cells[iRow, 6] = string.Format("=SUM(B"+ (iRow-1) + ":D" + (iRow-1) + ")");
            ws.Range["A" + (iRow) + ":E" + (iRow)].Merge();
            ws.Cells[iRow, 1] = "Total Pemasukan";
        }
    }
    class ExpenseReportGenerator : reportGenerator
    {
        public override void generateReport(List<System.Data.DataTable> dt, string period, int year)
        {
            this.period = period;
            this.year = year;

            string filename = Environment.CurrentDirectory + @"\Data\Expense\Expense_" + year + "_" + period.Replace(" ", "") + ".xlsx";
            createFile(filename);
            foreach (System.Data.DataTable d in dt)
            {
                configureColumns();
                configureHeader();
                writeReport(d, "Expense_" + year + "_" + period.Replace(" ", ""), 3);
                iRow += 2;
                sumUpTotal();
            }
            saveFile(filename);
        }
        protected override void configureColumns()
        {
            ws = wb.Worksheets.Add();
            ws.Columns["A:A"].ColumnWidth = 12.00;
            ws.Columns["A:A"].NumberFormat = "@";
            ws.Columns["B:B"].ColumnWidth = 30.00;
            ws.Columns["C:C"].ColumnWidth = 30.00;
        }
        protected override void configureHeader()
        {
            ws.Cells[1, 1] = "CV Ana Budimulya";
            ws.Cells[1, 3] = "Per " + this.period + " " + year.ToString();
        }
        protected override void sumUpTotal()
        {
            base.sumUpTotal();

            ws.Range["A" + (iRow) + ":B" + (iRow)].Merge();
            ws.Cells[iRow, 1] = "Total";
            ws.Cells[iRow, 3].Formula = string.Format("=SUM(C1:C" + (iRow-1) + ")");
        }
    }
    class RecapReportGenerator : reportGenerator
    {
        public override void generateReport(List<System.Data.DataTable> dt, string period, int year)
        {
            this.period = period;
            this.year = year;

            string filename = Environment.CurrentDirectory + @"\Data\Recap\Recap_" + year + "_" + period.Replace(" ", "") + ".xlsx";
            createFile(filename);
            List<string> doctorNames = (from doc in conn.msDoctors orderby doc.DoctorId select doc.Name).ToList();
            int count = 0;
            foreach (System.Data.DataTable d in dt)
            {
                configureColumns();
                configureHeader(doctorNames[count]);
                writeReport(d, doctorNames[count], 3);
                iRow += 2;
                sumUpTotal();
                count++;
            }
            saveFile(filename);
        }
        protected override void configureColumns()
        {
            ws = wb.Worksheets.Add();
            ws.Columns["A:A"].ColumnWidth = 12.00;
            ws.Columns["A:A"].NumberFormat = "@";

            ws.Columns["B:B"].ColumnWidth = 30.00;
            ws.Columns["C:C"].ColumnWidth = 5.00;

            ws.Columns["D:D"].ColumnWidth = 10.00;
            ws.Columns["D:D"].NumberFormat = "@";

            ws.Columns["E:E"].ColumnWidth = 5.00;
            ws.Columns["F:F"].ColumnWidth = 10.00;

        }
        protected void configureHeader(string doctorName)
        {
            ws.Range["A1:B1"].Merge();
            ws.Range["E1:F1"].Merge();
            ws.Cells[1, 1] = doctorName;
            ws.Cells[1, 5] = "Per " + this.period + " " + year.ToString();
        }
        protected override void sumUpTotal()
        {
            base.sumUpTotal();

            ws.Range["A" + (iRow) + ":D" + (iRow)].Merge();
            ws.Cells[iRow, 1] = "Total Per Unit Konsultasi";
            ws.Cells[iRow, 5].Formula = string.Format("=SUM(E1:E" + (iRow-1) + ")");
            ws.Cells[iRow, 6].Formula = string.Format("=SUM(F1:F" + (iRow-1) + ")");
        }
    }
    class DailyReportGenerator : reportGenerator
    {
        public override void generateReport(List<System.Data.DataTable> dt, string period, int year)
        {
            this.period = period;
            this.year = year;

            string filename = Environment.CurrentDirectory + @"\Data\Daily\Daily_" + year + "_" + period.Replace(" ", "") + ".xlsx";
            createFile(filename);
            foreach (System.Data.DataTable d in dt)
            {
                configureColumns();
                configureHeader();
                writeReport(d, "Daily_" + year + "_" + period.Replace(" ", ""), 5);
            }
            saveFile(filename);
        }
        protected override void configureColumns()
        {
            ws = wb.Worksheets.Add();
            ws.Columns["A:A"].ColumnWidth = 50.00;
            ws.Columns["B:B"].ColumnWidth = 50.00;
            ws.Range["A1:B1"].Merge();
            ws.Range["A2:B2"].Merge();
            ws.Range["A3:B3"].Merge();
            ws.Range["A4:B4"].Merge();
        }
        protected override void configureHeader()
        {
            ws.Cells[1, 1] = "KLINIK GIGI ANA MEDIKA";
            ws.Cells[2, 1] = "KASIR";
            ws.Cells[3, 1] = DateTime.Now;
        }
    }
}