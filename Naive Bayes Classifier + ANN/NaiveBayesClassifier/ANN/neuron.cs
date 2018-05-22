using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaiveBayesClassifier.ANN
{
    class neuron
    {
        public List<Link> inputLinks;
        public List<Link> outLinks;
        public double value;

        public neuron()
        {
            value = 0;
            inputLinks = new List<Link>();
            outLinks = new List<Link>();
        }
        
        public void calculateValue(List<Link> inputLinks)
        {
            foreach (Link link in inputLinks)
            {
                value += link.inputValue * link.weight;
                
            }
        }
        
        public void setValueOutLinks()
        {
            foreach (Link link in outLinks)
            {
                link.inputValue = value;
            }
        }
    }
}
