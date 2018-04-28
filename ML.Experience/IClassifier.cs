using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Experience
{
    interface IClassifier<T>
    {
        /// <summary>
        /// Обучающий алгоритм
        /// </summary>
        /// <param name="dataTestInputs">вектор входных параметров</param>
        /// <param name="dataTestOutputs">массив целевых переменных</param>
        /// <returns>Обученный алгоритм</returns>
        T Learn(double[][] dataTrainInputs, int[] dataTrainOutputs);

        /// <summary>
        /// Предсказательный алгоритм
        /// </summary>
        /// <param name="dataTestInputs">>вектор входных параметров</param>
        /// <returns>массив предсказанных чисел</returns>
        int[] Predict(double[][] dataTestInputs);
    }
}
