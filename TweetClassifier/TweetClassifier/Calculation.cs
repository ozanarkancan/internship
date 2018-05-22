using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetClassifier
{
    class Calculation
    {
        public int[] side;
        public double[] meanWords, varianceWords, meanNWords, varianceNWords, meanPozitive, variancePozitive, meanNegative, varianceNegative;
        public double[] gaussValueWords, gaussValueNWords, gaussValuePozitive, gaussValueNegative;
        public double posteriorMale, posteriorFemale;

        public Calculation()//Constructor 
        {
            side = new int[2];
            meanWords = new double[2];
            meanNWords = new double[2];
            meanPozitive = new double[2];
            meanNegative = new double[2];

            varianceWords = new double[2];
            varianceNWords = new double[2];
            variancePozitive = new double[2];
            varianceNegative = new double[2];

            gaussValueWords = new double[2];
            gaussValueNWords = new double[2];
            gaussValuePozitive = new double[2];
            gaussValueNegative = new double[2];

            side[0] = 0; side[1] = 0;
            meanWords[0] = 0; varianceWords[0] = 0; meanNWords[0] = 0;  meanPozitive[0] = 0; variancePozitive[0] = 0; meanNegative[0] = 0; varianceNegative[0] = 0;
            meanWords[1] = 0; varianceWords[1] = 0; varianceNWords[1] = 0;  meanPozitive[1] = 0; variancePozitive[1] = 0; meanNegative[1] = 0; varianceNegative[1] = 0;
            posteriorMale = 0; posteriorFemale = 0;


        }
        public void CalculateMeans(List<Tweet> tweets)
        {
            foreach (Tweet p in tweets)
            {
                meanWords[p.side] += p.pozitiveWords;
                meanNWords[p.side] += p.negativeWords;
                meanPozitive[p.side] += p.pozitiveSmiles;
                meanNegative[p.side] += p.negativeSmiles;
                side[p.side]++;
            }

            meanWords[0] /= side[0];
            meanWords[1] /= side[1];
            meanNWords[0] /= side[0];
            meanNWords[1] /= side[1];
            meanPozitive[0] /= side[0];
            meanPozitive[1] /= side[1];
            meanNegative[0] /= side[0];
            meanNegative[1] /= side[1];
        }

        public void CalculateVariances(List<Tweet> tweets)
        {
            CalculateMeans(tweets);

            foreach (Tweet p in tweets)
            {
                varianceWords[p.side] += Math.Pow((p.pozitiveWords - meanWords[p.side]), 2);
                varianceNWords[p.side] += Math.Pow((p.negativeWords - meanNWords[p.side]), 2);
                variancePozitive[p.side] += Math.Pow((p.pozitiveSmiles - meanPozitive[p.side]), 2);
                varianceNegative[p.side] += Math.Pow((p.negativeSmiles - meanNegative[p.side]), 2);
            }

            varianceWords[0] /= (side[0] - 1);
            varianceWords[1] /= (side[1] - 1);
            varianceNWords[0] /= (side[0] - 1);
            varianceNWords[1] /= (side[1] - 1);
            variancePozitive[0] /= (side[0] - 1);
            variancePozitive[1] /= (side[1] - 1);
            varianceNegative[0] /= (side[0] - 1);
            varianceNegative[1] /= (side[1] - 1);
        }

        public void CalculateGaussProbabilityForFeature(int feature, double value)//feature(0) = pozitiveWords, feature(1) = negativeWords, feature(2) = pozitiveSmiles, feature(3) = negativeSmiles
        {
            double numerator, denominator;

            if (feature == 0)
            {
                numerator = Math.Exp((-1) * Math.Pow((value - meanWords[0]), 2) / (2 * varianceWords[0]));
                denominator = Math.Sqrt(2 * Math.PI * varianceWords[0]);
                gaussValueWords[0] = numerator / denominator;

                numerator = Math.Exp((-1) * Math.Pow((value - meanWords[1]), 2) / (2 * varianceWords[1]));
                denominator = Math.Sqrt(2 * Math.PI * varianceWords[1]);
                gaussValueWords[1] = numerator / denominator;
            }
            else
            {
                if (feature == 1)
                {
                    numerator = Math.Exp((-1) * Math.Pow((value - meanNWords[0]), 2) / (2 * varianceNWords[0]));
                    denominator = Math.Sqrt(2 * Math.PI * varianceNWords[0]);
                    gaussValueWords[0] = numerator / denominator;

                    numerator = Math.Exp((-1) * Math.Pow((value - meanNWords[1]), 2) / (2 * varianceNWords[1]));
                    denominator = Math.Sqrt(2 * Math.PI * varianceNWords[1]);
                    gaussValueNWords[1] = numerator / denominator;
                }
                else
                {
                    if (feature == 2)
                    {
                        numerator = Math.Exp((-1) * Math.Pow((value - meanPozitive[0]), 2) / (2 * variancePozitive[0]));
                        denominator = Math.Sqrt(2 * Math.PI * variancePozitive[0]);
                        gaussValuePozitive[0] = numerator / denominator;

                        numerator = Math.Exp((-1) * Math.Pow((value - meanPozitive[1]), 2) / (2 * variancePozitive[1]));
                        denominator = Math.Sqrt(2 * Math.PI * variancePozitive[1]);
                        gaussValuePozitive[1] = numerator / denominator;
                    }
                    else
                    {
                        numerator = Math.Exp((-1) * Math.Pow((value - meanNegative[0]), 2) / (2 * varianceNegative[0]));
                        denominator = Math.Sqrt(2 * Math.PI * varianceNegative[0]);
                        gaussValueNegative[0] = numerator / denominator;

                        numerator = Math.Exp((-1) * Math.Pow((value - meanNegative[1]), 2) / (2 * varianceNegative[1]));
                        denominator = Math.Sqrt(2 * Math.PI * varianceWords[1]);
                        gaussValueNegative[1] = numerator / denominator;
                    }
                }
            }
        }

        public void Train(List<Tweet> tweets)
        {
            CalculateVariances(tweets);
        }

        public void CalculatePosteriorProbabilities(double words, double negativeWords, double pozitiveSmiles, double negativeSmiles)
        {
            CalculateGaussProbabilityForFeature(0, words);
            CalculateGaussProbabilityForFeature(1, negativeWords);
            CalculateGaussProbabilityForFeature(2, pozitiveSmiles);
            CalculateGaussProbabilityForFeature(3, negativeSmiles);
            posteriorMale = 0.5 * gaussValueWords[0] * gaussValueNWords[0] * gaussValuePozitive[0] * gaussValueNegative[0];
            posteriorFemale = 0.5 * gaussValueWords[1] * gaussValueNWords[1] * gaussValuePozitive[1] * gaussValueNegative[1];
        }

        public int Classify(double words, double nWords, double pozitiveSmiles, double negativeSmiles)
        {
            CalculatePosteriorProbabilities(words, nWords, pozitiveSmiles, negativeSmiles);

            if (posteriorMale > posteriorFemale)
                return 0;
            else
                return 1;
        }
    }
}
