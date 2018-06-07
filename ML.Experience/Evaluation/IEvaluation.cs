
namespace ML.Experience.Evaluation
{
    interface IEvaluation
    {
        double Measure(int[] expected, int[] predicted);
    }
}
