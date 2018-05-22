using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using System.IO;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "mongodb://localhost";
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase("Tweeter");
            MongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("Deneme");
            BsonClassMap.RegisterClassMap<Tweet>();
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            string str;
            double[] frequency = new double[28];
            int numberOfwords = 0;
            int count = 0;            

            System.Diagnostics.Process.Start("mongod.exe");
            StreamWriter outfile = new StreamWriter(@"C:\Users\eozacan\Desktop\x.txt");
            

            for (int i = 0; i < 28; i++)
                frequency[i] = 0;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(@"C:\Users\eozacan\Desktop\TweetterData.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;

            Dictionary<double, Dictionary<int, double>> fixxer = new Dictionary<double, Dictionary<int, double>>();
            Console.WriteLine("Data is being processed.");

            for (int rowCnt = 2; rowCnt <= range.Rows.Count; rowCnt++)
            {
                Tweet parsedTweet = new Tweet();

                for (int columnCnt = 1; columnCnt <= range.Columns.Count; columnCnt++)
                {
                    if (columnCnt == 1)
                    {
                        str = (string)(range.Cells[rowCnt, columnCnt] as Excel.Range).Value2;
                        parsedTweet.Parse(str, frequency, ref numberOfwords);

                    }
                    else if (columnCnt == 2)
                    {
                        parsedTweet.output = Convert.ToInt32((range.Cells[rowCnt, columnCnt] as Excel.Range).Value2);
                        collection.Save(parsedTweet.ToBsonDocument());
                    }
                    else throw new Exception("(1)Error");

                }
            }

            Console.WriteLine("Frequencies are being calculated.");

            for (int i = 0; i < 28; i++)
            {
                frequency[i] = frequency[i] / numberOfwords;
            }

            for (int i = 0; i < 28; i++)
            {
                outfile.WriteLine(frequency[i]);
                Console.WriteLine(i.ToString() + " : " + frequency[i].ToString());
            }

            Console.ReadLine();
            outfile.Close();

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

    }
}
