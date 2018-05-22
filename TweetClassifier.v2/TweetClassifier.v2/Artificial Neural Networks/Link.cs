using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetClassifier.v2.Artificial_Neural_Networks
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
