using System;

namespace ML.Experience.Evaluation
{
    class Precision : IEvaluation<double>
    {

        public double Measure(Accord.Statistics.Analysis.GeneralConfusionMatrix Estimater)
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
