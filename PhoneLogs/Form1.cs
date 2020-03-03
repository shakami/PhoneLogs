using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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

            string outputPath = GetOutputPath();

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

            var employees = Properties.Settings.Default.Employees.Cast<String>().ToList();
            var processedCalls = callProcessing.GetCallsPerPerson(employees);

            var pdfService = new PDFService(pdfPath);
            pdfService.GenerateOutput(processedCalls);

            ResultLabel.Text = "Sucess!";
            OpenPDFBtn.Enabled = true;
            OpenFolderBtn.Enabled = true;
        }

        private string GetOutputPath()
        {
            var inputPath = InputFilePathLabel.Text;
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
            System.Diagnostics.Process.Start(GetOutputPath() + ".pdf");
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

        private string GetOutputFolder()
        {
            var outputFolder = Properties.Settings.Default.OutputFoler;

            if (string.IsNullOrWhiteSpace(outputFolder))
            {
                var inputPath = InputFilePathLabel.Text;
                var slashIndex = inputPath.LastIndexOf('\\');
                outputFolder = inputPath.Substring(0, slashIndex);
            }

            return outputFolder;
        }

        private void OpenFolderBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(GetOutputFolder());
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

            if (!string.IsNullOrWhiteSpace(EmployeesFilterBox.Text))
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

            OpenPDFBtn.Enabled = false;
            OpenFolderBtn.Enabled = false;
        }

        private void OutputPathResetBtn_Click(object sender, EventArgs e)
        {
            OutputFolderLabel.Text = "";
            OutputSameAsInputLabel.Visible = true;
        }
    }
}
