namespace Text_CLassification
{
    partial class PerceptronForm
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
            this.createBtn = new System.Windows.Forms.Button();
            this.outputTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trainPartTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.trainBtn = new System.Windows.Forms.Button();
            this.learningRateTxt = new System.Windows.Forms.TextBox();
            this.tresholdTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.shuffleCheck = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numberOfIterationLbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.minRateLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.iterationLimitTxt = new System.Windows.Forms.TextBox();
            this.rateLimitTxt = new System.Windows.Forms.TextBox();
            this.iterationLimitCheck = new System.Windows.Forms.CheckBox();
            this.rateLimitCheck = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.accuracyLbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.testBtn = new System.Windows.Forms.Button();
            this.testPartTxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.returnMainBtn = new System.Windows.Forms.Button();
            this.saveNetworkBtn = new System.Windows.Forms.Button();
            this.resetWeightBtn = new System.Windows.Forms.Button();
            this.resetNetworkBtn = new System.Windows.Forms.Button();
            this.loadNetworkBtn = new System.Windows.Forms.Button();
            this.networkCombo = new System.Windows.Forms.ComboBox();
            this.getNetworksBtn = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.createBtn);
            this.groupBox1.Controls.Add(this.outputTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.inputTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perceptron Design";
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(228, 19);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(58, 48);
            this.createBtn.TabIndex = 4;
            this.createBtn.Text = "CREATE";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // outputTxt
            // 
            this.outputTxt.Location = new System.Drawing.Point(177, 50);
            this.outputTxt.Name = "outputTxt";
            this.outputTxt.Size = new System.Drawing.Size(36, 20);
            this.outputTxt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of neurons in output layer: ";
            // 
            // inputTxt
            // 
            this.inputTxt.Location = new System.Drawing.Point(177, 22);
            this.inputTxt.Name = "inputTxt";
            this.inputTxt.Size = new System.Drawing.Size(36, 20);
            this.inputTxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of neurons in input layer: ";
            // 
            // trainPartTxt
            // 
            this.trainPartTxt.Location = new System.Drawing.Point(208, 36);
            this.trainPartTxt.Name = "trainPartTxt";
            this.trainPartTxt.Size = new System.Drawing.Size(69, 20);
            this.trainPartTxt.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "TrainWithDataSet(%)";
            // 
            // trainBtn
            // 
            this.trainBtn.Location = new System.Drawing.Point(6, 165);
            this.trainBtn.Name = "trainBtn";
            this.trainBtn.Size = new System.Drawing.Size(62, 69);
            this.trainBtn.TabIndex = 6;
            this.trainBtn.Text = "TRAIN";
            this.trainBtn.UseVisualStyleBackColor = true;
            this.trainBtn.Click += new System.EventHandler(this.trainBtn_Click);
            // 
            // learningRateTxt
            // 
            this.learningRateTxt.Location = new System.Drawing.Point(87, 36);
            this.learningRateTxt.Name = "learningRateTxt";
            this.learningRateTxt.Size = new System.Drawing.Size(52, 20);
            this.learningRateTxt.TabIndex = 3;
            // 
            // tresholdTxt
            // 
            this.tresholdTxt.Location = new System.Drawing.Point(18, 36);
            this.tresholdTxt.Name = "tresholdTxt";
            this.tresholdTxt.Size = new System.Drawing.Size(31, 20);
            this.tresholdTxt.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Learning Rate(%)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Treshold(%)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.shuffleCheck);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.iterationLimitTxt);
            this.groupBox2.Controls.Add(this.rateLimitTxt);
            this.groupBox2.Controls.Add(this.iterationLimitCheck);
            this.groupBox2.Controls.Add(this.rateLimitCheck);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.trainBtn);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tresholdTxt);
            this.groupBox2.Controls.Add(this.trainPartTxt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.learningRateTxt);
            this.groupBox2.Location = new System.Drawing.Point(12, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 241);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Train";
            // 
            // shuffleCheck
            // 
            this.shuffleCheck.AutoSize = true;
            this.shuffleCheck.Location = new System.Drawing.Point(168, 124);
            this.shuffleCheck.Name = "shuffleCheck";
            this.shuffleCheck.Size = new System.Drawing.Size(105, 17);
            this.shuffleCheck.TabIndex = 19;
            this.shuffleCheck.Text = "Shuffle Train Set";
            this.shuffleCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numberOfIterationLbl);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.minRateLbl);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(164, 157);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(254, 77);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Train Results";
            // 
            // numberOfIterationLbl
            // 
            this.numberOfIterationLbl.AutoSize = true;
            this.numberOfIterationLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numberOfIterationLbl.Location = new System.Drawing.Point(113, 45);
            this.numberOfIterationLbl.Name = "numberOfIterationLbl";
            this.numberOfIterationLbl.Size = new System.Drawing.Size(54, 13);
            this.numberOfIterationLbl.TabIndex = 3;
            this.numberOfIterationLbl.Text = "Iteration";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Number of Iterations:";
            // 
            // minRateLbl
            // 
            this.minRateLbl.AutoSize = true;
            this.minRateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.minRateLbl.Location = new System.Drawing.Point(113, 20);
            this.minRateLbl.Name = "minRateLbl";
            this.minRateLbl.Size = new System.Drawing.Size(54, 13);
            this.minRateLbl.TabIndex = 1;
            this.minRateLbl.Text = "MinRate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Minimum Train Rate:";
            // 
            // iterationLimitTxt
            // 
            this.iterationLimitTxt.Location = new System.Drawing.Point(285, 98);
            this.iterationLimitTxt.Name = "iterationLimitTxt";
            this.iterationLimitTxt.Size = new System.Drawing.Size(40, 20);
            this.iterationLimitTxt.TabIndex = 18;
            // 
            // rateLimitTxt
            // 
            this.rateLimitTxt.Location = new System.Drawing.Point(285, 75);
            this.rateLimitTxt.Name = "rateLimitTxt";
            this.rateLimitTxt.Size = new System.Drawing.Size(40, 20);
            this.rateLimitTxt.TabIndex = 17;
            // 
            // iterationLimitCheck
            // 
            this.iterationLimitCheck.AutoSize = true;
            this.iterationLimitCheck.Location = new System.Drawing.Point(168, 101);
            this.iterationLimitCheck.Name = "iterationLimitCheck";
            this.iterationLimitCheck.Size = new System.Drawing.Size(88, 17);
            this.iterationLimitCheck.TabIndex = 14;
            this.iterationLimitCheck.Text = "Iteration Limit";
            this.iterationLimitCheck.UseVisualStyleBackColor = true;
            this.iterationLimitCheck.CheckedChanged += new System.EventHandler(this.iterationLimitCheck_CheckedChanged);
            // 
            // rateLimitCheck
            // 
            this.rateLimitCheck.AutoSize = true;
            this.rateLimitCheck.Location = new System.Drawing.Point(168, 78);
            this.rateLimitCheck.Name = "rateLimitCheck";
            this.rateLimitCheck.Size = new System.Drawing.Size(114, 17);
            this.rateLimitCheck.TabIndex = 13;
            this.rateLimitCheck.Text = "Train Rate Limit(%)";
            this.rateLimitCheck.UseVisualStyleBackColor = true;
            this.rateLimitCheck.CheckedChanged += new System.EventHandler(this.rateLimitCheck_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Function";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Linear",
            "Sigmoid",
            "Hyperbolic Tangent"});
            this.comboBox1.Location = new System.Drawing.Point(60, 87);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.accuracyLbl);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.testBtn);
            this.groupBox4.Controls.Add(this.testPartTxt);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(442, 121);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(262, 140);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Test";
            // 
            // accuracyLbl
            // 
            this.accuracyLbl.AutoSize = true;
            this.accuracyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.accuracyLbl.Location = new System.Drawing.Point(112, 57);
            this.accuracyLbl.Name = "accuracyLbl";
            this.accuracyLbl.Size = new System.Drawing.Size(59, 13);
            this.accuracyLbl.TabIndex = 1;
            this.accuracyLbl.Text = "accuracy";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Total Accuracy:";
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(9, 87);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(52, 40);
            this.testBtn.TabIndex = 12;
            this.testBtn.Text = "TEST";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // testPartTxt
            // 
            this.testPartTxt.Location = new System.Drawing.Point(115, 22);
            this.testPartTxt.Name = "testPartTxt";
            this.testPartTxt.Size = new System.Drawing.Size(52, 20);
            this.testPartTxt.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "TestWithDataSet(%)";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.returnMainBtn);
            this.groupBox6.Controls.Add(this.saveNetworkBtn);
            this.groupBox6.Controls.Add(this.resetWeightBtn);
            this.groupBox6.Controls.Add(this.resetNetworkBtn);
            this.groupBox6.Location = new System.Drawing.Point(16, 367);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(420, 74);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            // 
            // returnMainBtn
            // 
            this.returnMainBtn.Location = new System.Drawing.Point(331, 19);
            this.returnMainBtn.Name = "returnMainBtn";
            this.returnMainBtn.Size = new System.Drawing.Size(74, 44);
            this.returnMainBtn.TabIndex = 6;
            this.returnMainBtn.Text = "RETURN MAİN";
            this.returnMainBtn.UseVisualStyleBackColor = true;
            this.returnMainBtn.Click += new System.EventHandler(this.returnMainBtn_Click);
            // 
            // saveNetworkBtn
            // 
            this.saveNetworkBtn.Location = new System.Drawing.Point(157, 19);
            this.saveNetworkBtn.Name = "saveNetworkBtn";
            this.saveNetworkBtn.Size = new System.Drawing.Size(74, 44);
            this.saveNetworkBtn.TabIndex = 2;
            this.saveNetworkBtn.Text = "SAVE NETWORK";
            this.saveNetworkBtn.UseVisualStyleBackColor = true;
            this.saveNetworkBtn.Click += new System.EventHandler(this.saveNetworkBtn_Click);
            // 
            // resetWeightBtn
            // 
            this.resetWeightBtn.Location = new System.Drawing.Point(83, 19);
            this.resetWeightBtn.Name = "resetWeightBtn";
            this.resetWeightBtn.Size = new System.Drawing.Size(68, 44);
            this.resetWeightBtn.TabIndex = 1;
            this.resetWeightBtn.Text = "RESET WEIGHT";
            this.resetWeightBtn.UseVisualStyleBackColor = true;
            this.resetWeightBtn.Click += new System.EventHandler(this.resetWeightBtn_Click);
            // 
            // resetNetworkBtn
            // 
            this.resetNetworkBtn.Location = new System.Drawing.Point(6, 19);
            this.resetNetworkBtn.Name = "resetNetworkBtn";
            this.resetNetworkBtn.Size = new System.Drawing.Size(71, 44);
            this.resetNetworkBtn.TabIndex = 0;
            this.resetNetworkBtn.Text = "RESET NETWORK";
            this.resetNetworkBtn.UseVisualStyleBackColor = true;
            this.resetNetworkBtn.Click += new System.EventHandler(this.resetNetworkBtn_Click);
            // 
            // loadNetworkBtn
            // 
            this.loadNetworkBtn.Location = new System.Drawing.Point(177, 112);
            this.loadNetworkBtn.Name = "loadNetworkBtn";
            this.loadNetworkBtn.Size = new System.Drawing.Size(79, 44);
            this.loadNetworkBtn.TabIndex = 5;
            this.loadNetworkBtn.Text = "LOAD NETWORK";
            this.loadNetworkBtn.UseVisualStyleBackColor = true;
            this.loadNetworkBtn.Click += new System.EventHandler(this.loadNetworkBtn_Click);
            // 
            // networkCombo
            // 
            this.networkCombo.FormattingEnabled = true;
            this.networkCombo.Location = new System.Drawing.Point(6, 15);
            this.networkCombo.Name = "networkCombo";
            this.networkCombo.Size = new System.Drawing.Size(165, 21);
            this.networkCombo.TabIndex = 4;
            this.networkCombo.SelectedIndexChanged += new System.EventHandler(this.networkCombo_SelectedIndexChanged);
            // 
            // getNetworksBtn
            // 
            this.getNetworksBtn.Location = new System.Drawing.Point(177, 11);
            this.getNetworksBtn.Name = "getNetworksBtn";
            this.getNetworksBtn.Size = new System.Drawing.Size(79, 46);
            this.getNetworksBtn.TabIndex = 3;
            this.getNetworksBtn.Text = "GET NETWORKS";
            this.getNetworksBtn.UseVisualStyleBackColor = true;
            this.getNetworksBtn.Click += new System.EventHandler(this.getNetworksBtn_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.infoLabel.Location = new System.Drawing.Point(315, 47);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(0, 16);
            this.infoLabel.TabIndex = 4;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.richTextBox1);
            this.groupBox5.Controls.Add(this.getNetworksBtn);
            this.groupBox5.Controls.Add(this.loadNetworkBtn);
            this.groupBox5.Controls.Add(this.networkCombo);
            this.groupBox5.Location = new System.Drawing.Point(442, 274);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(262, 167);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(7, 42);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(164, 113);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // PerceptronForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 446);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PerceptronForm";
            this.Text = "Perceptron";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PerceptronForm_FormClosed);
            this.Load += new System.EventHandler(this.PerceptronForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox trainPartTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button trainBtn;
        private System.Windows.Forms.TextBox learningRateTxt;
        private System.Windows.Forms.TextBox tresholdTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox outputTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox iterationLimitTxt;
        private System.Windows.Forms.TextBox rateLimitTxt;
        private System.Windows.Forms.CheckBox iterationLimitCheck;
        private System.Windows.Forms.CheckBox rateLimitCheck;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox shuffleCheck;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label numberOfIterationLbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label minRateLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label accuracyLbl;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.TextBox testPartTxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button loadNetworkBtn;
        private System.Windows.Forms.ComboBox networkCombo;
        private System.Windows.Forms.Button getNetworksBtn;
        private System.Windows.Forms.Button saveNetworkBtn;
        private System.Windows.Forms.Button resetWeightBtn;
        private System.Windows.Forms.Button resetNetworkBtn;
        private System.Windows.Forms.Button returnMainBtn;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}