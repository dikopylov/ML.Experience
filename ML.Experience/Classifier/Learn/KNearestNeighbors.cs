using ML.Experience.Converter;
using System;
using Accord.MachineLearning;
using ML.Experience.Data;

namespace ML.Experience.Classifier.Learn
{
    class KNearestNeighbors : IClassifierLearn
    {
        public Accord.MachineLearning.KNearestNeighbors Model { get; set; }

        public Accord.MachineLearning.KNearestNeighbors Teacher { get; set; }

        public int K { get { return Teacher.K; } set { Teacher.K = value; } }

        public KNearestNeighbors(int k = 2)
        {
            Teacher = new Accord.MachineLearning.KNearestNeighbors(k);
        }

        public void Learn(LearnData data)
        {
            Model = Teacher.Learn(data.Inputs, data.Outputs);
        }

        public int[] TestPredict(LearnData data)
        {
            return Model.Decide(data.Inputs);
        }

        public void Save(string path)
        {
            Accord.IO.Serializer.Save(Model, path);
        }

    }
}
