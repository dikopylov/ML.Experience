using System;

namespace ML.Experience.Evaluation
{
    class Precision : IEvaluation<double>
    {
        public Accord.Statistics.Analysis.GeneralConfusionMatrix Estimater { get; set; }

        public Precision(int[] dataOutputs, int[] dataPredicted)
        {
            Estimater = new Accord.Statistics.Analysis.GeneralConfusionMatrix(dataOutputs, dataPredicted);
        }

        public double Measure()
        {
            /// Получаем точность по каждому вектору
            double[] precisions = Estimater.Precision;
            double sumPresicions = 0;

            for (int i = 0; i < precisions.Length; i++)
            {
                sumPresicions += precisions[i];
            }

            return Math.Round((sumPresicions / precisions.Length) * 100, 0);
        }
    }
}
