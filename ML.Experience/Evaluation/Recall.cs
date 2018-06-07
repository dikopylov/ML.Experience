using System;

namespace ML.Experience.Evaluation
{
    class Recall : IEvaluation
    {
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
