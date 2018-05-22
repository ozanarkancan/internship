using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TweetClassifier.v3.Naive_Bayes;
using TweetClassifier.v3.Data;
using MongoDB.Bson;
using System.IO;

namespace TweetClassifier.v3
{
    public partial class NaiveBayesForm : Form
    {

        Calculation naiveBayes;
        List<Pattern> dSet;
        List<Pattern> testSet;
        Main mainMenu;
        Mongo preparing;

        public NaiveBayesForm(Mongo m)
        {
            InitializeComponent();
            preparing = new Mongo();
            preparing = m;
            dSet = new List<Pattern>();
            testSet = new List<Pattern>();
        }

        private void crossValidationCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (crossValidationCheck.Checked)
            {
                comboBox1.Enabled = true;
                comboBox1.Visible = true;
                testPartTxt.Enabled = false;
                label1.Enabled = false;
            }
            else
            {
                comboBox1.Enabled = false;
                comboBox1.Visible = false;
                testPartTxt.Enabled = true;
                label1.Enabled = true;
            }
        }

        private void NaiveBayesForm_Load(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            comboBox1.Visible = false;
            groupBox1.Enabled = false;
            dataGridView1.Visible = false;
            accuracyLbl.Visible = false;
            accuracyLbl2.Visible = false;
        }

        private void trainBtn_Click(object sender, EventArgs e)
        {

            if (trainPartTxt.Text == "")
            {
                MessageBox.Show("Please enter percentage of data that will be trained.");
                return;
            }

            if (Convert.ToDouble(trainPartTxt.Text) > 100)
                trainPartTxt.Text = Convert.ToString(100);

            naiveBayes = new Calculation();
            DataTable t = new DataTable();
            StreamReader infile = new StreamReader("frequency.txt");
            dataGridView1.Visible = false; 

            t.Columns.Add("Test");
            t.Columns.Add("Accuracy", typeof(double));

            obtainData();
            while (!infile.EndOfStream)
                naiveBayes.weight.Add(Convert.ToDouble(infile.ReadLine()));
            
            if (crossValidationCheck.Checked)
            {
                int option;
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        option = 2;
                        break;
                    case 1:
                        option = 5;
                        break;
                    case 2:
                        option = 10;
                        break;
                    default:
                        option = 10;
                        break;
                }


                List<double> average = new List<double>();

                for (int i = 1; i <= option; i++)
                {
                    double accuracy = 0;

                    testSet = dSet.GetRange((i - 1) * (int)(dSet.Count * Convert.ToDouble(trainPartTxt.Text) / (100 * option)), (int)(dSet.Count * Convert.ToDouble(trainPartTxt.Text) / (100 * option)));
                    if (i == 1)
                        naiveBayes.trainSet = dSet.GetRange((int)(dSet.Count * Convert.ToDouble(trainPartTxt.Text) / (100 * option)), (int)(dSet.Count * Convert.ToDouble(trainPartTxt.Text) / (100 * option)) * (option - 1));
                    else
                    {
                        naiveBayes.trainSet = dSet.GetRange(0, (i - 1) * (int)(dSet.Count * Convert.ToDouble(trainPartTxt.Text) / (100 * option)));
                        naiveBayes.trainSet.AddRange(dSet.GetRange(i * (int)(dSet.Count * Convert.ToDouble(trainPartTxt.Text) / (100 * option)), (option - i) * (int)(dSet.Count * Convert.ToDouble(trainPartTxt.Text) / (100 * option))));
                    }


                    naiveBayes.Train();

                    foreach (Pattern p in testSet)
                    {
                        int result = naiveBayes.Classify(p);
                        if (result == p.output)
                            accuracy++;
                    }

                    accuracy = accuracy / (dSet.Count * Convert.ToDouble(trainPartTxt.Text) / (100 * option));
                    average.Add(accuracy);

                    t.Rows.Add(i.ToString(), accuracy);
                }

                average.Add((average.Sum() / average.Count));
                t.Rows.Add("Average", average.Last());
                dataGridView1.DataSource = t;
                dataGridView1.Visible = true;         
            }
            else
            {
                naiveBayes.trainSet = new List<Pattern>(dSet.GetRange(0, (int)(dSet.Count * Convert.ToDouble(trainPartTxt.Text) / 100)));
                naiveBayes.Train();
                groupBox1.Enabled = true;
            }            
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            if (testPartTxt.Text == "")
            {
                MessageBox.Show("Please enter percentage of data that will be tested.");
                return;
            }

            if (Convert.ToDouble(testPartTxt.Text) > 100)
                testPartTxt.Text = Convert.ToString(100);

            DataTable t = new DataTable();
            double accuracy = 0;

            testSet = dSet.GetRange(dSet.Count - (int)(Convert.ToDouble(testPartTxt.Text) / 100 * dSet.Count), (int)(Convert.ToDouble(testPartTxt.Text) / 100 * dSet.Count));
            
            foreach (Pattern p in testSet)
            {
                int result = naiveBayes.Classify(p);
                if (result == p.output)
                    accuracy++;
            }

            accuracy = accuracy / testSet.Count;
            accuracyLbl.Visible = true;
            accuracyLbl2.Visible = true;

            accuracyLbl2.Text = accuracy.ToString();
        }

        private void obtainData()
        {
            preparing.getAllData();
            foreach (BsonDocument doc in preparing.cursor)//Obtaining Data Set from database
            {
                Pattern p = new Pattern();
                p.output = doc["output"].ToInt32();
                p.featureVector.Add(doc["reklam"].ToDouble());
                p.featureVector.Add(doc["kampanya"].ToDouble());
                p.featureVector.Add(doc["kontör"].ToDouble());
                p.featureVector.Add(doc["mesaj"].ToDouble());
                p.featureVector.Add(doc["sms"].ToDouble());
                p.featureVector.Add(doc["müşteri"].ToDouble());
                p.featureVector.Add(doc["fatura"].ToDouble());
                p.featureVector.Add(doc["geçirmek"].ToDouble());
                p.featureVector.Add(doc["hizmet"].ToDouble());
                p.featureVector.Add(doc["çekim"].ToDouble());
                p.featureVector.Add(doc["kalite"].ToDouble());
                p.featureVector.Add(doc["paket"].ToDouble());
                p.featureVector.Add(doc["tarife"].ToDouble());
                p.featureVector.Add(doc["sponsor"].ToDouble());
                p.featureVector.Add(doc["nefret"].ToDouble());
                p.featureVector.Add(doc["küfür"].ToDouble());
                p.featureVector.Add(doc["bayi"].ToDouble());
                p.featureVector.Add(doc["tim"].ToDouble());
                p.featureVector.Add(doc["lanet"].ToDouble());
                p.featureVector.Add(doc["iletişim"].ToDouble());
                p.featureVector.Add(doc["operatör"].ToDouble());
                p.featureVector.Add(doc["para"].ToDouble());
                p.featureVector.Add(doc["kazık"].ToDouble());
                p.featureVector.Add(doc["lig"].ToDouble());
                p.featureVector.Add(doc["baz"].ToDouble());
                p.featureVector.Add(doc["bis"].ToDouble());
                p.featureVector.Add(doc["internet"].ToDouble());
                p.featureVector.Add(doc["iphone"].ToDouble());
                dSet.Add(p);
            }
        }

        private void NaiveBayesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void returnMainBtn_Click(object sender, EventArgs e)
        {
            mainMenu = new Main(preparing);
            mainMenu.Show();
            this.Hide();
        }
    }
}
