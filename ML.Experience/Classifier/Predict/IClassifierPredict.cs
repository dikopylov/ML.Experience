using ML.Experience.Converter;

namespace ML.Experience.Classifier.Predict
{
    interface IClassifierPredict
    {
        int[] Predict(IConverter data);

        void Load(string path);
    }
}
