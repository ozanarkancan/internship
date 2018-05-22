using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using TweetClassifier.v2.Naive_Bayes;
using TweetClassifier.v2.Data;
using System.IO;
using TweetClassifier.v2.Artificial_Neural_Networks;


namespace TweetClassifier.v2
{
    public partial class Form1 : Form
    {
        string connectionString = "mongodb://localhost";
        MongoServer server;
        MongoDatabase database;
        MongoCollection<BsonDocument> collection;
        MongoCursor<BsonDocument> cursor;
        Calculation NaiveBayesClassifier;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox3.Visible = false;
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if (dbNameTxtBox.Text == "")
            {
                MessageBox.Show("Please enter database name!");
                dbStatusLbl.Text = "Connection error!";
                return;
            }

            if (collectionNameTxtBox.Text == "")
            {
                MessageBox.Show("Please enter collection name!");
                dbStatusLbl.Text = "Connection error!";
                return;
            }

            try
            {
                System.Diagnostics.Process.Start("mongod.exe"); //Preparing
                server = MongoServer.Create(connectionString); //Connect to server
                if (server.DatabaseExists(dbNameTxtBox.Text))
                {
                    database = server.GetDatabase(dbNameTxtBox.Text); //Get database that name is taken from user
                    if (database.CollectionExists(collectionNameTxtBox.Text))
                    {
                        collection = database.GetCollection<BsonDocument>(collectionNameTxtBox.Text);
                        dbStatusLbl.Text = "Mongodb is ready.";
                        groupBox2.Enabled = true;
                    }
                    else
                    {
                        dbStatusLbl.Text = "Collection does not exist.";

                    }
                }
                else
                {
                    dbStatusLbl.Text = "Database does not exist.";

                }

            }
            catch (Exception)
            {
                dbStatusLbl.Text = "Connection error!";
            }
        }

        private List<Pattern> obtainData(MongoCursor<BsonDocument> cursor)
        {
            List<Pattern> dataSet = new List<Pattern>();
            foreach (BsonDocument doc in cursor)//Obtaining Data Set from database
            {
                Pattern p = new Pattern();
                p.output = doc["output"].ToInt32();
                p.featureVector.Add(doc["reklam"].ToDouble());
                p.featureVector.Add(doc["kampanya"].ToDouble());
                p.featureVector.Add(doc["indirim"].ToDouble());
                p.featureVector.Add(doc["bonus"].ToDouble());
                p.featureVector.Add(doc["puan"].ToDouble());
                p.featureVector.Add(doc["kontör"].ToDouble());
                p.featureVector.Add(doc["mesaj"].ToDouble());
                p.featureVector.Add(doc["sms"].ToDouble());
                p.featureVector.Add(doc["t10"].ToDouble());
                p.featureVector.Add(doc["t20"].ToDouble());
                p.featureVector.Add(doc["müşteri"].ToDouble());
                p.featureVector.Add(doc["fatura"].ToDouble());
                p.featureVector.Add(doc["borç"].ToDouble());
                p.featureVector.Add(doc["ödeme"].ToDouble());
                p.featureVector.Add(doc["taşımak"].ToDouble());
                p.featureVector.Add(doc["geçirmek"].ToDouble());
                p.featureVector.Add(doc["abone"].ToDouble());
                p.featureVector.Add(doc["hizmet"].ToDouble());
                p.featureVector.Add(doc["çekim"].ToDouble());
                p.featureVector.Add(doc["kalite"].ToDouble());
                p.featureVector.Add(doc["konser"].ToDouble());
                p.featureVector.Add(doc["kuruçeşme"].ToDouble());
                p.featureVector.Add(doc["sertap"].ToDouble());
                p.featureVector.Add(doc["özturkcell"].ToDouble());
                p.featureVector.Add(doc["selocan"].ToDouble());
                p.featureVector.Add(doc["şahan"].ToDouble());
                p.featureVector.Add(doc["paket"].ToDouble());
                p.featureVector.Add(doc["tarife"].ToDouble());
                p.featureVector.Add(doc["sponsor"].ToDouble());
                p.featureVector.Add(doc["nefret"].ToDouble());
                p.featureVector.Add(doc["rezil"].ToDouble());
                p.featureVector.Add(doc["küfür"].ToDouble());
                p.featureVector.Add(doc["call"].ToDouble());
                p.featureVector.Add(doc["bayi"].ToDouble());
                p.featureVector.Add(doc["tim"].ToDouble());
                p.featureVector.Add(doc["lanet"].ToDouble());
                p.featureVector.Add(doc["geçmek"].ToDouble());
                p.featureVector.Add(doc["lira"].ToDouble());
                p.featureVector.Add(doc["platinium"].ToDouble());
                p.featureVector.Add(doc["gold"].ToDouble());
                p.featureVector.Add(doc["joker"].ToDouble());
                p.featureVector.Add(doc["iletişim"].ToDouble());
                p.featureVector.Add(doc["operatör"].ToDouble());
                p.featureVector.Add(doc["para"].ToDouble());
                p.featureVector.Add(doc["kazık"].ToDouble());
                p.featureVector.Add(doc["lig"].ToDouble());
                p.featureVector.Add(doc["baz"].ToDouble());
                p.featureVector.Add(doc["bis"].ToDouble());
                p.featureVector.Add(doc["internet"].ToDouble());
                p.featureVector.Add(doc["blackberry"].ToDouble());
                p.featureVector.Add(doc["iphone"].ToDouble());
                dataSet.Add(p);
            }

            return dataSet;
 
        }

