using System;
using System.Linq;

namespace ML.Experience.Classifier
{
    class LogitRegression : IClassifier<double, int>

    {
        Accord.Statistics.Models.Regression.MultinomialLogisticRegression MLR { get; set; }

        Accord.Statistics.Models.Regression.Fitting.MultinomialLogisticLearning<Accord.Math.Optimization.ConjugateGradient> Teacher { get; set; }

        public LogitRegression()
        {
            Teacher = new Accord.Statistics.Models.Regression.Fitting.MultinomialLogisticLearning<Accord.Math.Optimization.ConjugateGradient>();
        }

        public void Learn(double[][] dataTrainInputs, int[] dataTrainOutputs)
        {
            MLR = Teacher.Learn(dataTrainInputs, dataTrainOutputs);
        }

        public int[] Predict(double[][] dataTestInputs)
        {
            return MLR.Decide(dataTestInputs);
        }


        public int[] PredictByProbability(double[][] dataTrainInputs)
        {
            double[][] probabilities = MLR.Probabilities(dataTrainInputs);
            int[] predictedByProbabilities = new int[dataTrainInputs.Length];

            for(int i = 0; i < dataTrainInputs.Length; i++)
            {
                predictedByProbabilities[i] = Array.IndexOf(probabilities[i], probabilities[i].Max());
            }
            return predictedByProbabilities;
        }
    }
}

