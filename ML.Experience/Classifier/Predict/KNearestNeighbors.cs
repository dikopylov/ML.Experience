
using Accord.IO;
using ML.Experience.Converter;
using System.Linq;

namespace ML.Experience.Classifier.Predict
{
    class KNearestNeighbors : IClassifierPredict<Accord.MachineLearning.KNearestNeighbors>
        
    {
        public Accord.MachineLearning.KNearestNeighbors Model { get; set; }

        public KNearestNeighbors(Accord.MachineLearning.KNearestNeighbors model)
        {
            Model = model;
        }

        public KNearestNeighbors() { }

        public int[] Predict(IConverter data)
        {
            return Model.Decide(data.Inputs);
        }

        public string[] PredictToString(IConverter data)
        {
            int[] predict = Predict(data);

            string[] answer = new string[predict.Length];

            for (int i = 0; i < predict.Length; i++)
            {
                answer[i] = data.Translator.FirstOrDefault(x => x.Value == predict[i]).Key;
            }
            return answer;
        }

        public void Load(string path)
        {
            Model = Serializer.Load<Accord.MachineLearning.KNearestNeighbors>(path);
        }
    }
}
