using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PhoneLogs.Services
{
    public static class ExcelToPDFService
    {
        public static void GenerateLog(BackgroundWorker backgroundWorker, string inputPath, string outputPath)
        {
            var pdfPath = outputPath + ".pdf";
            var csvPath = outputPath + ".csv";

            var sheetToProcess = Properties.CommonSettings.Default.Sheet;

            try
            {
                var excelApp = new ExcelToCSVService(inputPath, sheetToProcess);
                excelApp.GetOutput(csvPath);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error processing the Excel worksheet.", ex);
            }

            backgroundWorker.ReportProgress(40);

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
            catch (Exception ex)
            {
                throw new ApplicationException("Error reading data from file.", ex);
            }

            backgroundWorker.ReportProgress(60);

            var callProcessing = new CallProcessingService(calls);

            var employees = Properties.CommonSettings.Default.Employees.Cast<string>().ToList();

            Dictionary<string, CallLog> processedCalls;
            Dictionary<string, CallStats> totalStats;

            try
            {
                processedCalls = callProcessing.GetCallsPerPerson(employees);
                totalStats = callProcessing.GetTotalStats(employees);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error performing queries on phone call logs.", ex);
            }

            backgroundWorker.ReportProgress(80);

            try
            {
                var pdfService = new PDFService(pdfPath);
                pdfService.GenerateOutput(processedCalls, totalStats);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error generating PDF file from data.", ex);
            }

            backgroundWorker.ReportProgress(100);
        }
    }
}
