using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace PhoneLogs
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InputFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "Microsoft Excel Worksheet|*.xlsx";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                InputFilePathLabel.Text = OpenFileDialog.FileName;
                ResultLabel.Text = "";
            }

        }

        private void ProcessBtn_Click(object sender, EventArgs e)
        {
            var inputPath = InputFilePathLabel.Text;

            if (String.IsNullOrWhiteSpace(inputPath))
            {
                ResultLabel.Text = "Please Select A File First!";
                return;
            }

            int _session_Id_column = 1;
            int _from_name_column = 2;
            int _from_number_column = 3;
            int _to_name_column = 4;
            int _to_number_column = 5;
            int _result_column = 6;
            int _length_column = 7;
            int _handle_time_column = 8;
            int _start_time_column = 9;
            int _direction_column = 10;
            int _queue_column = 11;

            var excelApp = new ExcelToCSVService(InputFilePathLabel.Text, 2);

            var csvPath = inputPath + ".csv";

            excelApp.GetOutput(csvPath);

            var csvToCallService = new CSVToCallsService(_session_Id_column,
                                                         _from_name_column,
                                                         _from_number_column,
                                                         _to_name_column,
                                                         _to_number_column,
                                                         _result_column,
                                                         _length_column,
                                                         _handle_time_column,
                                                         _start_time_column,
                                                         _direction_column,
                                                         _queue_column);

            var calls = csvToCallService.ParseCSV(csvPath);

            var callProcessing = new CallProcessingService(calls);

            var parsedCalls = callProcessing.GetCallsPerPerson(new List<string>()
            {
                "Araceli Ornelas",
                "Benita Lucero",
                "Freddy Shamoon",
                "Janice Romo",
                "Jenny Herrera",
                "Kevin Herrera",
                "Phillip Yadidian",
                "Vanessa Vargas"
            });

            FileInfo file = new FileInfo("test.pdf");
            file.Directory.Create();

            PdfDocument pdfDoc = new PdfDocument(new PdfWriter("test.pdf"));
            Document doc = new Document(pdfDoc, PageSize.LETTER.Rotate());
            // doc.SetMargins(0, 0, 0, 0);

            Table table = new Table(new float[8]).UseAllAvailableWidth();
            table.SetMarginTop(0);
            table.SetMarginBottom(0);

            Cell callsReceivedHeader = new Cell(1, 8).Add(new Paragraph("Calls Received"));
            callsReceivedHeader.SetTextAlignment(TextAlignment.CENTER);
            callsReceivedHeader.SetBackgroundColor(new DeviceRgb(160, 160, 160));

            Cell callsMadeHeader = callsReceivedHeader.Clone(includeContent: false);
            callsMadeHeader.Add(new Paragraph("Calls Made"));

            foreach (var employee in parsedCalls)
            {
                var cell = new Cell(1, 8).Add(new Paragraph
                    (
                        employee.Key + " - " +
                        employee.Value.GetStats().TotalCalls + " Calls" + " - " +
                        "Duration: " + employee.Value.GetStats().Duration
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

            doc.Add(table);

            doc.Close();


            // StreamWriter sw = new StreamWriter("data.txt");

            //sw.WriteLine("CALLS RECEIVED:");

            //foreach (var idList in callsReceived)
            //{
            //    foreach (var id in idList)
            //    {
            //        sw.WriteLine(id);
            //    }
            //    sw.WriteLine("-------");
            //}

            //sw.WriteLine("CALLS MADE:");

            //foreach (var idList in callsMade)
            //{
            //    foreach (var id in idList)
            //    {
            //        sw.WriteLine(id);
            //    }
            //    sw.WriteLine("-------");
            //}

            //foreach (var call in calls)
            //{
            //    sw.WriteLine(call.ToString());
            //}

            //sw.Close();

            ResultLabel.Text = "Sucess!";
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
            } else
            {
                cell = new Cell().Add(new Paragraph().SetFontSize(10).Add(call.FromName));
                //table.AddCell(call.FromName);
                table.AddCell(cell);

                cell = new Cell().Add(new Paragraph().SetFontSize(8).Add(call.FromNumber));
                //table.AddCell(call.FromNumber);
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



            ////table.AddCell(call.ToName);
            //table.AddCell(call.ToNumber);
            //table.AddCell(call.CallResult);
            //table.AddCell(call.CallLength);
            //table.AddCell(call.HandleTime);
            //table.AddCell(call.StartTime);
            //table.AddCell(call.CallDirection);
            //table.AddCell(call.CallQueue);
        }

        private void AddHeaders(Table table, bool callsMade)
        {
            Cell cell;
            if (callsMade)
            {
                cell = new Cell(1, 2).Add(new Paragraph("To"));
                table.AddCell(cell);
            } else
            {
                cell = new Cell(1, 2).Add(new Paragraph("From"));
                table.AddCell(cell);
            }
            
            // table.AddCell("From Number");
            // table.AddCell("To Name");
            // table.AddCell("To Number");
            
            table.AddCell("Result");
            table.AddCell("Call Length");
            table.AddCell("Handle Time");
            table.AddCell("Call Start Time");
            table.AddCell("Call Direction");
            table.AddCell("Queue");
        }

        private void ModifyOutputFolderBtn_Click(object sender, EventArgs e)
        {
            if(FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                OutputFolderLabel.Text = FolderBrowserDialog.SelectedPath;
            }
        }
    }
}
