﻿using Accord.IO;
using Accord.Math;
using Framework = Accord.MachineLearning;
using System;
using System.Data;
using System.IO;
using ML.Experience.Classifier;
using ML.Experience.Converter;
using ML.Experience.Evaluation;

namespace ML.Experience
{
    class Program
    {
        static void Iris()
        {
            DataTable dataTrain = new CsvReader(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Iris\IrisTrain.csv", false)
            {
                Delimiter = ';'
            }.ToTable();
            DataTable dataTest = new CsvReader(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Iris\IrisTest.csv", false)
            {
                Delimiter = ';'
            }.ToTable();

            int[] dataTrainOutputs = dataTrain.Columns[4].ToArray<int>();
            dataTrain.Columns.RemoveAt(4);
            double[][] dataTrainInputs = dataTrain.ToJagged<double>();

            int[] dataTestOutputs = dataTest.Columns[4].ToArray<int>();
            dataTest.Columns.RemoveAt(4);
            double[][] dataTestInputs = dataTest.ToJagged<double>();

            IClassifier<double, int>[] classifier = new IClassifier<double, int>[] { new KNearestNeighbors(4) , new NaiveBayes(),
                new SupportVectorMachines(Framework.VectorMachines.Learning.Loss.L2), new LogitRegression(), new RandomClass()};

            int[][] predicted = new int[classifier.Length][];

            for (int i = 0; i < classifier.Length; i++)
            {
                classifier[i].Learn(dataTrainInputs, dataTrainOutputs);
                predicted[i] = classifier[i].Predict(dataTestInputs);

                IEvaluation<double>[] evaluation = new IEvaluation<double>[] { new Precision(dataTestOutputs, predicted[i]),
                new Recall(dataTestOutputs, predicted[i]), new FScore(dataTestOutputs, predicted[i])} ;

                Console.WriteLine(classifier[i]);
                foreach (IEvaluation<double> metric in evaluation)
                {
                    Console.WriteLine("{0}: {1}%", metric, metric.Measure());
                }                                 
            }
        }

        static void NewsGroup()
        {
            string[] filesTrain = Directory.GetFiles(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\20_Newsgroups\Big\Train");
            string[] dataTrainInputs = new string[filesTrain.Length];
            int[] dataTrainOutputs = new int[filesTrain.Length];
            string[][] wordsTrain = new string[filesTrain.Length][];
            for (int i = 0; i < filesTrain.Length; i++)
            {
                using (StreamReader sr = new StreamReader(filesTrain[i]))
                {
                    dataTrainOutputs[i] = i;
                    dataTrainInputs[i] = sr.ReadToEnd();
                    wordsTrain[i] = Framework.Tools.Tokenize(dataTrainInputs[i]);
                }
            }
            string[] dir = Directory.GetDirectories(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\20_Newsgroups\Big\Test");
            string[][] filesTest = new string[dir.Length][];
            string[][] wordsTest = new string[dir.Length][];
            for (int i = 0; i < dir.Length; i++)
            {
                filesTest[i] = Directory.GetFiles(dir[i]);
            }

            string[,] dataTestInputs = new string[dir.Length, filesTest[0].Length];
            int[] dataTestOutputs = new int[dir.Length];
            for (int k = 0; k < filesTest.Length; k++)
            {
                for (int i = 0; i < filesTest[k].Length; i++)
                {
                    using (StreamReader sr = new StreamReader(filesTest[k][i]))
                    {
                        dataTestInputs[k, i] = sr.ReadToEnd();
                        wordsTest[k] = Framework.Tools.Tokenize(dataTrainInputs[k]);
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

            IClassifier<double, int>[] classifier = new IClassifier<double, int>[] { new KNearestNeighbors(3), new NaiveBayes(),
                new SupportVectorMachines(Framework.VectorMachines.Learning.Loss.L2), new LogitRegression(), new RandomClass()};

            int[][] predicted = new int[classifier.Length][];
            for (int i = 0; i < classifier.Length; i++)
            {
                classifier[i].Learn(bowTrain, dataTrainOutputs);
                predicted[i] = classifier[i].Predict(bowTest);

                IEvaluation<double>[] evaluation = new IEvaluation<double>[] { new Precision(dataTestOutputs, predicted[i]),
                new Recall(dataTestOutputs, predicted[i]), new FScore(dataTestOutputs, predicted[i])};

                Console.WriteLine(classifier[i]);
                foreach (IEvaluation<double> metric in evaluation)
                {
                    Console.WriteLine("{0}: {1}%", metric, metric.Measure());
                }
            }
        }

        static void Mnist()
        {
            string pathMnistCSV = @"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Mnist\ImageTestConvert\MnistTest.csv";
            string pathMnistImg = @"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Mnist\ImageTest";

            //ImgToCSV itc = new ImgToCSV();
            //itc.Convert(pathMnistImg, pathMnistCSV);

            DataTable dataTrain = new CsvReader(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Mnist\MnistTrain.csv", true).ToTable();
            DataTable dataTest = new CsvReader(pathMnistCSV, true).ToTable();

            int[] dataTrainOutputs = dataTrain.Columns["label"].ToArray<int>();
            dataTrain.Columns.Remove("label");
            double[][] dataTrainInputs = dataTrain.ToJagged<double>();

            int[] dataTestOutputs = dataTest.Columns["label"].ToArray<int>();
            dataTest.Columns.Remove("label");
            double[][] dataTestInputs = dataTest.ToJagged<double>();


            IClassifier<double, int>[] classifier = new IClassifier<double, int>[] { new KNearestNeighbors(5) , new NaiveBayes(),
                new SupportVectorMachines(Framework.VectorMachines.Learning.Loss.L2), new LogitRegression(), new RandomClass()};

            int[][] predicted = new int[classifier.Length][];

            for (int i = 0; i < classifier.Length; i++)
            {
                classifier[i].Learn(dataTrainInputs, dataTrainOutputs);
                predicted[i] = classifier[i].Predict(dataTestInputs);

                IEvaluation<double>[] evaluation = new IEvaluation<double>[] { new Precision(dataTestOutputs, predicted[i]),
                new Recall(dataTestOutputs, predicted[i]), new FScore(dataTestOutputs, predicted[i])};

                Console.WriteLine(classifier[i]);
                foreach (IEvaluation<double> metric in evaluation)
                {
                    Console.WriteLine("{0}: {1}%", metric, metric.Measure());
                }
            }
        }

        static void Main(string[] args)
        {
            Mnist();


            Console.ReadLine();
        }
    }
}
