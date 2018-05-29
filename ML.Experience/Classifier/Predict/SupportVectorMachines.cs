
using Accord.IO;
using ML.Experience.Converter;

namespace ML.Experience.Classifier.Predict
{
    class SupportVectorMachines : IClassifierPredict
    {
        /// <summary>
        /// Обученная модель
        /// </summary>
        public Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine Model { get; set; }

        public SupportVectorMachines(Learn.SupportVectorMachines svm)
        {
            Model = svm.Model;
        }

        public SupportVectorMachines() { }

        public int[] Predict(IConverter data)
        {
            return Model.Decide(data.Inputs);
        }

        public void Load(string path)
        {
            Model = Serializer.Load<Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine>(path);
        }
    }
}
