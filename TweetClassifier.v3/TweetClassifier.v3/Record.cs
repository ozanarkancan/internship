﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetClassifier.v3.ANN;

namespace TweetClassifier.v3
{
    class Record
    {
        public DateTime date;
        public string input;
        public string hidden;
        public string output;
        public int links;
        public string accuracy;
        public string treshold;
        public string learningRate;
        public string trainData;
        public string testData;
        public int function;
        public string minTrainRate;
        public string numberOfEpoch;
        public List<double> weight;

        public Record()
        {
            weight = new List<double>();
        }
    }
}
