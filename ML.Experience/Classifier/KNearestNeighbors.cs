
namespace ML.Experience.Classifier
{
    class KNearestNeighbors : IClassifier<double, int>
        
    {
        Accord.MachineLearning.KNearestNeighbors KNN { get; set; }

        public KNearestNeighbors(int k = 2)
        {
            KNN = new Accord.MachineLearning.KNearestNeighbors(k);
        }

        public void Learn(double[][] dataTrainInputs, int[] dataTrainOutputs)
        {
            KNN = KNN.Learn(dataTrainInputs, dataTrainOutputs);
        }

        public int[] Predict(double[][] dataTestInputs)
        {
            return KNN.Decide(dataTestInputs);
        }

    }
}
