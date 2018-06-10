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
        static string projectPath = @"..\..\";
        static void Iris()
        {

            ConvertFromCSV dataTrain = new ConvertFromCSV("class", ';');
            ConvertFromCSV dataTest = new ConvertFromCSV("class", ';');

            string pathTrain = projectPath + @"Datasets\Iris\IrisTrain.csv";
            string pathTest = projectPath + @"Datasets\Iris\IrisTest.csv";

            dataTrain.Convert(pathTrain);
            dataTest.Convert(pathTest);

            LearnData dataL = dataTest;

            LearnData dataT = dataTest;

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

            dataTrain.Convert(projectPath + @"Data\20_Newsgroups\Lite\Train1");
            dataTest.Convert(projectPath + @"Data\20_Newsgroups\Lite\Test1");

            LearnData dataT = dataTest;

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
            string pathMnistImg = projectPath + @"Datasets\Mnist\ImageTestLite";
            string pathMnistCSV = projectPath + @"Datasets\Mnist\MnistTrainLite.csv";
            string pathMnistTestCSV = projectPath + @"Datasets\Mnist\MnistTestLite.csv";

            ConvertFromCSV dataTrain = new ConvertFromCSV("label");
            ConvertFromImage dataTest = new ConvertFromImage();

            dataTrain.Convert(pathMnistCSV);
            dataTest.Convert(pathMnistImg);

            LearnData dataT = dataTest;

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
            string pathTrain = System.IO.Path.GetFullPath(projectPath + @"Datasets\Iris\IrisTrain.csv");
            dataTrain.Convert(pathTrain);

            LearnData data = dataTrain;

            var linear = new Accord.Statistics.Kernels.Linear();
            var gussian = new Accord.Statistics.Kernels.Gaussian();
            var polynomial = new Accord.Statistics.Kernels.Polynomial();

            var kernel = new GridDimensionParameters<Accord.Statistics.Kernels.IKernel>[] {
            new GridDimensionParameters<Accord.Statistics.Kernels.IKernel>(linear),
            new GridDimensionParameters<Accord.Statistics.Kernels.IKernel>(gussian),
            new GridDimensionParameters<Accord.Statistics.Kernels.IKernel>(polynomial)};

            var K = GridDimensionParameters<int>.Range(3, 8, 2);

            IGridDimension[] gridDimensions = new IGridDimension[] {
                new GridDimension<int>
                (learnOption: (x) => new Learn.KNearestNeighbors(x.Value),
                criterion: K),
                new GridDimension<Accord.Statistics.Kernels.IKernel>
                (learnOption: (x) => new Learn.SupportVectorMachines(x.Value),
                criterion: kernel) };

            IEvaluation[] evaluation = new IEvaluation[] { new Precision(), new Recall(), new FScore()};

            CrossValidation cv = new CrossValidation(3);
            LearnData[][] cvData = cv.Fit(data);

            double[,,] measure = new double[cvData.Length, cvData[0].Length, cvData[0].Length];
            
            /// [clf, gd, test, eval, data]
            /// Цикл по IGridDimension
            foreach (var gd in gridDimensions)
            {
                Learn.IClassifierLearn[] clfFit = gd.Fit();
                /// Цикл по созданным классификаторам с РАЗНЫМИ параметрами
                foreach (var clf in clfFit)
                {
                    /// Цикл по данным, разреженным на j блоков при помощи кросс-валидации
                    for (int j = 0; j < cvData.Length; j++)
                    {
                        int k;
                        /// Цикл по k частям внутри каждого блока
                        for (k = 0; k < cvData[j].Length - 1; k++)
                        {
                            clf.Learn(cvData[j][k]);
                        } 
                        var predict = clf.TestPredict(cvData[j][k]);
                        int m = 0;
                        /// Цикл по метрикам качества алгоритмов
                        foreach (IEvaluation metric in evaluation)
                        {
                            measure[j, k, m++] = metric.Measure(cvData[j][k].Outputs, predict);
                        }

                    }
                }
            }
        }

        static void Main(string[] args)
        {
            GD();
        }
    }
}
