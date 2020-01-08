namespace WindowsFormsApp1
{
    partial class Form1
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
            this.CalculateButton = new System.Windows.Forms.Button();
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.MovingBrowse = new System.Windows.Forms.Button();
            this.FixedBrowse = new System.Windows.Forms.Button();
            this.MovingFile = new System.Windows.Forms.TextBox();
            this.FixedFile = new System.Windows.Forms.TextBox();
            this.ClearOutput = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ConvertBox = new System.Windows.Forms.TextBox();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.ConvertBrowse = new System.Windows.Forms.Button();
            this.ConvertFile = new System.Windows.Forms.TextBox();
            this.DotCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BestFitAdditionalCheck = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.FixedBox = new System.Windows.Forms.TextBox();
            this.FixedExplorer = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.MovingBox = new System.Windows.Forms.TextBox();
            this.MovingExplorer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ConvertAdditionalCheck = new System.Windows.Forms.CheckBox();
            this.ConvertExplorer = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.InverseCheck = new System.Windows.Forms.CheckBox();
            this.TransformButton = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.TransformInputFile = new System.Windows.Forms.TextBox();
            this.TransformInputBox = new System.Windows.Forms.TextBox();
            this.TransformInputExplorer = new System.Windows.Forms.Button();
            this.TransformInputBrowse = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.TransformMatrixBox = new System.Windows.Forms.TextBox();
            this.TransformMatrixBrowse = new System.Windows.Forms.Button();
            this.TransformMatrixExplorer = new System.Windows.Forms.Button();
            this.TransformMatrixFile = new System.Windows.Forms.TextBox();
            this.ClearAll = new System.Windows.Forms.Button();
            this.ClearInput = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MultiplyButton = new System.Windows.Forms.Button();
            this.MultiplyBox2 = new System.Windows.Forms.TextBox();
            this.MultiplyBox1 = new System.Windows.Forms.TextBox();
            this.AutomaticButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(188, 391);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(225, 23);
            this.CalculateButton.TabIndex = 0;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // OutputBox
            // 
            this.OutputBox.Font = new System.Drawing.Font("Courier New", 10F);
            this.OutputBox.Location = new System.Drawing.Point(12, 25);
            this.OutputBox.Multiline = true;
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputBox.Size = new System.Drawing.Size(542, 584);
            this.OutputBox.TabIndex = 1;
            // 
            // MovingBrowse
            // 
            this.MovingBrowse.Location = new System.Drawing.Point(288, 19);
            this.MovingBrowse.Name = "MovingBrowse";
            this.MovingBrowse.Size = new System.Drawing.Size(110, 23);
            this.MovingBrowse.TabIndex = 2;
            this.MovingBrowse.Text = "Browse ...";
            this.MovingBrowse.UseVisualStyleBackColor = true;
            this.MovingBrowse.Click += new System.EventHandler(this.button2_Click);
            // 
            // FixedBrowse
            // 
            this.FixedBrowse.Location = new System.Drawing.Point(288, 19);
            this.FixedBrowse.Name = "FixedBrowse";
            this.FixedBrowse.Size = new System.Drawing.Size(110, 23);
            this.FixedBrowse.TabIndex = 3;
            this.FixedBrowse.Text = "Browse ...";
            this.FixedBrowse.UseVisualStyleBackColor = true;
            this.FixedBrowse.Click += new System.EventHandler(this.button3_Click);
            // 
            // MovingFile
            // 
            this.MovingFile.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MovingFile.Location = new System.Drawing.Point(6, 19);
            this.MovingFile.Name = "MovingFile";
            this.MovingFile.ReadOnly = true;
            this.MovingFile.Size = new System.Drawing.Size(247, 22);
            this.MovingFile.TabIndex = 4;
            this.MovingFile.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // FixedFile
            // 
            this.FixedFile.Font = new System.Drawing.Font("Courier New", 10F);
            this.FixedFile.Location = new System.Drawing.Point(15, 38);
            this.FixedFile.Name = "FixedFile";
            this.FixedFile.ReadOnly = true;
            this.FixedFile.Size = new System.Drawing.Size(247, 23);
            this.FixedFile.TabIndex = 7;
            this.FixedFile.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // ClearOutput
            // 
            this.ClearOutput.Location = new System.Drawing.Point(438, 623);
            this.ClearOutput.Name = "ClearOutput";
            this.ClearOutput.Size = new System.Drawing.Size(116, 23);
            this.ClearOutput.TabIndex = 9;
            this.ClearOutput.Text = "Clear Output";
            this.ClearOutput.UseVisualStyleBackColor = true;
            this.ClearOutput.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Output";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ConvertBox
            // 
            this.ConvertBox.Font = new System.Drawing.Font("Courier New", 10F);
            this.ConvertBox.Location = new System.Drawing.Point(9, 47);
            this.ConvertBox.Multiline = true;
            this.ConvertBox.Name = "ConvertBox";
            this.ConvertBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConvertBox.Size = new System.Drawing.Size(404, 80);
            this.ConvertBox.TabIndex = 11;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(188, 137);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(225, 23);
            this.ConvertButton.TabIndex = 13;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // ConvertBrowse
            // 
            this.ConvertBrowse.Location = new System.Drawing.Point(297, 18);
            this.ConvertBrowse.Name = "ConvertBrowse";
            this.ConvertBrowse.Size = new System.Drawing.Size(116, 23);
            this.ConvertBrowse.TabIndex = 14;
            this.ConvertBrowse.Text = "Browse ...";
            this.ConvertBrowse.UseVisualStyleBackColor = true;
            this.ConvertBrowse.Click += new System.EventHandler(this.button7_Click);
            // 
            // ConvertFile
            // 
            this.ConvertFile.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ConvertFile.Location = new System.Drawing.Point(9, 19);
            this.ConvertFile.Name = "ConvertFile";
            this.ConvertFile.ReadOnly = true;
            this.ConvertFile.Size = new System.Drawing.Size(253, 22);
            this.ConvertFile.TabIndex = 16;
            // 
            // DotCheck
            // 
            this.DotCheck.AutoSize = true;
            this.DotCheck.Checked = true;
            this.DotCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DotCheck.Location = new System.Drawing.Point(422, 5);
            this.DotCheck.Name = "DotCheck";
            this.DotCheck.Size = new System.Drawing.Size(132, 17);
            this.DotCheck.TabIndex = 17;
            this.DotCheck.Text = "Dot delimited output [.]";
            this.DotCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AutomaticButton);
            this.groupBox1.Controls.Add(this.BestFitAdditionalCheck);
            this.groupBox1.Controls.Add(this.FixedFile);
            this.groupBox1.Controls.Add(this.CalculateButton);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Location = new System.Drawing.Point(563, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 451);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "3D BestFit Transformation from Cloud Of Points";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // BestFitAdditionalCheck
            // 
            this.BestFitAdditionalCheck.AutoSize = true;
            this.BestFitAdditionalCheck.Location = new System.Drawing.Point(6, 395);
            this.BestFitAdditionalCheck.Name = "BestFitAdditionalCheck";
            this.BestFitAdditionalCheck.Size = new System.Drawing.Size(131, 17);
            this.BestFitAdditionalCheck.TabIndex = 23;
            this.BestFitAdditionalCheck.Text = "Additional calculations";
            this.BestFitAdditionalCheck.UseVisualStyleBackColor = true;
            this.BestFitAdditionalCheck.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.FixedBox);
            this.groupBox5.Controls.Add(this.FixedExplorer);
            this.groupBox5.Controls.Add(this.FixedBrowse);
            this.groupBox5.Location = new System.Drawing.Point(9, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(404, 180);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "FIxed (No Force)";
            // 
            // FixedBox
            // 
            this.FixedBox.Font = new System.Drawing.Font("Courier New", 10F);
            this.FixedBox.Location = new System.Drawing.Point(6, 48);
            this.FixedBox.Multiline = true;
            this.FixedBox.Name = "FixedBox";
            this.FixedBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FixedBox.Size = new System.Drawing.Size(392, 126);
            this.FixedBox.TabIndex = 24;
            // 
            // FixedExplorer
            // 
            this.FixedExplorer.Location = new System.Drawing.Point(259, 19);
            this.FixedExplorer.Name = "FixedExplorer";
            this.FixedExplorer.Size = new System.Drawing.Size(23, 23);
            this.FixedExplorer.TabIndex = 21;
            this.FixedExplorer.Text = "...";
            this.FixedExplorer.UseVisualStyleBackColor = true;
            this.FixedExplorer.Click += new System.EventHandler(this.button8_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.MovingBox);
            this.groupBox6.Controls.Add(this.MovingExplorer);
            this.groupBox6.Controls.Add(this.MovingBrowse);
            this.groupBox6.Controls.Add(this.MovingFile);
            this.groupBox6.Location = new System.Drawing.Point(9, 205);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(404, 180);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Moving (Force)";
            // 
            // MovingBox
            // 
            this.MovingBox.Font = new System.Drawing.Font("Courier New", 10F);
            this.MovingBox.Location = new System.Drawing.Point(6, 48);
            this.MovingBox.Multiline = true;
            this.MovingBox.Name = "MovingBox";
            this.MovingBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MovingBox.Size = new System.Drawing.Size(392, 126);
            this.MovingBox.TabIndex = 26;
            // 
            // MovingExplorer
            // 
            this.MovingExplorer.Location = new System.Drawing.Point(259, 19);
            this.MovingExplorer.Name = "MovingExplorer";
            this.MovingExplorer.Size = new System.Drawing.Size(23, 23);
            this.MovingExplorer.TabIndex = 22;
            this.MovingExplorer.Text = "...";
            this.MovingExplorer.UseVisualStyleBackColor = true;
            this.MovingExplorer.Click += new System.EventHandler(this.button9_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ConvertAdditionalCheck);
            this.groupBox2.Controls.Add(this.ConvertExplorer);
            this.groupBox2.Controls.Add(this.ConvertButton);
            this.groupBox2.Controls.Add(this.ConvertFile);
            this.groupBox2.Controls.Add(this.ConvertBox);
            this.groupBox2.Controls.Add(this.ConvertBrowse);
            this.groupBox2.Location = new System.Drawing.Point(563, 482);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(419, 166);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Convert 4x4 Matrix to 6VOF";
            // 
            // ConvertAdditionalCheck
            // 
            this.ConvertAdditionalCheck.AutoSize = true;
            this.ConvertAdditionalCheck.Location = new System.Drawing.Point(11, 141);
            this.ConvertAdditionalCheck.Name = "ConvertAdditionalCheck";
            this.ConvertAdditionalCheck.Size = new System.Drawing.Size(131, 17);
            this.ConvertAdditionalCheck.TabIndex = 24;
            this.ConvertAdditionalCheck.Text = "Additional calculations";
            this.ConvertAdditionalCheck.UseVisualStyleBackColor = true;
            // 
            // ConvertExplorer
            // 
            this.ConvertExplorer.Location = new System.Drawing.Point(268, 18);
            this.ConvertExplorer.Name = "ConvertExplorer";
            this.ConvertExplorer.Size = new System.Drawing.Size(23, 23);
            this.ConvertExplorer.TabIndex = 22;
            this.ConvertExplorer.Text = "...";
            this.ConvertExplorer.UseVisualStyleBackColor = true;
            this.ConvertExplorer.Click += new System.EventHandler(this.button10_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.InverseCheck);
            this.groupBox4.Controls.Add(this.TransformButton);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.groupBox8);
            this.groupBox4.Location = new System.Drawing.Point(989, 25);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(419, 379);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cloud Of Points Transformation by 4x4 Matrix";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // InverseCheck
            // 
            this.InverseCheck.AutoSize = true;
            this.InverseCheck.Location = new System.Drawing.Point(7, 350);
            this.InverseCheck.Name = "InverseCheck";
            this.InverseCheck.Size = new System.Drawing.Size(142, 17);
            this.InverseCheck.TabIndex = 25;
            this.InverseCheck.Text = "Inverse Transform Marrix";
            this.InverseCheck.UseVisualStyleBackColor = true;
            this.InverseCheck.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // TransformButton
            // 
            this.TransformButton.Location = new System.Drawing.Point(188, 346);
            this.TransformButton.Name = "TransformButton";
            this.TransformButton.Size = new System.Drawing.Size(225, 23);
            this.TransformButton.TabIndex = 25;
            this.TransformButton.Text = "Ttransform";
            this.TransformButton.UseVisualStyleBackColor = true;
            this.TransformButton.Click += new System.EventHandler(this.button11_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.TransformInputFile);
            this.groupBox7.Controls.Add(this.TransformInputBox);
            this.groupBox7.Controls.Add(this.TransformInputExplorer);
            this.groupBox7.Controls.Add(this.TransformInputBrowse);
            this.groupBox7.Location = new System.Drawing.Point(7, 20);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(406, 179);
            this.groupBox7.TabIndex = 30;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Cloud Of Points";
            // 
            // TransformInputFile
            // 
            this.TransformInputFile.Font = new System.Drawing.Font("Courier New", 10F);
            this.TransformInputFile.Location = new System.Drawing.Point(8, 17);
            this.TransformInputFile.Name = "TransformInputFile";
            this.TransformInputFile.ReadOnly = true;
            this.TransformInputFile.Size = new System.Drawing.Size(247, 23);
            this.TransformInputFile.TabIndex = 26;
            // 
            // TransformInputBox
            // 
            this.TransformInputBox.Font = new System.Drawing.Font("Courier New", 10F);
            this.TransformInputBox.Location = new System.Drawing.Point(8, 47);
            this.TransformInputBox.Multiline = true;
            this.TransformInputBox.Name = "TransformInputBox";
            this.TransformInputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TransformInputBox.Size = new System.Drawing.Size(392, 126);
            this.TransformInputBox.TabIndex = 25;
            // 
            // TransformInputExplorer
            // 
            this.TransformInputExplorer.Location = new System.Drawing.Point(261, 16);
            this.TransformInputExplorer.Name = "TransformInputExplorer";
            this.TransformInputExplorer.Size = new System.Drawing.Size(23, 23);
            this.TransformInputExplorer.TabIndex = 27;
            this.TransformInputExplorer.Text = "...";
            this.TransformInputExplorer.UseVisualStyleBackColor = true;
            this.TransformInputExplorer.Click += new System.EventHandler(this.TransformInputExplorer_Click);
            // 
            // TransformInputBrowse
            // 
            this.TransformInputBrowse.Location = new System.Drawing.Point(290, 16);
            this.TransformInputBrowse.Name = "TransformInputBrowse";
            this.TransformInputBrowse.Size = new System.Drawing.Size(110, 23);
            this.TransformInputBrowse.TabIndex = 25;
            this.TransformInputBrowse.Text = "Browse ...";
            this.TransformInputBrowse.UseVisualStyleBackColor = true;
            this.TransformInputBrowse.Click += new System.EventHandler(this.TransformInputBrowse_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.TransformMatrixBox);
            this.groupBox8.Controls.Add(this.TransformMatrixBrowse);
            this.groupBox8.Controls.Add(this.TransformMatrixExplorer);
            this.groupBox8.Controls.Add(this.TransformMatrixFile);
            this.groupBox8.Location = new System.Drawing.Point(7, 205);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(406, 135);
            this.groupBox8.TabIndex = 31;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Transform 4x4 Matrix";
            // 
            // TransformMatrixBox
            // 
            this.TransformMatrixBox.Font = new System.Drawing.Font("Courier New", 10F);
            this.TransformMatrixBox.Location = new System.Drawing.Point(8, 48);
            this.TransformMatrixBox.Multiline = true;
            this.TransformMatrixBox.Name = "TransformMatrixBox";
            this.TransformMatrixBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TransformMatrixBox.Size = new System.Drawing.Size(392, 80);
            this.TransformMatrixBox.TabIndex = 29;
            // 
            // TransformMatrixBrowse
            // 
            this.TransformMatrixBrowse.Location = new System.Drawing.Point(290, 19);
            this.TransformMatrixBrowse.Name = "TransformMatrixBrowse";
            this.TransformMatrixBrowse.Size = new System.Drawing.Size(110, 23);
            this.TransformMatrixBrowse.TabIndex = 28;
            this.TransformMatrixBrowse.Text = "Browse ...";
            this.TransformMatrixBrowse.UseVisualStyleBackColor = true;
            this.TransformMatrixBrowse.Click += new System.EventHandler(this.TransformMatrixBrowse_Click);
            // 
            // TransformMatrixExplorer
            // 
            this.TransformMatrixExplorer.Location = new System.Drawing.Point(261, 19);
            this.TransformMatrixExplorer.Name = "TransformMatrixExplorer";
            this.TransformMatrixExplorer.Size = new System.Drawing.Size(23, 23);
            this.TransformMatrixExplorer.TabIndex = 28;
            this.TransformMatrixExplorer.Text = "...";
            this.TransformMatrixExplorer.UseVisualStyleBackColor = true;
            this.TransformMatrixExplorer.Click += new System.EventHandler(this.TransformMatrixExplorer_Click);
            // 
            // TransformMatrixFile
            // 
            this.TransformMatrixFile.Font = new System.Drawing.Font("Courier New", 10F);
            this.TransformMatrixFile.Location = new System.Drawing.Point(8, 20);
            this.TransformMatrixFile.Name = "TransformMatrixFile";
            this.TransformMatrixFile.ReadOnly = true;
            this.TransformMatrixFile.Size = new System.Drawing.Size(247, 23);
            this.TransformMatrixFile.TabIndex = 28;
            // 
            // ClearAll
            // 
            this.ClearAll.Location = new System.Drawing.Point(194, 623);
            this.ClearAll.Name = "ClearAll";
            this.ClearAll.Size = new System.Drawing.Size(116, 23);
            this.ClearAll.TabIndex = 18;
            this.ClearAll.Text = "Clear All";
            this.ClearAll.UseVisualStyleBackColor = true;
            this.ClearAll.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // ClearInput
            // 
            this.ClearInput.Location = new System.Drawing.Point(316, 623);
            this.ClearInput.Name = "ClearInput";
            this.ClearInput.Size = new System.Drawing.Size(116, 23);
            this.ClearInput.TabIndex = 19;
            this.ClearInput.Text = "Clear Input";
            this.ClearInput.UseVisualStyleBackColor = true;
            this.ClearInput.Click += new System.EventHandler(this.ClearInput_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(12, 623);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(116, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save As ...";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MultiplyButton);
            this.groupBox3.Controls.Add(this.MultiplyBox2);
            this.groupBox3.Controls.Add(this.MultiplyBox1);
            this.groupBox3.Location = new System.Drawing.Point(989, 423);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(419, 223);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "4x4 Matrix Multiplication";
            // 
            // MultiplyButton
            // 
            this.MultiplyButton.Location = new System.Drawing.Point(188, 191);
            this.MultiplyButton.Name = "MultiplyButton";
            this.MultiplyButton.Size = new System.Drawing.Size(225, 23);
            this.MultiplyButton.TabIndex = 25;
            this.MultiplyButton.Text = "Multiply Matrices";
            this.MultiplyButton.UseVisualStyleBackColor = true;
            this.MultiplyButton.Click += new System.EventHandler(this.MultiplyButton_Click);
            // 
            // MultiplyBox2
            // 
            this.MultiplyBox2.Font = new System.Drawing.Font("Courier New", 10F);
            this.MultiplyBox2.Location = new System.Drawing.Point(9, 105);
            this.MultiplyBox2.Multiline = true;
            this.MultiplyBox2.Name = "MultiplyBox2";
            this.MultiplyBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MultiplyBox2.Size = new System.Drawing.Size(404, 80);
            this.MultiplyBox2.TabIndex = 26;
            // 
            // MultiplyBox1
            // 
            this.MultiplyBox1.Font = new System.Drawing.Font("Courier New", 10F);
            this.MultiplyBox1.Location = new System.Drawing.Point(9, 19);
            this.MultiplyBox1.Multiline = true;
            this.MultiplyBox1.Name = "MultiplyBox1";
            this.MultiplyBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MultiplyBox1.Size = new System.Drawing.Size(404, 80);
            this.MultiplyBox1.TabIndex = 25;
            // 
            // AutomaticButton
            // 
            this.AutomaticButton.Location = new System.Drawing.Point(6, 420);
            this.AutomaticButton.Name = "AutomaticButton";
            this.AutomaticButton.Size = new System.Drawing.Size(407, 23);
            this.AutomaticButton.TabIndex = 25;
            this.AutomaticButton.Text = "• Automatic Calculation";
            this.AutomaticButton.UseVisualStyleBackColor = true;
            this.AutomaticButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1417, 655);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ClearAll);
            this.Controls.Add(this.ClearInput);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DotCheck);
            this.Controls.Add(this.ClearOutput);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "3D BestFit Transformation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.TextBox OutputBox;
        private System.Windows.Forms.Button MovingBrowse;
        private System.Windows.Forms.Button FixedBrowse;
        private System.Windows.Forms.TextBox MovingFile;
        private System.Windows.Forms.TextBox FixedFile;
        private System.Windows.Forms.Button ClearOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ConvertBox;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.Button ConvertBrowse;
        private System.Windows.Forms.TextBox ConvertFile;
        private System.Windows.Forms.CheckBox DotCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button FixedExplorer;
        private System.Windows.Forms.Button MovingExplorer;
        private System.Windows.Forms.Button ConvertExplorer;
        private System.Windows.Forms.CheckBox BestFitAdditionalCheck;
        private System.Windows.Forms.CheckBox ConvertAdditionalCheck;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button TransformButton;
        private System.Windows.Forms.TextBox TransformMatrixBox;
        private System.Windows.Forms.TextBox TransformInputBox;
        private System.Windows.Forms.CheckBox InverseCheck;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox FixedBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox MovingBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox TransformInputFile;
        private System.Windows.Forms.Button TransformInputExplorer;
        private System.Windows.Forms.Button TransformInputBrowse;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button TransformMatrixBrowse;
        private System.Windows.Forms.Button TransformMatrixExplorer;
        private System.Windows.Forms.TextBox TransformMatrixFile;
        private System.Windows.Forms.Button ClearAll;
        private System.Windows.Forms.Button ClearInput;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button MultiplyButton;
        private System.Windows.Forms.TextBox MultiplyBox2;
        private System.Windows.Forms.TextBox MultiplyBox1;
        private System.Windows.Forms.Button AutomaticButton;
    }
}

