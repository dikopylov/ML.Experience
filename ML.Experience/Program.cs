using Accord.Math;
using Accord.MachineLearning;
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
using ML.Experience.GridDimension;
using System.Collections;
using System.Reflection;
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

            dataTrain.Codebook = new Accord.MachineLearning.BagOfWords()
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

            var knn = new Learn.KNearestNeighbors();
            var svm = new Learn.SupportVectorMachines(linear);

            IGridDimension[] gridDimensions = new IGridDimension[] {
                new GridDimension<int>
                (learnOption: (x) => knn.K = x.Value,
                criterion: K,
                classifier: knn),
                new GridDimension<Accord.Statistics.Kernels.IKernel>
                (learnOption: (x) => svm.Kernel = x.Value,
                criterion: kernel,
                classifier: svm) };

            IEvaluation[] evaluation = new IEvaluation[] { new Precision(), new Recall(), new FScore() };

            DataDelimeter dd = new DataDelimeter(3);

            LearnData[] delimData = dd.Cut(data);

            double[][][] measure = new double[gridDimensions.Length][][];

            /// [clf, gd, test, eval, data]
            /// Цикл по IGridDimension
            for (int k = 0; k < gridDimensions.Length; k++)
            {
                gridDimensions[k].Reset();
                measure[k] = new double[gridDimensions[k].LengthCriterion][];
                
                /// Перебор всех параметров классификатора
                for (int i = 0; i < gridDimensions[k].LengthCriterion; i++)
                {
                    /// Цикл по данным, разреженным на j-1 блоков
                    /// j-ий блок остается для теста предсказаний
                    for (int j = 0; j < delimData.Length - 1; j++)
                    {
                        gridDimensions[k].Classifier.Learn(delimData[j]);
                    }
                    var predict = gridDimensions[k].Classifier.TestPredict(delimData[delimData.Length - 1]);

                    measure[k][i] = new double[evaluation.Length];

                    /// Цикл по метрикам качества
                    for (int n = 0; n < evaluation.Length; n++)
                    {
                        measure[k][i][n] = evaluation[n].Measure(delimData[delimData.Length - 1].Outputs, predict);
                    }


                    var parameter = gridDimensions[k].Value;
                    /// Идем к следующему числу параметра
                    gridDimensions[k].Next();
                }
            }
        }


        static void Main(string[] args)
        {
            GD();
        }
    }
}
