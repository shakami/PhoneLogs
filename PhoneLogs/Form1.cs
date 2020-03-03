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
                ProcessBtn.Enabled = true;
            }

        }

        private void ProcessBtn_Click(object sender, EventArgs e)
        {
            ResultLabel.Text = "working...";
            OpenPDFBtn.Enabled = false;
            OpenFolderBtn.Enabled = false;

            var inputPath = InputFilePathLabel.Text;
            var outputFolder = Properties.Settings.Default.OutputFoler;
            string outputPath;

            if (String.IsNullOrWhiteSpace(outputFolder))
            {
                outputPath = GetFilePathNoExtension(inputPath);
            } else
            {
                outputPath = outputFolder + "\\" + GetFileNameNoExtension(inputPath);
            }
            
            var pdfPath = outputPath + ".pdf";
            var csvPath = outputPath + ".csv";

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

            var sheetToProcess = Properties.Settings.Default.Sheet;

            var excelApp = new ExcelToCSVService(InputFilePathLabel.Text, sheetToProcess);

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

            //var parsedCalls = callProcessing.GetCallsPerPerson(new List<string>()
            //{
            //    "Araceli Ornelas",
            //    "Benita Lucero",
            //    "Freddy Shamoon",
            //    "Janice Romo",
            //    "Jenny Herrera",
            //    "Kevin Herrera",
            //    "Phillip Yadidian",
            //    "Vanessa Vargas"
            //});

            var employees = Properties.Settings.Default.Employees.Cast<String>().ToList();
            var parsedCalls = callProcessing.GetCallsPerPerson(employees);

            FileInfo file = new FileInfo(pdfPath);
            file.Directory.Create();

            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(pdfPath));
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
            OpenPDFBtn.Enabled = true;
            OpenFolderBtn.Enabled = true;
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
            }
            else
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
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                OutputSameAsInputLabel.Visible = false;
                OutputFolderLabel.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void OpenPDFBtn_Click(object sender, EventArgs e)
        {
            var inputPath = InputFilePathLabel.Text;
            var outputFolder = Properties.Settings.Default.OutputFoler;
            string pdfPath;
            if (string.IsNullOrWhiteSpace(outputFolder))
            {
                pdfPath = GetFilePathNoExtension(inputPath) + ".pdf";
            } else
            {
                pdfPath = outputFolder + "\\" + GetFileNameNoExtension(inputPath) + ".pdf";
            }

            System.Diagnostics.Process.Start(pdfPath);
        }

        private string GetFilePathNoExtension(string fullPath)
        {
            return fullPath.Substring(0, fullPath.LastIndexOf('.'));
        }

        private string GetFileNameNoExtension(string fullPath)
        {
            int slashIndex = fullPath.LastIndexOf('\\');
            string fileName = fullPath.Substring(slashIndex + 1, fullPath.Length - slashIndex - 1);
            var result = fileName.Substring(0, fileName.LastIndexOf('.'));
            return result;
        }

        private void OpenFolderBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ResultLabel.Text = Properties.Settings.Default.Sheet.ToString();
        }

        private void SettingsTab_Enter(object sender, EventArgs e)
        {
            SheetNumberPicker.Value = Properties.Settings.Default.Sheet;

            var outputFolder = Properties.Settings.Default.OutputFoler;
            if (string.IsNullOrWhiteSpace(outputFolder))
            {
                OutputSameAsInputLabel.Visible = true;
            }
            OutputFolderLabel.Text = outputFolder;

            var employees = new List<string>();
            if (Properties.Settings.Default.Employees != null)
            {
                foreach (var employee in Properties.Settings.Default.Employees)
                {
                    employees.Add(employee);
                }
                EmployeesFilterBox.Text = string.Join(",", employees);
            }
            else
            {
                EmployeesFilterBox.Text = "";
            }
        }

        private void SaveSettingsBtn_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrWhiteSpace(EmployeesFilterBox.Text))
            {
                var employees = EmployeesFilterBox.Text.Split(',');
                if (Properties.Settings.Default.Employees == null)
                {
                    Properties.Settings.Default.Employees = new System.Collections.Specialized.StringCollection();
                }
                Properties.Settings.Default.Employees.Clear();
                foreach (var employee in employees)
                {
                    Properties.Settings.Default.Employees.Add(employee.Trim());
                }
            }
            else
            {
                Properties.Settings.Default.Employees = new System.Collections.Specialized.StringCollection();
            }

            Properties.Settings.Default.OutputFoler = OutputFolderLabel.Text;

            Properties.Settings.Default.Save();
        }

        private void OutputPathResetBtn_Click(object sender, EventArgs e)
        {
            OutputFolderLabel.Text = "";
            OutputSameAsInputLabel.Visible = true;
        }
    }
}
