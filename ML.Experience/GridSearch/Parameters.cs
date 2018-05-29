using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Experience.GridSearch
{
    static class Parameters
    {
        public static double[] Range(double start, double finish, double step = 1)
        {
            List<double> param = new List<double>();
            for (double i = start; i < finish; i += step)
            {
                param.Add(i);
            }

            return param.ToArray();
        }

        public static double[] Values(params double[] values)
        {
            return values;
        }

        //static string[] Values(params string[] values)
        //{
        //    return values;
        //}
    }
}
