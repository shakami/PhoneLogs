using System;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace PhoneLogs.Services
{
    public class ExcelToCSVService
    {
        private readonly Excel.Application excelApp;
        private readonly Excel.Workbook workbook;
        private readonly Excel.Worksheet worksheet;
        private readonly Excel.Range data;

        public ExcelToCSVService(string inputPath, int sheet)
        {
            excelApp = new Excel.Application
            {
                DisplayAlerts = false
            };
            workbook = excelApp.Workbooks.Open(inputPath);
            worksheet = workbook.Sheets[sheet];
            worksheet.Select();
            data = worksheet.UsedRange;
        }

        public void GetOutput(string outputPath)
        {
            workbook.SaveAs(outputPath, Excel.XlFileFormat.xlCSV);
            Kill();
        }

        private void Kill()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(data);
            Marshal.ReleaseComObject(worksheet);
            workbook.Close(SaveChanges: false, Filename: null, RouteWorkbook: false);
            Marshal.ReleaseComObject(workbook);
            excelApp.Quit();
            Marshal.ReleaseComObject(excelApp);
        }
    }
}
