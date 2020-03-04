using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhoneLogs
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void CommonSettingsTab_Enter(object sender, EventArgs e)
        {
            var settings = Properties.CommonSettings.Default;

            //-- sheet selector
            SheetSelector.Value = settings.Sheet;

            //-- output folder
            var outputFolder = settings.OutputFolder;
            FolderSameAsInput.Checked = string.IsNullOrWhiteSpace(outputFolder);
            OutputFolderLabel.Text = outputFolder;

            //-- output filename
            var outputFileName = settings.OutputFileName;
            FileNameSameAsInput.Checked = string.IsNullOrWhiteSpace(outputFileName);
            OutputFileNameTextBox.Text = outputFileName;

            //-- employees filter
            var employees = new List<string>();
            if (settings.Employees != null)
            {
                foreach (var employee in settings.Employees)
                {
                    employees.Add(employee);
                }
                NoEmployeeFilterRadio.Checked = false;
                EmployeeFilterTextBox.Text = string.Join(",", employees);
            }
            else
            {
                NoEmployeeFilterRadio.Checked = true;
                EmployeeFilterTextBox.Text = "";
            }
        }

        private void ColumnSettingsTab_Enter(object sender, EventArgs e)
        {
            var settings = Properties.ColumnSettings.Default;

            SessionIDCol.Value = settings.SessionIDColumn;
            FromNameCol.Value = settings.FromNameColumn;
            FromNumberCol.Value = settings.FromNumberColumn;
            ToNameCol.Value = settings.ToNameColumn;
            ToNumberCol.Value = settings.ToNumberColumn;
            CallResultCol.Value = settings.CallResultColumn;
            CallLengthCol.Value = settings.CallLengthColumn;
            HandleTimeCol.Value = settings.HandleTimeColumn;
            StartTimeCol.Value = settings.StartTimeColumn;
            CallDirectionCol.Value = settings.CallDirectionColumn;
            CallQueueCol.Value = settings.CallQueueColumn;
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            var resetConfirmed = MessageBox.Show(
                "Are you sure you'd like to reset to default settings?",
                "Confirm",
                MessageBoxButtons.YesNo);

            if (resetConfirmed == DialogResult.Yes)
            {
                Properties.ColumnSettings.Default.Reset();
                this.Close();
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var settings = Properties.ColumnSettings.Default;

            settings.SessionIDColumn = (int)SessionIDCol.Value;
            settings.FromNameColumn = (int)FromNameCol.Value;
            settings.FromNumberColumn = (int)FromNumberCol.Value;
            settings.ToNameColumn = (int)ToNameCol.Value;
            settings.ToNumberColumn = (int)ToNumberCol.Value;
            settings.CallResultColumn = (int)CallResultCol.Value;
            settings.CallLengthColumn = (int)CallLengthCol.Value;
            settings.HandleTimeColumn = (int)HandleTimeCol.Value;
            settings.StartTimeColumn = (int)StartTimeCol.Value;
            settings.CallDirectionColumn = (int)CallDirectionCol.Value;
            settings.CallQueueColumn = (int)CallQueueCol.Value;

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FolderSameAsInput_CheckedChanged(object sender, EventArgs e)
        {
            if (FolderSameAsInput.Checked)
            {
                OutputFolderLabel.Text = "";
            }
        }

        private void FileNameSameAsInput_CheckedChanged(object sender, EventArgs e)
        {
            if (FileNameSameAsInput.Checked)
            {
                OutputFileNameTextBox.Text = "";
            }
        }

        private void NoEmployeeFilterRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (NoEmployeeFilterRadio.Checked)
            {
                EmployeeFilterTextBox.Text = "";
            }
        }

        private void OutputFileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (OutputFileNameTextBox.Text != string.Empty)
            {
                FileNameSameAsInput.Checked = false;
            }
        }

        private void EmployeeFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            if (EmployeeFilterTextBox.Text != string.Empty)
            {
                NoEmployeeFilterRadio.Checked = false;
            }
        }

        private void SelectOutputFolderBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                OutputFolderLabel.Text = folderBrowserDialog.SelectedPath;
                FolderSameAsInput.Checked = false;
            }
        }
    }
}
