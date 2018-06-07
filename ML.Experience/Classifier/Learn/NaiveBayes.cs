using Accord.Statistics.Distributions.Fitting;
using ML.Experience.Converter;
using System;
using ML.Experience.Data;

namespace ML.Experience.Classifier.Learn
{
    class NaiveBayes : IClassifierLearn
    {      
        public Accord.MachineLearning.Bayes.NaiveBayes<Accord.Statistics.Distributions.Univariate.NormalDistribution> Model { get; set; }

        public Accord.MachineLearning.Bayes.NaiveBayesLearning<Accord.Statistics.Distributions.Univariate.NormalDistribution> Teacher { get; set; }

        public NaiveBayes()
        {
            Teacher = new Accord.MachineLearning.Bayes.NaiveBayesLearning<Accord.Statistics.Distributions.Univariate.NormalDistribution>();
            Teacher.Options.InnerOption = new NormalOptions
            {
                Regularization = 1e-6
            };
        }

        public void Learn(IConverter data)
        {
            Model = Teacher.Learn(data.Inputs, data.Outputs);
        }

        public void Learn(LearnData data)
        {
            Model = Teacher.Learn(data.Inputs, data.Outputs);
        }

        public int[] TestPredict(LearnData data)
        {
            return Model.Decide(data.Inputs);
        }

        public void Save(string path)
        {
            Accord.IO.Serializer.Save(Model, path);
        }
    }
}
