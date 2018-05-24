﻿using Accord.IO;
using ML.Experience.Converter;

namespace ML.Experience.Classifier.Predict
{
    class NaiveBayes : IClassifierPredict<Accord.MachineLearning.Bayes.NaiveBayes<Accord.Statistics.Distributions.Univariate.NormalDistribution>>
    {
        /// <summary>
        /// Обученная модель
        /// </summary>        
        public Accord.MachineLearning.Bayes.NaiveBayes<Accord.Statistics.Distributions.Univariate.NormalDistribution> Model { get; set; }

        public NaiveBayes(Accord.MachineLearning.Bayes.NaiveBayes<Accord.Statistics.Distributions.Univariate.NormalDistribution> model)
        {
            Model = model;
        }

        public NaiveBayes() { }

        public int[] Predict(IConverter data)
        {
            return Model.Decide(data.Inputs);
        }

        public void Load(string path)
        {
            Model = Serializer.Load<Accord.MachineLearning.Bayes.NaiveBayes<Accord.Statistics.Distributions.Univariate.NormalDistribution>>(path);
        }
    }
}
