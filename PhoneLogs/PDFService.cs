using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
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

        public PDFService(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            file.Directory.Create();

            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(filePath));
            _doc = new Document(pdfDoc, PageSize.LETTER.Rotate());
        }

        public void GenerateOutput(Dictionary<String, CallLog> data)
        {
            Table table = new Table(new float[8]).UseAllAvailableWidth();
            table.SetMarginTop(0);
            table.SetMarginBottom(0);

            Cell callsReceivedHeader = new Cell(1, 8).Add(new Paragraph("Calls Received"));
            callsReceivedHeader.SetTextAlignment(TextAlignment.CENTER);
            callsReceivedHeader.SetBackgroundColor(new DeviceRgb(160, 160, 160));

            Cell callsMadeHeader = callsReceivedHeader.Clone(includeContent: false);
            callsMadeHeader.Add(new Paragraph("Calls Made"));

            foreach (var employee in data)
            {
                var cell = new Cell(1, 8).Add(new Paragraph
                    (
                        employee.Key + " - " +
                        employee.Value.Stats.TotalCalls + " Call(s)" + " - " +
                        "Duration: " + employee.Value.Stats.Duration
                    ));
                cell.SetTextAlignment(TextAlignment.CENTER);
                cell.SetPadding(5);
                cell.SetBackgroundColor(new DeviceRgb(140, 221, 8));
                table.AddCell(cell);

                if (employee.Value.CallsTo.Any())
                {
                    table.AddCell(callsReceivedHeader.Clone(includeContent: true));
                    AddHeaders(table, callsMade: false);
                    foreach (var call in employee.Value.CallsTo)
                    {
                        AddCall(table, call, callsMade: false);
                    }
                }

                if (employee.Value.CallsFrom.Any())
                {
                    table.AddCell(callsMadeHeader.Clone(includeContent: true));
                    AddHeaders(table, callsMade: true);
                    foreach (var call in employee.Value.CallsFrom)
                    {
                        AddCall(table, call, callsMade: true);
                    }
                }
            }

            _doc.Add(table);

            _doc.Close();
        }

        private void AddCall(Table table, Call call, bool callsMade)
        {
            Cell cell;
            if (callsMade)
            {
                cell = new Cell().Add(new Paragraph().SetFontSize(10).Add(call.ToName));
                table.AddCell(cell);

                cell = new Cell().Add(new Paragraph().SetFontSize(8).Add(call.ToNumber));
                table.AddCell(cell);
            }
            else
            {
                cell = new Cell().Add(new Paragraph().SetFontSize(10).Add(call.FromName));
                table.AddCell(cell);

                cell = new Cell().Add(new Paragraph().SetFontSize(8).Add(call.FromNumber));
                table.AddCell(cell);
            }

            cell = new Cell().Add(new Paragraph().SetFontSize(10).Add(call.CallResult));
            table.AddCell(cell);

            cell = new Cell().Add(new Paragraph().SetFontSize(8).Add(call.CallLength));
            table.AddCell(cell);

            cell = new Cell().Add(new Paragraph().SetFontSize(8).Add(call.HandleTime));
            table.AddCell(cell);

            cell = new Cell().Add(new Paragraph().SetFontSize(8).Add(call.StartTime));
            table.AddCell(cell);

            cell = new Cell().Add(new Paragraph().SetFontSize(10).Add(call.CallDirection));
            table.AddCell(cell);

            cell = new Cell().Add(new Paragraph().SetFontSize(10).Add(call.CallQueue));
            table.AddCell(cell);

        }

        private void AddHeaders(Table table, bool callsMade)
        {
            Cell cell;
            if (callsMade)
            {
                cell = new Cell(1, 2).Add(new Paragraph("To"));
                table.AddCell(cell);
            }
            else
            {
                cell = new Cell(1, 2).Add(new Paragraph("From"));
                table.AddCell(cell);
            }
            table.AddCell("Result");
            table.AddCell("Call Length");
            table.AddCell("Handle Time");
            table.AddCell("Call Start Time");
            table.AddCell("Call Direction");
            table.AddCell("Queue");
        }

    }
}
