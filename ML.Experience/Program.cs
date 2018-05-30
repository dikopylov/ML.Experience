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

namespace ML.Experience
{
    class Program
    {
        static void Iris()
        {

            ConvertFromCSV dataTrain = new ConvertFromCSV("class", ';');
            ConvertFromCSV dataTest = new ConvertFromCSV("class", ';');

            string pathTrain = @"C:\Users\user\Desktop\Дима\ML.Experience\Data\Iris\IrisTrain.csv";
            string pathTest= @"C:\Users\user\Desktop\Дима\ML.Experience\Data\Iris\IrisTest.csv";

            dataTrain.Convert(pathTrain);
            dataTest.Convert(pathTest);

            Learn.IClassifierLearn[] classifierLearn = new Learn.IClassifierLearn[]
            {
                new Learn.KNearestNeighbors(4) , new Learn.NaiveBayes(),
                new Learn.SupportVectorMachines(new Accord.Statistics.Kernels.Linear()), new Learn.LogitRegression()
            };

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
            //        Console.WriteLine("{ 0}: {1}%", metric, metric.Measure());
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
            string pathMnistTestCSV = @"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Mnist\MnistTestLite.csv";

            //ConvertFromCSV dataTrain = new ConvertFromCSV("label");
            ConvertFromCSV dataTest = new ConvertFromCSV("label");
            //ConvertFromImage dataTest = new ConvertFromImage();


            dataTest.Convert(pathMnistTestCSV);
            //dataTest.Convert(pathMnistImg);

           // var knn = new Predict.KNearestNeighbors(Serializer.Load<Framework.KNearestNeighbors>(Path.Combine(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\TrainedModel", "knn.bin")));

            //var predict = knn.Predict(dataTest);

            //var Estimater = new Accord.Statistics.Analysis.GeneralConfusionMatrix(dataTest.Outputs, predict);

            //Console.WriteLine(Estimater.ColumnErrors);

            //for (int i = 1; i < 10; i++)
            //{
            //    var predict = knn.Predict(dataTest);
            //    var Estimater = new Accord.Statistics.Analysis.GeneralConfusionMatrix(dataTest.Outputs, predict);
            //}

            //var lr = new Predict.LogitRegression();
            //var nb = new Predict.NaiveBayes();
            //var svm = new Predict.SupportVectorMachines(Framework.VectorMachines.Learning.Loss.L2);

            //knn.Learn(dataTrain);
            //lr.Learn(dataTrain);
            //nb.Learn(dataTrain);
            //svm.Learn(dataTrain);

            //knn.Model.Save(Path.Combine(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\TrainedModel", "knn.bin"));
            //lr.Model.Save(Path.Combine(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\TrainedModel", "lr.bin"));
            //nb.Model.Save(Path.Combine(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\TrainedModel", "nb.bin"));
            //svm.Model.Save(Path.Combine(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\TrainedModel", "svm.bin"));

            //knn.Model = Serializer.Load<Framework.KNearestNeighbors>(Path.Combine(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\TrainedModel", "knn.bin"));



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

        static void GSIris()
        {
            ConvertFromCSV dataTrain = new ConvertFromCSV("class", ';');
            //ConvertFromCSV dataTest = new ConvertFromCSV("class", ';');

            dataTrain.Convert(@"C:\Users\user\Desktop\Дима\ML.Experience\Data\Iris\IrisTrain.csv");
            //dataTest.Convert(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Iris\IrisTest.csv");

            var knn = new Learn.KNearestNeighbors();
           

            var gscv = Framework.Performance.GridSearch<double[], int>.Create(
            ranges: new
            {
                K = Framework.Performance.GridSearch.Range(1, 20),
            },

            learner: (p) => new Framework.KNearestNeighbors()
            {
                K = p.K,
                Distance = new Accord.Math.Distances.Euclidean()
            },

            fit: (teacher, x, y, w) => teacher.Learn(x, y, w),

            loss: (actual, expected, m) => new Accord.Math.Optimization.Losses.ZeroOneLoss(expected).Loss(actual)
        );

            var result = gscv.Learn(dataTrain.Inputs, dataTrain.Outputs);

            int bestK = result.BestParameters.K;

            var bestModel = result.BestModel;
        }

        static void IrisWord()
        {
            ConvertFromCSV dataTrain = new ConvertFromCSV("class", ';');
            ConvertFromCSV dataTest = new ConvertFromCSV("class", ';');

            string pathTrain = @"C:\Users\user\Desktop\Дима\ML.Experience\Data\Iris\IrisNameTrain.csv";
            string pathTest = @"C:\Users\user\Desktop\Дима\ML.Experience\Data\Iris\IrisNameTest.csv";

            dataTrain.Convert(pathTrain);
            dataTest.Convert(pathTest);

            var knnL = new Learn.KNearestNeighbors();
            knnL.Learn(dataTrain);

            //var knnP = new Predict.KNearestNeighbors(knnL.Model);
            //var predict = knnP.PredictToString(dataTest);
            //dataTest.Convert(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Iris\IrisTest.csv");
        }

        static void IrisOpti()
        {
            ConvertFromCSV dataTrain = new ConvertFromCSV("class", ';');
            ConvertFromCSV dataTest = new ConvertFromCSV("class", ';');

            //ConvertFromCSV dataTrain = new ConvertFromCSV("label");
            //ConvertFromCSV dataTest = new ConvertFromCSV("label");
            string pathTrain = @"C:\Users\user\Desktop\Дима\ML.Experience\Data\Iris\IrisNameTrain.csv";
            string pathTest = @"C:\Users\user\Desktop\Дима\ML.Experience\Data\Iris\IrisNameTest.csv";
            dataTrain.Convert(pathTrain);
            dataTest.Convert(pathTest);



            var knnL = new Learn.KNearestNeighbors();
            knnL.Learn(dataTrain);
            
            var knnP = new Predict.KNearestNeighbors(knnL);

            knnP.Model.Distance = new Accord.Math.Distances.Euclidean();

            double[] error = new double[dataTest.Outputs.Length];

            for (int i = 1; i < dataTest.Outputs.Length; i++)
            {
                knnP.Model.K = i;

                var predict = knnP.Predict(dataTest);
                var gcm = new Accord.Statistics.Analysis.GeneralConfusionMatrix(predict, dataTest.Outputs);
                error[i] = 1 - new Accuracy().Measure(gcm);
            }
                var errorMin = new Dictionary<string, double> { { "K", Array.IndexOf(error, error.Min()) + 1 },
                { "Error", error.Min() } };
          
        }

        static void GD()
        {
            ConvertFromCSV dataTrain = new ConvertFromCSV("class", ';');
            //ConvertFromCSV dataTest = new ConvertFromCSV("class", ';');

            string pathTrain = @"C:\Users\Дмитрий\Desktop\Дима\ML.Experience\Data\Iris\IrisNameTrain.csv";
            //string pathTest = @"C:\Users\user\Desktop\Дима\ML.Experience\Data\Iris\IrisNameTest.csv";
            dataTrain.Convert(pathTrain);
            //dataTest.Convert(pathTest);

            //var classifierLearn = new Learn.IClassifierLearn[] { new Learn.KNearestNeighbors(),
            //    new Learn.LogitRegression(), new Learn.NaiveBayes(), new Learn.SupportVectorMachines()};

            //var knnL = new Learn.KNearestNeighbors();
            //var knnP = new Predict.KNearestNeighbors();

            var gdKNN = new GridDimension<Framework.KNearestNeighbors>
            {
                LearnOption = (x) => new Learn.KNearestNeighbors()
                {
                    K = x
                },
                PredictOption = model => new Predict.KNearestNeighbors(model),
                Start = 1,
                Step = 1,
                Finish = 3,
                Learner = (teacher, data) => teacher.Learn(data),
                Predictor = (forecast, data) => forecast.Predict(data),
                Evaluation = (expected, predicted) => new Evaluation.Error()
                .Measure(new Accord.Statistics.Analysis.GeneralConfusionMatrix(expected, predicted)),
                Data = dataTrain
            };

            gdKNN.Fit();
        }
            //var bin = new string[] { "knn.bin", "lr.bin", "nb.bin", "svm.bin" };

            //for (int i = 0; i < classifierPredict.Length; i++)
            //{
            //    classifierPredict[i].Load(@"C:\Users\user\Desktop\Дима\ML.Experience\TrainedModel\Iris\" + bin[i]);
            //}

        static void Main(string[] args)
        {
            //GSIris();
            GD();
            //IrisWord();
            //GSIris();
            //Console.ReadLine();
        }
    }
}
