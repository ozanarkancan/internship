using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetClassifier.v2.Data
{
    class Pattern
    {
        public List<double> featureVector;
        public int output;
        
        public Pattern()
        {
            featureVector = new List<double>();
        }
    }
}

