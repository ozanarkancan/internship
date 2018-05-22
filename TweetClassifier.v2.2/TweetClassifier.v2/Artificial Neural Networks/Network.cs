using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetClassifier.v2.Data;
using System.Windows.Forms;
using System.Threading;

namespace TweetClassifier.v2.Artificial_Neural_Networks
{
    class Network
    {
        public List<Neuron> neurons;
        public List<Link> links;
        public List<Pattern> trainSet;
        double learningRate;
        double treshold;
        double error;
        double correction;
        int iterationLimit;

        public Network(int numberOfNodes, int numberOfLinks)
        {
            neurons = new List<Neuron>();
            links = new List<Link>();
            trainSet = new List<Pattern>();
            iterationLimit = 1000;
            for (int i = 0; i < numberOfNodes; i++)
            {
                Neuron n = new Neuron();
                neurons.Add(n);
            }

            for (int i = 0; i < numberOfLinks; i++)
            {
                Link l = new Link();
                links.Add(l);
            }
        }

        public void Connect(Neuron n1, Neuron n2, Link l1)
        {
            l1.neurons[0] = n1;
            l1.neurons[1] = n2;
            n1.outLinks.Add(l1);
            n2.inputLinks.Add(l1);
        }

        public double HyperbolicTangent(double x)
        {
            double a = Math.Exp(x);
            double b = Math.Exp(-x);

            return (a - b) / (a + b);
        }

        public double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public void setIterationLimit(int val)
        {
            iterationLimit = val;
        }

        public void SetTreshold(double t)
        {
            treshold = t;
        }

        public void SetLearningRate(double rate)
        {
            learningRate = rate;
        }

        public void initilizeWeight()
        {
            Random rNumber = new Random(DateTime.Now.Millisecond*DateTime.Now.Second);
            double number = rNumber.Next(100);
            double pow = rNumber.Next(2);
            links[0].weight = number / 100 * Math.Pow(-1, pow);

            for (int i = 1; i < links.Count; i++)
            {
                rNumber = new Random((int)(links[i - 1].weight * 100));
                number = rNumber.Next(100);
                pow = rNumber.Next(2);
                links[i].weight = number / 100 * Math.Pow(-1, pow);
            }
        }

        public void trainPerceptron(bool check)
        {
            if(check)
                initilizeWeight();
            int count = 0;
            int min = 3000;
            while (true)
            {
                count++;
                int errorCount = 0;
                foreach (Pattern p in trainSet)
                {
                    int[] outNodes = new int[4];
                    double s = 0;

                    switch (p.output)
                    {
                        case 0:
                            outNodes[0] = 1;
                            outNodes[1] = 0;
                            outNodes[2] = 0;
                            outNodes[3] = 0;
                            break;

                        case 1:
                            outNodes[0] = 0;
                            outNodes[1] = 1;
                            outNodes[2] = 0;
                            outNodes[3] = 0;
                            break;

                        case 2:
                            outNodes[0] = 0;
                            outNodes[1] = 0;
                            outNodes[2] = 1;
                            outNodes[3] = 0;
                            break;

                        case 3:
                            outNodes[0] = 0;
                            outNodes[1] = 0;
                            outNodes[2] = 0;
                            outNodes[3] = 1;
                            break;
                    }

                    for (int i = 0; i < p.featureVector.Count; i++)
                        neurons[i].value = p.featureVector[i];

                    neurons[28].value = 1; // bias node;

                    for (int i = 29; i < 33; i++)
                    {
                        s = 0;
                        foreach (Link link in neurons[i].inputLinks)
                        {
                            s += link.weight * link.neurons[0].value;
                        }

                        s = Sigmoid(s);
                        if (s > treshold)
                            neurons[i].value = 1;
                        else
                            neurons[i].value = 0;

                        error = outNodes[i - 29] - neurons[i].value;
                        if (error != 0)
                            errorCount++;
                        correction = error * learningRate;

                        foreach (Link link in neurons[i].inputLinks)
                            link.weight = link.weight + correction * link.neurons[0].value;

                    }
                    
                }
                //if (errorCount < (double)trainSet.Count*0.96)
                //if(errorCount == 0)
                if (min > errorCount)
                    min = errorCount;
                if (count == iterationLimit)
                    break;
            }
            MessageBox.Show("Min error:" + min.ToString() + "\nNumber of iteration: " + count.ToString());
 
        }

