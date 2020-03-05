using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;

namespace PhoneLogs.Forms
{
    public partial class SettingsForm : Form
    {
        private bool _dirty_settings;

        public SettingsForm()
        {
            InitializeComponent();
            _dirty_settings = false;
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
                if (settings.Employees.Count > 0)
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

            _dirty_settings = false;
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

            _dirty_settings = false;
        }

        private void ResetColumnBtn_Click(object sender, EventArgs e)
        {
            var resetConfirmed = MessageBox.Show(
                "Are you sure you'd like to reset to default settings?",
                "Confirm",
                MessageBoxButtons.YesNo);

            if (resetConfirmed == DialogResult.Yes)
            {
                var settings = Properties.ColumnSettings.Default;

                settings.Reset();
                settings.Save();
                ColumnSettingsTab_Enter(sender, e);
            }
        }

        private void SaveColumnBtn_Click(object sender, EventArgs e)
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

            settings.Save();
            _dirty_settings = false;
        }

        private void SaveCommonBtn_Click(object sender, EventArgs e)
        {
            var settings = Properties.CommonSettings.Default;

            //-- sheet selector
            settings.Sheet = (int)SheetSelector.Value;

            //-- output folder
            settings.OutputFolder = OutputFolderLabel.Text;

            //-- output filename
            settings.OutputFileName = OutputFileNameTextBox.Text;

            //-- employees filter
            if (!string.IsNullOrWhiteSpace(EmployeeFilterTextBox.Text))
            {
                var employees = EmployeeFilterTextBox.Text.Split(',');
                if (settings.Employees == null)
                {
                    settings.Employees = new StringCollection();
                }
                settings.Employees.Clear();
                foreach (var employee in employees)
                {
                    settings.Employees.Add(employee.Trim());
                }
            }
            else
            {
                settings.Employees = new StringCollection();
            }

            //-- save
            settings.Save();
            _dirty_settings = false;
        }

        private void ResetCommonBtn_Click(object sender, EventArgs e)
        {
            var resetConfirmed = MessageBox.Show(
                "Are you sure you'd like to reset to default settings?",
                "Confirm",
                MessageBoxButtons.YesNo);

            if (resetConfirmed == DialogResult.Yes)
            {
                var settings = Properties.CommonSettings.Default;

                settings.Reset();
                settings.Save();
                CommonSettingsTab_Enter(sender, e);
            }
        }

        private void FolderSameAsInput_CheckedChanged(object sender, EventArgs e)
        {
            _dirty_settings = true;
            if (FolderSameAsInput.Checked)
            {
                OutputFolderLabel.Text = "";
            }
        }

        private void FileNameSameAsInput_CheckedChanged(object sender, EventArgs e)
        {
            _dirty_settings = true;
            if (FileNameSameAsInput.Checked)
            {
                OutputFileNameTextBox.Text = "";
            }
        }

        private void NoEmployeeFilterRadio_CheckedChanged(object sender, EventArgs e)
        {
            _dirty_settings = true;
            if (NoEmployeeFilterRadio.Checked)
            {
                EmployeeFilterTextBox.Text = "";
            }
        }

        private void OutputFileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            _dirty_settings = true;
            if (OutputFileNameTextBox.Text != string.Empty)
            {
                FileNameSameAsInput.Checked = false;
            }
        }

        private void EmployeeFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            _dirty_settings = true;
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
                _dirty_settings = true;
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            if (!_dirty_settings)
            {
                this.Close();
                return;
            }

            if (ShowAbortDialog())
            {
                this.Close();
                return;
            }
        }

        private void TabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_dirty_settings)
            {
                if (ShowAbortDialog())
                {
                    return;
                }

                e.Cancel = true;
            }
        }

        private void SheetSelector_ValueChanged(object sender, EventArgs e)
        {
            _dirty_settings = true;
        }

        private void NumberSelector_ValueChanged(object sender, EventArgs e)
        {
            _dirty_settings = true;
        }

        private bool ShowAbortDialog()
        {
            var abortConfirmed = MessageBox.Show(
                "Are you sure you'd like to abort modified values?",
                "Confirm",
                MessageBoxButtons.YesNo);

            return abortConfirmed == DialogResult.Yes;
        }

    }
}
