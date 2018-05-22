using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

namespace ParserForNews
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "mongodb://localhost";
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase("News");
            MongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("Perceptron");
            BsonClassMap.RegisterClassMap<New>();

            System.Diagnostics.Process.Start("mongod.exe");

            int newClass = 0;
            double[] frequency = new double[100];
            int numberOfwords = 0;
            StreamWriter outfile = new StreamWriter(@"C:\Users\eozacan\Desktop\x.txt");

            for (int i = 0; i < 100; i++)
                frequency[i] = 0;

            for (int i = 1; i <= 750; i++)
            {
                if (i != 1 && (i - 1) % 150 == 0)
                    newClass++;
                string s = "";
                s += "C:\\Users\\eozacan\\Desktop\\haberler\\";
                s += i.ToString() + ".txt";
                StreamReader infile = new StreamReader(s, Encoding.GetEncoding("windows-1254"));
                New n = new New();

                string str = infile.ReadToEnd();
                n.Parse(newClass, str, frequency, ref  numberOfwords);
                collection.Save(n.ToBsonDocument()); 
            }

            Console.WriteLine("\nFrequencies are being calculated.");

            for (int i = 0; i < 100; i++)
            {
                frequency[i] = frequency[i] / numberOfwords;
            }

            for (int i = 0; i < 100; i++)
            {
                outfile.WriteLine(frequency[i]);
                Console.WriteLine(i.ToString() + " : " + frequency[i].ToString());
            }

            Console.ReadLine();
            outfile.Close();

        }
    }
}
