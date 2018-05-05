
namespace ML.Experience.Evaluation
{
    interface IEvaluation<TOutput>
    {
        /// <summary>
        /// Оценщик
        /// </summary>
        Accord.Statistics.Analysis.GeneralConfusionMatrix Estimater { get; set; }

        /// <summary>
        /// Выполнение оценки
        /// </summary>
        /// <returns>Оценка</returns>
        TOutput Measure();
    }
}
