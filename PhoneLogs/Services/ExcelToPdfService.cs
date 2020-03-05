using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneLogs.Services
{
    public static class ExcelToPDFService
    {
        public static void GenerateLog(string inputPath, string outputPath)
        {
            var pdfPath = outputPath + ".pdf";
            var csvPath = outputPath + ".csv";

            var sheetToProcess = Properties.CommonSettings.Default.Sheet;

            try
            {
                var excelApp = new ExcelToCSVService(inputPath, sheetToProcess);
                excelApp.GetOutput(csvPath);

            }
            catch (Exception e)
            {
                throw new ApplicationException("Error processing the Excel worksheet.", e);
            }

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

            List<Call> calls;

            try
            {
                calls = csvToCallService.ParseCSV(csvPath);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error reading data from file.", e);
            }

            var callProcessing = new CallProcessingService(calls);

            var employees = Properties.CommonSettings.Default.Employees.Cast<string>().ToList();
            
            Dictionary<string, CallLog> processedCalls;
            Dictionary<string, CallStats> totalStats;

            try
            {
                processedCalls = callProcessing.GetCallsPerPerson(employees);
                totalStats = callProcessing.GetTotalStats(employees);

            }
            catch (Exception e)
            {
                throw new ApplicationException("Error performing queries on phone call logs.", e);
            }

            var pdfService = new PDFService(pdfPath);

            try
            {
                pdfService.GenerateOutput(processedCalls, totalStats);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error generating PDF file from data", e);
            }
        }
    }
}
