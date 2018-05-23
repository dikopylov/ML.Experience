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

        static void CvIris()
        {
            ConvertFromCSV dataTrain = new ConvertFromCSV("class", ';');
            ConvertFromCSV dataTest = new ConvertFromCSV("class", ';');

            dataTrain.Convert(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Iris\IrisTrain.csv");
            dataTest.Convert(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Iris\IrisTest.csv");

            var knnL = new Learn.KNearestNeighbors();
            //var z = new Accord.Math.Distances.Euclidean();
            //knn.Model.Distance = z;
            var knnP = new Predict.KNearestNeighbors();
            knnP.Load(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\TrainedModel\knn.bin");
            //a.

            //var knn = new Predict.KNearestNeighbors(Serializer.Load<Framework.KNearestNeighbors>(Path.Combine(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\TrainedModel", "knn.bin")));

            var cv = Framework.CrossValidation.Create(

            k: 5, // We will be using 10-fold cross validation

            learner: (p) => knnP.Model,

            // Now we have to specify how the tree performance should be measured:
            loss: (actual, expected, p) => new Accord.Math.Optimization.Losses.ZeroOneLoss(expected).Loss(actual),

            // This function can be used to perform any special
            // operations before the actual learning is done, but
            // here we will just leave it as simple as it can be:
            fit: (teacher, x, y, w) => teacher.Learn(x, y, w),

            // Finally, we have to pass the input and output data
            // that will be used in cross-validation. 
            x: dataTrain.Inputs, y: dataTrain.Outputs
            );
            var result = cv.Learn(dataTrain.Inputs, dataTrain.Outputs);
            double validationError = result.Validation.Mean; 
        }


        static void GSIris()
        {
            ConvertFromCSV dataTrain = new ConvertFromCSV("class", ';');
            //ConvertFromCSV dataTest = new ConvertFromCSV("class", ';');

            dataTrain.Convert(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Iris\IrisTrain.csv");
            //dataTest.Convert(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Iris\IrisTest.csv");

            var knn = new Learn.KNearestNeighbors();

            //    var gscv = Framework.Performance.GridSearch<double[], int>.Create(

            //    // Here we can specify the range of the parameters to be included in the search
            //    ranges: new
            //    {
            //        Method = Framework.Performance.GridSearch.Values<Accord.Math.Optimization.IOptimizationMethod>(new Accord.Math.Optimization.ConjugateGradient(),
            //        new Accord.Math.Optimization.GradientDescent())
            //    },

            //    // Indicate how learning algorithms for the models should be created
            //    learner: (p) => new Accord.Statistics.Models.Regression.Fitting.MultinomialLogisticLearning<TMethod>
            //    {
            //        // Here, we can use the parameters we have specified above:
            //        Method = p.Method.Value
            //    },

            //    // Define how the model should be learned, if needed
            //    fit: (teacher, x, y, w) => teacher.Learn(x, y, w),

            //    // Define how the performance of the models should be measured
            //    loss: (actual, expected, m) => new Accord.Math.Optimization.Losses.ZeroOneLoss(expected).Loss(actual)

            //    //folds: 5 // use k = 3 in k-fold cross validation

            //    //x: dataTrain.Inputs, y: dataTrain.Outputs // so the compiler can infer generic types
            //);

            //   var result = gscv.Learn(dataTrain.Inputs, dataTrain.Outputs);

            //    // Get the best values for the parameters:
            //    int bestK = result.BestParameters.K;
            //}

//            var gscv = Framework.Performance.GridSearch<double[], int>.Create(

//    // Here we can specify the range of the parameters to be included in the search
//    ranges: new
//    {
//        K = Framework.Performance.GridSearch.Range(1, 20),
//    },

//    // Indicate how learning algorithms for the models should be created
//    learner: (p) => new Framework.KNearestNeighbors()
//    {
//                    // Here, we can use the parameters we have specified above:
//                    K = p.K,
//        Distance = new Accord.Math.Distances.Euclidean()
//    },

//    // Define how the model should be learned, if needed
//    fit: (teacher, x, y, w) => teacher.Learn(x, y, w),

//    // Define how the performance of the models should be measured
//    loss: (actual, expected, m) => new Accord.Math.Optimization.Losses.ZeroOneLoss(expected).Loss(actual)

////folds: 5 // use k = 3 in k-fold cross validation

////x: dataTrain.Inputs, y: dataTrain.Outputs // so the compiler can infer generic types
//);

//            var result = gscv.Learn(dataTrain.Inputs, dataTrain.Outputs);

//            //// Get the best values for the parameters:
//            //int bestK = result.BestParameters.K;
        }

        static void Main(string[] args)
        {
            CvIris();

            //Console.ReadLine();
        }
    }
}
