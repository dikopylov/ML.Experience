using ML.Experience.Converter;

namespace ML.Experience.Classifier.Learn
{
    interface IClassifierLearn<TInput, TOutput, TModel, TTeacher>
    {
        /// <summary>
        /// Объект классификатора
        /// </summary>
        TModel Model { get; set; }

        /// <summary>
        /// Объект обучения классификатора
        /// </summary>
        TTeacher Teacher { get; set; }

        /// <summary>
        /// Обучающий алгоритм
        /// </summary>
        /// <param name="data">вектор входных параметров</param>
        void Learn(IConverter<TInput, TOutput> data);
    }
}
