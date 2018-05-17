
namespace ML.Experience.Evaluation
{
    interface IEvaluation<TOutput>
    {

        /// <summary>
        /// Выполнение оценки
        /// </summary>
        /// <returns>Оценка</returns>
        TOutput Measure(Accord.Statistics.Analysis.GeneralConfusionMatrix estimater);
    }
}
