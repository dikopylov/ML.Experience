using Accord.IO;
using Accord.Math;
using Framework = Accord.MachineLearning;
using System;
using System.Data;
using System.IO;
using ML.Experience.Classifier;

namespace ML.Experience
{
    class Program
    {
        static void Iris(IClassifier[] classifier)
        {
            DataTable dataTrainPoker = new CsvReader(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Iris\IrisTrain.csv", false)
            {
                Delimiter = ';'
            }.ToTable();
            DataTable dataTestPoker = new CsvReader(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Iris\IrisTest.csv", false)
            {
                Delimiter = ';'
            }.ToTable();

            int[] dataTrainOutputs = dataTrainPoker.Columns[4].ToArray<int>();
            dataTrainPoker.Columns.RemoveAt(4);
            double[][] dataTrainInputs = dataTrainPoker.ToJagged<double>();

            int[] dataTestOutputs = dataTestPoker.Columns[4].ToArray<int>();
            dataTestPoker.Columns.RemoveAt(4);
            double[][] dataTestInputs = dataTestPoker.ToJagged<double>();

            int[][] predictedPoker = new int[classifier.Length][];

            Console.WriteLine("Iris");
            for (int i = 0; i < classifier.Length; i++)
            {
                classifier[i].Learn(dataTrainInputs, dataTrainOutputs);
                predictedPoker[i] = classifier[i].Predict(dataTestInputs);
                Console.WriteLine(classifier[i]);
                Console.WriteLine("Precision: " + new Evaluation(dataTestOutputs, predictedPoker[i]).Precision());
                Console.WriteLine("Recall: " + new Evaluation(dataTestOutputs, predictedPoker[i]).Recall());
                Console.WriteLine("F-Measure: " + new Evaluation(dataTestOutputs, predictedPoker[i]).Fmeasure());
            }
        }

        static void NewsGroup(IClassifier[] classifier)
        {
            string[] filesTrain = Directory.GetFiles(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\20_Newsgroups\Big\Train");
            string[] dataTrainNewsInputs = new string[filesTrain.Length];
            int[] dataTrainNewsOutputs = new int[filesTrain.Length];
            string[][] wordsTrain = new string[filesTrain.Length][];
            for (int i = 0; i < filesTrain.Length; i++)
            {
                using (StreamReader sr = new StreamReader(filesTrain[i]))
                {
                    dataTrainNewsOutputs[i] = i;
                    dataTrainNewsInputs[i] = sr.ReadToEnd();
                    wordsTrain[i] = Framework.Tools.Tokenize(dataTrainNewsInputs[i]);
                }
            }
            string[] dir = Directory.GetDirectories(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\20_Newsgroups\Big\Test");
            string[][] filesTest = new string[dir.Length][];
            string[][] wordsTest = new string[dir.Length][];
            for (int i = 0; i < dir.Length; i++)
            {
                filesTest[i] = Directory.GetFiles(dir[i]);
            }

            string[,] dataTestNewsInputs = new string[dir.Length, filesTest[0].Length];
            int[] dataTestNewsOutputs = new int[dir.Length];
            for (int k = 0; k < filesTest.Length; k++)
            {
                for (int i = 0; i < filesTest[k].Length; i++)
                {
                    using (StreamReader sr = new StreamReader(filesTest[k][i]))
                    {
                        dataTestNewsInputs[k, i] = sr.ReadToEnd();
                        wordsTest[k] = Framework.Tools.Tokenize(dataTrainNewsInputs[k]);
                    }
                }
            }


            var codebook = new Framework.BagOfWords()
            {
                MaximumOccurance = 20
            };

            codebook.Learn(wordsTrain);

            double[][] bowTrain = codebook.Transform(wordsTrain);
            double[][] bowTest = codebook.Transform(wordsTest);

            int[][] predictedNews = new int[classifier.Length][];
            for (int i = 0; i < classifier.Length; i++)
            {
                classifier[i].Learn(bowTrain, dataTrainNewsOutputs);
                predictedNews[i] = classifier[i].Predict(bowTest);
                Console.WriteLine(new Evaluation(dataTrainNewsOutputs, predictedNews[i]).Fmeasure());
            }
        }
        static void Main(string[] args)
        {
            IClassifier[] classifier = new IClassifier[] { new KNearestNeighbors(1), new NaiveBayes(),
                new SupportVectorMachines(Framework.VectorMachines.Learning.Loss.L2), new RandomClass(10)};
            //Iris(classifier);
            //NewsGroup(classifier);
            Console.ReadLine();
        }
    }
}
