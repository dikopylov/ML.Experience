using ML.Experience.Converter;
using ML.Experience.Data;

namespace ML.Experience.Classifier.Predict
{
    interface IClassifier
    {
        int[] Predict(IConverter data);

        int[] Predict(PredictData data);

        void Load(string path);
    }
}
