using ML.Experience.Converter;

namespace ML.Experience.Classifier.Learn
{
    class SupportVectorMachines : IClassifierLearn<double, int, Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine<Accord.Statistics.Kernels.Linear>,
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

        /// <summary>
        /// Функция потерь: L1 or L2
        /// </summary>
        public Accord.MachineLearning.VectorMachines.Learning.Loss lossFunction { get; set; }

        public SupportVectorMachines(Accord.MachineLearning.VectorMachines.Learning.Loss L)
        {
            lossFunction = L;
            Teacher = new Accord.MachineLearning.VectorMachines.Learning.MulticlassSupportVectorLearning<Accord.Statistics.Kernels.Linear>()
            {
                Learner = (p) => new Accord.MachineLearning.VectorMachines.Learning.LinearDualCoordinateDescent()
                {
                    Loss = lossFunction
                }
            };
        }

        public void Learn(IConverter<double, int> data)
        {
            Model = Teacher.Learn(data.Inputs, data.Outputs);
        }
    }
}
