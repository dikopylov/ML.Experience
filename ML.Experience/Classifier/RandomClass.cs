using System;

namespace ML.Experience.Classifier
{
    class RandomClass : IClassifier
    {
        int NumberOfClasses { get; set; }
        public RandomClass(int numberOfClasses)
        {
            NumberOfClasses = numberOfClasses;
        }
        public void Learn(double[][] dataTrainInputs, int[] dataTrainOutputs)
        {
            return;
        }

        public int[] Predict(double[][] dataTestInputs)
        {
            int[] predicted = new int[dataTestInputs.Length];

            Random label = new Random();
            for (int i = 0; i < predicted.Length; i++)
            {
                predicted[i] = label.Next(0, NumberOfClasses);
            }
            return predicted;
        }

    }
}
