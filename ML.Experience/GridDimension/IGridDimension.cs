using ML.Experience.Classifier.Learn;
using System;

namespace ML.Experience.GridSearch
{
    interface IGridDimension
    {
        IClassifierLearn Classifier { get; set; }
        int LengthCriterion { get; }
        int Count { get; set; }
        void Reset();
        void Next();

    }
}
