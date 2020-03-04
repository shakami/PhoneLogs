using System.Linq;

namespace PhoneLogs
{
    public static class ExcelToPDFService
    {
        public static void GenerateLog(string inputPath, string outputPath)
        {
            var pdfPath = outputPath + ".pdf";
            var csvPath = outputPath + ".csv";

            var sheetToProcess = Properties.CommonSettings.Default.Sheet;

            var excelApp = new ExcelToCSVService(inputPath, sheetToProcess);
            excelApp.GetOutput(csvPath);

            var columns = Properties.ColumnSettings.Default;
            var csvToCallService = new CSVToCallsService(columns.SessionIDColumn,
                                                         columns.FromNameColumn,
                                                         columns.FromNumberColumn,
                                                         columns.ToNameColumn,
                                                         columns.ToNumberColumn,
                                                         columns.CallResultColumn,
                                                         columns.CallLengthColumn,
                                                         columns.HandleTimeColumn,
                                                         columns.StartTimeColumn,
                                                         columns.CallDirectionColumn,
                                                         columns.CallQueueColumn);

            var calls = csvToCallService.ParseCSV(csvPath);

            var callProcessing = new CallProcessingService(calls);

            var employees = Properties.CommonSettings.Default.Employees.Cast<string>().ToList();
            var processedCalls = callProcessing.GetCallsPerPerson(employees);

            var pdfService = new PDFService(pdfPath);
            pdfService.GenerateOutput(processedCalls);
        }
    }
}
