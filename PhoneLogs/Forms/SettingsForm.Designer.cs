
namespace PhoneLogs
{
    partial class SettingsForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.CallResultCol = new System.Windows.Forms.NumericUpDown();
            this.ToNumberCol = new System.Windows.Forms.NumericUpDown();
            this.ToNameCol = new System.Windows.Forms.NumericUpDown();
            this.FromNumberCol = new System.Windows.Forms.NumericUpDown();
            this.FromNameCol = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SessionIDCol = new System.Windows.Forms.NumericUpDown();
            this.CallLengthCol = new System.Windows.Forms.NumericUpDown();
            this.HandleTimeCol = new System.Windows.Forms.NumericUpDown();
            this.StartTimeCol = new System.Windows.Forms.NumericUpDown();
            this.CallDirectionCol = new System.Windows.Forms.NumericUpDown();
            this.CallQueueCol = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.SaveColumnBtn = new System.Windows.Forms.Button();
            this.ResetColumnBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SheetSelector = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.FileNameSameAsInput = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.OutputFileNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.FolderSameAsInput = new System.Windows.Forms.RadioButton();
            this.OutputFolderLabel = new System.Windows.Forms.Label();
            this.SelectOutputFolderBtn = new System.Windows.Forms.Button();
            this.SaveCommonBtn = new System.Windows.Forms.Button();
            this.ResetCommonBtn = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NoEmployeeFilterRadio = new System.Windows.Forms.RadioButton();
            this.EmployeeFilterTextBox = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.CommonSettingsTab = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.CloseCommonBtn = new System.Windows.Forms.Button();
            this.ColumnSettingsTab = new System.Windows.Forms.TabPage();
            this.CloseColumnBtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CallResultCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToNumberCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToNameCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromNumberCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromNameCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SessionIDCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CallLengthCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HandleTimeCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartTimeCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CallDirectionCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CallQueueCol)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SheetSelector)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.CommonSettingsTab.SuspendLayout();
            this.ColumnSettingsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.CallResultCol, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ToNumberCol, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ToNameCol, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.FromNumberCol, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.FromNameCol, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SessionIDCol, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.CallLengthCol, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.HandleTimeCol, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.StartTimeCol, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.CallDirectionCol, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.CallQueueCol, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label13, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label15, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label17, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label19, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label21, 2, 5);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(337, 175);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(171, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 28);
            this.label11.TabIndex = 10;
            this.label11.Text = "Call Result Column";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CallResultCol
            // 
            this.CallResultCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CallResultCol.Location = new System.Drawing.Point(288, 4);
            this.CallResultCol.Name = "CallResultCol";
            this.CallResultCol.Size = new System.Drawing.Size(45, 20);
            this.CallResultCol.TabIndex = 26;
            this.CallResultCol.ValueChanged += new System.EventHandler(this.NumberSelector_ValueChanged);
            // 
            // ToNumberCol
            // 
            this.ToNumberCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToNumberCol.Location = new System.Drawing.Point(121, 120);
            this.ToNumberCol.Name = "ToNumberCol";
            this.ToNumberCol.Size = new System.Drawing.Size(43, 20);
            this.ToNumberCol.TabIndex = 25;
            this.ToNumberCol.ValueChanged += new System.EventHandler(this.NumberSelector_ValueChanged);
            // 
            // ToNameCol
            // 
            this.ToNameCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToNameCol.Location = new System.Drawing.Point(121, 91);
            this.ToNameCol.Name = "ToNameCol";
            this.ToNameCol.Size = new System.Drawing.Size(43, 20);
            this.ToNameCol.TabIndex = 24;
            this.ToNameCol.ValueChanged += new System.EventHandler(this.NumberSelector_ValueChanged);
            // 
            // FromNumberCol
            // 
            this.FromNumberCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FromNumberCol.Location = new System.Drawing.Point(121, 62);
            this.FromNumberCol.Name = "FromNumberCol";
            this.FromNumberCol.Size = new System.Drawing.Size(43, 20);
            this.FromNumberCol.TabIndex = 23;
            this.FromNumberCol.ValueChanged += new System.EventHandler(this.NumberSelector_ValueChanged);
            // 
            // FromNameCol
            // 
            this.FromNameCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FromNameCol.Location = new System.Drawing.Point(121, 33);
            this.FromNameCol.Name = "FromNameCol";
            this.FromNameCol.Size = new System.Drawing.Size(43, 20);
            this.FromNameCol.TabIndex = 22;
            this.FromNameCol.ValueChanged += new System.EventHandler(this.NumberSelector_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(4, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 28);
            this.label9.TabIndex = 8;
            this.label9.Text = "To Number Column";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(4, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 28);
            this.label7.TabIndex = 6;
            this.label7.Text = "To Name Column";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(4, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "From Number Column";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(4, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "From Name Column";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Session ID Column";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SessionIDCol
            // 
            this.SessionIDCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SessionIDCol.Location = new System.Drawing.Point(121, 4);
            this.SessionIDCol.Name = "SessionIDCol";
            this.SessionIDCol.Size = new System.Drawing.Size(43, 20);
            this.SessionIDCol.TabIndex = 21;
            this.SessionIDCol.ValueChanged += new System.EventHandler(this.NumberSelector_ValueChanged);
            // 
            // CallLengthCol
            // 
            this.CallLengthCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CallLengthCol.Location = new System.Drawing.Point(288, 33);
            this.CallLengthCol.Name = "CallLengthCol";
            this.CallLengthCol.Size = new System.Drawing.Size(45, 20);
            this.CallLengthCol.TabIndex = 27;
            this.CallLengthCol.ValueChanged += new System.EventHandler(this.NumberSelector_ValueChanged);
            // 
            // HandleTimeCol
            // 
            this.HandleTimeCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HandleTimeCol.Location = new System.Drawing.Point(288, 62);
            this.HandleTimeCol.Name = "HandleTimeCol";
            this.HandleTimeCol.Size = new System.Drawing.Size(45, 20);
            this.HandleTimeCol.TabIndex = 28;
            this.HandleTimeCol.ValueChanged += new System.EventHandler(this.NumberSelector_ValueChanged);
            // 
            // StartTimeCol
            // 
            this.StartTimeCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartTimeCol.Location = new System.Drawing.Point(288, 91);
            this.StartTimeCol.Name = "StartTimeCol";
            this.StartTimeCol.Size = new System.Drawing.Size(45, 20);
            this.StartTimeCol.TabIndex = 29;
            this.StartTimeCol.ValueChanged += new System.EventHandler(this.NumberSelector_ValueChanged);
            // 
            // CallDirectionCol
            // 
            this.CallDirectionCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CallDirectionCol.Location = new System.Drawing.Point(288, 120);
            this.CallDirectionCol.Name = "CallDirectionCol";
            this.CallDirectionCol.Size = new System.Drawing.Size(45, 20);
            this.CallDirectionCol.TabIndex = 30;
            this.CallDirectionCol.ValueChanged += new System.EventHandler(this.NumberSelector_ValueChanged);
            // 
            // CallQueueCol
            // 
            this.CallQueueCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CallQueueCol.Location = new System.Drawing.Point(288, 149);
            this.CallQueueCol.Name = "CallQueueCol";
            this.CallQueueCol.Size = new System.Drawing.Size(45, 20);
            this.CallQueueCol.TabIndex = 31;
            this.CallQueueCol.ValueChanged += new System.EventHandler(this.NumberSelector_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(171, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 28);
            this.label13.TabIndex = 12;
            this.label13.Text = "Call Length Column";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(171, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 28);
            this.label15.TabIndex = 14;
            this.label15.Text = "Handle Time Column";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(171, 88);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 28);
            this.label17.TabIndex = 16;
            this.label17.Text = "Start Time Column";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Location = new System.Drawing.Point(171, 117);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(110, 28);
            this.label19.TabIndex = 18;
            this.label19.Text = "Call Direction Column";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Location = new System.Drawing.Point(171, 146);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(110, 28);
            this.label21.TabIndex = 20;
            this.label21.Text = "Call Queue Column";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SaveColumnBtn
            // 
            this.SaveColumnBtn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveColumnBtn.Location = new System.Drawing.Point(6, 403);
            this.SaveColumnBtn.Name = "SaveColumnBtn";
            this.SaveColumnBtn.Size = new System.Drawing.Size(75, 25);
            this.SaveColumnBtn.TabIndex = 1;
            this.SaveColumnBtn.Text = "Save";
            this.SaveColumnBtn.UseVisualStyleBackColor = true;
            this.SaveColumnBtn.Click += new System.EventHandler(this.SaveColumnBtn_Click);
            // 
            // ResetColumnBtn
            // 
            this.ResetColumnBtn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetColumnBtn.Location = new System.Drawing.Point(87, 403);
            this.ResetColumnBtn.Name = "ResetColumnBtn";
            this.ResetColumnBtn.Size = new System.Drawing.Size(75, 25);
            this.ResetColumnBtn.TabIndex = 2;
            this.ResetColumnBtn.Text = "Reset";
            this.ResetColumnBtn.UseVisualStyleBackColor = true;
            this.ResetColumnBtn.Click += new System.EventHandler(this.ResetColumnBtn_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(387, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "You can change the default column numbers for each of the values below. This will" +
    " change the way your Excel data file is processed.";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.SheetSelector);
            this.groupBox5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(387, 72);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Excel Sheet";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(356, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "(Default is 2)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SheetSelector
            // 
            this.SheetSelector.Location = new System.Drawing.Point(21, 19);
            this.SheetSelector.Name = "SheetSelector";
            this.SheetSelector.Size = new System.Drawing.Size(44, 20);
            this.SheetSelector.TabIndex = 22;
            this.SheetSelector.ValueChanged += new System.EventHandler(this.SheetSelector_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FileNameSameAsInput);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.OutputFileNameTextBox);
            this.groupBox3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 162);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(387, 72);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output File Name";
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
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(341, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = ".pdf";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.FolderSameAsInput);
            this.groupBox4.Controls.Add(this.OutputFolderLabel);
            this.groupBox4.Controls.Add(this.SelectOutputFolderBtn);
            this.groupBox4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(6, 84);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(387, 72);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Output Folder";
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
            // SaveCommonBtn
            // 
            this.SaveCommonBtn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveCommonBtn.Location = new System.Drawing.Point(6, 403);
            this.SaveCommonBtn.Name = "SaveCommonBtn";
            this.SaveCommonBtn.Size = new System.Drawing.Size(75, 25);
            this.SaveCommonBtn.TabIndex = 1;
            this.SaveCommonBtn.Text = "Save";
            this.SaveCommonBtn.UseVisualStyleBackColor = true;
            this.SaveCommonBtn.Click += new System.EventHandler(this.SaveCommonBtn_Click);
            // 
            // ResetCommonBtn
            // 
            this.ResetCommonBtn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetCommonBtn.Location = new System.Drawing.Point(87, 403);
            this.ResetCommonBtn.Name = "ResetCommonBtn";
            this.ResetCommonBtn.Size = new System.Drawing.Size(75, 25);
            this.ResetCommonBtn.TabIndex = 2;
            this.ResetCommonBtn.Text = "Reset";
            this.ResetCommonBtn.UseVisualStyleBackColor = true;
            this.ResetCommonBtn.Click += new System.EventHandler(this.ResetCommonBtn_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.NoEmployeeFilterRadio);
            this.groupBox6.Controls.Add(this.EmployeeFilterTextBox);
            this.groupBox6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(6, 240);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(387, 141);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Active Employees";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(353, 18);
            this.label8.TabIndex = 17;
            this.label8.Text = "Type a comma separated list of employees below to filter your logs.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NoEmployeeFilterRadio
            // 
            this.NoEmployeeFilterRadio.AutoSize = true;
            this.NoEmployeeFilterRadio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoEmployeeFilterRadio.Location = new System.Drawing.Point(21, 19);
            this.NoEmployeeFilterRadio.Name = "NoEmployeeFilterRadio";
            this.NoEmployeeFilterRadio.Size = new System.Drawing.Size(64, 18);
            this.NoEmployeeFilterRadio.TabIndex = 16;
            this.NoEmployeeFilterRadio.TabStop = true;
            this.NoEmployeeFilterRadio.Text = "No Filter";
            this.NoEmployeeFilterRadio.UseVisualStyleBackColor = true;
            this.NoEmployeeFilterRadio.CheckedChanged += new System.EventHandler(this.NoEmployeeFilterRadio_CheckedChanged);
            // 
            // EmployeeFilterTextBox
            // 
            this.EmployeeFilterTextBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeFilterTextBox.Location = new System.Drawing.Point(21, 59);
            this.EmployeeFilterTextBox.Multiline = true;
            this.EmployeeFilterTextBox.Name = "EmployeeFilterTextBox";
            this.EmployeeFilterTextBox.Size = new System.Drawing.Size(360, 76);
            this.EmployeeFilterTextBox.TabIndex = 16;
            this.EmployeeFilterTextBox.TextChanged += new System.EventHandler(this.EmployeeFilterTextBox_TextChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.CommonSettingsTab);
            this.tabControl.Controls.Add(this.ColumnSettingsTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(408, 461);
            this.tabControl.TabIndex = 8;
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl_Selecting);
            // 
            // CommonSettingsTab
            // 
            this.CommonSettingsTab.Controls.Add(this.label10);
            this.CommonSettingsTab.Controls.Add(this.SaveCommonBtn);
            this.CommonSettingsTab.Controls.Add(this.CloseCommonBtn);
            this.CommonSettingsTab.Controls.Add(this.ResetCommonBtn);
            this.CommonSettingsTab.Controls.Add(this.groupBox6);
            this.CommonSettingsTab.Controls.Add(this.groupBox5);
            this.CommonSettingsTab.Controls.Add(this.groupBox3);
            this.CommonSettingsTab.Controls.Add(this.groupBox4);
            this.CommonSettingsTab.Location = new System.Drawing.Point(4, 23);
            this.CommonSettingsTab.Name = "CommonSettingsTab";
            this.CommonSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.CommonSettingsTab.Size = new System.Drawing.Size(400, 434);
            this.CommonSettingsTab.TabIndex = 0;
            this.CommonSettingsTab.Text = "Common Settings";
            this.CommonSettingsTab.UseVisualStyleBackColor = true;
            this.CommonSettingsTab.Enter += new System.EventHandler(this.CommonSettingsTab_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 386);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 14);
            this.label10.TabIndex = 27;
            this.label10.Text = "(Only affect settings in this tab)";
            // 
            // CloseCommonBtn
            // 
            this.CloseCommonBtn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseCommonBtn.Location = new System.Drawing.Point(319, 403);
            this.CloseCommonBtn.Name = "CloseCommonBtn";
            this.CloseCommonBtn.Size = new System.Drawing.Size(75, 25);
            this.CloseCommonBtn.TabIndex = 2;
            this.CloseCommonBtn.Text = "Close";
            this.CloseCommonBtn.UseVisualStyleBackColor = true;
            this.CloseCommonBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // ColumnSettingsTab
            // 
            this.ColumnSettingsTab.Controls.Add(this.CloseColumnBtn);
            this.ColumnSettingsTab.Controls.Add(this.label12);
            this.ColumnSettingsTab.Controls.Add(this.label2);
            this.ColumnSettingsTab.Controls.Add(this.tableLayoutPanel1);
            this.ColumnSettingsTab.Controls.Add(this.SaveColumnBtn);
            this.ColumnSettingsTab.Controls.Add(this.ResetColumnBtn);
            this.ColumnSettingsTab.Location = new System.Drawing.Point(4, 23);
            this.ColumnSettingsTab.Name = "ColumnSettingsTab";
            this.ColumnSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ColumnSettingsTab.Size = new System.Drawing.Size(400, 434);
            this.ColumnSettingsTab.TabIndex = 1;
            this.ColumnSettingsTab.Text = "Column Settings";
            this.ColumnSettingsTab.UseVisualStyleBackColor = true;
            this.ColumnSettingsTab.Enter += new System.EventHandler(this.ColumnSettingsTab_Enter);
            // 
            // CloseColumnBtn
            // 
            this.CloseColumnBtn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseColumnBtn.Location = new System.Drawing.Point(319, 403);
            this.CloseColumnBtn.Name = "CloseColumnBtn";
            this.CloseColumnBtn.Size = new System.Drawing.Size(75, 25);
            this.CloseColumnBtn.TabIndex = 29;
            this.CloseColumnBtn.Text = "Close";
            this.CloseColumnBtn.UseVisualStyleBackColor = true;
            this.CloseColumnBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 386);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 14);
            this.label12.TabIndex = 28;
            this.label12.Text = "(Only affect settings in this tab)";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 461);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CallResultCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToNumberCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToNameCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromNumberCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromNameCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SessionIDCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CallLengthCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HandleTimeCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartTimeCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CallDirectionCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CallQueueCol)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SheetSelector)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.CommonSettingsTab.ResumeLayout(false);
            this.CommonSettingsTab.PerformLayout();
            this.ColumnSettingsTab.ResumeLayout(false);
            this.ColumnSettingsTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown SessionIDCol;
        private System.Windows.Forms.NumericUpDown CallQueueCol;
        private System.Windows.Forms.NumericUpDown CallDirectionCol;
        private System.Windows.Forms.NumericUpDown StartTimeCol;
        private System.Windows.Forms.NumericUpDown HandleTimeCol;
        private System.Windows.Forms.NumericUpDown CallLengthCol;
        private System.Windows.Forms.NumericUpDown CallResultCol;
        private System.Windows.Forms.NumericUpDown ToNumberCol;
        private System.Windows.Forms.NumericUpDown ToNameCol;
        private System.Windows.Forms.NumericUpDown FromNumberCol;
        private System.Windows.Forms.Button SaveColumnBtn;
        private System.Windows.Forms.Button ResetColumnBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown SheetSelector;
        private System.Windows.Forms.Button SaveCommonBtn;
        private System.Windows.Forms.Button ResetCommonBtn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton FileNameSameAsInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox OutputFileNameTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton FolderSameAsInput;
        private System.Windows.Forms.Label OutputFolderLabel;
        private System.Windows.Forms.Button SelectOutputFolderBtn;
        private System.Windows.Forms.NumericUpDown FromNameCol;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton NoEmployeeFilterRadio;
        private System.Windows.Forms.TextBox EmployeeFilterTextBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage CommonSettingsTab;
        private System.Windows.Forms.TabPage ColumnSettingsTab;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button CloseCommonBtn;
        private System.Windows.Forms.Button CloseColumnBtn;
    }
}