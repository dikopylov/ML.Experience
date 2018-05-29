
namespace ML.Experience.Evaluation
{
    interface IEvaluation
    {

        /// <summary>
        /// Выполнение оценки
        /// </summary>
        /// <returns>Оценка</returns>
        double Measure(Accord.Statistics.Analysis.GeneralConfusionMatrix estimater);
    }
}
