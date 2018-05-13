using ML.Experience.Converter;
using System;
using System.Linq;

namespace ML.Experience.Classifier.Predict
{
    class LogitRegression : IClassifierPredict<double, int, Accord.Statistics.Models.Regression.MultinomialLogisticRegression>

    {
        public Accord.Statistics.Models.Regression.MultinomialLogisticRegression Model { get; set; }

        public LogitRegression(Accord.Statistics.Models.Regression.MultinomialLogisticRegression model)
        {
            Model = model;
        }

        public int[] Predict(IConverter<double, int> data)
        {
            double[][] probabilities = Model.Probabilities(data.Inputs);
            int[] predictedByProbabilities = new int[data.Inputs.Length];

            for (int i = 0; i < data.Inputs.Length; i++)
            {
                predictedByProbabilities[i] = Array.IndexOf(probabilities[i], probabilities[i].Max());
            }
            return predictedByProbabilities;
        }

    }
}

