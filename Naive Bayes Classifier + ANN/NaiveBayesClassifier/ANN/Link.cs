using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaiveBayesClassifier.ANN
{
    class Link
    {
        public double weight;
        public double inputValue;
        public neuron[] neurons;
        public Link()
        {
            neurons = new neuron[2];
        }
    }
}
