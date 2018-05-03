using System;

namespace ML.Experience
{
    class Evaluation 
    {
        Accord.Statistics.Analysis.GeneralConfusionMatrix Estimater { get; set; }

        public Evaluation(int[] dataOutputs, int[] dataPredicted)
        {
            Estimater = new Accord.Statistics.Analysis.GeneralConfusionMatrix(dataOutputs, dataPredicted);
        }

        public double Precision()
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

        public double Recall()
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

        public double Fmeasure()
        {
            double precision = Precision();
            double recall = Recall();

            return Math.Round((2 * precision * recall / (precision + recall)), 0);
        }
    }
}
