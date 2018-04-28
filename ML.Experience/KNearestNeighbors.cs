using Accord.MachineLearning;

namespace ML.Experience
{
    class KNearestNeighbors : IClassifier<KNearestNeighbors>
    {
        int K { get; set; }
        Accord.MachineLearning.KNearestNeighbors KNN { get; set; }

        public KNearestNeighbors(int k)
        {
            KNN = new Accord.MachineLearning.KNearestNeighbors(k);
        }

        public KNearestNeighbors Learn(double[][] dataTrainInputs, int[] dataTrainOutputs)
        {
            return new KNearestNeighbors(K)
            {
                KNN = KNN.Learn(dataTrainInputs, dataTrainOutputs)
            };
        }

        public int[] Predict(double[][] dataTestInputs)
        {
            return KNN.Decide(dataTestInputs);
        }
    }
}
