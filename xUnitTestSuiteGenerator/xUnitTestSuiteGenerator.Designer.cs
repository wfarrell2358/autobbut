using System.Windows.Forms;
using System;
namespace autobbut_gui
{
   partial class xUnitTestSuiteGenerator
    {
       /// <summary>
       /// The main entry point for the application.
       /// </summary>
       [STAThread]
       static void Main()
       {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new xUnitTestSuiteGenerator());
       }

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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xUnitTestSuiteGenerator));
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
           this.generateXunitButton = new System.Windows.Forms.Button();
           this.btnExit = new System.Windows.Forms.Button();
           this.generateCSVButton = new System.Windows.Forms.Button();
           this.tabPage1 = new System.Windows.Forms.TabPage();
           this.oracleCode = new System.Windows.Forms.TextBox();
           this.pictureBox2 = new System.Windows.Forms.PictureBox();
           this.outputGridView = new System.Windows.Forms.DataGridView();
           this.nameOutput = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this.typeOutput = new System.Windows.Forms.DataGridViewComboBoxColumn();
           this.Oracle = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this.tabInput = new System.Windows.Forms.TabPage();
           this.prefixTextField = new System.Windows.Forms.TextBox();
           this.prefixLabel = new System.Windows.Forms.Label();
           this.label3 = new System.Windows.Forms.Label();
           this.label1 = new System.Windows.Forms.Label();
           this.wayField = new System.Windows.Forms.NumericUpDown();
           this.pictureBox1 = new System.Windows.Forms.PictureBox();
           this.textBoxValue = new System.Windows.Forms.TextBox();
           this.inputGridView = new System.Windows.Forms.DataGridView();
           this.Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
           this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this.tabControl = new System.Windows.Forms.TabControl();
           this.progressBarXUNIT = new System.Windows.Forms.ProgressBar();
           this.progressBarCSV = new System.Windows.Forms.ProgressBar();
           this.textProgress = new System.Windows.Forms.Label();
           this.tabPage1.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this.outputGridView)).BeginInit();
           this.tabInput.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.wayField)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this.inputGridView)).BeginInit();
           this.tabControl.SuspendLayout();
           this.SuspendLayout();
           // 
           // generateXunitButton
           // 
           this.generateXunitButton.BackColor = System.Drawing.Color.Transparent;
           this.generateXunitButton.Location = new System.Drawing.Point(16, 380);
           this.generateXunitButton.Name = "generateXunitButton";
           this.generateXunitButton.Size = new System.Drawing.Size(149, 23);
           this.generateXunitButton.TabIndex = 4;
           this.generateXunitButton.Text = "Generate xUnit Code";
           this.generateXunitButton.UseVisualStyleBackColor = false;
           this.generateXunitButton.Click += new System.EventHandler(this.generateButtonXUNIT_Click);
           // 
           // btnExit
           // 
           this.btnExit.Location = new System.Drawing.Point(412, 380);
           this.btnExit.Name = "btnExit";
           this.btnExit.Size = new System.Drawing.Size(103, 23);
           this.btnExit.TabIndex = 13;
           this.btnExit.Text = "Exit";
           this.btnExit.UseVisualStyleBackColor = true;
           this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
           // 
           // generateCSVButton
           // 
           this.generateCSVButton.BackColor = System.Drawing.Color.Transparent;
           this.generateCSVButton.Location = new System.Drawing.Point(192, 380);
           this.generateCSVButton.Name = "generateCSVButton";
           this.generateCSVButton.Size = new System.Drawing.Size(95, 23);
           this.generateCSVButton.TabIndex = 16;
           this.generateCSVButton.Text = "Generate CSV";
           this.generateCSVButton.UseVisualStyleBackColor = false;
           this.generateCSVButton.Click += new System.EventHandler(this.generateButtonCSV_Click);
           // 
           // tabPage1
           // 
           this.tabPage1.Controls.Add(this.oracleCode);
           this.tabPage1.Controls.Add(this.pictureBox2);
           this.tabPage1.Controls.Add(this.outputGridView);
           this.tabPage1.Location = new System.Drawing.Point(4, 22);
           this.tabPage1.Name = "tabPage1";
           this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
           this.tabPage1.Size = new System.Drawing.Size(900, 310);
           this.tabPage1.TabIndex = 1;
           this.tabPage1.Text = "Output";
           this.tabPage1.UseVisualStyleBackColor = true;
           // 
           // oracleCode
           // 
           this.oracleCode.Location = new System.Drawing.Point(292, 26);
           this.oracleCode.Multiline = true;
           this.oracleCode.Name = "oracleCode";
           this.oracleCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
           this.oracleCode.Size = new System.Drawing.Size(602, 176);
           this.oracleCode.TabIndex = 16;
           this.oracleCode.WordWrap = false;
           this.oracleCode.TextChanged += new System.EventHandler(this.textOracle_TextChanged);
           // 
           // pictureBox2
           // 
           this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
           this.pictureBox2.Location = new System.Drawing.Point(679, 234);
           this.pictureBox2.Name = "pictureBox2";
           this.pictureBox2.Size = new System.Drawing.Size(221, 76);
           this.pictureBox2.TabIndex = 15;
           this.pictureBox2.TabStop = false;
           // 
           // outputGridView
           // 
           this.outputGridView.BackgroundColor = System.Drawing.SystemColors.Control;
           dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
           dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
           dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
           dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
           dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
           dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
           this.outputGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
           this.outputGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
           this.outputGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameOutput,
            this.typeOutput,
            this.Oracle});
           dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
           dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
           dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
           dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
           dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
           dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
           this.outputGridView.DefaultCellStyle = dataGridViewCellStyle2;
           this.outputGridView.Location = new System.Drawing.Point(25, 7);
           this.outputGridView.Name = "outputGridView";
           dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
           dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
           dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
           dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
           dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
           dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
           this.outputGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
           this.outputGridView.Size = new System.Drawing.Size(875, 266);
           this.outputGridView.TabIndex = 0;
           this.outputGridView.SelectionChanged += new System.EventHandler(this.outputSelectedRow);
           // 
           // nameOutput
           // 
           this.nameOutput.HeaderText = "Parameter";
           this.nameOutput.Name = "nameOutput";
           // 
           // typeOutput
           // 
           this.typeOutput.FillWeight = 125F;
           this.typeOutput.HeaderText = "Type";
           this.typeOutput.Items.AddRange(new object[] {
            "Float (32 bit)",
            "Float (64 bit)",
            "Int (8 bit)",
            "Int (16 bit)",
            "Int (32 bit)",
            "Int (64 bit)",
            "Unsigned Int (8 bit)",
            "Unsigned Int (16 bit)",
            "Unsigned Int (32 bit)",
            "Unsigned Int (64 bit)",
            "Text",
            "Digital",
            "TimeInterval",
            "DateTime",
            "E-mail",
            "Digital"});
           this.typeOutput.Name = "typeOutput";
           this.typeOutput.Resizable = System.Windows.Forms.DataGridViewTriState.True;
           this.typeOutput.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
           this.typeOutput.Width = 125;
           // 
           // Oracle
           // 
           this.Oracle.HeaderText = "Oracle";
           this.Oracle.Name = "Oracle";
           this.Oracle.Width = 600;
           // 
           // tabInput
           // 
           this.tabInput.Controls.Add(this.prefixTextField);
           this.tabInput.Controls.Add(this.prefixLabel);
           this.tabInput.Controls.Add(this.label3);
           this.tabInput.Controls.Add(this.label1);
           this.tabInput.Controls.Add(this.wayField);
           this.tabInput.Controls.Add(this.pictureBox1);
           this.tabInput.Controls.Add(this.textBoxValue);
           this.tabInput.Controls.Add(this.inputGridView);
           this.tabInput.Location = new System.Drawing.Point(4, 22);
           this.tabInput.Name = "tabInput";
           this.tabInput.Padding = new System.Windows.Forms.Padding(3);
           this.tabInput.Size = new System.Drawing.Size(900, 310);
           this.tabInput.TabIndex = 0;
           this.tabInput.Text = "Input";
           this.tabInput.UseVisualStyleBackColor = true;
           // 
           // prefixTextField
           // 
           this.prefixTextField.Location = new System.Drawing.Point(16, 266);
           this.prefixTextField.Name = "prefixTextField";
           this.prefixTextField.Size = new System.Drawing.Size(100, 20);
           this.prefixTextField.TabIndex = 18;
           // 
           // prefixLabel
           // 
           this.prefixLabel.AutoSize = true;
           this.prefixLabel.Location = new System.Drawing.Point(13, 250);
           this.prefixLabel.Name = "prefixLabel";
           this.prefixLabel.Size = new System.Drawing.Size(105, 13);
           this.prefixLabel.TabIndex = 17;
           this.prefixLabel.Text = "prefix for test method";
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.Location = new System.Drawing.Point(13, 203);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(87, 13);
           this.label3.TabIndex = 16;
           this.label3.Text = "Pair-wise Testing";
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(72, 225);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(26, 13);
           this.label1.TabIndex = 15;
           this.label1.Text = "way";
           // 
           // wayField
           // 
           this.wayField.Location = new System.Drawing.Point(16, 222);
           this.wayField.Name = "wayField";
           this.wayField.Size = new System.Drawing.Size(50, 20);
           this.wayField.TabIndex = 14;
           // 
           // pictureBox1
           // 
           this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
           this.pictureBox1.Location = new System.Drawing.Point(668, 222);
           this.pictureBox1.Name = "pictureBox1";
           this.pictureBox1.Size = new System.Drawing.Size(226, 82);
           this.pictureBox1.TabIndex = 12;
           this.pictureBox1.TabStop = false;
           // 
           // textBoxValue
           // 
           this.textBoxValue.Location = new System.Drawing.Point(272, 24);
           this.textBoxValue.Multiline = true;
           this.textBoxValue.Name = "textBoxValue";
           this.textBoxValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
           this.textBoxValue.Size = new System.Drawing.Size(622, 176);
           this.textBoxValue.TabIndex = 11;
           this.textBoxValue.WordWrap = false;
           this.textBoxValue.TextChanged += new System.EventHandler(this.textBoxValue_TextChanged);
           // 
           // inputGridView
           // 
           this.inputGridView.AllowUserToOrderColumns = true;
           dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
           this.inputGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
           this.inputGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
           dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
           dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
           dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
           dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
           dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
           dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
           this.inputGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
           this.inputGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
           this.inputGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Parameter,
            this.Type,
            this.Value});
           dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
           dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
           dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
           dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
           dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
           dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
           this.inputGridView.DefaultCellStyle = dataGridViewCellStyle8;
           this.inputGridView.Location = new System.Drawing.Point(6, 6);
           this.inputGridView.Name = "inputGridView";
           dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
           dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
           dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
           dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
           dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
           dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
           this.inputGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
           dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
           this.inputGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
           this.inputGridView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
           this.inputGridView.Size = new System.Drawing.Size(888, 194);
           this.inputGridView.TabIndex = 1;
           this.inputGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.cellValidated);
           this.inputGridView.SelectionChanged += new System.EventHandler(this.selectedRow);
           // 
           // Parameter
           // 
           dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
           this.Parameter.DefaultCellStyle = dataGridViewCellStyle6;
           this.Parameter.HeaderText = "Parameter";
           this.Parameter.Name = "Parameter";
           this.Parameter.Resizable = System.Windows.Forms.DataGridViewTriState.True;
           this.Parameter.ToolTipText = "Autoincrement value";
           // 
           // Type
           // 
           this.Type.FillWeight = 125F;
           this.Type.HeaderText = "Type";
           this.Type.Items.AddRange(new object[] {
            "Float (32 bit)",
            "Float (64 bit)",
            "Int (8 bit)",
            "Int (16 bit)",
            "Int (32 bit)",
            "Int (64 bit)",
            "Unsigned Int (8 bit)",
            "Unsigned Int (16 bit)",
            "Unsigned Int (32 bit)",
            "Unsigned Int (64 bit)",
            "Text",
            "Digital",
            "TimeInterval",
            "DateTime",
            "E-mail",
            "Digital"});
           this.Type.Name = "Type";
           this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
           this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
           this.Type.Width = 125;
           // 
           // Value
           // 
           this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
           dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
           this.Value.DefaultCellStyle = dataGridViewCellStyle7;
           this.Value.HeaderText = "Value";
           this.Value.Name = "Value";
           // 
           // tabControl
           // 
           this.tabControl.Controls.Add(this.tabInput);
           this.tabControl.Controls.Add(this.tabPage1);
           this.tabControl.Location = new System.Drawing.Point(12, 12);
           this.tabControl.Name = "tabControl";
           this.tabControl.SelectedIndex = 0;
           this.tabControl.Size = new System.Drawing.Size(908, 336);
           this.tabControl.TabIndex = 10;
           // 
           // progressBarXUNIT
           // 
           this.progressBarXUNIT.Location = new System.Drawing.Point(16, 354);
           this.progressBarXUNIT.Name = "progressBarXUNIT";
           this.progressBarXUNIT.Size = new System.Drawing.Size(499, 20);
           this.progressBarXUNIT.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
           this.progressBarXUNIT.TabIndex = 19;
           this.progressBarXUNIT.Visible = false;
           // 
           // progressBarCSV
           // 
           this.progressBarCSV.Location = new System.Drawing.Point(12, 354);
           this.progressBarCSV.Name = "progressBarCSV";
           this.progressBarCSV.Size = new System.Drawing.Size(503, 20);
           this.progressBarCSV.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
           this.progressBarCSV.TabIndex = 20;
           this.progressBarCSV.Visible = false;
           // 
           // textProgress
           // 
           this.textProgress.AutoSize = true;
           this.textProgress.Location = new System.Drawing.Point(522, 360);
           this.textProgress.Name = "textProgress";
           this.textProgress.Size = new System.Drawing.Size(0, 13);
           this.textProgress.TabIndex = 21;
           // 
           // xUnitTestSuiteGenerator
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(927, 410);
           this.Controls.Add(this.textProgress);
           this.Controls.Add(this.progressBarCSV);
           this.Controls.Add(this.progressBarXUNIT);
           this.Controls.Add(this.generateCSVButton);
           this.Controls.Add(this.tabControl);
           this.Controls.Add(this.generateXunitButton);
           this.Controls.Add(this.btnExit);
           this.Name = "xUnitTestSuiteGenerator";
           this.Text = "xUnitTestSuiteGenerator";
           this.tabPage1.ResumeLayout(false);
           this.tabPage1.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this.outputGridView)).EndInit();
           this.tabInput.ResumeLayout(false);
           this.tabInput.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.wayField)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this.inputGridView)).EndInit();
           this.tabControl.ResumeLayout(false);
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateXunitButton;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button generateCSVButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView outputGridView;
        private System.Windows.Forms.TabPage tabInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown wayField;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.DataGridView inputGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameter;
        private System.Windows.Forms.DataGridViewComboBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameOutput;
        private System.Windows.Forms.DataGridViewComboBoxColumn typeOutput;
        private System.Windows.Forms.DataGridViewTextBoxColumn Oracle;
        private System.Windows.Forms.TextBox oracleCode;
        private Label prefixLabel;
        private TextBox prefixTextField;
        private ProgressBar progressBarXUNIT;
        private ProgressBar progressBarCSV;
        private Label textProgress;

    }
}

