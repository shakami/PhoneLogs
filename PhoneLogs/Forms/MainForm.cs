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

            GenerateLog();

            ResultLabel.Text = "Sucess!";
            OpenPDFBtn.Enabled = true;
            OpenFolderBtn.Enabled = true;
        }

        private void GenerateLog()
        {
            string inputPath = InputFilePathLabel.Text;
            string outputPath = GetOutputPath();

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

            var employees = Properties.Settings.Default.Employees.Cast<String>().ToList();
            var processedCalls = callProcessing.GetCallsPerPerson(employees);

            var pdfService = new PDFService(pdfPath);
            pdfService.GenerateOutput(processedCalls);
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

        private void AdvancedSettingsBtn_Click(object sender, EventArgs e)
        {
            AdvancedSettings advancedSettings = new AdvancedSettings();
            advancedSettings.ShowDialog();
        }
    }
}
