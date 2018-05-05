
namespace ML.Experience.Classifier
{
    interface IClassifierLearn<TInput, TOutput>
    {
        /// <summary>
        /// Обучающий алгоритм
        /// </summary>
        /// <param name="dataTestInputs">вектор входных параметров</param>
        /// <param name="dataTestOutputs">массив целевых переменных</param>
        /// <returns>Обученный алгоритм</returns>
        void Learn(TInput[][] dataTrainInputs, TOutput[] dataTrainOutputs);
    }
}
