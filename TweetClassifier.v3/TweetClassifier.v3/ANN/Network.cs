using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetClassifier.v3.Data;
using System.Windows.Forms;
using System.Threading;

namespace TweetClassifier.v3.ANN
{
    class Network
    {
        public List<Neuron> inputLayer;
        public List<Neuron> hiddenLayer;
        public List<Neuron> outputLayer;
        public List<Link> links;
        public List<Pattern> trainSet;

        public int numberOfIteration;
        public double trainErrorRate;

        double learningRate;
        double treshold;
        double error;
        double correction;
        double alfa;
        double beta;
        int iterationLimit;
        double trainErrorLimit;
        int validFunction;

        public Network(int iNodes, int hNodes, int oNodes)
        {
            int numberOfLinks;
            if (hNodes != 0)
            {
                numberOfLinks = (iNodes + 1) * hNodes;
                numberOfLinks += (hNodes + 1) * oNodes;
            }
            else
            {
                numberOfLinks = (iNodes + 1) * oNodes;
            }

            inputLayer = new List<Neuron>();
            if(hNodes != 0)
                hiddenLayer = new List<Neuron>();
            outputLayer = new List<Neuron>();
            links = new List<Link>();
            trainSet = new List<Pattern>();

            for (int i = 0; i < iNodes + 1; i++)
            {
                Neuron n = new Neuron();
                inputLayer.Add(n);
            }
            if (hNodes != 0)
            {
                for (int i = 0; i < hNodes + 1; i++)
                {
                    Neuron n = new Neuron();
                    hiddenLayer.Add(n);
                }
            }

            for (int i = 0; i < oNodes; i++)
            {
                Neuron n = new Neuron();
                outputLayer.Add(n);
            }

            for (int i = 0; i < numberOfLinks; i++)
            {
                Link l = new Link();
                links.Add(l);
            }

            if (hNodes == 0)
            {
                int lcount = 0;
                for (int i = 0; i < outputLayer.Count; i++)
                {
                    for (int j = 0; j < inputLayer.Count; j++)
                    {
                        Connect(inputLayer[j], outputLayer[i], links[lcount]);
                        lcount++;
                    }
                }
            }
            else
            {
                int lcount = 0;
                for (int i = 0; i < hiddenLayer.Count - 1; i++)
                {
                    for (int j = 0; j < inputLayer.Count; j++)
                    {
                        Connect(inputLayer[j], hiddenLayer[i], links[lcount]);
                        lcount++;
                    }
                }
                for (int i = 0; i < outputLayer.Count; i++)
                {
                    for (int j = 0; j < hiddenLayer.Count; j++)
                    {
                        Connect(hiddenLayer[j], outputLayer[i], links[lcount]);
                        lcount++;
                    }
                } 
            }
            initilizeWeight();
        }

        public void Connect(Neuron n1, Neuron n2, Link l1)
        {
            l1.neurons[0] = n1;
            l1.neurons[1] = n2;
            n1.outLinks.Add(l1);
            n2.inputLinks.Add(l1);
        }

        public double Function(double x)
        {
            switch (validFunction)
            {
                case 0:
                    return linear(x);
                case 1:
                    return Sigmoid(x);
                case 2:
                    return HyperbolicTangent(x);
                default:
                    return Sigmoid(x);
            }
        }

