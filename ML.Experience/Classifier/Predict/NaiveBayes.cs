using Accord.IO;
using ML.Experience.Converter;
using ML.Experience.Data;

namespace ML.Experience.Classifier.Predict
{
    class NaiveBayes : IClassifier
    {  
        public Accord.MachineLearning.Bayes.NaiveBayes<Accord.Statistics.Distributions.Univariate.NormalDistribution> Model { get; set; }

        public NaiveBayes(Learn.NaiveBayes nb)
        {
            Model = nb.Model;
        }

        public NaiveBayes() { }

        public int[] Predict(PredictData data)
        {
            return Model.Decide(data.Inputs);
        }
        
        public void Load(string path)
        {
            Model = Serializer.Load<Accord.MachineLearning.Bayes.NaiveBayes<Accord.Statistics.Distributions.Univariate.NormalDistribution>>(path);
        }
    }
}
