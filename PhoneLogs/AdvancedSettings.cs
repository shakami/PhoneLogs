using System;
using System.Windows.Forms;

namespace PhoneLogs
{
    public partial class AdvancedSettings : Form
    {
        public AdvancedSettings()
        {
            InitializeComponent();
        }

        private void AdvancedSettings_Load(object sender, EventArgs e)
        {
            var settings = Properties.AdvancedSettings.Default;

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

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            var resetConfirmed = MessageBox.Show(
                "Are you sure you'd like to reset to default settings?",
                "Confirm",
                MessageBoxButtons.YesNo);

            if (resetConfirmed == DialogResult.Yes)
            {
                Properties.AdvancedSettings.Default.Reset();
                this.Close();
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var settings = Properties.AdvancedSettings.Default;

            settings.SessionIDColumn = (int)SessionIDCol.Value;
            settings.FromNameColumn = (int)FromNameCol.Value;
            settings.FromNumberColumn = (int)FromNumberCol.Value;
            settings.ToNameColumn = (int)ToNameCol.Value;
            settings.ToNumberColumn = (int) ToNumberCol.Value;
            settings.CallResultColumn = (int) CallResultCol.Value;
            settings.CallLengthColumn = (int) CallLengthCol.Value;
            settings.HandleTimeColumn = (int)HandleTimeCol.Value;
            settings.StartTimeColumn = (int) StartTimeCol.Value;
            settings.CallDirectionColumn = (int) CallDirectionCol.Value;
            settings.CallQueueColumn = (int) CallQueueCol.Value;

            this.Close();
        }
    }
}
