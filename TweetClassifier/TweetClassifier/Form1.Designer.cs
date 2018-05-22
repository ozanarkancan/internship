namespace TweetClassifier
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.collectionNameTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dbStatusLbl = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.dbNameTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.trainBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pSmilesTxtBox = new System.Windows.Forms.TextBox();
            this.pWordsTxtBox = new System.Windows.Forms.TextBox();
            this.nSmilesTxtBox = new System.Windows.Forms.TextBox();
            this.ClassifyBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.resultLbl = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.trainAndTestCrossBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.nWordsTxtBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.collectionNameTxtBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dbStatusLbl);
            this.groupBox1.Controls.Add(this.connectBtn);
            this.groupBox1.Controls.Add(this.dbNameTxtBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database";
            // 
            // collectionNameTxtBox
            // 
            this.collectionNameTxtBox.Location = new System.Drawing.Point(118, 49);
            this.collectionNameTxtBox.Name = "collectionNameTxtBox";
            this.collectionNameTxtBox.Size = new System.Drawing.Size(76, 20);
            this.collectionNameTxtBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(11, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Collection Name:";
            // 
            // dbStatusLbl
            // 
            this.dbStatusLbl.AutoSize = true;
            this.dbStatusLbl.Location = new System.Drawing.Point(115, 97);
            this.dbStatusLbl.Name = "dbStatusLbl";
            this.dbStatusLbl.Size = new System.Drawing.Size(37, 13);
            this.dbStatusLbl.TabIndex = 3;
            this.dbStatusLbl.Text = "Status";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(14, 87);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(69, 32);
            this.connectBtn.TabIndex = 2;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // dbNameTxtBox
            // 
            this.dbNameTxtBox.Location = new System.Drawing.Point(118, 23);
            this.dbNameTxtBox.Name = "dbNameTxtBox";
            this.dbNameTxtBox.Size = new System.Drawing.Size(76, 20);
            this.dbNameTxtBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.trainBtn);
            this.groupBox2.Location = new System.Drawing.Point(12, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(845, 146);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Training";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(412, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Train Result";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(90, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(744, 104);
            this.dataGridView1.TabIndex = 1;
            // 
            // trainBtn
            // 
            this.trainBtn.Location = new System.Drawing.Point(6, 31);
            this.trainBtn.Name = "trainBtn";
            this.trainBtn.Size = new System.Drawing.Size(63, 104);
            this.trainBtn.TabIndex = 0;
            this.trainBtn.Text = "Train All Data Set";
            this.trainBtn.UseVisualStyleBackColor = true;
            this.trainBtn.Click += new System.EventHandler(this.trainBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(6, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Please Enter Properties of Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(6, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "pozitiveWords:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(218, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "pozitiveSmiles:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(218, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "negativeSmiles:";
            // 
            // pSmilesTxtBox
            // 
            this.pSmilesTxtBox.Location = new System.Drawing.Point(320, 34);
            this.pSmilesTxtBox.Name = "pSmilesTxtBox";
            this.pSmilesTxtBox.Size = new System.Drawing.Size(85, 20);
            this.pSmilesTxtBox.TabIndex = 4;
            // 
            // pWordsTxtBox
            // 
            this.pWordsTxtBox.Location = new System.Drawing.Point(114, 34);
            this.pWordsTxtBox.Name = "pWordsTxtBox";
            this.pWordsTxtBox.Size = new System.Drawing.Size(85, 20);
            this.pWordsTxtBox.TabIndex = 5;
            // 
            // nSmilesTxtBox
            // 
            this.nSmilesTxtBox.Location = new System.Drawing.Point(320, 60);
            this.nSmilesTxtBox.Name = "nSmilesTxtBox";
            this.nSmilesTxtBox.Size = new System.Drawing.Size(85, 20);
            this.nSmilesTxtBox.TabIndex = 6;
            // 
            // ClassifyBtn
            // 
            this.ClassifyBtn.Location = new System.Drawing.Point(451, 16);
            this.ClassifyBtn.Name = "ClassifyBtn";
            this.ClassifyBtn.Size = new System.Drawing.Size(89, 40);
            this.ClassifyBtn.TabIndex = 7;
            this.ClassifyBtn.Text = "Classify Element";
            this.ClassifyBtn.UseVisualStyleBackColor = true;
            this.ClassifyBtn.Click += new System.EventHandler(this.ClassifyBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(448, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Result:";
            // 
            // resultLbl
            // 
            this.resultLbl.AutoSize = true;
            this.resultLbl.Location = new System.Drawing.Point(494, 63);
            this.resultLbl.Name = "resultLbl";
            this.resultLbl.Size = new System.Drawing.Size(32, 13);
            this.resultLbl.TabIndex = 9;
            this.resultLbl.Text = "result";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nWordsTxtBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.resultLbl);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.ClassifyBtn);
            this.groupBox3.Controls.Add(this.nSmilesTxtBox);
            this.groupBox3.Controls.Add(this.pWordsTxtBox);
            this.groupBox3.Controls.Add(this.pSmilesTxtBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(293, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(564, 124);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Classification";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView2);
            this.groupBox4.Controls.Add(this.trainAndTestCrossBtn);
            this.groupBox4.Location = new System.Drawing.Point(15, 305);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(841, 246);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ten Cross Validation";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(87, 18);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(744, 222);
            this.dataGridView2.TabIndex = 1;
            // 
            // trainAndTestCrossBtn
            // 
            this.trainAndTestCrossBtn.Location = new System.Drawing.Point(6, 30);
            this.trainAndTestCrossBtn.Name = "trainAndTestCrossBtn";
            this.trainAndTestCrossBtn.Size = new System.Drawing.Size(60, 138);
            this.trainAndTestCrossBtn.TabIndex = 0;
            this.trainAndTestCrossBtn.Text = "Train And Test";
            this.trainAndTestCrossBtn.UseVisualStyleBackColor = true;
            this.trainAndTestCrossBtn.Click += new System.EventHandler(this.trainAndTestCrossBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(6, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "negativeWords:";
            // 
            // nWordsTxtBox
            // 
            this.nWordsTxtBox.Location = new System.Drawing.Point(114, 60);
            this.nWordsTxtBox.Name = "nWordsTxtBox";
            this.nWordsTxtBox.Size = new System.Drawing.Size(85, 20);
            this.nWordsTxtBox.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 563);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Naive Bayes Classifier";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label dbStatusLbl;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.TextBox dbNameTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox collectionNameTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button trainBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox pSmilesTxtBox;
        private System.Windows.Forms.TextBox pWordsTxtBox;
        private System.Windows.Forms.TextBox nSmilesTxtBox;
        private System.Windows.Forms.Button ClassifyBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label resultLbl;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button trainAndTestCrossBtn;
        private System.Windows.Forms.TextBox nWordsTxtBox;
        private System.Windows.Forms.Label label9;
    }
}

