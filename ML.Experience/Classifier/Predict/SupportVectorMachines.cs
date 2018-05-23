
using Accord.IO;
using ML.Experience.Converter;

namespace ML.Experience.Classifier.Predict
{
    class SupportVectorMachines : IClassifierPredict<double, int, Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine<Accord.Statistics.Kernels.Linear>>
    {
        /// <summary>
        /// Обученная модель
        /// </summary>
        public Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine<Accord.Statistics.Kernels.Linear> Model { get; set; }

        public SupportVectorMachines(Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine<Accord.Statistics.Kernels.Linear> model)
        {
            Model = model;
        }

        public SupportVectorMachines() { }

        public int[] Predict(IConverter<double, int> data)
        {
            return Model.Decide(data.Inputs);
        }

        public void Load(string path)
        {
            Model = Serializer.Load<Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine<Accord.Statistics.Kernels.Linear>>(path);
        }
    }
}
