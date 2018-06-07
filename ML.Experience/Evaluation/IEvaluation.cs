
using ML.Experience.Classifier.Learn;
using ML.Experience.Classifier.Predict;
using ML.Experience.Data;

namespace ML.Experience.Evaluation
{
    interface IEvaluation
    {
        double Measure(int[] expected, int[] predicted);

        double Measure(IClassifierLearn classifier, LearnData data, int[] expected);

        double Measure(IClassifier classifier, PredictData data, int[] expected);
    }
}
