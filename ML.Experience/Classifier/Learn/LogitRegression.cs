using ML.Experience.Converter;

namespace ML.Experience.Classifier.Learn
{
    class LogitRegression : IClassifierLearn<double, int, Accord.Statistics.Models.Regression.MultinomialLogisticRegression, 
        Accord.Statistics.Models.Regression.Fitting.MultinomialLogisticLearning<Accord.Math.Optimization.ConjugateGradient>>

    {
        public Accord.Statistics.Models.Regression.MultinomialLogisticRegression Model { get; set; }

        public Accord.Statistics.Models.Regression.Fitting.MultinomialLogisticLearning<Accord.Math.Optimization.ConjugateGradient> Teacher { get; set; }

        public LogitRegression()
        {
            Teacher = new Accord.Statistics.Models.Regression.Fitting.MultinomialLogisticLearning<Accord.Math.Optimization.ConjugateGradient>();
        }

        public void Learn(IConverter<double, int> data)
        {
            Model = Teacher.Learn(data.Inputs, data.Outputs);
        }
    }
}

