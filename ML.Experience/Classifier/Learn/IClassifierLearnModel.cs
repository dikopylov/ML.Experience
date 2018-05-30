using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Experience.Classifier.Learn
{
    interface IClassifierLearnModel<T> : IClassifierLearn
    {
        T Model { get; set; }

        IClassifierLearnModel<T> Clone();
    }
}
