using ML.Experience.Converter;
using System;

namespace ML.Experience.Classifier.Learn
{
    class SupportVectorMachines : IClassifierLearn
    {
        /// <summary>
        /// Обученная модель
        /// </summary>
        public Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine Model { get; set; }

        /// <summary>
        /// Обучение модели
        /// </summary>
        public Accord.MachineLearning.VectorMachines.Learning.MulticlassSupportVectorLearning Teacher { get; set; }

        public SupportVectorMachines(Accord.Statistics.Kernels.IKernel kernel)
        {
            Teacher = new Accord.MachineLearning.VectorMachines.Learning.MulticlassSupportVectorLearning()
            {
                Kernel = kernel
            };
        }

        public SupportVectorMachines() { }

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
