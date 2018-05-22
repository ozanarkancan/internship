using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Text_CLassification.Data;
using MongoDB.Bson;
using System.IO;

namespace Text_CLassification
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
            StreamReader infile = new StreamReader("newFrequency.txt");
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

        private void Swap(Pattern p1, Pattern p2)
        {
            Pattern tmp = new Pattern();
            tmp = p1;
            p1 = p2;
            p2 = tmp;
        }

        private void Shuffle(List<Pattern> l)
        {
            int seed = DateTime.Now.Millisecond * DateTime.Now.Second;
            Random r = new Random(seed);
            for (int i = 0; i < l.Count; i++)
            {
                seed = r.Next(0, l.Count);
                Swap(l[i], l[seed]);
                r = new Random(seed);
            }
        }

        private void obtainData()
        {
            preparing.getAllData();
            foreach (BsonDocument doc in preparing.cursor)//Obtaining Data Set from database
            {
                Pattern p = new Pattern();
                p.output = doc["output"].ToInt32();
                p.featureVector.Add(doc["devlet"].ToDouble());
                p.featureVector.Add(doc["düşüş"].ToDouble());
                p.featureVector.Add(doc["düzey"].ToDouble());
                p.featureVector.Add(doc["eğilim"].ToDouble());
                p.featureVector.Add(doc["ekonomi"].ToDouble());
                p.featureVector.Add(doc["enflasyon"].ToDouble());
                p.featureVector.Add(doc["firma"].ToDouble());
                p.featureVector.Add(doc["fiyat"].ToDouble());
                p.featureVector.Add(doc["fuar"].ToDouble());
                p.featureVector.Add(doc["ihale"].ToDouble());
                p.featureVector.Add(doc["ihraç"].ToDouble());
                p.featureVector.Add(doc["kalkınma"].ToDouble());
                p.featureVector.Add(doc["kamu"].ToDouble());
                p.featureVector.Add(doc["petrol"].ToDouble());
                p.featureVector.Add(doc["taahhüt"].ToDouble());
                p.featureVector.Add(doc["tutma"].ToDouble());
                p.featureVector.Add(doc["ürün"].ToDouble());
                p.featureVector.Add(doc["yatırım"].ToDouble());
                p.featureVector.Add(doc["yükseliş"].ToDouble());
                p.featureVector.Add(doc["yüzde"].ToDouble());
                p.featureVector.Add(doc["aşk"].ToDouble());
                p.featureVector.Add(doc["kilo"].ToDouble());
                p.featureVector.Add(doc["arkadaş"].ToDouble());
                p.featureVector.Add(doc["film"].ToDouble());
                p.featureVector.Add(doc["televizyon"].ToDouble());
                p.featureVector.Add(doc["program"].ToDouble());
                p.featureVector.Add(doc["yıldız"].ToDouble());
                p.featureVector.Add(doc["tatil"].ToDouble());
                p.featureVector.Add(doc["kostüm"].ToDouble());
                p.featureVector.Add(doc["oyuncu"].ToDouble());
                p.featureVector.Add(doc["dizi"].ToDouble());
                p.featureVector.Add(doc["sevgili"].ToDouble());
                p.featureVector.Add(doc["parti"].ToDouble());
                p.featureVector.Add(doc["rol"].ToDouble());
                p.featureVector.Add(doc["genç"].ToDouble());
                p.featureVector.Add(doc["çekim"].ToDouble());
                p.featureVector.Add(doc["başrol"].ToDouble());
                p.featureVector.Add(doc["defile"].ToDouble());
                p.featureVector.Add(doc["albüm"].ToDouble());
                p.featureVector.Add(doc["yayın"].ToDouble());
                p.featureVector.Add(doc["tıp"].ToDouble());
                p.featureVector.Add(doc["hastane"].ToDouble());
                p.featureVector.Add(doc["sağlık"].ToDouble());
                p.featureVector.Add(doc["ilaç"].ToDouble());
                p.featureVector.Add(doc["ameliyat"].ToDouble());
                p.featureVector.Add(doc["hasta"].ToDouble());
                p.featureVector.Add(doc["doktor"].ToDouble());
                p.featureVector.Add(doc["bebek"].ToDouble());
                p.featureVector.Add(doc["tespit"].ToDouble());
                p.featureVector.Add(doc["tedavi"].ToDouble());
                p.featureVector.Add(doc["insan"].ToDouble());
                p.featureVector.Add(doc["çocuk"].ToDouble());
                p.featureVector.Add(doc["kanser"].ToDouble());
                p.featureVector.Add(doc["vitamin"].ToDouble());
                p.featureVector.Add(doc["ağrı"].ToDouble());
                p.featureVector.Add(doc["cerrah"].ToDouble());
                p.featureVector.Add(doc["kontrol"].ToDouble());
                p.featureVector.Add(doc["diyabet"].ToDouble());
                p.featureVector.Add(doc["kalp"].ToDouble());
                p.featureVector.Add(doc["tansiyon"].ToDouble());
                p.featureVector.Add(doc["bakan"].ToDouble());
                p.featureVector.Add(doc["hükümet"].ToDouble());
                p.featureVector.Add(doc["meclis"].ToDouble());
                p.featureVector.Add(doc["seçim"].ToDouble());
                p.featureVector.Add(doc["oy"].ToDouble());
                p.featureVector.Add(doc["halk"].ToDouble());
                p.featureVector.Add(doc["demokrasi"].ToDouble());
                p.featureVector.Add(doc["anayasa"].ToDouble());
                p.featureVector.Add(doc["yetki"].ToDouble());
                p.featureVector.Add(doc["yargı"].ToDouble());
                p.featureVector.Add(doc["savcı"].ToDouble());
                p.featureVector.Add(doc["yasak"].ToDouble());
                p.featureVector.Add(doc["ceza"].ToDouble());
                p.featureVector.Add(doc["slogan"].ToDouble());
                p.featureVector.Add(doc["miting"].ToDouble());
                p.featureVector.Add(doc["laik"].ToDouble());
                p.featureVector.Add(doc["mahkeme"].ToDouble());
                p.featureVector.Add(doc["ulus"].ToDouble());
                p.featureVector.Add(doc["elçi"].ToDouble());
                p.featureVector.Add(doc["heyet"].ToDouble());
                p.featureVector.Add(doc["fark"].ToDouble());
                p.featureVector.Add(doc["fikstür"].ToDouble());
                p.featureVector.Add(doc["forma"].ToDouble());
                p.featureVector.Add(doc["futbol"].ToDouble());
                p.featureVector.Add(doc["galibiyet"].ToDouble());
                p.featureVector.Add(doc["gol"].ToDouble());
                p.featureVector.Add(doc["hakem"].ToDouble());
                p.featureVector.Add(doc["kart"].ToDouble());
                p.featureVector.Add(doc["lider"].ToDouble());
                p.featureVector.Add(doc["lig"].ToDouble());
                p.featureVector.Add(doc["maç"].ToDouble());
                p.featureVector.Add(doc["menajer"].ToDouble());
                p.featureVector.Add(doc["pozisyon"].ToDouble());
                p.featureVector.Add(doc["puan"].ToDouble());
                p.featureVector.Add(doc["saha"].ToDouble());
                p.featureVector.Add(doc["spor"].ToDouble());
                p.featureVector.Add(doc["stad"].ToDouble());
                p.featureVector.Add(doc["şampiyon"].ToDouble());
                p.featureVector.Add(doc["teşvik"].ToDouble());
                p.featureVector.Add(doc["transfer"].ToDouble());
                dSet.Add(p);
            }

            Shuffle(dSet);
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
