
namespace ML.Experience.Classifier
{
    interface IClassifierPredict<TInput, TOutput>
    {
        /// <summary>
        /// Предсказательный алгоритм
        /// </summary>
        /// <param name="dataTestInputs">>вектор входных параметров</param>
        /// <returns>массив предсказанных чисел</returns>
        TOutput[] Predict(TInput[][] dataTestInputs);
    }
}
