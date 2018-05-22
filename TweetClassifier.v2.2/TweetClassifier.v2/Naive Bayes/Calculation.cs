using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetClassifier.v2.Data;

namespace TweetClassifier.v2.Naive_Bayes
{
    class Calculation
    {
        public Dictionary<int, int> numberOfDataInClass;
        public Dictionary<int, List<double>> means;
        public Dictionary<int, List<double>> variance;
        public Dictionary<int, List<double>> gaussProbabilities;
        public List<double> posteriorProbabilities;
        public List<Pattern> trainSet;
        public List<double> classProbabilities;
        public List<double> weight;


        public Calculation()
        {
            numberOfDataInClass = new Dictionary<int,int>();
            means = new Dictionary<int, List<double>>();
            variance = new Dictionary<int,List<double>>();
            posteriorProbabilities = new List<double>();
            gaussProbabilities = new Dictionary<int, List<double>>();
            trainSet = new List<Pattern>();
            classProbabilities = new List<double>();
            weight = new List<double>();
        }

        public void CalculateMeans()
        {
            foreach (Pattern p in trainSet)
            {
                if (!numberOfDataInClass.ContainsKey(p.output))
                {
                    numberOfDataInClass.Add(p.output, 1);
                    List<double> list = new List<double>();
                    foreach (int val in p.featureVector)
                        list.Add(val);
                    means.Add(p.output, list);
                }
                else
                {
                    numberOfDataInClass[p.output]++;
                    for (int i = 0; i < p.featureVector.Count; i++)
                        means[p.output][i] += p.featureVector[i];
                }
            }

            for (int i = 0; i < means.Count; i++)
            {
                for (int j = 0; j < means[i].Count; j++)
                    means[i][j] = (means[i][j] + 1) / (numberOfDataInClass[i] + numberOfDataInClass.Count);
            }

        }

        public void CalculateVariance()
        {
            foreach (Pattern p in trainSet)
            {
                if (!variance.ContainsKey(p.output))
                {
                    List<double> list = new List<double>();
                    for (int i = 0; i < p.featureVector.Count; i++)
                        list.Add(Math.Pow((p.featureVector[i] - means[p.output][i]), 2));
                    variance.Add(p.output, list);
                }
                else
                {
                    for (int i = 0; i < p.featureVector.Count; i++)
                        variance[p.output][i] += (Math.Pow((p.featureVector[i] - means[p.output][i]), 2));
                }
            }

            for (int i = 0; i < variance.Count; i++)
            {
                for (int j = 0; j < variance[i].Count; j++)
                    variance[i][j] /= (numberOfDataInClass[i] - 1);
            }
 
        }

        public void CalculateClassProbabilities()
        {
            int sum = 0;
            for (int i = 0; i < numberOfDataInClass.Count; i++)
            {
                sum += numberOfDataInClass[i];
            }

            for (int i = 0; i < numberOfDataInClass.Count; i++)
            {
                classProbabilities.Add(((double)numberOfDataInClass[i] / sum));
            }
            
        }

        public void CalculateGaussProbabilities(Pattern p)
        {
            double numerator, denominator;
            gaussProbabilities.Clear();
            for (int i = 0; i < numberOfDataInClass.Count; i++)
            {
                List<double> list = new List<double>();
                for(int j = 0; j < p.featureVector.Count; j++)
                {
                    numerator = Math.Exp((-1) * Math.Pow((p.featureVector[j] - means[i][j]), 2) / 2 * variance[i][j]);
                    denominator = Math.Sqrt(2 * Math.PI * variance[i][j]);
                    list.Add(numerator / denominator);
                }

                gaussProbabilities.Add(i, list);        
            }
 
        }

        public void CalculatePosteriorProbabilies()
        {
            posteriorProbabilities.Clear();
            double probability;
            for (int i = 0; i < numberOfDataInClass.Count; i++)
            {   
                probability = 1;
                probability *= classProbabilities[i];

                for (int j = 0; j < gaussProbabilities.Count; j++)
                    probability = probability * gaussProbabilities[i][j] * weight[j];
                posteriorProbabilities.Add(probability);
            }
        }

        public void Train()
        {
            CalculateMeans();
            CalculateVariance();
            CalculateClassProbabilities();
        }

        public int Classify(Pattern p)
        {
            
            CalculateGaussProbabilities(p);
            CalculatePosteriorProbabilies();
            double max = posteriorProbabilities[0];
            int result = 0;
            for (int i = 1; i < posteriorProbabilities.Count; i++)
            {
                if (max < posteriorProbabilities[i])
                {
                    max = posteriorProbabilities[i];
                    result = i;
                }
            }

            return result;
            
        }
    }
}
