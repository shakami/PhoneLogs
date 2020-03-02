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
            this.InputFilePathTextBox = new System.Windows.Forms.TextBox();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // InputFileBtn
            // 
            this.InputFileBtn.Location = new System.Drawing.Point(12, 12);
            this.InputFileBtn.Name = "InputFileBtn";
            this.InputFileBtn.Size = new System.Drawing.Size(102, 23);
            this.InputFileBtn.TabIndex = 0;
            this.InputFileBtn.Text = "Select Input File";
            this.InputFileBtn.UseVisualStyleBackColor = true;
            this.InputFileBtn.Click += new System.EventHandler(this.InputFileBtn_Click);
            // 
            // InputFilePathTextBox
            // 
            this.InputFilePathTextBox.Location = new System.Drawing.Point(12, 41);
            this.InputFilePathTextBox.Name = "InputFilePathTextBox";
            this.InputFilePathTextBox.ReadOnly = true;
            this.InputFilePathTextBox.Size = new System.Drawing.Size(403, 20);
            this.InputFilePathTextBox.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 304);
            this.Controls.Add(this.InputFilePathTextBox);
            this.Controls.Add(this.InputFileBtn);
            this.Name = "MainForm";
            this.Text = "Phone Logs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InputFileBtn;
        private System.Windows.Forms.TextBox InputFilePathTextBox;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
    }
}

