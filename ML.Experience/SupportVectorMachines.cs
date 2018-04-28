using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Experience
{
    class SupportVectorMachines : IClassifier<SupportVectorMachines>
    {
        /// <summary>
        /// Ядро
        /// </summary>
        //Accord.Statistics.Kernels.IKernel Kernel { get; set; }

        Accord.MachineLearning.VectorMachines.MulticlassSupportVectorMachine<Accord.Statistics.Kernels.Linear> SVM { get; set; }
        Accord.MachineLearning.VectorMachines.Learning.MulticlassSupportVectorLearning<Accord.Statistics.Kernels.Linear> Teacher { get; set; }

        /// <summary>
        /// Функция потерь: L1 or L2
        /// </summary>
        Accord.MachineLearning.VectorMachines.Learning.Loss lossFunction { get; set; }

        public SupportVectorMachines(Accord.MachineLearning.VectorMachines.Learning.Loss L)//Accord.Statistics.Kernels.IKernel kernel)
        {
            lossFunction = L;
            Teacher = new Accord.MachineLearning.VectorMachines.Learning.MulticlassSupportVectorLearning<Accord.Statistics.Kernels.Linear>()
            {
                Learner = (p) => new Accord.MachineLearning.VectorMachines.Learning.LinearDualCoordinateDescent()
                {
                    Loss = lossFunction
                }
            };
            /// new Accord.Statistics.Kernels.Linear();
            //Kernel = kernel;
        }

        public SupportVectorMachines Learn(double[][] dataTrainInputs, int[] dataTrainOutputs)
        {
            return new SupportVectorMachines(lossFunction)
            {
                SVM = Teacher.Learn(dataTrainInputs, dataTrainOutputs)
            };
        }

        public int[] Predict(double[][] dataTestInputs)
        {
            return SVM.Decide(dataTestInputs);
        }
    }
}
