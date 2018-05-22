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
using MongoDB.Bson.Serialization;

namespace TweetClassifier
{
    public partial class Form1 : Form
    {
        string connectionString = "mongodb://localhost";
        MongoServer server;
        MongoDatabase database;
        MongoCollection<BsonDocument> collection; 
        MongoCursor<BsonDocument> cursor;
        Calculation classifier; //Classifier for data set
        Tweet testElement;

        public Form1()
        {
            InitializeComponent();
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
                database = server.GetDatabase( dbNameTxtBox.Text ); //Get database that name is taken from user
                collection = database.GetCollection<BsonDocument>(collectionNameTxtBox.Text);
                dbStatusLbl.Text = "Mongodb is ready.";
                groupBox2.Enabled = true;
                groupBox4.Enabled = true;

            }
            catch (Exception)
            {
                dbStatusLbl.Text = "Connection error!";
            }
        }

        private void trainBtn_Click(object sender, EventArgs e)
        {
            classifier = new Calculation(); 
            List<Tweet> tweets = new List<Tweet>(); //A Tweet list for trainer
            DataTable table = new DataTable();// Data Grid for training result
            cursor = collection.FindAll();
            
            foreach (BsonDocument Tweet in cursor)//Obtaining Data Set from database
            {
                Tweet t = new Tweet();
                t.dataID = Tweet["dataID"].ToInt32();
                t.side = Tweet["side"].ToInt32();
                t.pozitiveWords = Tweet["pozitiveWords"].ToInt32();
                t.negativeWords = Tweet["negativeWords"].ToInt32();
                t.pozitiveSmiles = Tweet["pozitiveSmiles"].ToInt32();
                t.negativeSmiles = Tweet["negativeSmiles"].ToInt32();
                tweets.Add(t);
            }

            classifier.Train(tweets);
            //Filling Train Result Table
            table.Columns.Add("Side");
            table.Columns.Add("Mean Pozitive Words", typeof(double));
            table.Columns.Add("Variance Pozitive Words", typeof(double));
            table.Columns.Add("Mean Negative Words", typeof(double));
            table.Columns.Add("Variance Negative Words", typeof(double));
            table.Columns.Add("Mean Pozitive Smiles", typeof(double));
            table.Columns.Add("Variance Pozitive Smiles", typeof(double));
            table.Columns.Add("Mean Negative Smiles", typeof(double));
            table.Columns.Add("Variance Negative Smiles", typeof(double));
            table.Rows.Add("Pozitive", classifier.meanWords[0], classifier.meanNWords[0], classifier.varianceNWords[0], classifier.varianceWords[0], classifier.meanPozitive[0], classifier.variancePozitive[0], classifier.meanNegative[0], classifier.varianceNegative[0]);
            table.Rows.Add("Negative", classifier.meanWords[1], classifier.meanNWords[1], classifier.varianceNWords[1], classifier.varianceWords[1], classifier.meanPozitive[1], classifier.variancePozitive[1], classifier.meanNegative[1], classifier.varianceNegative[1]);

            dataGridView1.DataSource = table;
            groupBox3.Enabled = true;
        }

        private void ClassifyBtn_Click(object sender, EventArgs e)
        {
            testElement = new Tweet();
            testElement.pozitiveWords = Convert.ToInt32(pWordsTxtBox.Text);
            testElement.negativeWords = Convert.ToInt32(nWordsTxtBox.Text);
            testElement.pozitiveSmiles = Convert.ToInt32(pSmilesTxtBox.Text);
            testElement.negativeSmiles = Convert.ToInt32(nSmilesTxtBox.Text);

            int result = classifier.Classify(testElement.pozitiveWords, testElement.negativeWords, testElement.pozitiveSmiles, testElement.negativeSmiles);
            testElement.side = result;
            if (result == 0)
                resultLbl.Text = "Pozitive";
            else
                resultLbl.Text = "Negative";
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
        }

        private void trainAndTestCrossBtn_Click(object sender, EventArgs e)
        {
            List<Tweet> tweets = new List<Tweet>(); //A Tweet list for trainer
            cursor = collection.FindAll();
            
            double[] precision = new double[11];
            double[] recall = new double[11];
            double[] fscore = new double[11];
            double[] accuracy = new double[11];
            
            DataTable table = new DataTable();// Data Grid for training result
            table.Columns.Add("Test");
            table.Columns.Add("Precision", typeof(double));
            table.Columns.Add("Recall", typeof(double));
            table.Columns.Add("Accuracy", typeof(double));
            table.Columns.Add("Fscore", typeof(double));
            

            foreach (BsonDocument Tweetdoc in cursor)//Obtaining Data Set from database
            {
                Tweet t = new Tweet();
                t.dataID = Tweetdoc["dataID"].ToInt32();
                t.side = Tweetdoc["side"].ToInt32();
                t.pozitiveWords = Tweetdoc["pozitiveWords"].ToInt32();
                t.negativeWords = Tweetdoc["negativeWords"].ToInt32();
                t.pozitiveSmiles = Tweetdoc["pozitiveSmiles"].ToInt32();
                t.negativeSmiles = Tweetdoc["negativeSmiles"].ToInt32();
                tweets.Add(t);
            }


            for (int i = 0; i < 10; i++)
            {
                double tp = 0;// true pozitive
                double fp = 0;// false pozitive
                double fn = 0;// false negative
                double tn = 0;// true negative

                classifier = new Calculation();                
                List<Tweet> trainSet = tweets.GetRange(i, 10);
                List<Tweet> testSet = new List<Tweet>();
                if (i == 0)
                    testSet = tweets.GetRange(10, 90);
                else
                {
                    testSet = tweets.GetRange(0, i * 10);
                    testSet.AddRange(tweets.GetRange(i * 10, 100 - (i * 10 + 10)));
                }

                classifier.Train(trainSet);

                foreach (Tweet t in testSet)
                {
                    int result = classifier.Classify(t.pozitiveWords, t.negativeWords, t.pozitiveSmiles, t.negativeSmiles); // Classify an element
                    
                    if (t.side == 0)
                    {
                        if (result == 0)
                            tp++;
                        else
                            fn++;
                    }
                    else
                    {
                        if (result == 1)
                            tn++;
                        else
                            fp++;
                    }
                }

                //Scoring
                precision[i] = tp / (tp + fp);
                recall[i] = tp / (tp + fn);
                accuracy[i] = (tp + tn) / (tp + tn + fp + fn);
                fscore[i] = 2 * ((precision[i] * recall[i]) / (precision[i] + recall[i]));

                //Filling table;
                table.Rows.Add(i.ToString(), precision[i], recall[i], accuracy[i], fscore[i]);
                
            }

            //Obtaining Average Scores
            precision[10] = 0;
            recall[10] = 0;
            accuracy[10] = 0;
            fscore[10] = 0;

            for (int i = 0; i < 10; i++)
            {
                precision[10] += precision[i];
                recall[10] += recall[i];
                accuracy[10] += accuracy[i];
                fscore[10] += fscore[i];
            }

            precision[10] /= 10;
            recall[10] /= 10;
            accuracy[10] /= 10;
            fscore[10] /= 10;

            table.Rows.Add("Average", precision[10], recall[10], accuracy[10], fscore[10]);
            dataGridView2.DataSource = table;
        }

    }
}
