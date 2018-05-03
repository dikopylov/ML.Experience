using Accord.Statistics.Distributions.Fitting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Experience.Classifier
{
    class NaiveBayes : IClassifier//<NaiveBayes>
    {
        /// <summary>
        /// Распределение
        /// </summary>
        ///Accord.Statistics.Distributions.Univariate.UnivariateContinuousDistribution Distribution { get; set; }

        
        Accord.MachineLearning.Bayes.NaiveBayes<Accord.Statistics.Distributions.Univariate.NormalDistribution> NB { get; set; }

        Accord.MachineLearning.Bayes.NaiveBayesLearning<Accord.Statistics.Distributions.Univariate.NormalDistribution> Teacher { get; set; }

        public NaiveBayes()
        {
            //Distribution = distribution;
            Teacher = new Accord.MachineLearning.Bayes.NaiveBayesLearning<Accord.Statistics.Distributions.Univariate.NormalDistribution>();
            Teacher.Options.InnerOption = new NormalOptions
            {
                Regularization = 1e-5
            };
            //learner = new Accord.MachineLearning.Bayes.NaiveBayesLearning();
        }

        public void Learn(double[][] dataTrainInputs, int[] dataTrainOutputs)
        {
            //return new NaiveBayes()
            //{
            NB = Teacher.Learn(dataTrainInputs, dataTrainOutputs);
           // };
        }

        public int[] Predict(double[][] dataTestInputs)
        {
            return NB.Decide(dataTestInputs);
        }
    }
}