        public double linear(double x)
        {
            double s = alfa * x + beta;
            if (s > treshold)
                return 1;
            else
                return 0;
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

        public void SetValidFunction(int val)
        {
            /*
             *  0 - Linear
             *  1 - Sigmoid
             *  2 - Hyperbolic Tangent
             */
             
            validFunction = val;
        }

        public void SetTrainErrorLimit(double val)
        {
            trainErrorLimit = val;
        }

        public void SetIterationLimit(int val = 1000)
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

        public void SetAlfaAndBeta(double a, double b)
        {
            alfa = a;
            beta = b;
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

        public void Swap( Pattern p1,  Pattern p2)
        {
            Pattern tmp = new Pattern();
            tmp = p1;
            p1 = p2;
            p2 = tmp;
        }

        public void ShuffleTrainSet()
        {
            int seed = DateTime.Now.Millisecond * DateTime.Now.Second;
            Random r = new Random(seed);
            for (int i = 0; i < trainSet.Count; i++)
            {
                seed = r.Next(0, trainSet.Count);
                Swap(trainSet[i],trainSet[seed]);
                r = new Random(seed);
            }
        }

        public void trainPerceptron(bool trainError, bool iteration, bool shuffling)
        {
            numberOfIteration = 0;
            int min = trainSet.Count*outputLayer.Count*100;
            while (true)
            {
                numberOfIteration++;
                int errorCount = 0;
                if (shuffling)
                    ShuffleTrainSet();
                foreach (Pattern p in trainSet)
                {
                    int[] outNodes = new int[outputLayer.Count];
                    double s = 0;

                    for(int i = 0; i < outNodes.Count<int>(); i++)
                        outNodes[i] = 0;
                    outNodes[p.output] = 1;

                    for (int i = 0; i < p.featureVector.Count; i++)
                        inputLayer[i].value = p.featureVector[i];

                    inputLayer[inputLayer.Count - 1].value = 1; // bias node;

                    for (int i = 0; i < outputLayer.Count; i++)
                    {
                        s = 0;
                        foreach (Link link in outputLayer[i].inputLinks)
                        {
                            s += link.weight * link.neurons[0].value;
                        }

                        s = Function(s);

                        if (s > treshold)
                            outputLayer[i].value = 1;
                        else
                            outputLayer[i].value = 0;

                        error = outNodes[i] - outputLayer[i].value;
                        if (error != 0)
                            errorCount++;
                        correction = error * learningRate;

                        foreach (Link link in outputLayer[i].inputLinks)
                            link.weight = link.weight + correction * link.neurons[0].value;
                    }
                    
                }
                if (min > errorCount)
                    min = errorCount;
                trainErrorRate = (errorCount / (double)(trainSet.Count * outputLayer.Count));
                if (trainError && !iteration)
                {
                    if (trainErrorRate <= trainErrorLimit)
                        break;
                    else
                    {
                        if (numberOfIteration == 50000)
                        {
                            MessageBox.Show("Default iteration limit(50000) is exceeded.\nTraining is stoped");
                            break;
                        }
                    }

                }
                else
                {
                    if (trainError && iteration)
                    {
                        if (trainErrorRate <= trainErrorLimit)
                            break;
                        else if (numberOfIteration >= iterationLimit)
                            break;
                    }
                    else
                    {
                        if (numberOfIteration >= iterationLimit)
                            break;
                    }
                }
            }
        }

        public void trainBackPropagation(bool trainError, bool iteration, bool shuffling)
        {
            numberOfIteration = 0;
            int min = trainSet.Count * outputLayer.Count * 100;
            while (true)
            {
                if (shuffling)
                    ShuffleTrainSet();
                numberOfIteration++;
                int errorCount = 0;
                foreach (Pattern p in trainSet)
                {
                    int[] outNodes = new int[outputLayer.Count];
                    double s = 0;

                    for (int i = 0; i < outNodes.Count<int>(); i++)
                        outNodes[i] = 0;
                    outNodes[p.output] = 1;


                    for (int i = 0; i < p.featureVector.Count; i++)
                        inputLayer[i].value = p.featureVector[i];
                    inputLayer[inputLayer.Count - 1].value = 1; // bias node

                    for (int i = 0; i < hiddenLayer.Count - 1; i++)
                    {
                        s = 0;
                        foreach (Link link in hiddenLayer[i].inputLinks)
                        {
                            s += link.weight * link.neurons[0].value; 
                        }

                        s = Function(s);

                        if (s > treshold)
                            hiddenLayer[i].value = 1;
                        else
                            hiddenLayer[i].value = 0;
                    }

                    hiddenLayer[hiddenLayer.Count - 1].value = 1; //bias node;

                    for (int i = 0; i < outputLayer.Count; i++)
                    {
                        s = 0;
                        foreach (Link link in outputLayer[i].inputLinks)
                        {
                            s += link.weight * link.neurons[0].value;
                        }

                        s = Function(s);
                        if (s > treshold)
                            outputLayer[i].value = 1;
                        else
                            outputLayer[i].value = 0;

                        foreach (Link link in outputLayer[i].inputLinks)
                        {
                            link.weight = link.weight + learningRate * link.neurons[0].value * (outputLayer[i].value * (1 - outputLayer[i].value) * (outNodes[i] - outputLayer[i].value));
                        }
 
                    }

                    for (int i = 0; i < hiddenLayer.Count - 1; i++)
                    {
                        foreach (Link link in hiddenLayer[i].inputLinks)
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
                    for (int i = 0; i < outputLayer.Count; i++)
                        error += Math.Pow(outNodes[i] - outputLayer[i].value, 2);

                    error = Math.Sqrt(error) / outputLayer.Count;
                    if (error != 0)
                        errorCount++;               
                }
                if (min > errorCount)
                    min = errorCount;
                trainErrorRate = (errorCount / (double)(trainSet.Count));
                if (trainError && !iteration)
                {
                    if (trainErrorRate < trainErrorLimit)
                        break;
                    else
                    {
                        if (numberOfIteration == 10000)
                        {
                            MessageBox.Show("Default iteration limit(10000) is exceeded.\nTraining is stoped");
                            break;
                        }
                    }

                }
                else
                {
                    if (trainError && iteration)
                    {
                        if (trainErrorRate <= trainErrorLimit)
                            break;
                        else if (numberOfIteration >= iterationLimit)
                            break;
                    }
                    else
                    {
                        if (numberOfIteration >= iterationLimit)
                            break;
                    }
                }
            }
 
        }

        public int ClassifyPerceptron(Pattern p)
        {
            double max = -2;
            int result = 0;
            for (int i = 0; i < p.featureVector.Count; i++)
                inputLayer[i].value = p.featureVector[i];

            for (int i = 0; i < outputLayer.Count; i++)
            {
                outputLayer[i].value = 0;
                foreach (Link link in outputLayer[i].inputLinks)
                    outputLayer[i].value += link.weight * link.neurons[0].value;
                outputLayer[i].value = Function(outputLayer[i].value);
                if (max < outputLayer[i].value)
                {
                    max = outputLayer[i].value;
                    result = i;
                }
            }

            return result;
        }

        public int ClassifyBackpropagation(Pattern p)
        {
            double max = -2;
            int result = 0;
            for (int i = 0; i < p.featureVector.Count; i++)
                inputLayer[i].value = p.featureVector[i];

            for (int i = 0; i < hiddenLayer.Count - 1; i++)
            {
                hiddenLayer[i].value = 0;

                foreach (Link link in hiddenLayer[i].inputLinks)
                    hiddenLayer[i].value += link.weight * link.neurons[0].value;

                hiddenLayer[i].value = Function(hiddenLayer[i].value);

                if (hiddenLayer[i].value > treshold)
                    hiddenLayer[i].value = 1;
                else
                    hiddenLayer[i].value = 0;
            }

            for (int i = 0; i < outputLayer.Count; i++)
            {
                outputLayer[i].value = 0;

                foreach (Link link in outputLayer[i].inputLinks)
                    outputLayer[i].value += link.weight * link.neurons[0].value;

                outputLayer[i].value = Function(outputLayer[i].value);
                
                if (max < outputLayer[i].value)
                {
                    max = outputLayer[i].value;
                    result = i;
                }
            }

            return result;
        }


    }
}
