using Accord.IO;
using Accord.Math;
using Framework = Accord.MachineLearning;
using System;
using System.Data;
using System.IO;
using ML.Experience.Classifier;
using ML.Experience.Converter;
using ML.Experience.Evaluation;
using ML.Experience.Classifier.Learn;

namespace ML.Experience
{
    class Program
    {
        static void Iris()
        {

            ConvertFromCSV dataTrain = new ConvertFromCSV("class", ';');
            ConvertFromCSV dataTest = new ConvertFromCSV("class", ';');

            dataTrain.Convert(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Iris\IrisTrain.csv");
            dataTest.Convert(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Iris\IrisTest.csv");

            object [] classifierLearn = new object[] { new KNearestNeighbors(4) , new NaiveBayes(),
                new SupportVectorMachines(Framework.VectorMachines.Learning.Loss.L2), new LogitRegression() };

            //IClassifierLearn<double, int, object, object> classifierLearn = new IClassifierLearn<double, int, object, object>[]
            //{
            //    new KNearestNeighbors(4) , new NaiveBayes(),
            //    new SupportVectorMachines(Framework.VectorMachines.Learning.Loss.L2), new LogitRegression()
            //};


            //int[][] predicted = new int[classifier.Length][];

            //for (int i = 0; i < classifier.Length; i++)
            //{
            //    classifier[i].Learn(dataTrainInputs, dataTrainOutputs);
            //    predicted[i] = classifier[i].Predict(dataTestInputs);

            //    IEvaluation<double>[] evaluation = new IEvaluation<double>[] { new Precision(dataTestOutputs, predicted[i]),
            //    new Recall(dataTestOutputs, predicted[i]), new FScore(dataTestOutputs, predicted[i])};

            //    Console.WriteLine(classifier[i]);
            //    foreach (IEvaluation<double> metric in evaluation)
            //    {
            //        Console.WriteLine("{0}: {1}%", metric, metric.Measure());
            //    }
            //}
        }
        
        static void NewsGroup()
        {

            ConvertFromText dataTrain = new ConvertFromText();
            ConvertFromText dataTest = new ConvertFromText(false);

            dataTrain.Codebook = new Framework.BagOfWords()
            {
                MaximumOccurance = 20
            };

            dataTest.Codebook = dataTrain.Codebook;

            dataTrain.Convert(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\20_Newsgroups\Lite\Train1");
            dataTest.Convert(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\20_Newsgroups\Lite\Test1");

            //double[][] bowTrain = codebook.Transform(wordsTrain);
            //double[][] bowTest = codebook.Transform(wordsTest);

            //IClassifier<double, int>[] classifier = new IClassifier<double, int>[] { new KNearestNeighbors(3), new NaiveBayes(),
            //    new SupportVectorMachines(Framework.VectorMachines.Learning.Loss.L2), new LogitRegression(), new RandomClassifier()};

            //int[][] predicted = new int[classifier.Length][];
            //for (int i = 0; i < classifier.Length; i++)
            //{
            //    classifier[i].Learn(bowTrain, dataTrainOutputs);
            //    predicted[i] = classifier[i].Predict(bowTest);

            //    IEvaluation<double>[] evaluation = new IEvaluation<double>[] { new Precision(dataTestOutputs, predicted[i]),
            //    new Recall(dataTestOutputs, predicted[i]), new FScore(dataTestOutputs, predicted[i])};

            //    Console.WriteLine(classifier[i]);
            //    foreach (IEvaluation<double> metric in evaluation)
            //    {
            //        Console.WriteLine("{0}: {1}%", metric, metric.Measure());
            //    }
            //}
        }

        static void Mnist()
        {
            string pathMnistImg = @"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Mnist\ImageTestLite";
            string pathMnistCSV = @"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Mnist\MnistTrainLite.csv";

            ConvertFromCSV dataTrain = new ConvertFromCSV("label");
            ConvertFromImage dataTest = new ConvertFromImage();

            dataTrain.Convert(pathMnistCSV);
            dataTest.Convert(pathMnistImg);

            //IClassifier<double, int>[] classifier = new IClassifier<double, int>[] { new KNearestNeighbors(5) , new NaiveBayes(),
            //    new SupportVectorMachines(Framework.VectorMachines.Learning.Loss.L2), new LogitRegression(), new RandomClassifier()};

            //int[][] predicted = new int[classifier.Length][];

            //for (int i = 0; i < classifier.Length; i++)
            //{
            //    classifier[i].Learn(dataTrainInputs, dataTrainOutputs);
            //    predicted[i] = classifier[i].Predict(dataTestInputs);

            //    IEvaluation<double>[] evaluation = new IEvaluation<double>[] { new Precision(dataTestOutputs, predicted[i]),
            //    new Recall(dataTestOutputs, predicted[i]), new FScore(dataTestOutputs, predicted[i])};

            //    Console.WriteLine(classifier[i]);
            //    foreach (IEvaluation<double> metric in evaluation)
            //    {
            //        Console.WriteLine("{0}: {1}%", metric, metric.Measure());
            //    }
            //}
        }

        
        static void Main(string[] args)
        {
            Mnist();

            Console.ReadLine();
        }
    }
}
