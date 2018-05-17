using System;

namespace ML.Experience.Evaluation
{
    class Recall : IEvaluation<double>
    {
        public double Measure(Accord.Statistics.Analysis.GeneralConfusionMatrix Estimater)
        {
            /// Получаем полноту по каждому вектору
            double[] recalls = Estimater.Recall;
            double sumRecalls = 0;

            for (int i = 0; i < recalls.Length; i++)
            {
                sumRecalls += recalls[i];
            }

            return Math.Round((sumRecalls / recalls.Length) * 100, 0);
        }
    }
}
