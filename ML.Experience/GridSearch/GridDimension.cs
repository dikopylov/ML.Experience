using ML.Experience.Converter;
using ML.Experience.Evaluation;
using System;
using Learn = ML.Experience.Classifier.Learn;
using Predict = ML.Experience.Classifier.Predict;

namespace ML.Experience.GridSearch
{
    class GridDimension<T> : IDimensionEnumerator
    {
        public int Start { get; set; }
        public int Step { get; set; }
        public int Finish { get; set; }

        public Action<double[]> Criterion { get; set; }

        public Action<int> SetParameter { get; set; }

        public Func<Learn.IClassifierLearnModel<T>> ClassifierLearn { get; set; }

        public Func<Learn.IClassifierLearnModel<T>, Predict.IClassifierPredict> ClassifierPredict { get; set; }

        public Action<Learn.IClassifierLearn, IConverter> Learner { get; set; }

        public Func<Predict.IClassifierPredict, IConverter, int[]> Predictor { get; set; }

        public Learn.IClassifierLearn[] LearnModel { get; set; }

        public Predict.IClassifierPredict[] PredictModel { get; set; }

        public IConverter Data { get; set; }

        public Func<int[], int[], double> Evaluation { get; set; }

        public double[] Error { get; set; }

        public int[][] Predicted { get; set; }

        public GridDimension()
        {
            
        }

        int GetLengthModels()
        {
            int k = 0;
            for (int i = Start; i < Finish; i += Step) { k++; }

            LearnModel = new Learn.IClassifierLearn[k];
            PredictModel = new Predict.IClassifierPredict[k];
            Predicted = new int[k][];
            Error = new double[k];

            return LearnModel.Length;
        }

        public void Fit()
        {
            if (Learner == null)
                throw new InvalidOperationException();

            if (SetParameter == null)
                throw new InvalidOperationException();

            if (Evaluation == null)
                throw new InvalidOperationException();

            if (ClassifierLearn == null)
                throw new InvalidOperationException();

            if (ClassifierPredict == null)
                throw new InvalidOperationException();

            if (Predictor == null)
                throw new InvalidOperationException();
            
            
            

            int lengthModel = GetLengthModels();

            int tmplengthModel = lengthModel - 1;
            for (int i = Start; i < Finish; i += Step)
            {
                Learn.IClassifierLearnModel<T> clfLearn = ClassifierLearn();
                SetParameter(i);
                Learner(clfLearn, Data);
                LearnModel[lengthModel - tmplengthModel - 1] = clfLearn;

                var clfPredict = ClassifierPredict(clfLearn);
                Predicted[lengthModel - tmplengthModel - 1] = Predictor(clfPredict, Data);
                LearnModel[lengthModel - tmplengthModel - 1] = clfLearn;
                PredictModel[lengthModel - tmplengthModel - 1] = clfPredict;

                Error[lengthModel - tmplengthModel - 1] = Evaluation(Data.Outputs, Predicted[lengthModel - tmplengthModel - 1]);
                tmplengthModel--;
            }
        }

    }
}
