namespace NaiveBayesClassifier
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.insertLbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.insertBtn = new System.Windows.Forms.Button();
            this.resultLbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ClassifyBtn = new System.Windows.Forms.Button();
            this.footSizeTxtBox = new System.Windows.Forms.TextBox();
            this.heightTxtBox = new System.Windows.Forms.TextBox();
            this.weightTxtBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.learningRateTxtBox = new System.Windows.Forms.TextBox();
            this.annTrainBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tresholdTxtBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.resultAnnLbl = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.ClassifyAnnBtn = new System.Windows.Forms.Button();
            this.footSizeAnnTxt = new System.Windows.Forms.TextBox();
            this.heightAnnTxt = new System.Windows.Forms.TextBox();
            this.weightAnnTxt = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.trainLbl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.groupBox2.Size = new System.Drawing.Size(845, 141);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Naive Bayes - Training";
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
            this.trainBtn.Text = "Train Data Set";
            this.trainBtn.UseVisualStyleBackColor = true;
            this.trainBtn.Click += new System.EventHandler(this.trainBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.insertLbl);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.insertBtn);
            this.groupBox3.Controls.Add(this.resultLbl);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.ClassifyBtn);
            this.groupBox3.Controls.Add(this.footSizeTxtBox);
            this.groupBox3.Controls.Add(this.heightTxtBox);
            this.groupBox3.Controls.Add(this.weightTxtBox);
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
            // insertLbl
            // 
            this.insertLbl.AutoSize = true;
            this.insertLbl.Location = new System.Drawing.Point(347, 63);
            this.insertLbl.Name = "insertLbl";
            this.insertLbl.Size = new System.Drawing.Size(0, 13);
            this.insertLbl.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(301, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Status:";
            // 
            // insertBtn
            // 
            this.insertBtn.Location = new System.Drawing.Point(304, 15);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(89, 40);
            this.insertBtn.TabIndex = 10;
            this.insertBtn.Text = "Insert Element Database";
            this.insertBtn.UseVisualStyleBackColor = true;
            this.insertBtn.Click += new System.EventHandler(this.insertBtn_Click);
            // 
            // resultLbl
            // 
            this.resultLbl.AutoSize = true;
            this.resultLbl.Location = new System.Drawing.Point(233, 63);
            this.resultLbl.Name = "resultLbl";
            this.resultLbl.Size = new System.Drawing.Size(32, 13);
            this.resultLbl.TabIndex = 9;
            this.resultLbl.Text = "result";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(187, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Result:";
            // 
            // ClassifyBtn
            // 
            this.ClassifyBtn.Location = new System.Drawing.Point(190, 15);
            this.ClassifyBtn.Name = "ClassifyBtn";
            this.ClassifyBtn.Size = new System.Drawing.Size(89, 40);
            this.ClassifyBtn.TabIndex = 7;
            this.ClassifyBtn.Text = "Classify";
            this.ClassifyBtn.UseVisualStyleBackColor = true;
            this.ClassifyBtn.Click += new System.EventHandler(this.ClassifyBtn_Click);
            // 
            // footSizeTxtBox
            // 
            this.footSizeTxtBox.Location = new System.Drawing.Point(76, 86);
            this.footSizeTxtBox.Name = "footSizeTxtBox";
            this.footSizeTxtBox.Size = new System.Drawing.Size(85, 20);
            this.footSizeTxtBox.TabIndex = 6;
            // 
            // heightTxtBox
            // 
            this.heightTxtBox.Location = new System.Drawing.Point(76, 35);
            this.heightTxtBox.Name = "heightTxtBox";
            this.heightTxtBox.Size = new System.Drawing.Size(85, 20);
            this.heightTxtBox.TabIndex = 5;
            // 
            // weightTxtBox
            // 
            this.weightTxtBox.Location = new System.Drawing.Point(76, 60);
            this.weightTxtBox.Name = "weightTxtBox";
            this.weightTxtBox.Size = new System.Drawing.Size(85, 20);
            this.weightTxtBox.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(6, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Foot Size:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(6, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Weight: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(6, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Height: ";
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Location = new System.Drawing.Point(14, 303);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(842, 219);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Artificial Neural Networks";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.result);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.trainLbl);
            this.groupBox5.Controls.Add(this.learningRateTxtBox);
            this.groupBox5.Controls.Add(this.annTrainBtn);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.tresholdTxtBox);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(6, 18);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(378, 143);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Train";
            // 
            // learningRateTxtBox
            // 
            this.learningRateTxtBox.Location = new System.Drawing.Point(242, 13);
            this.learningRateTxtBox.Name = "learningRateTxtBox";
            this.learningRateTxtBox.Size = new System.Drawing.Size(25, 20);
            this.learningRateTxtBox.TabIndex = 4;
            // 
            // annTrainBtn
            // 
            this.annTrainBtn.Location = new System.Drawing.Point(6, 39);
            this.annTrainBtn.Name = "annTrainBtn";
            this.annTrainBtn.Size = new System.Drawing.Size(70, 24);
            this.annTrainBtn.TabIndex = 0;
            this.annTrainBtn.Text = "Train";
            this.annTrainBtn.UseVisualStyleBackColor = true;
            this.annTrainBtn.Click += new System.EventHandler(this.annTrainBtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(139, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Learnig Rate(%):";
            // 
            // tresholdTxtBox
            // 
            this.tresholdTxtBox.Location = new System.Drawing.Point(93, 13);
            this.tresholdTxtBox.Name = "tresholdTxtBox";
            this.tresholdTxtBox.Size = new System.Drawing.Size(25, 20);
            this.tresholdTxtBox.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Treshold(%): ";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.resultAnnLbl);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.ClassifyAnnBtn);
            this.groupBox6.Controls.Add(this.footSizeAnnTxt);
            this.groupBox6.Controls.Add(this.heightAnnTxt);
            this.groupBox6.Controls.Add(this.weightAnnTxt);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Location = new System.Drawing.Point(399, 18);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(368, 143);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Test";
            // 
            // resultAnnLbl
            // 
            this.resultAnnLbl.AutoSize = true;
            this.resultAnnLbl.Location = new System.Drawing.Point(219, 70);
            this.resultAnnLbl.Name = "resultAnnLbl";
            this.resultAnnLbl.Size = new System.Drawing.Size(32, 13);
            this.resultAnnLbl.TabIndex = 19;
            this.resultAnnLbl.Text = "result";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(173, 70);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "Result:";
            // 
            // ClassifyAnnBtn
            // 
            this.ClassifyAnnBtn.Location = new System.Drawing.Point(176, 22);
            this.ClassifyAnnBtn.Name = "ClassifyAnnBtn";
            this.ClassifyAnnBtn.Size = new System.Drawing.Size(89, 40);
            this.ClassifyAnnBtn.TabIndex = 17;
            this.ClassifyAnnBtn.Text = "Classify";
            this.ClassifyAnnBtn.UseVisualStyleBackColor = true;
            this.ClassifyAnnBtn.Click += new System.EventHandler(this.ClassifyAnnBtn_Click);
            // 
            // footSizeAnnTxt
            // 
            this.footSizeAnnTxt.Location = new System.Drawing.Point(76, 93);
            this.footSizeAnnTxt.Name = "footSizeAnnTxt";
            this.footSizeAnnTxt.Size = new System.Drawing.Size(85, 20);
            this.footSizeAnnTxt.TabIndex = 16;
            // 
            // heightAnnTxt
            // 
            this.heightAnnTxt.Location = new System.Drawing.Point(76, 42);
            this.heightAnnTxt.Name = "heightAnnTxt";
            this.heightAnnTxt.Size = new System.Drawing.Size(85, 20);
            this.heightAnnTxt.TabIndex = 15;
            // 
            // weightAnnTxt
            // 
            this.weightAnnTxt.Location = new System.Drawing.Point(76, 67);
            this.weightAnnTxt.Name = "weightAnnTxt";
            this.weightAnnTxt.Size = new System.Drawing.Size(85, 20);
            this.weightAnnTxt.TabIndex = 14;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label20.Location = new System.Drawing.Point(6, 96);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 13);
            this.label20.TabIndex = 13;
            this.label20.Text = "Foot Size:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label21.Location = new System.Drawing.Point(6, 67);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 13);
            this.label21.TabIndex = 12;
            this.label21.Text = "Weight: ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label22.Location = new System.Drawing.Point(6, 45);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(52, 13);
            this.label22.TabIndex = 11;
            this.label22.Text = "Height: ";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label23.Location = new System.Drawing.Point(6, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(155, 13);
            this.label23.TabIndex = 10;
            this.label23.Text = "Please Enter Properties of Data";
            // 
            // trainLbl
            // 
            this.trainLbl.AutoSize = true;
            this.trainLbl.Location = new System.Drawing.Point(90, 45);
            this.trainLbl.Name = "trainLbl";
            this.trainLbl.Size = new System.Drawing.Size(37, 13);
            this.trainLbl.TabIndex = 5;
            this.trainLbl.Text = "Status";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Number Of Iteration: ";
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(117, 93);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(0, 13);
            this.result.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 537);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Classifier";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox heightTxtBox;
        private System.Windows.Forms.TextBox weightTxtBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox footSizeTxtBox;
        private System.Windows.Forms.Label resultLbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ClassifyBtn;
        private System.Windows.Forms.Button insertBtn;
        private System.Windows.Forms.Label insertLbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button annTrainBtn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox learningRateTxtBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tresholdTxtBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label resultAnnLbl;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button ClassifyAnnBtn;
        private System.Windows.Forms.TextBox footSizeAnnTxt;
        private System.Windows.Forms.TextBox heightAnnTxt;
        private System.Windows.Forms.TextBox weightAnnTxt;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label trainLbl;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Label label12;
    }
}

