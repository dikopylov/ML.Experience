using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Experience.Evaluation
{
    class Error : IEvaluation
    {
        public double Measure(int[] expected, int[] predicted)
        {
            Accord.Statistics.Analysis.GeneralConfusionMatrix Estimater =
                new Accord.Statistics.Analysis.GeneralConfusionMatrix(expected, predicted);
            return Estimater.Error;
        }
    }
}
