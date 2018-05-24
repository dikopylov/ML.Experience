using ML.Experience.Converter;
using System;

namespace ML.Experience.Classifier.Learn
{
    class SupportVectorMachines : IClassifierLearn<Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine<Accord.Statistics.Kernels.Linear>,
        Accord.MachineLearning.VectorMachines.Learning.MulticlassSupportVectorLearning<Accord.Statistics.Kernels.Linear>>
    {
        /// <summary>
        /// Обученная модель
        /// </summary>
        public Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine<Accord.Statistics.Kernels.Linear> Model { get; set; }

        /// <summary>
        /// Обучение модели
        /// </summary>
        public Accord.MachineLearning.VectorMachines.Learning.MulticlassSupportVectorLearning<Accord.Statistics.Kernels.Linear> Teacher { get; set; }

        public SupportVectorMachines()
        {
            Teacher = new Accord.MachineLearning.VectorMachines.Learning.MulticlassSupportVectorLearning<Accord.Statistics.Kernels.Linear>()
            {
                Learner = (p) => new Accord.MachineLearning.VectorMachines.Learning.LinearDualCoordinateDescent()
                {
                    Loss = Accord.MachineLearning.VectorMachines.Learning.Loss.L2
                }
            };
        }

        public void Learn(IConverter data)
        {
            Model = Teacher.Learn(data.Inputs, data.Outputs);
        }

        public void Save(IClassifierLearn<Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine<Accord.Statistics.Kernels.Linear>,
                        Accord.MachineLearning.VectorMachines.Learning.MulticlassSupportVectorLearning<Accord.Statistics.Kernels.Linear>> classifier,
            string path)
        {
            Accord.IO.Serializer.Save(classifier.Model, path);
        }
    }
}
