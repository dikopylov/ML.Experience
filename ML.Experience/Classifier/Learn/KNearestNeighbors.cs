using ML.Experience.Converter;
using System;
using Accord.MachineLearning;

namespace ML.Experience.Classifier.Learn
{
    class KNearestNeighbors : IClassifierLearnModel<Accord.MachineLearning.KNearestNeighbors, 
        Accord.MachineLearning.KNearestNeighbors>
    {
        public Accord.MachineLearning.KNearestNeighbors Model { get; set; }

        public Accord.MachineLearning.KNearestNeighbors Teacher { get; set; }

        public int K { get { return Teacher.K; } set { Teacher.K = value; } }

        public KNearestNeighbors(int k = 2)
        {
            Teacher = new Accord.MachineLearning.KNearestNeighbors(k);
        }

        public void Learn(IConverter data)
        {
            Model = Teacher.Learn(data.Inputs, data.Outputs);
        }

        public void Save(string path)
        {
            Accord.IO.Serializer.Save(Model, path);
        }

    }
}
