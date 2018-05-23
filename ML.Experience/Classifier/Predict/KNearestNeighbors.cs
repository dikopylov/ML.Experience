
using Accord.IO;
using ML.Experience.Converter;

namespace ML.Experience.Classifier.Predict
{
    class KNearestNeighbors : IClassifierPredict<double, int, Accord.MachineLearning.KNearestNeighbors>
        
    {
        public Accord.MachineLearning.KNearestNeighbors Model { get; set; }

        public KNearestNeighbors(Accord.MachineLearning.KNearestNeighbors model)
        {
            Model = model;
        }

        public KNearestNeighbors() { }

        public int[] Predict(IConverter<double, int> data)
        {
            return Model.Decide(data.Inputs);
        }

        public void Load(string path)
        {
            Model = Serializer.Load<Accord.MachineLearning.KNearestNeighbors>(path);
        }
    }
}
