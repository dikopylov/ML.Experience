using System;

namespace ML.Experience.Evaluation
{
    class FScore : IEvaluation<double>
    {
        public double Measure(Accord.Statistics.Analysis.GeneralConfusionMatrix Estimater)
        {
            double dataPrecision = new Precision().Measure(Estimater);
            double dataRecall = new Recall().Measure(Estimater);

            return Math.Round((2 * dataPrecision * dataRecall / (dataPrecision + dataRecall)), 0);
        }
    }
}
