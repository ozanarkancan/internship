using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TweetClassifier.v3.ANN;
using TweetClassifier.v3.Data;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TweetClassifier.v3
{
    public partial class PerceptronForm : Form
    {
        Main mainMenu;
        Mongo preparing;
        Network perceptron;
        List<Pattern> dSet;
        List<Pattern> testSet;
        List<Record> records;

        public PerceptronForm(Mongo m)
        {
            InitializeComponent();
            preparing = new Mongo();
            preparing = m;
            dSet = new List<Pattern>();
        }

        private void PerceptronForm_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            groupBox6.Enabled = false;
            saveNetworkBtn.Enabled = false;
            initilizeTrainGroupBox();

        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (inputTxt.Text == "")
            {
                infoLabel.Text = "Please enter number of nodes in input layer.";
                return;
            }

            if (outputTxt.Text == "")
            {
                infoLabel.Text = "Please enter number of nodes in output layer.";
                return;
            }

            perceptron = new Network(Convert.ToInt32(inputTxt.Text), 0, Convert.ToInt32(outputTxt.Text));
            infoLabel.Text = "Perceptron is created.";
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            groupBox5.Enabled = true;
            groupBox6.Enabled = true;    
       }

        private void initilizeTrainGroupBox()
        {
            rateLimitTxt.Enabled = false;
            rateLimitTxt.Visible = false;
            iterationLimitTxt.Enabled = false; ;
            iterationLimitTxt.Visible = false;
            groupBox3.Enabled = false;
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

        private void rateLimitCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (rateLimitCheck.Checked)
            {
                rateLimitTxt.Enabled = true;
                rateLimitTxt.Visible = true;
            }
            else
            {
                rateLimitTxt.Enabled = false;
                rateLimitTxt.Visible = false;
            }
        }

        private void iterationLimitCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (iterationLimitCheck.Checked)
            {
                iterationLimitTxt.Enabled = true;
                iterationLimitTxt.Visible = true;
            }
            else
            {
                iterationLimitTxt.Enabled = false;
                iterationLimitTxt.Visible = false;
            }
        }

        private void PerceptronForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void resetWeightBtn_Click(object sender, EventArgs e)
        {
            perceptron.initilizeWeight();
            initilizeTrainBox();
            infoLabel.Text = "Weights are reset.";
        }

        private void returnMainBtn_Click(object sender, EventArgs e)
        {
            mainMenu = new Main(preparing);
            mainMenu.Show();
            this.Hide();
        }

        private void trainBtn_Click(object sender, EventArgs e)
        {
            if (!CheckNecesseryTrainInfo())
                return;
            groupBox3.Enabled = false;
            initilizeTestBox();
            infoLabel.Text = "";
            obtainData();
            int trainSet = (int)(dSet.Count * Convert.ToDouble(trainPartTxt.Text) / 100);
            perceptron.trainSet = new List<Pattern>(dSet.GetRange(0, trainSet));
            perceptron.SetTreshold(Convert.ToDouble(tresholdTxt.Text) / 100);
            perceptron.SetLearningRate(Convert.ToDouble(learningRateTxt.Text) / 100);
            perceptron.SetValidFunction(comboBox1.SelectedIndex);
            if (rateLimitCheck.Checked)
                perceptron.SetTrainErrorLimit(Convert.ToDouble(rateLimitTxt.Text) / 100);
            else
                perceptron.SetTrainErrorLimit(0);
            if (iterationLimitCheck.Checked)
                perceptron.SetIterationLimit(Convert.ToInt32(iterationLimitTxt.Text));

            perceptron.trainPerceptron(rateLimitCheck.Checked, iterationLimitCheck.Checked, shuffleCheck.Checked);

            groupBox3.Enabled = true;

            minRateLbl.Text = perceptron.trainErrorRate.ToString();
            numberOfIterationLbl.Text = perceptron.numberOfIteration.ToString();

            infoLabel.Text = "Perceptron is trained.";
            groupBox4.Enabled = true;
        }

        private bool CheckNecesseryTrainInfo()
        {
            if (tresholdTxt.Text == "")
            {
                infoLabel.Text = "Please enter treshold value.";
                return false;
            }
            if (learningRateTxt.Text == "")
            {
                infoLabel.Text = "Please enter learning rate value.";
                return false; 
            }
            if (trainPartTxt.Text == "")
            {
                infoLabel.Text = "Please enter percentage of data that will be trained over all data.";
                return false;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                infoLabel.Text = "Please choose a function.";
                return false;
            }
            if (rateLimitCheck.Checked)
            {
                if (rateLimitTxt.Text == "")
                {
                    infoLabel.Text = "Please enter train rate limit value.";
                    return false;
                }
            }
            if (iterationLimitCheck.Checked)
            {
                if (iterationLimitTxt.Text == "")
                {
                    infoLabel.Text = "Please enter iteration limit value.";
                    return false;
                }
            }
            if (!iterationLimitCheck.Checked && !rateLimitCheck.Checked)
            {
                infoLabel.Text = "Please choose  one or more limit condition.";
                return false;
            }
            return true;
        }

        private void initilizeTrainBox()
        {
            tresholdTxt.Text = "";
            learningRateTxt.Text = "";
            trainPartTxt.Text = "";
            comboBox1.SelectedIndex = -1;
            rateLimitCheck.Checked = false;
            rateLimitTxt.Text = "";
            iterationLimitCheck.Checked = false;
            iterationLimitTxt.Text = "";
            shuffleCheck.Checked = false;
            minRateLbl.Text = "";
            numberOfIterationLbl.Text = "";
            groupBox3.Enabled = false; 
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            if (testPartTxt.Text == "")
            {
                infoLabel.Text = "Please enter percentage of data that will be tested over all data.";
                return;
            }

            testSet = dSet.GetRange(dSet.Count - (int)(Convert.ToDouble(testPartTxt.Text) / 100 * dSet.Count), (int)(Convert.ToDouble(testPartTxt.Text) / 100 * dSet.Count));
            double accuracy = 0;

            foreach (Pattern p in testSet)//Testing
            {
                int result = perceptron.ClassifyPerceptron(p);
                if (result == p.output)
                    accuracy++;
            }

            accuracy = accuracy / ((Convert.ToDouble(testPartTxt.Text) / 100) * dSet.Count);
            accuracyLbl.Text = accuracy.ToString();
            saveNetworkBtn.Enabled = true;
        }

        private void resetNetworkBtn_Click(object sender, EventArgs e)
        {
            perceptron = null;
            initilizeTrainBox();
            initilizeTestBox();
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
            groupBox6.Enabled = false;
            infoLabel.Text = "";
            inputTxt.Text = "";
            outputTxt.Text = "";
        }

        private void initilizeTestBox()
        {
            testPartTxt.Text = "";
            accuracyLbl.Text = "accuracy";
            groupBox4.Enabled = false;
        }

        private void saveNetworkBtn_Click(object sender, EventArgs e)
        {
            StreamWriter outfile = new StreamWriter("perceptron", true);

            outfile.WriteLine(inputTxt.Text);
            outfile.WriteLine("0");
            outfile.WriteLine(outputTxt.Text);
            outfile.WriteLine(perceptron.links.Count.ToString());
            
            for (int i = 0; i < perceptron.links.Count; i++)
                outfile.WriteLine(perceptron.links[i].weight);

            outfile.WriteLine(accuracyLbl.Text);
            outfile.WriteLine(tresholdTxt.Text);
            outfile.WriteLine(learningRateTxt.Text);
            outfile.WriteLine(minRateLbl.Text);
            outfile.WriteLine(numberOfIterationLbl.Text);
            outfile.WriteLine(trainPartTxt.Text);
            outfile.WriteLine(testPartTxt.Text);
            outfile.WriteLine(comboBox1.SelectedIndex.ToString());
            outfile.WriteLine(DateTime.Now);
            outfile.WriteLine("");

            outfile.Close();

            infoLabel.Text = "Perceptron is saved.";
        }

        private void getNetworksBtn_Click(object sender, EventArgs e)
        {
            networkCombo.Items.Clear();
            StreamReader infile = new StreamReader("perceptron");
            records = new List<Record>();
            int j = 0;

            while (!infile.EndOfStream)
            {
                Record r = new Record();
                string s = infile.ReadLine();                
                while (s != "")
                {
                    r.input = s;
                    r.hidden = infile.ReadLine();
                    r.output = infile.ReadLine();
                    r.links = Convert.ToInt32(infile.ReadLine());
                    for (int i = 0; i < r.links; i++)
                        r.weight.Add(Convert.ToDouble(infile.ReadLine()));
                    r.accuracy = infile.ReadLine();
                    r.treshold = infile.ReadLine();
                    r.learningRate = infile.ReadLine();
                    r.minTrainRate = infile.ReadLine();
                    r.numberOfEpoch = infile.ReadLine();
                    r.trainData = infile.ReadLine();
                    r.testData = infile.ReadLine();
                    r.function = Convert.ToInt32(infile.ReadLine());
                    r.date = Convert.ToDateTime(infile.ReadLine());
                    s = infile.ReadLine();
                }

                records.Add(r);

                networkCombo.Items.Add(j.ToString() + " - " + r.date.ToString());
                j++;
            }

            infile.Close();
            infoLabel.Text = "Networks are usable.";
        }

        private void loadNetworkBtn_Click(object sender, EventArgs e)
        {
            initilizeTrainBox();
            int choice = networkCombo.SelectedIndex;
            perceptron = new Network(Convert.ToInt32(records[choice].input), 0, Convert.ToInt32(records[choice].output));

            for (int i = 0; i < perceptron.links.Count; i++)
                perceptron.links[i].weight = records[choice].weight[i];

            accuracyLbl.Text = records[choice].accuracy;
            tresholdTxt.Text = records[choice].treshold;
            learningRateTxt.Text = records[choice].learningRate;
            trainPartTxt.Text = records[choice].trainData;
            testPartTxt.Text = records[choice].testData;
            comboBox1.SelectedIndex = records[choice].function;
            inputTxt.Text = records[choice].input;
            outputTxt.Text = records[choice].output;

            infoLabel.Text = "Network is loaded.";

        }

        private void networkCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string combo = "";
            if (networkCombo.SelectedIndex != -1)
            {
                Record r = records[networkCombo.SelectedIndex];

                combo += "Date: " + r.date.ToString() + "\n";
                combo += "accuracy: " + r.accuracy + "\n";
                combo += "input layer: " + r.input + "\n";
                combo += "output layer: " + r.output + "\n";
                combo += "treshold: " + r.treshold + "\n";
                combo += "learning rate: " + r.learningRate + "\n";

                switch (r.function)
                {
                    case 0:
                        combo += "function: " + "linear" + "\n";
                        break;
                    case 1:
                        combo += "function: " + "sigmoid" + "\n";
                        break;
                    case 2:
                        combo += "function: " + "hyperbolic tangent" + "\n";
                        break;
                    default:
                        combo += "function: " + "sigmoid" + "\n";
                        break;
                }

                combo += "number of iteration: " + r.numberOfEpoch + "\n";
                combo += "train data percentage: " + r.trainData + "\n";
                combo += "test data percentage: " + r.testData + "\n";

                richTextBox1.Text = combo;
            }

        }

    }
}
