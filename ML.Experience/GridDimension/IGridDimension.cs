using ML.Experience.Classifier.Learn;
using System;

namespace ML.Experience.GridSearch
{
    interface IGridDimension
    {
        IClassifierLearn[] Fit();
    }
}
