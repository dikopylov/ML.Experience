using ML.Experience.Converter;

namespace ML.Experience.Classifier.Learn
{
    interface IClassifierLearn<TModel, TTeacher>
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
        void Learn(IConverter data);

        void Save(IClassifierLearn<TModel, TTeacher> classifier, string path);
    }
}
