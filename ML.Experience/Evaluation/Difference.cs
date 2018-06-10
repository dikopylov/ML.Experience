using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Experience.Evaluation
{
    class Difference 
    {
        public int[] FindEjection(int[] expected, int[] predicted)
        {
            if (expected.Length != predicted.Length)
            {
                throw new Exception("Matrices length need be equal");
            }

            List<int> difference = new List<int>();
            for (int i = 0; i < expected.Length; i++)
            {
                if (expected[i] != predicted[i])
                {
                    difference.Add(i);
                }
            }

            return difference.ToArray();
        }
    }
}
