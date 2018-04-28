using Accord.IO;
using Accord.Math;
using ML.Experience.Classifier;
using System;
using System.Data;
using System.IO;

namespace ML.Experience
{
    class Program
    {
        static void Main(string[] args)
        {
            // Poker Hand //
            DataTable dataTrainPoker = new CsvReader(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\PokerHand\PokerTrain.csv", false).ToTable();
            DataTable dataTestPoker = new CsvReader(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\PokerHand\PokerTest.csv", false).ToTable();
           
            int[] dataTrainOutputs = dataTrainPoker.Columns[10].ToArray<int>();
            dataTrainPoker.Columns.RemoveAt(10);
            double[][] dataTrainInputs = dataTrainPoker.ToJagged<double>();

            int[] dataTestOutputs = dataTestPoker.Columns[10].ToArray<int>();
            dataTestPoker.Columns.RemoveAt(10);
            double[][] dataTestInputs = dataTestPoker.ToJagged<double>();

            IClassifier[] classifier = new IClassifier[] { new KNearestNeighbors(4), new NaiveBayes(),
                new SupportVectorMachines(Accord.MachineLearning.VectorMachines.Learning.Loss.L2), new RandomClass(10)};

            int[][] predicted = new int[classifier.Length][];
            for (int i = 0; i < classifier.Length; i++)
            {
                classifier[i].Learn(dataTrainInputs, dataTrainOutputs);
                predicted[i] = classifier[i].Predict(dataTestInputs);
                Console.WriteLine(new Evaluation(dataTestOutputs, predicted[i]).Fmeasure());
            }
            // Poker Hand //

            // 20 Newsgroup //
            string[] categoriesTxt; 
            foreach( Directory.GetFiles(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\20_Newsgroups\Train");
            string[][] categories = Directory.GetFiles(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\20_Newsgroups\Test");

            DataTable[] dataTrainNewsgroup = new DataTable[categories.Length];
            DataTable[] dataTestNewsgroup = new DataTable[categories.Length];

            for (int i = 0; i < dataTrainNewsgroup.Length; i++)
            {
                dataTrainNewsgroup[i] = new CsvReader(Path.Combine(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\20_Newsgroups\Train", categories[i]), false).ToTable();
                dataTestNewsgroup[i] = new CsvReader(Path.Combine(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\20_Newsgroups\Test", categories[i]), false).ToTable();
            }

            DataTable[] dataTrainNewsgroup = new CsvReader(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\PokerHand\PokerTrain.csv", false).ToTable();
            DataTable dataTestNewsgroup = new CsvReader(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\PokerHand\PokerTest.csv", false).ToTable();

            int[] dataTrainOutputs = dataTrainPoker.Columns[10].ToArray<int>();
            dataTrainPoker.Columns.RemoveAt(10);
            double[][] dataTrainInputs = dataTrainPoker.ToJagged<double>();

            int[] dataTestOutputs = dataTestPoker.Columns[10].ToArray<int>();
            dataTestPoker.Columns.RemoveAt(10);
            double[][] dataTestInputs = dataTestPoker.ToJagged<double>();


        }
    }
}
