using ML.Experience.Classifier.Learn;
using ML.Experience.Classifier.Predict;
using ML.Experience.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Experience.Evaluation
{
    class Error : IEvaluation
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
            return Estimater.Error;
        }
    }
}
