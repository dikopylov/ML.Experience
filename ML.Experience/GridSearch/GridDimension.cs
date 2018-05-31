using ML.Experience.Converter;
using System;
using System.Linq;
using Learn = ML.Experience.Classifier.Learn;
using Predict = ML.Experience.Classifier.Predict;

namespace ML.Experience.GridSearch
{
    class GridDimension<TModel, TTeacher, TParam> : IGridDimension

    {
        public Parameters<TParam>[] Criterion { get; set; }

        public Func<Parameters<TParam>, Learn.IClassifierLearnModel<TModel, TTeacher>> LearnOption { get; set; }

        public Func<Learn.IClassifierLearnModel<TModel, TTeacher>, Predict.IClassifierPredict> PredictOption { get; set; }

        public Action<Learn.IClassifierLearn, IConverter> Learner { get; set; }

        public Func<Predict.IClassifierPredict, IConverter, int[]> Predictor { get; set; }

        public Learn.IClassifierLearnModel<TModel, TTeacher>[] LearnModel { get; set; }

        public Predict.IClassifierPredict[] PredictModel { get; set; }

        public IConverter Data { get; set; }

        public Func<int[], int[], double> Evaluation { get; set; }

        public double[] Error { get; set; }

        public double BestError { get; set; }

        public int[][] Predicted { get; set; }

        public Predict.IClassifierPredict BestModel { get; set; }

        public void Fit()
        {
            if (Learner == null)
                throw new InvalidOperationException();

            if (Evaluation == null)
                throw new InvalidOperationException();

            if (LearnOption == null)
                throw new InvalidOperationException();

            if (PredictOption == null)
                throw new InvalidOperationException();

            if (Predictor == null)
                throw new InvalidOperationException();

            LearnModel = new Learn.IClassifierLearnModel<TModel, TTeacher>[Criterion.Length];
            PredictModel = new Predict.IClassifierPredict[Criterion.Length];
            Predicted = new int[Criterion.Length][];
            Error = new double[Criterion.Length];

            for (int i = 0; i < Criterion.Length; i++)
            {
                Learn.IClassifierLearnModel<TModel, TTeacher> clfLearn = LearnOption(Criterion[i]);

                Learner(clfLearn, Data);
                LearnModel[i] = clfLearn;

                Predict.IClassifierPredict clfPredict = PredictOption(clfLearn);
                Predicted[i] = Predictor(clfPredict, Data);
                PredictModel[i] = clfPredict;

                Error[i] = Evaluation(Data.Outputs, Predicted[i]);
            }
            BestModel = PredictModel[Array.IndexOf(Error, Error.Min())];
            BestError = Error[Array.IndexOf(Error, Error.Min())];
        }
    }
}