        private void trainBtn_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                label4.Text = "Please select classification method";
            else
            {
                MongoCursor<BsonDocument> cursor = collection.FindAll();
                List<Pattern> dataSet = new List<Pattern>();
                List<Pattern> train = new List<Pattern>();
                List<Pattern> test = new List<Pattern>();

                /*-------------------------Naive Bayes Classifier------------------------------*/
                if (comboBox1.SelectedIndex == 0)
                {
                    StreamReader infile = new StreamReader(@"C:\Users\eozacan\Desktop\frequency.txt");
                    NaiveBayesClassifier = new Calculation();
                    for (int i = 0; i < 51; i++)
                    {
                        double val = Convert.ToDouble(infile.ReadLine());
                        NaiveBayesClassifier.weight.Add(val);                      
                    }

                    infile.Close();
                    dataSet = obtainData(cursor);                   

                    try
                    {
                        DataTable table = new DataTable();
                        table.Columns.Add("Test");
                        table.Columns.Add("Precision", typeof(double));
                        table.Columns.Add("Recall", typeof(double));
                        table.Columns.Add("Accuracy", typeof(double));
                        table.Columns.Add("Fscore", typeof(double));
                        List<double> average = new List<double>();
                        for (int i = 1; i < 11; i++)
                        {
                            double accuracy = 0;

                            train = dataSet.GetRange((i - 1) * 185, 185);
                            if (i == 1)
                                test = dataSet.GetRange(185, 185 * 9);
                            else
                            {
                                test = dataSet.GetRange(0, (i - 1) * 185);
                                test.AddRange(dataSet.GetRange(i*185, (10 - i)*185));
                            }

                            NaiveBayesClassifier.trainSet = train;
                            NaiveBayesClassifier.Train();

                            foreach (Pattern p in test)
                            {
                                int result = NaiveBayesClassifier.Classify(p);
                                if (result == p.output)
                                    accuracy++;

                            }

                            accuracy = accuracy / (185 * 9);
                            average.Add(accuracy);
                            table.Rows.Add(i.ToString(), 0.0, 0.0, accuracy, 0.0);
                        }

                        average.Add((average.Sum() / average.Count));
                        table.Rows.Add("Average", 0.0, 0.0, average.Last(), 0.0);
                        dataGridView1.DataSource = table;

                    }
                    catch (Exception)
                    {
                        label4.Text = "Process could not completed.";
                        throw;
                    }
                    groupBox3.Visible = true;
                }
                /*-------------------------PERCEPTRON------------------------------*/
                if (comboBox1.SelectedIndex == 1)
                {
                    Network perceptron = new Network(56, 208);//56 neurons - 204 links
                    int countLink = 0;
                    double accuracy = 0;

                    for (int i = 0; i < 52; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            perceptron.Connect(perceptron.neurons[i], perceptron.neurons[52 + j], perceptron.links[countLink]);
                            countLink++;
                        }
                    }

                    dataSet = obtainData(cursor);
                    train = dataSet.GetRange(0, 7 * 185);
                    test = dataSet.GetRange(7 * 185 - 1, 3 * 185);//7-3 Train - Test

                    perceptron.trainSet = train;
                    label4.Text = "Network is being trained.";
                    perceptron.SetLearningRate(0.1);
                    perceptron.SetTreshold(0.5);
                    perceptron.trainPerceptron();
                    label4.Text = "Network is trained.";
                    
                    foreach (Pattern p in test)//Testing
                    {
                        int result = perceptron.ClassifyPerceptron(p);
                        if (result == p.output)
                            accuracy++;
                    }

                    accuracy = accuracy / (185 * 3);

                    MessageBox.Show(accuracy.ToString());

                }

                /*---------Multilayer Perceptron & Backpropagation Learning Algorithm----------*/
                if (comboBox1.SelectedIndex == 2)
                {
                    Network multiLayerPerceptron = new Network(70, 732);
                    int countLink = 0;
                    double accuracy = 0;
                    for (int i = 0; i < 52; i++)
                    {
                        for (int j = 0; j < 13; j++)
                        {
                            multiLayerPerceptron.Connect(multiLayerPerceptron.neurons[i], multiLayerPerceptron.neurons[52 + j], multiLayerPerceptron.links[countLink]);
                            countLink++;
                        }
                    }
                    for (int i = 52; i < 66; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            multiLayerPerceptron.Connect(multiLayerPerceptron.neurons[i], multiLayerPerceptron.neurons[66 + j], multiLayerPerceptron.links[countLink]);
                            countLink++;
                        }
                    }

                    dataSet = obtainData(cursor);
                    train = dataSet.GetRange(0, 7 * 185);
                    test = dataSet.GetRange(7 * 185 - 1, 3 * 185);//7-3 Train - Test

                    multiLayerPerceptron.trainSet = train;
                    label4.Text = "Network is being trained.";
                    multiLayerPerceptron.SetLearningRate(0.1);
                    multiLayerPerceptron.SetTreshold(0.5);
                    multiLayerPerceptron.trainBackPropagation();
                    label4.Text = "Network is trained.";

                    foreach (Pattern p in test)//Testing
                    {
                        int result = multiLayerPerceptron.ClassifyBackpropagation(p);
                        if (result == p.output)
                            accuracy++;
                    }

                    accuracy = accuracy / (185 * 3);

                    MessageBox.Show(accuracy.ToString());
       
                }

                /*-----------------K Nearest Neighbour --------------------*/
                if (comboBox1.SelectedIndex == 3)
                { 
                }
            }
        }

    }
}
