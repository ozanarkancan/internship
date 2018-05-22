namespace Text_CLassification
{
    partial class NaiveBayesForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.crossValidationCheck = new System.Windows.Forms.CheckBox();
            this.trainBtn = new System.Windows.Forms.Button();
            this.trainPartTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.testBtn = new System.Windows.Forms.Button();
            this.testPartTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.returnMainBtn = new System.Windows.Forms.Button();
            this.accuracyLbl = new System.Windows.Forms.Label();
            this.accuracyLbl2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.crossValidationCheck);
            this.groupBox2.Controls.Add(this.trainBtn);
            this.groupBox2.Controls.Add(this.trainPartTxt);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(25, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 108);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Train";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "2   Cross",
            "5   Cross",
            "10 Cross"});
            this.comboBox1.Location = new System.Drawing.Point(113, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(77, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // crossValidationCheck
            // 
            this.crossValidationCheck.AutoSize = true;
            this.crossValidationCheck.Location = new System.Drawing.Point(6, 19);
            this.crossValidationCheck.Name = "crossValidationCheck";
            this.crossValidationCheck.Size = new System.Drawing.Size(101, 17);
            this.crossValidationCheck.TabIndex = 9;
            this.crossValidationCheck.Text = "Cross Validation";
            this.crossValidationCheck.UseVisualStyleBackColor = true;
            this.crossValidationCheck.CheckedChanged += new System.EventHandler(this.crossValidationCheck_CheckedChanged);
            // 
            // trainBtn
            // 
            this.trainBtn.Location = new System.Drawing.Point(127, 58);
            this.trainBtn.Name = "trainBtn";
            this.trainBtn.Size = new System.Drawing.Size(63, 36);
            this.trainBtn.TabIndex = 6;
            this.trainBtn.Text = "TRAIN";
            this.trainBtn.UseVisualStyleBackColor = true;
            this.trainBtn.Click += new System.EventHandler(this.trainBtn_Click);
            // 
            // trainPartTxt
            // 
            this.trainPartTxt.Location = new System.Drawing.Point(18, 74);
            this.trainPartTxt.Name = "trainPartTxt";
            this.trainPartTxt.Size = new System.Drawing.Size(69, 20);
            this.trainPartTxt.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "TrainWithDataSet(%)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.testBtn);
            this.groupBox1.Controls.Add(this.testPartTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(310, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 108);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test";
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(12, 73);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(75, 29);
            this.testBtn.TabIndex = 13;
            this.testBtn.Text = "TEST";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // testPartTxt
            // 
            this.testPartTxt.Location = new System.Drawing.Point(12, 34);
            this.testPartTxt.Name = "testPartTxt";
            this.testPartTxt.Size = new System.Drawing.Size(69, 20);
            this.testPartTxt.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "TestWithDataSet(%)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(269, 283);
            this.dataGridView1.TabIndex = 4;
            // 
            // returnMainBtn
            // 
            this.returnMainBtn.Location = new System.Drawing.Point(370, 385);
            this.returnMainBtn.Name = "returnMainBtn";
            this.returnMainBtn.Size = new System.Drawing.Size(70, 39);
            this.returnMainBtn.TabIndex = 5;
            this.returnMainBtn.Text = "RETURN MAIN";
            this.returnMainBtn.UseVisualStyleBackColor = true;
            this.returnMainBtn.Click += new System.EventHandler(this.returnMainBtn_Click);
            // 
            // accuracyLbl
            // 
            this.accuracyLbl.AutoSize = true;
            this.accuracyLbl.Location = new System.Drawing.Point(341, 141);
            this.accuracyLbl.Name = "accuracyLbl";
            this.accuracyLbl.Size = new System.Drawing.Size(52, 13);
            this.accuracyLbl.TabIndex = 6;
            this.accuracyLbl.Text = "Accuracy";
            // 
            // accuracyLbl2
            // 
            this.accuracyLbl2.AutoSize = true;
            this.accuracyLbl2.Location = new System.Drawing.Point(341, 170);
            this.accuracyLbl2.Name = "accuracyLbl2";
            this.accuracyLbl2.Size = new System.Drawing.Size(0, 13);
            this.accuracyLbl2.TabIndex = 7;
            // 
            // NaiveBayesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 462);
            this.Controls.Add(this.accuracyLbl2);
            this.Controls.Add(this.accuracyLbl);
            this.Controls.Add(this.returnMainBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "NaiveBayesForm";
            this.Text = "Naive Bayes Classifier";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NaiveBayesForm_FormClosed);
            this.Load += new System.EventHandler(this.NaiveBayesForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox crossValidationCheck;
        private System.Windows.Forms.Button trainBtn;
        private System.Windows.Forms.TextBox trainPartTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.TextBox testPartTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button returnMainBtn;
        private System.Windows.Forms.Label accuracyLbl;
        private System.Windows.Forms.Label accuracyLbl2;
    }
}