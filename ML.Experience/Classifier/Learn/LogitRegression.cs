using Accord.IO;
using ML.Experience.Converter;
using System;

namespace ML.Experience.Classifier.Learn
{
    class LogitRegression : IClassifierLearn
    {
        public Accord.Statistics.Models.Regression.MultinomialLogisticRegression Model { get; set; }

        public Accord.Statistics.Models.Regression.Fitting.MultinomialLogisticLearning<Accord.Math.Optimization.ConjugateGradient> Teacher { get; set; }

        public LogitRegression()
        {
            Teacher = new Accord.Statistics.Models.Regression.Fitting.MultinomialLogisticLearning<Accord.Math.Optimization.ConjugateGradient>();
        }

        public void Learn(IConverter data)
        {
            Model = Teacher.Learn(data.Inputs, data.Outputs);
        }

        public void Save(string path)
        {
            Accord.IO.Serializer.Save(Model, path);
        }
    }
}

