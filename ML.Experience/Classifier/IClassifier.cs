
namespace ML.Experience.Classifier
{
    interface IClassifier<TInput, TOutput> : IClassifierPredict<TInput, TOutput>,
        IClassifierLearn<TInput, TOutput>
    {
        /// TInput TOutput?
    }
}
