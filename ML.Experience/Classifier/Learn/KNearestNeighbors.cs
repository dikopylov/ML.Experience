
using ML.Experience.Converter;

namespace ML.Experience.Classifier.Learn
{
    class KNearestNeighbors : IClassifierLearn<double, int, Accord.MachineLearning.KNearestNeighbors, Accord.MachineLearning.KNearestNeighbors>
        
    {
        public Accord.MachineLearning.KNearestNeighbors Model { get; set; }

        public Accord.MachineLearning.KNearestNeighbors Teacher { get; set; }

        public KNearestNeighbors(int k = 2)
        {
            Teacher = new Accord.MachineLearning.KNearestNeighbors(k);
        }

        public void Learn(IConverter<double,int> data)
        {
            Model = Teacher.Learn(data.Inputs, data.Outputs);
        }

    }
}
