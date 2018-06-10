using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Experience.Data
{
    class LearnData : ICloneable
    {
        public double[][] Inputs { get; set; }

        public int[] Outputs { get; set; }

        public object Clone()
        {
            return new LearnData
            {
                Inputs = this.Inputs,
                Outputs = this.Outputs
            };
        }
    }
}
