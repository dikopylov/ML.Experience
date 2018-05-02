using Accord.MachineLearning;

namespace ML.Experience.Classifier
{
    class KNearestNeighbors : IClassifier//<KNearestNeighbors>
    {
        /// <summary>
        /// Количество соседей
        /// </summary>
        int K { get; set; }

        Accord.MachineLearning.KNearestNeighbors KNN { get; set; }

        public KNearestNeighbors(int k)
        {
            KNN = new Accord.MachineLearning.KNearestNeighbors(k);
        }

        public void Learn(double[][] dataTrainInputs, int[] dataTrainOutputs)
        {
            //return new KNearestNeighbors(K)
            // {
            KNN = KNN.Learn(dataTrainInputs, dataTrainOutputs);
            //};
        }

        public int[] Predict(double[][] dataTestInputs)
        {
            return KNN.Decide(dataTestInputs);
        }
    }
}
