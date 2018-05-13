using ML.Experience.Converter;

namespace ML.Experience.Classifier.Predict
{
    class NaiveBayes : IClassifierPredict<double, int, Accord.MachineLearning.Bayes.NaiveBayes<Accord.Statistics.Distributions.Univariate.NormalDistribution>>
    {
        /// <summary>
        /// Обученная модель
        /// </summary>        
        public Accord.MachineLearning.Bayes.NaiveBayes<Accord.Statistics.Distributions.Univariate.NormalDistribution> Model { get; set; }

        public NaiveBayes(Accord.MachineLearning.Bayes.NaiveBayes<Accord.Statistics.Distributions.Univariate.NormalDistribution> model)
        {
            Model = model;
        }

        public int[] Predict(IConverter<double, int> data)
        {
            return Model.Decide(data.Inputs);
        }
    }
}
