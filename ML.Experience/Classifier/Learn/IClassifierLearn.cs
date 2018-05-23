using ML.Experience.Converter;

namespace ML.Experience.Classifier.Learn
{
    interface IClassifierLearn<TInput, TOutput, TModel, TTeacher> //: IClassifierLearn
    {
        /// <summary>
        /// Объект модели
        /// </summary>
        TModel Model { get; set; }

        /// <summary>
        /// Объект обучения
        /// </summary>
        TTeacher Teacher { get; set; }

        /// <summary>
        /// Обучающий алгоритм
        /// </summary>
        /// <param name="data">вектор входных параметров</param>
        void Learn(IConverter<TInput, TOutput> data);

        void Save(IClassifierLearn<TInput, TOutput, TModel, TTeacher> classifier, string path);
    }
}
