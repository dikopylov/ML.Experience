
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

        public int[] Predict(IConverter<double, int> data)
        {
            return Model.Decide(data.Inputs);
        }

    }
}
