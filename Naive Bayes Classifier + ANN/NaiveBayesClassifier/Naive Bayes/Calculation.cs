using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaiveBayesClassifier
{
    class Calculation
    {
        public int[] sex;//Number of male(0) and female(1)
        public double[] meanHeight, varianceHeight, meanWeight, varianceWeight, meanFootSize, varianceFootSize;
        public double[] gaussValueHeight, gaussValueWeight, gaussValueFootSize;
        public double posteriorMale, posteriorFemale;
        
        public Calculation()//Constructor 
        {
            sex = new int[2];
            meanHeight = new double[2];
            meanWeight = new double[2];
            meanFootSize = new double[2];

            varianceHeight = new double[2];
            varianceWeight = new double[2];
            varianceFootSize = new double[2];
            
            gaussValueHeight = new double[2];  
            gaussValueWeight = new double[2];
            gaussValueFootSize = new double[2];

            sex[0] = 0; sex[1] = 0;
            meanHeight[0] = 0; varianceHeight[0] = 0; meanWeight[0] = 0; varianceWeight[0] = 0; meanFootSize[0] = 0; varianceFootSize[0] = 0;
            meanHeight[1] = 0; varianceHeight[1] = 0; meanWeight[1] = 0; varianceWeight[1] = 0; meanFootSize[1] = 0; varianceFootSize[1] = 0;
            posteriorMale = 0; posteriorFemale = 0;
        }
        public void CalculateMeans(List<Person> people)
        {
            foreach (Person p in people)
            {
                    meanHeight[p.sex] += p.height;
                    meanWeight[p.sex] += p.weight;
                    meanFootSize[p.sex] += p.footSize;
                    sex[p.sex]++;
            }

            meanHeight[0] /= sex[0];
            meanHeight[1] /= sex[1];
            meanWeight[0] /= sex[0];
            meanWeight[1] /= sex[1];
            meanFootSize[0] /= sex[0];
            meanFootSize[1] /= sex[1];
        }

        public void CalculateVariances(List<Person> people)
        {
            CalculateMeans(people);

            foreach (Person p in people)
            {
                varianceHeight[p.sex] += Math.Pow((p.height - meanHeight[p.sex]),2) ;
                varianceWeight[p.sex] += Math.Pow((p.weight - meanWeight[p.sex]), 2);
                varianceFootSize[p.sex] += Math.Pow((p.footSize - meanFootSize[p.sex]), 2);
            }

            varianceHeight[0] /= (sex[0] - 1);
            varianceHeight[1] /= (sex[1] - 1);
            varianceWeight[0] /= (sex[0] - 1);
            varianceWeight[1] /= (sex[1] - 1);
            varianceFootSize[0] /= (sex[0] - 1);
            varianceFootSize[1] /= (sex[1] - 1);
        }

        public void CalculateGaussProbabilityForFeature(int feature, double value)//feature(0) = height, feature(1) = weight, feature(2) = footSize
        {
            double numerator, denominator;

            if (feature == 0)//Calculation For Height
            {
                numerator = Math.Exp((-1) * Math.Pow((value - meanHeight[0]), 2) / (2 * varianceHeight[0]));
                denominator = Math.Sqrt(2 * Math.PI * varianceHeight[0]);
                gaussValueHeight[0] = numerator / denominator;

                numerator = Math.Exp((-1) * Math.Pow((value - meanHeight[1]), 2) / (2 * varianceHeight[1]));
                denominator = Math.Sqrt(2 * Math.PI * varianceHeight[1]);
                gaussValueHeight[1] = numerator / denominator;
            }
            else
            {
                if (feature == 1)//Calculation For Weight
                {
                    numerator = Math.Exp((-1) * Math.Pow((value - meanWeight[0]), 2) / (2 * varianceWeight[0]));
                    denominator = Math.Sqrt(2 * Math.PI * varianceWeight[0]);
                    gaussValueWeight[0] = numerator / denominator;

                    numerator = Math.Exp((-1) * Math.Pow((value - meanWeight[1]), 2) / (2 * varianceWeight[1]));
                    denominator = Math.Sqrt(2 * Math.PI * varianceWeight[1]);
                    gaussValueWeight[1] = numerator / denominator;
                }
                else//Calculation For Foot Size
                {
                    numerator = Math.Exp((-1) * Math.Pow((value - meanFootSize[0]), 2) / (2 * varianceFootSize[0]));
                    denominator = Math.Sqrt(2 * Math.PI * varianceFootSize[0]);
                    gaussValueFootSize[0] = numerator / denominator;

                    numerator = Math.Exp((-1) * Math.Pow((value - meanFootSize[1]), 2) / (2 * varianceFootSize[1]));
                    denominator = Math.Sqrt(2 * Math.PI * varianceHeight[1]);
                    gaussValueFootSize[1] = numerator / denominator;
                }
            }
        }

        public void Train(List<Person> people)
        {
            CalculateVariances(people);
        }

        public void CalculatePosteriorProbabilities(double height, double weight, double footSize)
        {
            CalculateGaussProbabilityForFeature(0, height);
            CalculateGaussProbabilityForFeature(1, weight);
            CalculateGaussProbabilityForFeature(2, footSize);
            posteriorMale = 0.5 * gaussValueHeight[0] * gaussValueWeight[0] * gaussValueFootSize[0];
            posteriorFemale = 0.5 * gaussValueHeight[1] * gaussValueWeight[1] * gaussValueFootSize[1];
        }

        public int Classify(double height, double weight, double footSize)
        {
            CalculatePosteriorProbabilities(height, weight, footSize);

            if (posteriorMale > posteriorFemale)
                return 0;
            else
                return 1;
        }

    }
}
