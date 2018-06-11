using ML.Experience.Classifier.Learn;
using System;

namespace ML.Experience.GridDimension
{
    interface IGridDimension
    {
        IClassifierLearn Classifier { get; set; }
        object Value { get; }
        int LengthCriterion { get; }
        void Reset();
        void Next();
        void Back();

    }
}
