namespace PhoneLogs.Forms
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenOutputFolderBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.OpenPDFBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ProcessBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectInputBtn = new System.Windows.Forms.Button();
            this.OutputFileNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.OutputFolderLabel = new System.Windows.Forms.Label();
            this.SelectOutputFolderBtn = new System.Windows.Forms.Button();
            this.InputFilePathLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FolderSameAsInput = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FileNameSameAsInput = new System.Windows.Forms.RadioButton();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(414, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // OpenOutputFolderBtn
            // 
            this.OpenOutputFolderBtn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenOutputFolderBtn.Location = new System.Drawing.Point(15, 420);
            this.OpenOutputFolderBtn.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.OpenOutputFolderBtn.Name = "OpenOutputFolderBtn";
            this.OpenOutputFolderBtn.Size = new System.Drawing.Size(125, 23);
            this.OpenOutputFolderBtn.TabIndex = 13;
            this.OpenOutputFolderBtn.Text = "Open Output Folder";
            this.OpenOutputFolderBtn.UseVisualStyleBackColor = true;
            this.OpenOutputFolderBtn.Click += new System.EventHandler(this.OpenOutputFolderBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Step 3";
            // 
            // OpenPDFBtn
            // 
            this.OpenPDFBtn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenPDFBtn.Location = new System.Drawing.Point(15, 391);
            this.OpenPDFBtn.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.OpenPDFBtn.Name = "OpenPDFBtn";
            this.OpenPDFBtn.Size = new System.Drawing.Size(125, 23);
            this.OpenPDFBtn.TabIndex = 11;
            this.OpenPDFBtn.Text = "Open PDF";
            this.OpenPDFBtn.UseVisualStyleBackColor = true;
            this.OpenPDFBtn.Click += new System.EventHandler(this.OpenPDFBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Step 2";
            // 
            // ProcessBtn
            // 
            this.ProcessBtn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessBtn.Location = new System.Drawing.Point(15, 301);
            this.ProcessBtn.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.ProcessBtn.Name = "ProcessBtn";
            this.ProcessBtn.Size = new System.Drawing.Size(125, 23);
            this.ProcessBtn.TabIndex = 9;
            this.ProcessBtn.Text = "Process File";
            this.ProcessBtn.UseVisualStyleBackColor = true;
            this.ProcessBtn.Click += new System.EventHandler(this.ProcessBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Step 1";
            // 
            // SelectInputBtn
            // 
            this.SelectInputBtn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectInputBtn.Location = new System.Drawing.Point(15, 67);
            this.SelectInputBtn.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.SelectInputBtn.Name = "SelectInputBtn";
            this.SelectInputBtn.Size = new System.Drawing.Size(125, 23);
            this.SelectInputBtn.TabIndex = 7;
            this.SelectInputBtn.Text = "Select Input File";
            this.SelectInputBtn.UseVisualStyleBackColor = true;
            this.SelectInputBtn.Click += new System.EventHandler(this.SelectInputBtn_Click);
            // 
            // OutputFileNameTextBox
            // 
            this.OutputFileNameTextBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputFileNameTextBox.Location = new System.Drawing.Point(21, 46);
            this.OutputFileNameTextBox.Name = "OutputFileNameTextBox";
            this.OutputFileNameTextBox.Size = new System.Drawing.Size(314, 20);
            this.OutputFileNameTextBox.TabIndex = 16;
            this.OutputFileNameTextBox.TextChanged += new System.EventHandler(this.OutputFileNameTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(341, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = ".pdf";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OutputFolderLabel
            // 
            this.OutputFolderLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputFolderLabel.Location = new System.Drawing.Point(19, 46);
            this.OutputFolderLabel.Name = "OutputFolderLabel";
            this.OutputFolderLabel.Size = new System.Drawing.Size(356, 18);
            this.OutputFolderLabel.TabIndex = 15;
            this.OutputFolderLabel.Text = "Output Folder";
            this.OutputFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SelectOutputFolderBtn
            // 
            this.SelectOutputFolderBtn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectOutputFolderBtn.Location = new System.Drawing.Point(250, 17);
            this.SelectOutputFolderBtn.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.SelectOutputFolderBtn.Name = "SelectOutputFolderBtn";
            this.SelectOutputFolderBtn.Size = new System.Drawing.Size(125, 23);
            this.SelectOutputFolderBtn.TabIndex = 12;
            this.SelectOutputFolderBtn.Text = "Select Different Folder";
            this.SelectOutputFolderBtn.UseVisualStyleBackColor = true;
            this.SelectOutputFolderBtn.Click += new System.EventHandler(this.SelectOutputFolderBtn_Click);
            // 
            // InputFilePathLabel
            // 
            this.InputFilePathLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputFilePathLabel.Location = new System.Drawing.Point(15, 96);
            this.InputFilePathLabel.Name = "InputFilePathLabel";
            this.InputFilePathLabel.Size = new System.Drawing.Size(387, 18);
            this.InputFilePathLabel.TabIndex = 17;
            this.InputFilePathLabel.Text = "Input File";
            this.InputFilePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FolderSameAsInput);
            this.groupBox1.Controls.Add(this.OutputFolderLabel);
            this.groupBox1.Controls.Add(this.SelectOutputFolderBtn);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 72);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output Folder";
            // 
            // FolderSameAsInput
            // 
            this.FolderSameAsInput.AutoSize = true;
            this.FolderSameAsInput.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FolderSameAsInput.Location = new System.Drawing.Point(21, 19);
            this.FolderSameAsInput.Name = "FolderSameAsInput";
            this.FolderSameAsInput.Size = new System.Drawing.Size(93, 18);
            this.FolderSameAsInput.TabIndex = 16;
            this.FolderSameAsInput.TabStop = true;
            this.FolderSameAsInput.Text = "Same as Input";
            this.FolderSameAsInput.UseVisualStyleBackColor = true;
            this.FolderSameAsInput.CheckedChanged += new System.EventHandler(this.FolderSameAsInput_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FileNameSameAsInput);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.OutputFileNameTextBox);
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(15, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 72);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output File Name";
            // 
            // FileNameSameAsInput
            // 
            this.FileNameSameAsInput.AutoSize = true;
            this.FileNameSameAsInput.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameSameAsInput.Location = new System.Drawing.Point(21, 19);
            this.FileNameSameAsInput.Name = "FileNameSameAsInput";
            this.FileNameSameAsInput.Size = new System.Drawing.Size(93, 18);
            this.FileNameSameAsInput.TabIndex = 16;
            this.FileNameSameAsInput.TabStop = true;
            this.FileNameSameAsInput.Text = "Same as Input";
            this.FileNameSameAsInput.UseVisualStyleBackColor = true;
            this.FileNameSameAsInput.CheckedChanged += new System.EventHandler(this.FileNameSameAsInput_CheckedChanged);
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressLabel.Location = new System.Drawing.Point(15, 328);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(387, 18);
            this.ProgressLabel.TabIndex = 24;
            this.ProgressLabel.Text = "Progress";
            this.ProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AcceptButton = this.ProcessBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 459);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.InputFilePathLabel);
            this.Controls.Add(this.OpenOutputFolderBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OpenPDFBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProcessBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectInputBtn);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Phone Logs";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button OpenOutputFolderBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OpenPDFBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ProcessBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectInputBtn;
        private System.Windows.Forms.TextBox OutputFileNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label OutputFolderLabel;
        private System.Windows.Forms.Button SelectOutputFolderBtn;
        private System.Windows.Forms.Label InputFilePathLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton FolderSameAsInput;
        private System.Windows.Forms.RadioButton FileNameSameAsInput;
        private System.Windows.Forms.Label ProgressLabel;
    }
}

