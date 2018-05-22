using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaiveBayesClassifier.ANN
{
    class Network
    {
        public List<neuron> neurons;
        public List<Link> links;
        double treshold;
        double alfa, beta;
        int actualOutput;
        double learningRate;
        double error;
        double correction;

        public Network(int numberOfNodes, int numberOfLinks)
        {
            neurons = new List<neuron>();
            links = new List<Link>();
            for (int i = 0; i < numberOfNodes; i++)
            {
                neuron n = new neuron();
                neurons.Add(n);
            }
            
            for (int i = 0; i < numberOfLinks; i++)
            {
                Link l = new Link();
                links.Add(l);
            }
        }

        public double lineerFunction(double x)
        {
            return alfa * x + beta;
        }

        public double hyperbolicTangent(double x)
        {
            double a = Math.Exp(x);
            double b = Math.Exp(-x);

            return (a - b) / (a + b);
        }

        public double sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
        
        public void filterValues(List<Person> people)
        {
            double[] min = new double[3];//height, weight, footSize
            double[] max = new double[3];//height, weight, footSize

            min[0] = people[0].height;
            min[1] = people[0].weight;
            min[2] = people[0].footSize;
            max[0] = people[0].height;
            max[1] = people[0].weight;
            max[2] = people[0].footSize;
            
            foreach (Person p in people)
            {
                if (min[0] > p.height)
                    min[0] = p.height;
                if (min[1] > p.weight)
                    min[1] = p.weight;
                if (min[2] > p.footSize)
                    min[2] = p.footSize;

                if (max[0] < p.height)
                    max[0] = p.height;
                if (max[1] < p.weight)
                    max[1] = p.weight;
                if (max[2] < p.footSize)
                    max[2] = p.footSize;            
            }

            foreach (Person p in people)
            {
                p.height = (p.height - min[0]) / (max[0] - min[0]);
                p.weight = (p.weight - min[1]) / (max[1] - min[1]);
                p.footSize = (p.footSize - min[2]) / (max[2] - min[2]);
            }     
        }

        public void initilizeWeights()
        {
            for (int i = 0; i < links.Count(); i++)
            {
                links[i].weight = 0.4;
            }
        }

        public void setTreshold(double t)
        {
            treshold = t;
        }

        public void setLearningRate(double rate)
        {
            learningRate = rate;
        }

        public void Connect(neuron n1, neuron n2, Link l1)
        {
            l1.inputValue = n1.value;
            l1.neurons[0] = n1;
            l1.neurons[1] = n2;
            n1.outLinks.Add(l1);
            n2.inputLinks.Add(l1);
        }
        
        public int train(List<Person> people)
        {
            filterValues(people);
            initilizeWeights();
            int errorCount;
            int numberOfIteration = 0;
            while(true)
            {
                numberOfIteration++;
                errorCount = 0;
                foreach (Person p in people)
	            {
                    neurons[0].value = p.height;
                    neurons[1].value = p.weight;
                    neurons[2].value = p.footSize;
                    double s = links[0].neurons[0].value * links[0].weight + links[1].neurons[0].value * links[1].weight + links[2].neurons[0].value * links[2].weight;
                    if (s < treshold)
                        actualOutput = 1;
                    else
                        actualOutput = 0;

                    error = Convert.ToDouble((actualOutput - p.sex));
                    if (error != 0)
                        errorCount++;
                    correction = error * learningRate;

                    links[0].weight = links[0].weight + correction * links[0].neurons[0].value;
                    links[1].weight = links[1].weight + correction * links[1].neurons[0].value;
                    links[2].weight = links[0].weight + correction * links[0].neurons[0].value;
		 
	            }

                if (errorCount == 0)
                    break;
            }

            return numberOfIteration;
        }

        public int classify()
        {
            double s = links[0].neurons[0].value * links[0].weight + links[1].neurons[0].value * links[1].weight + links[2].neurons[0].value * links[2].weight;
            if (s < treshold)
                return 1;
            else
                return  0;
        }
    }
}
