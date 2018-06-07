using System;
using ML.Experience.Classifier.Learn;
using ML.Experience.Classifier.Predict;
using ML.Experience.Data;

namespace ML.Experience.Evaluation
{
    class FScore : IEvaluation
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
            double dataPrecision = new Precision().Measure(expected, predicted);
            double dataRecall = new Recall().Measure(expected, predicted);

            return 2 * dataPrecision * dataRecall / (dataPrecision + dataRecall);
        }
    }
}
