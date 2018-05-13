using Accord.Statistics.Distributions.Fitting;
using ML.Experience.Converter;

namespace ML.Experience.Classifier.Learn
{
    class NaiveBayes : IClassifierLearn<double, int, 
        Accord.MachineLearning.Bayes.NaiveBayes<Accord.Statistics.Distributions.Univariate.NormalDistribution>,
         Accord.MachineLearning.Bayes.NaiveBayesLearning<Accord.Statistics.Distributions.Univariate.NormalDistribution>>
    {
        /// <summary>
        /// Обученная модель
        /// </summary>        
        public Accord.MachineLearning.Bayes.NaiveBayes<Accord.Statistics.Distributions.Univariate.NormalDistribution> Model { get; set; }

        /// <summary>
        /// Обучение модели
        /// </summary>
        public Accord.MachineLearning.Bayes.NaiveBayesLearning<Accord.Statistics.Distributions.Univariate.NormalDistribution> Teacher { get; set; }

        public NaiveBayes()
        {
            Teacher = new Accord.MachineLearning.Bayes.NaiveBayesLearning<Accord.Statistics.Distributions.Univariate.NormalDistribution>();
            Teacher.Options.InnerOption = new NormalOptions
            {
                Regularization = 1e-6
            };
        }

        public void Learn(IConverter<double, int> data)
        {
            Model = Teacher.Learn(data.Inputs, data.Outputs);
        }

    }
}
