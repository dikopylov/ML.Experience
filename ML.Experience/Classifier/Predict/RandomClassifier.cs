using ML.Experience.Converter;
using System;
using System.Linq;

namespace ML.Experience.Classifier.Predict
{
    class RandomClassifier : IClassifierPredict<double, int, object>
    {
        public object Model { get; set; }

        public int[] Predict(IConverter<double, int> data)
        {
            int NumberOfClasses = data.Outputs
                            .Cast<int>()
                            .ToList()
                            .Distinct()
                            .Count();

            int[] predicted = new int[data.Inputs.Length];
            Random label = new Random();

            for (int i = 0; i < predicted.Length; i++)
            {
                predicted[i] = label.Next(0, NumberOfClasses);
            }
            return predicted;
        }

        public void Load(string path)
        {
            throw new NotImplementedException();
        }
    }
}
