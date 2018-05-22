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

namespace TweetClassifier.v3
{
    public partial class Main : Form
    {

        Mongo preparing;
        NaiveBayesForm nbf;
        PerceptronForm pf;
        MultiLayerPerceptronForm mlpf;

        public Main()
        {
            InitializeComponent();
        }

        public Main(Mongo m)
        {
            InitializeComponent();
            preparing = new Mongo();
            preparing = m;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
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
                try 
	            {
                    preparing = new Mongo();
                    preparing.setDataBase(dbNameTxtBox.Text);
                    preparing.setCollection(collectionNameTxtBox.Text);
                    groupBox2.Enabled = true;
                    dbStatusLbl.Text = "MongoDb is ready.";
	            }
	            catch (Exception ex)
	            {
		            dbStatusLbl.Text = ex.Message;
                    return;
	            }
            }
            catch (Exception)
            {
                dbStatusLbl.Text = "Connection error!";
                return;
            }
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                MessageBox.Show("Please Choose a method.");
            else
            {
                switch(comboBox1.SelectedIndex)
                {
                    case 0:
                        nbf = new NaiveBayesForm(preparing);
                        nbf.Show();
                        this.Hide();
                        break;
                    case 1:
                        pf = new PerceptronForm(preparing);
                        pf.Show();
                        this.Hide();
                        break;
                    case 2:
                        mlpf = new MultiLayerPerceptronForm(preparing);
                        mlpf.Show();
                        this.Hide();
                        break;
                }
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
