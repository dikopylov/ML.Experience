using System;

namespace ML.Experience.Evaluation
{
    class FScore : IEvaluation
    {
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