        public void trainBackPropagation(bool check)
        {
            if(check)
                initilizeWeight();
            int count = 0;
            while (true)
            {
                count++;
                int errorCount = 0;
                foreach (Pattern p in trainSet)
                {
                    int[] outNodes = new int[4];
                    double s = 0;

                    switch (p.output)
                    {
                        case 0:
                            outNodes[0] = 1;
                            outNodes[1] = 0;
                            outNodes[2] = 0;
                            outNodes[3] = 0;
                            break;

                        case 1:
                            outNodes[0] = 0;
                            outNodes[1] = 1;
                            outNodes[2] = 0;
                            outNodes[3] = 0;
                            break;

                        case 2:
                            outNodes[0] = 0;
                            outNodes[1] = 0;
                            outNodes[2] = 1;
                            outNodes[3] = 0;
                            break;

                        case 3:
                            outNodes[0] = 0;
                            outNodes[1] = 0;
                            outNodes[2] = 0;
                            outNodes[3] = 1;
                            break;
                    }

                    for (int i = 0; i < p.featureVector.Count; i++)
                        neurons[i].value = p.featureVector[i];
                    neurons[28].value = 1;
                    neurons[43].value = 1;
                    for (int i = 29; i < 43; i++)
                    {
                        s = 0;
                        foreach (Link link in neurons[i].inputLinks)
                        {
                            s += link.weight * link.neurons[0].value;
                        }

                        s = Sigmoid(s);
                        if (s > treshold)
                            neurons[i].value = 1;
                        else
                            neurons[i].value = 0;
                    }

                    for (int i = 44; i < 48; i++)
                    {
                        s = 0;
                        foreach (Link link in neurons[i].inputLinks)
                        {
                            s += link.weight * link.neurons[0].value;
                        }

                        s = Sigmoid(s);
                        if (s > treshold)
                            neurons[i].value = 1;
                        else
                            neurons[i].value = 0;

                        foreach (Link link in neurons[i].inputLinks)
                        {
                            link.weight = link.weight + learningRate * link.neurons[0].value * (neurons[i].value * (1 - neurons[i].value) * (outNodes[i - 44] - neurons[i].value));
                        }
                    }

                    for (int i = 29; i < 43; i++)
                    {
                        foreach (Link link in neurons[i].inputLinks)
                        {
                            double val = link.neurons[1].value * (1 - link.neurons[1].value);
                            double val2 = 0;
                            for (int j = 0; j < link.neurons[1].outLinks.Count; j++)
                            {
                                val2 += link.neurons[1].outLinks[j].weight * (link.neurons[1].outLinks[j].neurons[1].value * (1 - link.neurons[1].outLinks[j].neurons[1].value) * (outNodes[j] - link.neurons[1].outLinks[j].neurons[1].value));
                            }

                            link.weight = link.weight + learningRate * link.neurons[0].value * val * val2;

                        }
                    }
                    
                    error = 0;
                    for (int i = 44; i < 48; i++)
                        error += Math.Pow(outNodes[i - 44] - neurons[i].value, 2);

                    error = Math.Sqrt(error) / 2;
                    if (error != 0)
                        errorCount++;
               
                }
                MessageBox.Show("Number of iteration: " + count.ToString() + " errorCount : " + errorCount.ToString());
                if (count == iterationLimit)
                    break;
            }
 
        }

        public int ClassifyPerceptron(Pattern p)
        {
            double max = -2;
            int result = 0;
            for (int i = 0; i < p.featureVector.Count; i++)
                neurons[i].value = p.featureVector[i];
            neurons[28].value = 1;
            for (int i = 29; i < 33; i++)
            {
                neurons[i].value = 0;
                foreach (Link link in neurons[i].inputLinks)
                    neurons[i].value += link.weight * link.neurons[0].value;
                neurons[i].value = Sigmoid(neurons[i].value);
                if (max < neurons[i].value)
                {
                    max = neurons[i].value;
                    result = i - 29;
                }
            }

            return result;
        }

        public int ClassifyBackpropagation(Pattern p)
        {
            double max = -2;
            int result = 0;
            for (int i = 0; i < p.featureVector.Count; i++)
                neurons[i].value = p.featureVector[i];
            for (int i = 29; i < 43; i++)
            {
                neurons[i].value = 0;
                foreach (Link link in neurons[i].inputLinks)
                    neurons[i].value += link.weight * link.neurons[0].value;
                neurons[i].value = Sigmoid(neurons[i].value);
                if (neurons[i].value > treshold)
                    neurons[i].value = 1;
                else
                    neurons[i].value = 0;
            }
            for (int i = 44; i < 48; i++)
            {
                neurons[i].value = 0;
                foreach (Link link in neurons[i].inputLinks)
                    neurons[i].value += link.weight * link.neurons[0].value;
                neurons[i].value = Sigmoid(neurons[i].value);
                if (max < neurons[i].value)
                {
                    max = neurons[i].value;
                    result = i - 44;
                }
            }

            return result;
        }


    }
}
