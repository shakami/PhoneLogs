using System.Linq;

namespace PhoneLogs
{
    public static class Utility
    {
        public static void GenerateLog(string inputPath)
        {
            string outputPath = GetOutputPath(inputPath);

            var pdfPath = outputPath + ".pdf";
            var csvPath = outputPath + ".csv";

            var sheetToProcess = Properties.Settings.Default.Sheet;

            var excelApp = new ExcelToCSVService(inputPath, sheetToProcess);
            excelApp.GetOutput(csvPath);

            var columns = Properties.AdvancedSettings.Default;
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

            var employees = Properties.Settings.Default.Employees.Cast<string>().ToList();
            var processedCalls = callProcessing.GetCallsPerPerson(employees);

            var pdfService = new PDFService(pdfPath);
            pdfService.GenerateOutput(processedCalls);
        }

        public static string GetOutputPath(string inputPath)
        {
            var outputFolder = Properties.Settings.Default.OutputFoler;
            string outputPath;

            if (string.IsNullOrWhiteSpace(outputFolder))
            {
                outputPath = GetFilePathNoExtension(inputPath);
            }
            else
            {
                outputPath = outputFolder + "\\" + GetFileNameNoExtension(inputPath);
            }

            return outputPath;
        }

        public static string GetOutputFolder(string inputPath)
        {
            var outputFolder = Properties.Settings.Default.OutputFoler;

            if (string.IsNullOrWhiteSpace(outputFolder))
            {
                var slashIndex = inputPath.LastIndexOf('\\');
                outputFolder = inputPath.Substring(0, slashIndex);
            }

            return outputFolder;
        }

        private static string GetFilePathNoExtension(string fullPath)
        {
            return fullPath.Substring(0, fullPath.LastIndexOf('.'));
        }

        private static string GetFileNameNoExtension(string fullPath)
        {
            int slashIndex = fullPath.LastIndexOf('\\');
            string fileName = fullPath.Substring(slashIndex + 1, fullPath.Length - slashIndex - 1);
            var result = fileName.Substring(0, fileName.LastIndexOf('.'));
            return result;
        }
    }
}
