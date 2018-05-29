using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Experience.Evaluation
{
    class Error : IEvaluation
    {
        public double Measure(Accord.Statistics.Analysis.GeneralConfusionMatrix Estimater)
        {
            return Estimater.Error;
        }
    }
}
