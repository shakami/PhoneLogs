using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhoneLogs
{
    public class PDFService
    {
        private readonly Document _doc;
        private const int NUM_COLUMNS = 8;
        private const float DIV_MARGIN = 25;
        private readonly DeviceRgb HEADING_COLOR = new DeviceRgb(68, 111, 111);
        private readonly DeviceRgb GREY_BACKGROUND = new DeviceRgb(160, 160, 160);
        private readonly DeviceRgb BLUE_BACKGROUND = new DeviceRgb(145, 186, 186);
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

        public void GenerateOutput(Dictionary<string, CallLog> data)
        {

            Cell header = new Cell(1, NUM_COLUMNS)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetBackgroundColor(GREY_BACKGROUND);

            Cell callsReceivedHeader = header.Clone(false)
                .Add(new Paragraph("Calls Received"));

            Cell callsMadeHeader = header.Clone(false)
                .Add(new Paragraph("Calls Made"));

            foreach (var employee in data)
            {
                Div div = new Div()
                    .SetKeepTogether(true)
                    .SetMarginTop(DIV_MARGIN)
                    .SetFont(REGULAR_FONT);

                var titleText = employee.Key + " - " +
                                employee.Value.Stats.TotalCalls + " Call(s)" + " - " +
                                "Duration: " + employee.Value.Stats.Duration;

                Paragraph title = new Paragraph(titleText)
                    .SetFont(BOLD_FONT)
                    .SetFontSize(LARGE_FONT_SIZE)
                    .SetFontColor(HEADING_COLOR);

                div.Add(title);

                Table table = new Table(new float[NUM_COLUMNS]).UseAllAvailableWidth();
                if (employee.Value.CallsTo.Any())
                {
                    table.AddCell(callsReceivedHeader.Clone(includeContent: true));
                    AddHeaders(table, callsMade: false);
                    for (int i = 0; i < employee.Value.CallsTo.Count; i++)
                    {
                        AddCall(table, employee.Value.CallsTo[i], callsMade: false, striped: (i % 2 == 1));
                    }
                }

                if (employee.Value.CallsFrom.Any())
                {
                    table.AddCell(callsMadeHeader.Clone(includeContent: true));
                    AddHeaders(table, callsMade: true);

                    for (int i = 0; i < employee.Value.CallsFrom.Count; i++)
                    {
                        AddCall(table, employee.Value.CallsFrom[i], callsMade: true, striped: (i % 2 == 1));
                    }
                }

                div.Add(table);
                _doc.Add(div);
            }
            _doc.Close();
        }

        private Cell GetCell(string text, bool striped)
        {
            return new Cell()
                .SetBackgroundColor(striped ? TABLE_STRIPE : ColorConstants.WHITE)
                .SetFontSize(REGULAR_FONT_SIZE)
                .Add(new Paragraph(text));
        }

        private void AddCall(Table table, Call call, bool callsMade, bool striped)
        {


            table.AddCell(GetCell(call.StartTime.ToString(), striped));

            table.AddCell(GetCell(call.CallLength, striped));

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
        }

    }
}
