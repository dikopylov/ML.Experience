using System;

namespace ML.Experience.Evaluation
{
    class FScore : IEvaluation<double>
    {
        public Accord.Statistics.Analysis.GeneralConfusionMatrix Estimater { get; set; }

        double DataPrecision { get; set; }

        double DataRecall { get; set; }

        public FScore(int[] dataOutputs, int[] dataPredicted)
        {
            Estimater = new Accord.Statistics.Analysis.GeneralConfusionMatrix(dataOutputs, dataPredicted);
            DataPrecision = new Precision(dataOutputs, dataPredicted).Measure();
            DataRecall = new Recall(dataOutputs, dataPredicted).Measure();
        }

        public double Measure()
        {
            return Math.Round((2 * DataPrecision * DataRecall / (DataPrecision + DataRecall)), 0);
        }
    }
}
