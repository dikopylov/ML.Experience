using Accord.Statistics.Distributions.Fitting;

namespace ML.Experience.Classifier
{
    class NaiveBayes : IClassifier<double, int>
    {
        /// <summary>
        /// Обученная модель
        /// </summary>        
        Accord.MachineLearning.Bayes.NaiveBayes<Accord.Statistics.Distributions.Univariate.NormalDistribution> NB { get; set; }

        /// <summary>
        /// Обучение модели
        /// </summary>
        Accord.MachineLearning.Bayes.NaiveBayesLearning<Accord.Statistics.Distributions.Univariate.NormalDistribution> Teacher { get; set; }

        public NaiveBayes()
        {
            Teacher = new Accord.MachineLearning.Bayes.NaiveBayesLearning<Accord.Statistics.Distributions.Univariate.NormalDistribution>();
            Teacher.Options.InnerOption = new NormalOptions
            {
                Regularization = 1e-6
            };
        }

        public void Learn(double[][] dataTrainInputs, int[] dataTrainOutputs)
        {
            NB = Teacher.Learn(dataTrainInputs, dataTrainOutputs);
        }

        public int[] Predict(double[][] dataTestInputs)
        {
            return NB.Decide(dataTestInputs);
        }
    }
}
