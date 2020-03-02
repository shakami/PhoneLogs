using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.OpenFileDialog.Filter = "XLSX|*.xlsx";
            if (this.OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.InputFilePathTextBox.Text = this.OpenFileDialog.FileName;
            }

        }
    }
}
