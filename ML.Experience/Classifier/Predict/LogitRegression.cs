using Accord.IO;
using ML.Experience.Converter;
using System;
using System.Linq;
using ML.Experience.Data;

namespace ML.Experience.Classifier.Predict
{
    class LogitRegression : IClassifier

    {
        public Accord.Statistics.Models.Regression.MultinomialLogisticRegression Model { get; set; }

        public LogitRegression(Learn.LogitRegression lr)
        {
            Model = lr.Model;
        }

        public LogitRegression() { }

        public int[] Predict(PredictData data)
        {
            double[][] probabilities = Model.Probabilities(data.Inputs);
            int[] predictedByProbabilities = new int[data.Inputs.Length];

            for (int i = 0; i < data.Inputs.Length; i++)
            {
                predictedByProbabilities[i] = Array.IndexOf(probabilities[i], probabilities[i].Max());
            }
            return predictedByProbabilities;
        }

        public void Load(string path)
        {
            Model = Serializer.Load<Accord.Statistics.Models.Regression.MultinomialLogisticRegression>(path);
        }
    }
}

