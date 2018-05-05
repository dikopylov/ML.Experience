
namespace ML.Experience.Classifier
{
    class SupportVectorMachines : IClassifier<double, int>
    {
        /// <summary>
        /// Обученная модель
        /// </summary>
        Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine<Accord.Statistics.Kernels.Linear> SVM { get; set; }

        /// <summary>
        /// Обучение модели
        /// </summary>
        Accord.MachineLearning.VectorMachines.Learning.MulticlassSupportVectorLearning<Accord.Statistics.Kernels.Linear> Teacher { get; set; }

        /// <summary>
        /// Функция потерь: L1 or L2
        /// </summary>
        Accord.MachineLearning.VectorMachines.Learning.Loss lossFunction { get; set; }

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

        public void Learn(double[][] dataTrainInputs, int[] dataTrainOutputs)
        {
            SVM = Teacher.Learn(dataTrainInputs, dataTrainOutputs);
        }

        public int[] Predict(double[][] dataTestInputs)
        {
            return SVM.Decide(dataTestInputs);
        }
    }
}
