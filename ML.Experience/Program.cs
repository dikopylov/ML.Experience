using Accord.Math;
using Framework = Accord.MachineLearning;
using System;
using System.Data;
using System.IO;
using ML.Experience.Classifier;
using ML.Experience.Converter;
using ML.Experience.Evaluation;
using Learn = ML.Experience.Classifier.Learn;
using Predict = ML.Experience.Classifier.Predict;
using Accord.IO;
using System.Collections.Generic;
using ML.Experience.GridSearch;
using System.Collections;
using System.Reflection;
using ML.Experience.CrossValid;
using ML.Experience.Data;

namespace ML.Experience
{
    class Program
    {
        static void Iris()
        {

            ConvertFromCSV dataTrain = new ConvertFromCSV("class", ';');
            ConvertFromCSV dataTest = new ConvertFromCSV("class", ';');

            string pathTrain = @"Data\Iris\IrisTrain.csv";
            string pathTest = @"Data\Iris\IrisTest.csv";

            dataTrain.Convert(pathTrain);
            dataTest.Convert(pathTest);

            var dataT = new LearnData
            {
                Inputs = dataTest.Inputs,
                Outputs = dataTest.Outputs
            };

            var dataL = new LearnData
            {
                Inputs = dataTrain.Inputs,
                Outputs = dataTrain.Outputs
            };

            Learn.IClassifierLearn[] classifierLearn = new Learn.IClassifierLearn[]
            {
                new Learn.KNearestNeighbors(4) , new Learn.NaiveBayes(),
                new Learn.SupportVectorMachines(new Accord.Statistics.Kernels.Linear()), new Learn.LogitRegression()
            };

            int[][] predicted = new int[classifierLearn.Length][];

            for (int i = 0; i < classifierLearn.Length; i++)
            {
                classifierLearn[i].Learn(dataL);
                predicted[i] = classifierLearn[i].TestPredict(dataT);

                IEvaluation[] evaluation = new IEvaluation[] { new Precision(),
                new Recall(), new FScore()};

                foreach (IEvaluation metric in evaluation)
                {
                    Console.WriteLine("{0}: {1}", metric, metric.Measure(dataT.Outputs, predicted[i]));
                }
            }
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

            dataTrain.Convert(@"Data\20_Newsgroups\Lite\Train1");
            dataTest.Convert(@"Data\20_Newsgroups\Lite\Test1");

            var dataT = new LearnData
            {
                Inputs = dataTest.Inputs,
                Outputs = dataTest.Outputs
            };

            Learn.IClassifierLearn[] classifier = new Learn.IClassifierLearn[] { new Learn.KNearestNeighbors(), new Learn.NaiveBayes(),
                new Learn.SupportVectorMachines(new Accord.Statistics.Kernels.Linear()), new Learn.LogitRegression() };

            int[][] predicted = new int[classifier.Length][];
            for (int i = 0; i < classifier.Length; i++)
            {
                classifier[i].Learn(dataTrain);
                predicted[i] = classifier[i].TestPredict(dataT);

                IEvaluation[] evaluation = new IEvaluation[] { new Precision(),
                new Recall(), new FScore()};

                Console.WriteLine(classifier[i]);
                foreach (IEvaluation metric in evaluation)
                {
                    Console.WriteLine("{0}: {1}", metric, metric.Measure(dataTest.Outputs, predicted[i]));
                }
            }
        }

        static void Mnist()
        {
            string pathMnistImg = @"Data\Mnist\ImageTestLite";
            string pathMnistCSV = @"Data\Mnist\MnistTrainLite.csv";
            string pathMnistTestCSV = @"Data\Mnist\MnistTestLite.csv";

            ConvertFromCSV dataTrain = new ConvertFromCSV("label");
            ConvertFromImage dataTest = new ConvertFromImage();

            dataTrain.Convert(pathMnistCSV);
            dataTest.Convert(pathMnistImg);

            var dataT = new LearnData
            {
                Inputs = dataTest.Inputs,
                Outputs = dataTest.Outputs
            };

            Learn.IClassifierLearn[] classifier = new Learn.IClassifierLearn[] { new Learn.KNearestNeighbors(5),
                new Learn.NaiveBayes(),
                new Learn.SupportVectorMachines(new Accord.Statistics.Kernels.Linear()) };

            int[][] predicted = new int[classifier.Length][];

            for (int i = 0; i < classifier.Length; i++)
            {
                classifier[i].Learn(dataTrain);
                predicted[i] = classifier[i].TestPredict(dataT);

                IEvaluation[] evaluation = new IEvaluation[] { new Precision(),
                new Recall(), new FScore()};

                Console.WriteLine(classifier[i]);
                foreach (IEvaluation metric in evaluation)
                {
                    Console.WriteLine("{0}: {1}", metric, metric.Measure(dataTest.Outputs, predicted[i]));
                }
            }
        }

