using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Experience.Classifier.Learn
{
    interface IClassifierLearnModel<TModel> : IClassifierLearn
    {
        TModel Model { get; set; }
    }
}
