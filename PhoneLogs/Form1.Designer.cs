namespace PhoneLogs
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InputFileBtn = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ProcessBtn = new System.Windows.Forms.Button();
            this.InputFilePathLabel = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.OpenFolderBtn = new System.Windows.Forms.Button();
            this.OpenPDFBtn = new System.Windows.Forms.Button();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.OutputSameAsInputLabel = new System.Windows.Forms.Label();
            this.OutputPathResetBtn = new System.Windows.Forms.Button();
            this.OutputFolderLabel = new System.Windows.Forms.Label();
            this.EmployeesFilterBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ModifyOutputFolderBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveSettingsBtn = new System.Windows.Forms.Button();
            this.SheetNumberPicker = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.AdvancedSettingsBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SheetNumberPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // InputFileBtn
            // 
            this.InputFileBtn.Location = new System.Drawing.Point(6, 6);
            this.InputFileBtn.Name = "InputFileBtn";
            this.InputFileBtn.Size = new System.Drawing.Size(100, 23);
            this.InputFileBtn.TabIndex = 0;
            this.InputFileBtn.Text = "Select Input File";
            this.InputFileBtn.UseVisualStyleBackColor = true;
            this.InputFileBtn.Click += new System.EventHandler(this.InputFileBtn_Click);
            // 
            // ProcessBtn
            // 
            this.ProcessBtn.Enabled = false;
            this.ProcessBtn.Location = new System.Drawing.Point(6, 104);
            this.ProcessBtn.Name = "ProcessBtn";
            this.ProcessBtn.Size = new System.Drawing.Size(100, 23);
            this.ProcessBtn.TabIndex = 2;
            this.ProcessBtn.Text = "Process";
            this.ProcessBtn.UseVisualStyleBackColor = true;
            this.ProcessBtn.Click += new System.EventHandler(this.ProcessBtn_Click);
            // 
            // InputFilePathLabel
            // 
            this.InputFilePathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputFilePathLabel.Location = new System.Drawing.Point(6, 32);
            this.InputFilePathLabel.Name = "InputFilePathLabel";
            this.InputFilePathLabel.Size = new System.Drawing.Size(394, 23);
            this.InputFilePathLabel.TabIndex = 4;
            this.InputFilePathLabel.Text = "Select a Valid Microsoft Excel Workshet Please.";
            // 
            // ResultLabel
            // 
            this.ResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultLabel.Location = new System.Drawing.Point(3, 130);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(394, 23);
            this.ResultLabel.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.SettingsTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(434, 261);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.OpenFolderBtn);
            this.tabPage1.Controls.Add(this.OpenPDFBtn);
            this.tabPage1.Controls.Add(this.InputFileBtn);
            this.tabPage1.Controls.Add(this.InputFilePathLabel);
            this.tabPage1.Controls.Add(this.ResultLabel);
            this.tabPage1.Controls.Add(this.ProcessBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(426, 235);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // OpenFolderBtn
            // 
            this.OpenFolderBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OpenFolderBtn.Enabled = false;
            this.OpenFolderBtn.Location = new System.Drawing.Point(3, 186);
            this.OpenFolderBtn.Name = "OpenFolderBtn";
            this.OpenFolderBtn.Size = new System.Drawing.Size(420, 23);
            this.OpenFolderBtn.TabIndex = 7;
            this.OpenFolderBtn.Text = "Open Output Folder";
            this.OpenFolderBtn.UseVisualStyleBackColor = true;
            this.OpenFolderBtn.Click += new System.EventHandler(this.OpenFolderBtn_Click);
            // 
            // OpenPDFBtn
            // 
            this.OpenPDFBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OpenPDFBtn.Enabled = false;
            this.OpenPDFBtn.Location = new System.Drawing.Point(3, 209);
            this.OpenPDFBtn.Name = "OpenPDFBtn";
            this.OpenPDFBtn.Size = new System.Drawing.Size(420, 23);
            this.OpenPDFBtn.TabIndex = 6;
            this.OpenPDFBtn.Text = "Open PDF";
            this.OpenPDFBtn.UseVisualStyleBackColor = true;
            this.OpenPDFBtn.Click += new System.EventHandler(this.OpenPDFBtn_Click);
            // 
            // SettingsTab
            // 
            this.SettingsTab.Controls.Add(this.AdvancedSettingsBtn);
            this.SettingsTab.Controls.Add(this.OutputSameAsInputLabel);
            this.SettingsTab.Controls.Add(this.OutputPathResetBtn);
            this.SettingsTab.Controls.Add(this.OutputFolderLabel);
            this.SettingsTab.Controls.Add(this.EmployeesFilterBox);
            this.SettingsTab.Controls.Add(this.label3);
            this.SettingsTab.Controls.Add(this.ModifyOutputFolderBtn);
            this.SettingsTab.Controls.Add(this.label2);
            this.SettingsTab.Controls.Add(this.SaveSettingsBtn);
            this.SettingsTab.Controls.Add(this.SheetNumberPicker);
            this.SettingsTab.Controls.Add(this.label1);
            this.SettingsTab.Location = new System.Drawing.Point(4, 22);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTab.Size = new System.Drawing.Size(426, 235);
            this.SettingsTab.TabIndex = 1;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.UseVisualStyleBackColor = true;
            this.SettingsTab.Enter += new System.EventHandler(this.SettingsTab_Enter);
            // 
            // OutputSameAsInputLabel
            // 
            this.OutputSameAsInputLabel.AutoSize = true;
            this.OutputSameAsInputLabel.Location = new System.Drawing.Point(86, 35);
            this.OutputSameAsInputLabel.Name = "OutputSameAsInputLabel";
            this.OutputSameAsInputLabel.Size = new System.Drawing.Size(107, 13);
            this.OutputSameAsInputLabel.TabIndex = 10;
            this.OutputSameAsInputLabel.Text = "Same as Input Folder";
            this.OutputSameAsInputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OutputSameAsInputLabel.Visible = false;
            // 
            // OutputPathResetBtn
            // 
            this.OutputPathResetBtn.Location = new System.Drawing.Point(348, 48);
            this.OutputPathResetBtn.Name = "OutputPathResetBtn";
            this.OutputPathResetBtn.Size = new System.Drawing.Size(75, 23);
            this.OutputPathResetBtn.TabIndex = 9;
            this.OutputPathResetBtn.Text = "Reset";
            this.OutputPathResetBtn.UseVisualStyleBackColor = true;
            this.OutputPathResetBtn.Click += new System.EventHandler(this.OutputPathResetBtn_Click);
            // 
            // OutputFolderLabel
            // 
            this.OutputFolderLabel.Location = new System.Drawing.Point(27, 48);
            this.OutputFolderLabel.Name = "OutputFolderLabel";
            this.OutputFolderLabel.Size = new System.Drawing.Size(234, 23);
            this.OutputFolderLabel.TabIndex = 8;
            this.OutputFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EmployeesFilterBox
            // 
            this.EmployeesFilterBox.Location = new System.Drawing.Point(30, 99);
            this.EmployeesFilterBox.Multiline = true;
            this.EmployeesFilterBox.Name = "EmployeesFilterBox";
            this.EmployeesFilterBox.Size = new System.Drawing.Size(390, 99);
            this.EmployeesFilterBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(382, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Active Employees - Type a comma separated list of employees to filter your logs.";
            // 
            // ModifyOutputFolderBtn
            // 
            this.ModifyOutputFolderBtn.Location = new System.Drawing.Point(267, 48);
            this.ModifyOutputFolderBtn.Name = "ModifyOutputFolderBtn";
            this.ModifyOutputFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.ModifyOutputFolderBtn.TabIndex = 5;
            this.ModifyOutputFolderBtn.Text = "Modify";
            this.ModifyOutputFolderBtn.UseVisualStyleBackColor = true;
            this.ModifyOutputFolderBtn.Click += new System.EventHandler(this.ModifyOutputFolderBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output Folder:";
            // 
            // SaveSettingsBtn
            // 
            this.SaveSettingsBtn.Location = new System.Drawing.Point(345, 204);
            this.SaveSettingsBtn.Name = "SaveSettingsBtn";
            this.SaveSettingsBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveSettingsBtn.TabIndex = 2;
            this.SaveSettingsBtn.Text = "Save";
            this.SaveSettingsBtn.UseVisualStyleBackColor = true;
            this.SaveSettingsBtn.Click += new System.EventHandler(this.SaveSettingsBtn_Click);
            // 
            // SheetNumberPicker
            // 
            this.SheetNumberPicker.Location = new System.Drawing.Point(89, 6);
            this.SheetNumberPicker.Name = "SheetNumberPicker";
            this.SheetNumberPicker.Size = new System.Drawing.Size(40, 20);
            this.SheetNumberPicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sheet Number:";
            // 
            // AdvancedSettingsBtn
            // 
            this.AdvancedSettingsBtn.Location = new System.Drawing.Point(6, 204);
            this.AdvancedSettingsBtn.Name = "AdvancedSettingsBtn";
            this.AdvancedSettingsBtn.Size = new System.Drawing.Size(75, 23);
            this.AdvancedSettingsBtn.TabIndex = 11;
            this.AdvancedSettingsBtn.Text = "Advanced";
            this.AdvancedSettingsBtn.UseVisualStyleBackColor = true;
            this.AdvancedSettingsBtn.Click += new System.EventHandler(this.AdvancedSettingsBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Phone Logs";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SheetNumberPicker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InputFileBtn;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Button ProcessBtn;
        private System.Windows.Forms.Label InputFilePathLabel;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage SettingsTab;
        private System.Windows.Forms.Button SaveSettingsBtn;
        private System.Windows.Forms.NumericUpDown SheetNumberPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ModifyOutputFolderBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EmployeesFilterBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.Label OutputFolderLabel;
        private System.Windows.Forms.Button OpenPDFBtn;
        private System.Windows.Forms.Button OpenFolderBtn;
        private System.Windows.Forms.Button OutputPathResetBtn;
        private System.Windows.Forms.Label OutputSameAsInputLabel;
        private System.Windows.Forms.Button AdvancedSettingsBtn;
    }
}

