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
using MongoDB.Driver.Builders;

namespace DataBaseExercise
{
    public partial class Form1 : Form
    {

        string connectionString = "mongodb://localhost";
        MongoServer server;
        MongoDatabase database;
        MongoCollection<BsonDocument> myCollection;
        MongoCursor<BsonDocument> cursor;
        BsonDocument element;

        public Form1()
        {
            InitializeComponent();
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\Users\eozacan\Desktop\mongodb-win32-i386-1.8.2\bin\mongod.exe"); //Preparing
                server = MongoServer.Create(connectionString);
                database = server.GetDatabase("deneme");
                label2.Text = "MongoDb is ready.";
                myCollection = database.GetCollection<BsonDocument>("collectionDeneme");
                element = new BsonDocument();
                cursor = myCollection.FindAll();
                fillListbox(cursor);
                groupBox2.Enabled = true;
                groupBox4.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                label2.Text = "Connection error!";
            }
            
        }

        private void insertFieldBtn_Click(object sender, EventArgs e)
        {
            string fieldName = fieldTxtBox.Text;
            BsonValue  value = null;
            if (KindsComboBox.SelectedIndex == 0)
                value = Convert.ToInt64(valueTxtBox.Text);
            else
                value = valueTxtBox.Text;
            element.Add(fieldName, value);
            try
            {
                listBox1.Items.Add(fieldName + " : " + valueTxtBox.Text);
                ClearBoxes();
                label6.Text = "Field is inserted successfully";
            }
            catch (Exception ex)
            {
                label6.Text = "Field is not inserted!";
            }

        }

        private void insertElementBtn_Click(object sender, EventArgs e)
        {
            try
            {
                myCollection.Save(element);
                element = new BsonDocument();
                listBox1.Items.Clear();
                ClearBoxes();
                label6.Text = "Element is inserted successfully";
                cursor = myCollection.FindAll();
                fillListbox(cursor);
            }
            catch (Exception)
            {

                label6.Text = "Element is not inserted!";
            }
            
        }

        private void ClearBoxes()
        {
            fieldTxtBox.Text = "";
            valueTxtBox.Text = "";
            KindsComboBox.SelectedItem = null;
        }

        private void fillListbox(MongoCursor<BsonDocument> cursor)
        {
            foreach (BsonDocument doc in cursor)
	        {
                int elementCount = doc.ElementCount;
                string s = "";
                for(int i = 1; i < elementCount; i++)
                {
                    BsonElement e = doc.GetElement(i);
                    s += e.Name + " : " + e.Value + ", ";
                    
                }
                listBox2.Items.Add(s);
	        }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false; 
            button1.Enabled = false;

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox5.Enabled = true;
            int index = listBox2.SelectedIndex;
            int elementCount;
            listBox3.Items.Clear();
            BsonDocument[] docList = cursor.ToArray<BsonDocument>();
            elementCount = docList[index].ElementCount;
            for (int i = 1; i < elementCount; i++)
                listBox3.Items.Add(i.ToString() + ") " + docList[index].GetElement(i).Name + " : " + docList[index].GetElement(i).Value.ToString());
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BsonDocument[] docList = cursor.ToArray<BsonDocument>();
            int indx = Convert.ToInt16(textBox1.Text);
            var query = new QueryDocument{ {"_id", docList[listBox2.SelectedIndex].GetElement(0).Value } };
            var update = new UpdateDocument{ { "$set", new BsonDocument(nameTxtbox.Text, fieldValueTxtbox.Text)} };
            myCollection.Update(query, update);
            cursor = myCollection.FindAll();
            listBox2.Items.Clear();
            ClearUpdateDeleteBox();
            fillListbox(cursor);
            groupBox5.Enabled = false;
        }

        private void ClearUpdateDeleteBox()
        {
            listBox3.Items.Clear();
            textBox1.Text = "";
            nameTxtbox.Text = "";
            fieldValueTxtbox.Text = "";
        }

    }
}
