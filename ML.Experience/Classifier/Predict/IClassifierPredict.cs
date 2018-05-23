using ML.Experience.Converter;

namespace ML.Experience.Classifier.Predict
{
    interface IClassifierPredict<TInput, TOutput, TModel>
    {
        TModel Model { get; set; }
        
        /// <summary>
        /// Предсказательный алгоритм
        /// </summary>
        /// <param name="dataTestInputs">>вектор входных параметров</param>
        /// <returns>массив предсказанных чисел</returns>
        TOutput[] Predict(IConverter<TInput, TOutput> data);

        /// <summary>
        /// Загрузить модель
        /// </summary>
        void Load(string path);
    }
}
