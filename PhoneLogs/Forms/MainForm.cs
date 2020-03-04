using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            ResultLabel.Text = "Working...";
            OpenPDFBtn.Enabled = false;
            OpenFolderBtn.Enabled = false;

            Utility.GenerateLog(InputFilePathLabel.Text);

            ResultLabel.Text = "Done!";
            OpenPDFBtn.Enabled = true;
            OpenFolderBtn.Enabled = true;
        }

        private void ModifyOutputFolderBtn_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                OutputSameAsInputRadio.Checked = false;
                OutputFolderLabel.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void OpenPDFBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(
                Utility.GetOutputPath(InputFilePathLabel.Text) + ".pdf");
        }

        private void OpenFolderBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(
                Utility.GetOutputFolder(InputFilePathLabel.Text));
        }

        private void SettingsTab_Enter(object sender, EventArgs e)
        {
            SheetNumberPicker.Value = Properties.Settings.Default.Sheet;

            var outputFolder = Properties.Settings.Default.OutputFoler;
            OutputSameAsInputRadio.Checked = string.IsNullOrWhiteSpace(outputFolder);
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

            Properties.Settings.Default.OutputFoler = OutputFolderLabel.Text;

            Properties.Settings.Default.Sheet = (int)SheetNumberPicker.Value;

            Properties.Settings.Default.Save();

            OpenPDFBtn.Enabled = false;
            OpenFolderBtn.Enabled = false;
            ResultLabel.Text = "";
        }

        private void OutpuSameAsInputRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (OutputSameAsInputRadio.Checked)
            {
                OutputFolderLabel.Text = "";
                OutputSameAsInputRadio.Checked = true;
            }

        }

        private void AdvancedSettingsBtn_Click(object sender, EventArgs e)
        {
            new AdvancedSettings().ShowDialog();
        }
    }
}
