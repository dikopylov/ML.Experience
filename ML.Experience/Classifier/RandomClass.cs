using Accord.MachineLearning;
using System;
using System.Collections.Generic;

namespace ML.Experience.Classifier
{
    class RandomClass : IClassifier<double, int>
    {
        List<int> NumberOfClasses { get; set; }

        public void Learn(double[][] dataTrainInputs, int[] dataTrainOutputs)
        {
            NumberOfClasses = new List<int>();
            foreach (int data in dataTrainOutputs)
            {
                if (!NumberOfClasses.Contains(data))
                {
                    NumberOfClasses.Add(data);
                }
            }
        }

        public int[] Predict(double[][] dataTestInputs)
        {
            int[] predicted = new int[dataTestInputs.Length];

            Random label = new Random();
            for (int i = 0; i < predicted.Length; i++)
            {
                predicted[i]  = label.Next(0, NumberOfClasses.Count);
            }
            return predicted;
        }

    }
}
