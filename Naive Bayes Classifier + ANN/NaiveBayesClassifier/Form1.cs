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
using NaiveBayesClassifier.ANN;

namespace NaiveBayesClassifier
{
    public partial class Form1 : Form
    {
        string connectionString = "mongodb://localhost";
        MongoServer server;
        MongoDatabase database;
        MongoCollection<BsonDocument> collection; 
        Calculation classifier; //Classifier for data set
        Person testElement;
        Network ann;

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
                System.Diagnostics.Process.Start(@"C:\Users\eozacan\Desktop\mongodb-win32-i386-1.8.2\bin\mongod.exe"); //Preparing
                server = MongoServer.Create(connectionString); //Connect to server
                if (server.DatabaseExists(dbNameTxtBox.Text))
                {
                    database = server.GetDatabase(dbNameTxtBox.Text); //Get database that name is taken from user
                    if (database.CollectionExists(collectionNameTxtBox.Text))
                    {
                        collection = database.GetCollection<BsonDocument>(collectionNameTxtBox.Text);
                        ann = new Network(4, 3);
                        dbStatusLbl.Text = "Mongodb is ready.";
                        groupBox2.Enabled = true;
                        groupBox4.Enabled = true;
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

        private void trainBtn_Click(object sender, EventArgs e)
        {
            classifier = new Calculation(); 
            List<Person> people = new List<Person>(); //A person list for trainer
            DataTable table = new DataTable();// Data Grid for training result
            //collection = database.GetCollection<BsonDocument>(collectionNameTxtBox.Text);//Get collection that name is taken from user
            MongoCursor<BsonDocument> cursor = collection.FindAll();

            foreach (BsonDocument person in cursor)//Obtaining Data Set from database
            {
                Person p = new Person();
                p.sex = person["sex"].ToInt32();
                p.height = person["height"].ToDouble();
                p.weight = person["weight"].ToDouble();
                p.footSize = person["footSize"].ToDouble();
                people.Add(p);
            }
            try
            {
                classifier.Train(people);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error1\n" + ex.Message);
                return;
            }
            
            //Filling Train Result Table
            table.Columns.Add("Sex");
            table.Columns.Add("Mean Height (feet)", typeof(double));
            table.Columns.Add("Variance Height (feet)", typeof(double));
            table.Columns.Add("Mean Weight (lbs)", typeof(double));
            table.Columns.Add("Variance Weight (lbs)", typeof(double));
            table.Columns.Add("Mean Foot Size (inches)", typeof(double));
            table.Columns.Add("Variance Foot Size (inches)", typeof(double));
            table.Rows.Add("Male", classifier.meanHeight[0], classifier.varianceHeight[0], classifier.meanWeight[0], classifier.varianceWeight[0], classifier.meanFootSize[0], classifier.varianceFootSize[0]);
            table.Rows.Add("Female", classifier.meanHeight[1], classifier.varianceHeight[1], classifier.meanWeight[1], classifier.varianceWeight[1], classifier.meanFootSize[1], classifier.varianceFootSize[1]);

            dataGridView1.DataSource = table;
            groupBox3.Enabled = true;
            
        }

        private void ClassifyBtn_Click(object sender, EventArgs e)
        {
            testElement = new Person();
            testElement.height = Convert.ToDouble(heightTxtBox.Text) / 10;
            testElement.weight = Convert.ToDouble(weightTxtBox.Text) / 10;
            testElement.footSize = Convert.ToDouble(footSizeTxtBox.Text) / 10;

            int result = classifier.Classify(testElement.height, testElement.weight, testElement.footSize);
            testElement.sex = result;
            if (result == 0)
                resultLbl.Text = "Male";
            else
                resultLbl.Text = "Female";

            insertBtn.Enabled = true;
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            insertBtn.Enabled = false;
            groupBox4.Enabled = false;
            groupBox6.Enabled = false;
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            // Classes mapping for bson serialazing proccess
            if (!BsonClassMap.IsClassMapRegistered(typeof(Person)))
                BsonClassMap.RegisterClassMap<Person>();
            try
            {
                collection.Save(testElement.ToBsonDocument());
                insertLbl.Text = "New data is inserted";
            }
            catch (Exception)
            {
                insertLbl.Text = "New data could not insert";
            }
            

        }

        private void annTrainBtn_Click(object sender, EventArgs e)
        {
            MongoCursor<BsonDocument> cursor = collection.FindAll();
            List<Person> people = new List<Person>(); //A person list for trainer
            
            ann.Connect(ann.neurons[0], ann.neurons[3], ann.links[0]);
            ann.Connect(ann.neurons[1], ann.neurons[3], ann.links[1]);
            ann.Connect(ann.neurons[2], ann.neurons[3], ann.links[2]);

            ann.setLearningRate(Convert.ToDouble(learningRateTxtBox.Text) / 100);
            ann.setTreshold(Convert.ToDouble(tresholdTxtBox.Text) / 100);

            foreach (BsonDocument person in cursor)//Obtaining Data Set from database
            {
                Person p = new Person();
                p.sex = person["sex"].ToInt32();
                p.height = person["height"].ToDouble();
                p.weight = person["weight"].ToDouble();
                p.footSize = person["footSize"].ToDouble();
                people.Add(p);
            }
            int numberOfIteration = ann.train(people);
            trainLbl.Text = "Network is trained.";
            result.Text = numberOfIteration.ToString();
            groupBox6.Enabled = true;
        }

        private void ClassifyAnnBtn_Click(object sender, EventArgs e)
        {
            ann.neurons[0].value = Convert.ToDouble(heightAnnTxt.Text) / 10 - 5.0;
            ann.neurons[1].value = (Convert.ToDouble(weightAnnTxt.Text) / 10 - 100.0) / 90.0;
            ann.neurons[2].value = (Convert.ToDouble(footSizeAnnTxt.Text) / 10 - 6) / 6.0;
            int result = ann.classify();
            if (result == 0)
                resultAnnLbl.Text = "Male";
            else
                resultAnnLbl.Text = "Female";
        }
    }   
}
