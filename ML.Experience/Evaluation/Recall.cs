﻿using System;
using ML.Experience.Classifier.Learn;
using ML.Experience.Classifier.Predict;
using ML.Experience.Data;

namespace ML.Experience.Evaluation
{
    class Recall : IEvaluation
    {
        public double Measure(IClassifier classifier, PredictData data, int[] expected)
        {
            int[] predict = classifier.Predict(data);
            return Measure(expected, predict);
        }

        public double Measure(IClassifierLearn classifier, LearnData data, int[] expected)
        {
            int[] predict = classifier.TestPredict(data);
            return Measure(expected, predict);
        }
        public double Measure(int[] expected, int[] predicted)
        {
            Accord.Statistics.Analysis.GeneralConfusionMatrix Estimater =
                new Accord.Statistics.Analysis.GeneralConfusionMatrix(expected, predicted);
            /// Получаем полноту по каждому вектору
            double[] recalls = Estimater.Recall;
            double sumRecalls = 0;

            for (int i = 0; i < recalls.Length; i++)
            {
                sumRecalls += recalls[i];
            }

            return sumRecalls / recalls.Length;
        }
    }
}
