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
using MongoDB.Bson;
using System.IO;

namespace TweetClassifier.v3
{
    public partial class MultiLayerPerceptronForm : Form
    {
        Main mainMenu;
        Mongo preparing;
        Network multiLayerPerceptron;
        List<Pattern> dSet;
        List<Pattern> testSet;
        List<Record> records;

        public MultiLayerPerceptronForm(Mongo m)
        {
            InitializeComponent();
            preparing = new Mongo();
            preparing = m;
            dSet = new List<Pattern>();
            records = new List<Record>();
        }

        private void MultiLayerPerceptronForm_Load(object sender, EventArgs e)
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

            if (hiddenTxt.Text == "")
            {
                infoLabel.Text = "Please enter number of nodes in hidden layer.";
                return;
            }

            if (outputTxt.Text == "")
            {
                infoLabel.Text = "Please enter number of nodes in output layer.";
                return;
            }

            multiLayerPerceptron = new Network(Convert.ToInt32(inputTxt.Text), Convert.ToInt32(hiddenTxt.Text), Convert.ToInt32(outputTxt.Text));
            infoLabel.Text = "Multi Layer Perceptron is created.";
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            groupBox5.Enabled = true;
            groupBox6.Enabled = true;
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

        private void MultiLayerPerceptronForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void initilizeTrainGroupBox()
        {
            rateLimitTxt.Enabled = false;
            rateLimitTxt.Visible = false;
            iterationLimitTxt.Enabled = false; ;
            iterationLimitTxt.Visible = false;
            groupBox3.Enabled = false;
        }

        private void resetWeightBtn_Click(object sender, EventArgs e)
        {
            multiLayerPerceptron.initilizeWeight();
            initilizeTrainBox();
            infoLabel.Text = "Weights are reset.";
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
                int result = multiLayerPerceptron.ClassifyBackpropagation(p);
                if (result == p.output)
                    accuracy++;
            }

            accuracy = accuracy / ((Convert.ToDouble(testPartTxt.Text) / 100) * dSet.Count);
            accuracyLbl.Text = accuracy.ToString();

            saveNetworkBtn.Enabled = true;
        }

        private void resetNetworkBtn_Click(object sender, EventArgs e)
        {
            multiLayerPerceptron = null;
            initilizeTrainBox();
            initilizeTestBox();
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
            groupBox6.Enabled = false;
            infoLabel.Text = "";
            inputTxt.Text = "";
            hiddenTxt.Text = "";
            outputTxt.Text = "";
        }

        private void initilizeTestBox()
        {
            testPartTxt.Text = "";
            accuracyLbl.Text = "accuracy";
            groupBox4.Enabled = false;
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
            multiLayerPerceptron.trainSet = new List<Pattern>(dSet.GetRange(0, trainSet));
            multiLayerPerceptron.SetTreshold(Convert.ToDouble(tresholdTxt.Text) / 100);
            multiLayerPerceptron.SetLearningRate(Convert.ToDouble(learningRateTxt.Text) / 100);
            multiLayerPerceptron.SetValidFunction(comboBox1.SelectedIndex);
            if (rateLimitCheck.Checked)
                multiLayerPerceptron.SetTrainErrorLimit(Convert.ToDouble(rateLimitTxt.Text) / 100);
            else
                multiLayerPerceptron.SetTrainErrorLimit(0);
            if (iterationLimitCheck.Checked)
                multiLayerPerceptron.SetIterationLimit(Convert.ToInt32(iterationLimitTxt.Text));

            multiLayerPerceptron.trainBackPropagation(rateLimitCheck.Checked, iterationLimitCheck.Checked, shuffleCheck.Checked);

            groupBox3.Enabled = true;

            minRateLbl.Text = multiLayerPerceptron.trainErrorRate.ToString();
            numberOfIterationLbl.Text = multiLayerPerceptron.numberOfIteration.ToString();

            infoLabel.Text = "Multi Layer Perceptron is trained.";
            groupBox4.Enabled = true;
        }

        private void returnMainBtn_Click(object sender, EventArgs e)
        {
            mainMenu = new Main(preparing);
            mainMenu.Show();
            this.Hide();
        }

        private void getNetworksBtn_Click(object sender, EventArgs e)
        {
            networkCombo.Items.Clear();
            StreamReader infile = new StreamReader("multiLayerPerceptron");
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
            multiLayerPerceptron = new Network(Convert.ToInt32(records[choice].input), Convert.ToInt32(records[choice].hidden), Convert.ToInt32(records[choice].output));

            for (int i = 0; i < multiLayerPerceptron.links.Count; i++)
                multiLayerPerceptron.links[i].weight = records[choice].weight[i];

            accuracyLbl.Text = records[choice].accuracy;
            tresholdTxt.Text = records[choice].treshold;
            learningRateTxt.Text = records[choice].learningRate;
            trainPartTxt.Text = records[choice].trainData;
            testPartTxt.Text = records[choice].testData;
            comboBox1.SelectedIndex = records[choice].function;
            inputTxt.Text = records[choice].input;
            hiddenTxt.Text = records[choice].hidden;
            outputTxt.Text = records[choice].output;

            infoLabel.Text = "Network is loaded.";

        }

        private void saveNetworkBtn_Click(object sender, EventArgs e)
        {
            StreamWriter outfile = new StreamWriter("multiLayerPerceptron", true);

            outfile.WriteLine(inputTxt.Text);
            outfile.WriteLine(hiddenTxt.Text);
            outfile.WriteLine(outputTxt.Text);
            outfile.WriteLine(multiLayerPerceptron.links.Count.ToString());

            for (int i = 0; i < multiLayerPerceptron.links.Count; i++)
                outfile.WriteLine(multiLayerPerceptron.links[i].weight);

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

            infoLabel.Text = "Multi Layer Perceptron is saved.";

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
                combo += "hidden layer: " + r.hidden + "\n";
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
