using ML.Experience.Converter;
using System;
using ML.Experience.Data;

namespace ML.Experience.Classifier.Learn
{
    class SupportVectorMachines : IClassifierLearn
    {
        public Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine Model { get; set; }

        public Accord.MachineLearning.VectorMachines.Learning.MulticlassSupportVectorLearning Teacher { get; set; }

        public Accord.Statistics.Kernels.IKernel Kernel { get { return Teacher.Kernel; } set { Teacher.Kernel = value; } }

        public SupportVectorMachines(Accord.Statistics.Kernels.IKernel kernel)
        {
            Teacher = new Accord.MachineLearning.VectorMachines.Learning.MulticlassSupportVectorLearning()
            {
                Kernel = kernel
            };
        }

        public SupportVectorMachines() { }

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
