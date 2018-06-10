
using Accord.IO;
using ML.Experience.Converter;
using System.Linq;
using ML.Experience.Data;

namespace ML.Experience.Classifier.Predict
{
    class KNearestNeighbors : IClassifier
        
    {
        public Accord.MachineLearning.KNearestNeighbors Model { get; set; }

        public KNearestNeighbors(Learn.KNearestNeighbors knn)
        {
            Model = knn.Model;
        }

        public KNearestNeighbors() { }

        public int[] Predict(PredictData data)
        {
            return Model.Decide(data.Inputs);
        }

        //public int[] Predict(IConverter data)
        //{
        //    return Model.Decide(data.Inputs);
        //}

        //public string[] PredictToString(IConverter data)
        //{
        //    int[] predict = Predict(data);

        //    string[] answer = new string[predict.Length];

        //    for (int i = 0; i < predict.Length; i++)
        //    {
        //        answer[i] = data.Translator.FirstOrDefault(x => x.Value == predict[i]).Key;
        //    }
        //    return answer;
        //}

        public void Load(string path)
        {
            Model = Serializer.Load<Accord.MachineLearning.KNearestNeighbors>(path);
        }
    }
}
