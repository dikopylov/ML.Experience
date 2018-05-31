using ML.Experience.Classifier.Predict;

namespace ML.Experience.GridSearch
{
    interface IGridDimension 
    {
        IClassifierPredict BestModel { get; set; }

        double BestError { get; set; }

        void Fit();
    }
}
