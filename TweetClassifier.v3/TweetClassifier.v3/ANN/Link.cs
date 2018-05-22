using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetClassifier.v3.ANN
{
    class Link
    {
        public double weight;
        public Neuron[] neurons;
        
        public Link()
        {
            neurons = new Neuron[2];
        }
    }
}
