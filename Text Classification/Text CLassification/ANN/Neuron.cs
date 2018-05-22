using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_CLassification.ANN
{
    class Neuron
    {
        public List<Link> inputLinks;
        public List<Link> outLinks;
        public double value;

        public Neuron()
        {
            value = 0;
            inputLinks = new List<Link>();
            outLinks = new List<Link>();
        }

        public void CalculateValue(List<Link> inputLinks)
        {
            foreach (Link link in inputLinks)
            {
                value += link.neurons[0].value * link.weight;

            }
        }
    }
}
