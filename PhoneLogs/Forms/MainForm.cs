using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        private void InitializeControls()
        {
            var settings = Properties.CommonSettings.Default;

            //-- output folder
            var outputFolder = settings.OutputFolder;
            FolderSameAsInput.Checked = string.IsNullOrWhiteSpace(outputFolder);
            OutputFolderLabel.Text = outputFolder;

            //-- output filename
            var outputFileName = settings.OutputFileName;
            FileNameSameAsInput.Checked = string.IsNullOrWhiteSpace(outputFileName);
            OutputFileNameTextBox.Text = outputFileName;

            //-- set up display
            InputFilePathLabel.Text = "Please select a valid Excel worksheet.";
            ProgressLabel.Text = "";
            ProcessBtn.Enabled = false;
            OpenPDFBtn.Enabled = false;
            OpenOutputFolderBtn.Enabled = false;
        }

        private void Step1Controls()
        {
            ProgressLabel.Text = "";
            ProcessBtn.Enabled = true;
            OpenPDFBtn.Enabled = false;
            OpenOutputFolderBtn.Enabled = false;
        }

        private void SelectInputBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Microsoft Excel Worksheet|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                InputFilePathLabel.Text = openFileDialog.FileName;

                Step1Controls();
            }
        }

        private string GetOutputPath(bool fullPath)
        {
            var inputPath = InputFilePathLabel.Text;
            var slashIndex = inputPath.LastIndexOf('\\');
            var extensionIndex = inputPath.LastIndexOf('.');

            var settings = Properties.CommonSettings.Default;

            var outputFolder = settings.OutputFolder;
            if (string.IsNullOrWhiteSpace(outputFolder))
            {
                outputFolder = inputPath.Substring(0, slashIndex);
            }

            if (!fullPath)
            {
                return outputFolder;
            }

            var outputFileName = settings.OutputFileName;
            if (string.IsNullOrWhiteSpace(outputFileName))
            {
                outputFileName = inputPath.Substring(slashIndex + 1, extensionIndex - slashIndex - 1);
            }

            return outputFolder + '\\' + outputFileName;
        }

        private void SaveOutputSettings()
        {
            var settings = Properties.CommonSettings.Default;

            //-- output folder
            settings.OutputFolder = OutputFolderLabel.Text;

            //-- output file name
            settings.OutputFileName = OutputFileNameTextBox.Text;

            settings.Save();
        }


        private void ProcessBtn_Click(object sender, EventArgs e)
        {
            ProgressLabel.Text = "Working...";

            SaveOutputSettings();
            
            OpenPDFBtn.Enabled = false;
            OpenOutputFolderBtn.Enabled = false;

            var inputPath = InputFilePathLabel.Text;
            var outputPath = GetOutputPath(fullPath: true);

            ExcelToPDFService.GenerateLog(inputPath, outputPath);

            OpenPDFBtn.Enabled = true;
            OpenOutputFolderBtn.Enabled = true;

            ProgressLabel.Text = "Done!";
        }

        private void SelectOutputFolderBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                FolderSameAsInput.Checked = false;
                OutputFolderLabel.Text = folderBrowserDialog.SelectedPath;
                Step1Controls();
            }
        }

        private void OpenPDFBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(
                GetOutputPath(fullPath: true) + ".pdf");
        }

        private void OpenOutputFolderBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(
                GetOutputPath(fullPath: false));
        }

        /*
        
    private void SaveSettingsBtn_Click(object sender, EventArgs e)
    {

        if (!string.IsNullOrWhiteSpace(EmployeesFilterBox.Text))
        {
            var employees = EmployeesFilterBox.Text.Split(',');
            if (Properties.Settings.Default.Employees == null)
            {
                Properties.Settings.Default.Employees = new StringCollection();
            }
            Properties.Settings.Default.Employees.Clear();
            foreach (var employee in employees)
            {
                Properties.Settings.Default.Employees.Add(employee.Trim());
            }
        }
        else
        {
            Properties.Settings.Default.Employees = new StringCollection();
        }


        Properties.Settings.Default.Save();

        OpenPDFBtn.Enabled = false;
        OpenFolderBtn.Enabled = false;
        ResultLabel.Text = "";
    }
    */
        private void FolderSameAsInput_CheckedChanged(object sender, EventArgs e)
        {
            if (FolderSameAsInput.Checked)
            {
                OutputFolderLabel.Text = "";
                Step1Controls();
            }

        }

        private void FileNameSameAsInput_CheckedChanged(object sender, EventArgs e)
        {
            if (FileNameSameAsInput.Checked)
            {
                OutputFileNameTextBox.Text = "";
                Step1Controls();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeControls();
        }

        private void OutputFileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (OutputFileNameTextBox.Text != string.Empty)
            {
                FileNameSameAsInput.Checked = false;
                Step1Controls();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
            InitializeControls();
        }


        /*
        private void AdvancedSettingsBtn_Click(object sender, EventArgs e)
        {
            new AdvancedSettings().ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }*/
    }
}
