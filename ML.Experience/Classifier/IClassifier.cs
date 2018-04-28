
namespace ML.Experience.Classifier
{
    interface IClassifier
    {
        /// <summary>
        /// Обучающий алгоритм
        /// </summary>
        /// <param name="dataTestInputs">вектор входных параметров</param>
        /// <param name="dataTestOutputs">массив целевых переменных</param>
        /// <returns>Обученный алгоритм</returns>
        void Learn(double[][] dataTrainInputs, int[] dataTrainOutputs);

        /// <summary>
        /// Предсказательный алгоритм
        /// </summary>
        /// <param name="dataTestInputs">>вектор входных параметров</param>
        /// <returns>массив предсказанных чисел</returns>
        int[] Predict(double[][] dataTestInputs);
    }
}
