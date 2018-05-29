using ML.Experience.Converter;

namespace ML.Experience.Classifier.Learn
{
    interface IClassifierLearn
    {
        void Learn(IConverter data);

        void Save(string path);
    }
}
