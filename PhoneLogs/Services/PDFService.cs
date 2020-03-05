using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhoneLogs.Services
{
    public class PDFService
    {
        private readonly Document _doc;
        private const int NUM_COLUMNS = 9;
        private const float DIV_MARGIN = 25;
        private readonly DeviceRgb HEADING_COLOR = new DeviceRgb(68, 111, 111);
        private readonly DeviceRgb GREY_BACKGROUND = new DeviceRgb(160, 160, 160);
        private readonly DeviceRgb BLUE_BACKGROUND = new DeviceRgb(145, 186, 186);
        private readonly DeviceRgb GREEN_BACKGROUND = new DeviceRgb(121, 210, 166);
        private readonly DeviceRgb TABLE_STRIPE = new DeviceRgb(224, 235, 235);
        private readonly PdfFont REGULAR_FONT = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
        private readonly PdfFont BOLD_FONT = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        private const int LARGE_FONT_SIZE = 12;
        private const int REGULAR_FONT_SIZE = 8;

        public PDFService(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            file.Directory.Create();

            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(filePath));
            _doc = new Document(pdfDoc, PageSize.LETTER.Rotate());
        }

        public void GenerateOutput(Dictionary<string, CallLog> data, Dictionary<string, CallStats> totalStats)
        {
            _doc.Add(GenerateOuputForTotalStats(totalStats["Total"]));
            totalStats.Remove("Total");

            foreach (var employee in data)
            {
                Div employeeDiv = GenerateOutputForEmployee(employee);
                _doc.Add(employeeDiv);
            }

            if (totalStats.Any())
            {
                _doc.Add(GenerateOutputForQueues(totalStats));
            }
            _doc.Close();
        }

        private Div GenerateOutputForQueues(Dictionary<string, CallStats> totalStats)
        {
            Div queueDiv = new Div()
                                .SetKeepTogether(true)
                                .SetMarginTop(DIV_MARGIN)
                                .SetFont(REGULAR_FONT);


            var queueTitle = new Paragraph("Call Stats For Different Queues")
                .SetFont(BOLD_FONT)
                .SetFontSize(LARGE_FONT_SIZE)
                .SetFontColor(HEADING_COLOR);

            queueDiv.Add(queueTitle);

            Table queueTable = new Table(new float[totalStats.Count]).UseAllAvailableWidth();
            foreach (var queue in totalStats)
            {
                Cell queueHeader = new Cell()
                    .SetBackgroundColor(GREEN_BACKGROUND)
                    .Add(new Paragraph(queue.Key));

                Cell queueCalls = new Cell()
                    .Add(new Paragraph($"{queue.Value.TotalCalls} Call(s)"));

                Cell queueTime = new Cell()
                    .SetBackgroundColor(TABLE_STRIPE)
                    .Add(new Paragraph($"Duration: {queue.Value.Duration}"));

                queueTable.AddHeaderCell(queueHeader)
                          .AddCell(queueCalls)
                          .AddFooterCell(queueTime);
            }
            queueDiv.Add(queueTable);
            return queueDiv;
        }

        private Div GenerateOuputForTotalStats(CallStats totalStats)
        {
            Div statsDiv = new Div()
                            .SetKeepTogether(true)
                            .SetMarginTop(DIV_MARGIN);

            Table statsTable = new Table(new float[2])
                .SetBorder(Border.NO_BORDER)
                .UseAllAvailableWidth()
                .SetFontColor(HEADING_COLOR)
                .SetFont(REGULAR_FONT)
                .SetFontSize(REGULAR_FONT_SIZE);

            Cell statsCell = new Cell()
                .SetBorder(Border.NO_BORDER)
                .Add(new Paragraph($"Total Calls: {totalStats.TotalCalls} - " +
                    $"Total Time: {totalStats.Duration}"));

            Cell timeCell = new Cell()
                .SetBorder(Border.NO_BORDER)
                .SetTextAlignment(TextAlignment.RIGHT)
                .Add(new Paragraph($"Report generated on: {DateTime.Now.ToString()}"));

            statsTable.AddCell(statsCell).AddCell(timeCell);

            statsDiv.Add(statsTable);

            return statsDiv;
        }

        private Div GenerateOutputForEmployee(KeyValuePair<string, CallLog> employee)
        {
            Div employeeDiv = new Div()
                .SetKeepTogether(true)
                .SetMarginTop(DIV_MARGIN)
                .SetFont(REGULAR_FONT);

            employeeDiv.Add(GenerateEmployeeTitle(employee));

            employeeDiv.Add(GenerateEmployeeTable(employee));

            return employeeDiv;
        }

        private Paragraph GenerateEmployeeTitle(KeyValuePair<string, CallLog> employee)
        {
            var titleText = $"{employee.Key} - " +
                            $"{employee.Value.Stats.TotalCalls} Call(s) - " +
                            $"Duration: {employee.Value.Stats.Duration}";

            return new Paragraph(titleText)
                .SetFont(BOLD_FONT)
                .SetFontSize(LARGE_FONT_SIZE)
                .SetFontColor(HEADING_COLOR);
        }

        private Table GenerateEmployeeTable(KeyValuePair<string, CallLog> employee)
        {
            Table table = new Table(new float[NUM_COLUMNS]).UseAllAvailableWidth();
            if (employee.Value.CallsTo.Any())
            {
                table.AddCell(GetHeader("Calls Received"));
                AddHeaders(table, callsMade: false);
                for (int i = 0; i < employee.Value.CallsTo.Count; i++)
                {
                    AddCall(table, employee.Value.CallsTo[i], callsMade: false, striped: (i % 2 == 1));
                }
            }

            if (employee.Value.CallsFrom.Any())
            {
                table.AddCell(GetHeader("Calls Made"));
                AddHeaders(table, callsMade: true);

                for (int i = 0; i < employee.Value.CallsFrom.Count; i++)
                {
                    AddCall(table, employee.Value.CallsFrom[i], callsMade: true, striped: (i % 2 == 1));
                }
            }

            return table;
        }

        private Cell GetHeader(string text)
        {
            return new Cell(1, NUM_COLUMNS)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetBackgroundColor(GREY_BACKGROUND)
                .Add(new Paragraph(text));
        }

        private void AddCall(Table table, Call call, bool callsMade, bool striped)
        {
            table.AddCell(GetCell(call.StartTime.ToString(), striped));

            table.AddCell(GetCell(call.CallLength.ToString(), striped));

            if (callsMade)
            {
                table.AddCell(GetCell(call.FromNumber, striped));

                var toText = call.ToName;
                if (!string.IsNullOrWhiteSpace(toText))
                {
                    toText += " - ";
                }
                toText += call.ToNumber;

                table.AddCell(GetCell(toText, striped));
            }
            else
            {
                table.AddCell(GetCell(call.ToNumber, striped));

                var fromText = call.FromName;
                if (!string.IsNullOrWhiteSpace(fromText))
                {
                    fromText += " - ";
                }
                fromText += call.FromNumber;

                table.AddCell(GetCell(fromText, striped));
            }

            table.AddCell(GetCell(call.CallResult, striped));

            table.AddCell(GetCell(call.CallDirection, striped));

            table.AddCell(GetCell(call.HandleTime, striped));

            table.AddCell(GetCell(call.CallQueue, striped));

            table.AddCell(GetCell(call.SessionId, striped));
        }

        private Cell GetCell(string text, bool striped)
        {
            return new Cell()
                .SetBackgroundColor(striped ? TABLE_STRIPE : ColorConstants.WHITE)
                .SetFontSize(REGULAR_FONT_SIZE)
                .Add(new Paragraph(text));
        }

        private void AddHeaders(Table table, bool callsMade)
        {
            Cell cell = new Cell().SetBackgroundColor(BLUE_BACKGROUND);

            table.AddCell(cell.Clone(false).Add(new Paragraph("Date/Time")));
            table.AddCell(cell.Clone(false).Add(new Paragraph("Duration")));


            if (callsMade)
            {
                table.AddCell(cell.Clone(false).Add(new Paragraph("Called From")));
                table.AddCell(cell.Clone(false).Add(new Paragraph("To")));
            }
            else
            {
                table.AddCell(cell.Clone(false).Add(new Paragraph("Received At")));
                table.AddCell(cell.Clone(false).Add(new Paragraph("From")));
            }

            table.AddCell(cell.Clone(false).Add(new Paragraph("Result")));
            table.AddCell(cell.Clone(false).Add(new Paragraph("Call Direction")));
            table.AddCell(cell.Clone(false).Add(new Paragraph("Handle Time")));
            table.AddCell(cell.Clone(false).Add(new Paragraph("Queue")));

            table.AddCell(cell.Clone(false).Add(new Paragraph("Call ID")));
        }

    }
}