        static void GD()
        {
            ConvertFromCSV dataTrain = new ConvertFromCSV("class", ';');
            string pathTrain = System.IO.Path.GetFullPath(@"Data\Iris\IrisTrain.csv");
            dataTrain.Convert(pathTrain);

            LearnData data = new LearnData
            {
                Inputs = dataTrain.Inputs,
                Outputs = dataTrain.Outputs
            };

            var linear = new Accord.Statistics.Kernels.Linear();
            var gussian = new Accord.Statistics.Kernels.Gaussian();
            var polynomial = new Accord.Statistics.Kernels.Polynomial();

            var kernel = new GridDimensionParameters<Accord.Statistics.Kernels.IKernel>[] {
            new GridDimensionParameters<Accord.Statistics.Kernels.IKernel>(linear),
            new GridDimensionParameters<Accord.Statistics.Kernels.IKernel>(gussian),
            new GridDimensionParameters<Accord.Statistics.Kernels.IKernel>(polynomial)};

            var K = GridDimensionParameters<int>.Range(3, 8, 2);

            // [clf, gd, test, eval, data]

            IGridDimension[] gridDimensions = new IGridDimension[] {
                new GridDimension<int>
                (learnOption: (x) => new Learn.KNearestNeighbors(x.Value),
                criterion: K),
                new GridDimension<Accord.Statistics.Kernels.IKernel>
                (learnOption: (x) => new Learn.SupportVectorMachines(x.Value),
                criterion: kernel) };

            IEvaluation[] evaluation = new IEvaluation[] { new Precision(), new Recall(), new FScore()};

            CrossDelimiter cv = new CrossDelimiter(3);
            LearnData[][] cvData = cv.Fit(data);

            double[,,] measure = new double[cvData.Length, cvData[0].Length, cvData[0].Length];

            for (int i = 0; i < gridDimensions.Length; i++)
            {
                var clfFit = gridDimensions[i].Fit();
                foreach (var clf in clfFit)
                {
                    for (int j = 0; j < cvData.Length; j++)
                    {
                        int k;
                        for (k = 0; k < cvData[j].Length - 1; k++)
                        {
                            clf.Learn(cvData[j][k]);
                        }
                        var predict = clf.TestPredict(cvData[j][k]);
                        int m = 0;
                        foreach (IEvaluation metric in evaluation)
                        {
                            measure[j, k, m++] = metric.Measure(cvData[j][k].Outputs, predict);
                        }

                    }
                }
            }
        }

        static void CV()
        {
            ConvertFromCSV dataTrain = new ConvertFromCSV("class", ';');
            string pathTrain = System.IO.Path.GetFullPath(@"Data\Iris\IrisTrain.csv");
            dataTrain.Convert(pathTrain);

            CrossDelimiter cv = new CrossDelimiter(3);

            LearnData[][] cvData = cv.Fit(dataTrain);

            var knn = new Learn.KNearestNeighbors(3);
            var knnP = new Predict.KNearestNeighbors();

            double[] ev = new double[cvData.Length];

            for (int i = 0; i < cvData.Length; i++)
            {
                for (int k = 0; k < cvData[i].Length - 1; k++)
                {
                    knn.Learn(cvData[i][k]);
                }
                var data = new PredictData
                {
                    Inputs = cvData[i][cvData[i].Length - 1].Inputs
                };
                knnP.Model = knn.Model;
                var predict = knnP.Predict(data);
                ev[i] = new Evaluation.Error().Measure(cvData[i][cvData[i].Length - 1].Outputs, predict);
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
