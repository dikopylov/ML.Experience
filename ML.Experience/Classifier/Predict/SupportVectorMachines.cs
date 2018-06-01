
using Accord.IO;
using ML.Experience.Converter;

namespace ML.Experience.Classifier.Predict
{
    class SupportVectorMachines : IClassifierPredict
    {
        public Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine
             Model { get; set; }

        public SupportVectorMachines(
            Learn.IClassifierLearnModel
            <Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine> svm)
        {
            Model = svm.Model;
        }

        //public SupportVectorMachines(Learn.SupportVectorMachines<TKernel> svm)
        //{
        //    Model = svm.Model;
        //}

        public SupportVectorMachines() { }

        public int[] Predict(IConverter data)
        {
            return Model.Decide(data.Inputs);
        }

        public void Load(string path)
        {
         //   Model = Serializer.Load<Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine<Accord.Statistics.Kernels.IKernel>>(path);
        }
    }
}
