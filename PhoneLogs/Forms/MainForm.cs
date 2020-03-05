using PhoneLogs.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PhoneLogs.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
        }

        private void ProcessCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.ToString() == "success")
            {
                ProgressLabel.Text = "Done!";
                OpenPDFBtn.Enabled = true;
                OpenOutputFolderBtn.Enabled = true;
                return;
            }

            MessageBox.Show($"Something bad happened. {e.Result}", "Error", MessageBoxButtons.OK);
            InitializeControls();
        }

        private void UpdateProgress(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void InitializeControls()
        {
            progressBar.Value = 0;

            ProgressLabel.Text = "";

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

            var inputPath = InputFilePathLabel.Text;
            var outputPath = GetOutputPath(fullPath: true);

            backgroundWorker.RunWorkerAsync(new string[] { inputPath, outputPath });
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

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var bw = sender as BackgroundWorker;
            var args = e.Argument as string[];
            var inputPath = args[0];
            var outputPath = args[1];

            try
            {
                ExcelToPDFService.GenerateLog(bw, inputPath, outputPath);
            }
            catch (ApplicationException ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                {
                    message += "\n\nDetails: " + ex.InnerException.Message;
                }
                e.Result = message;
                return;
            }
            e.Result = "success";
        }
    }
}
