using System.Collections.Generic;
using System.Data;

namespace ML.Experience.Converter
{
    interface IConverter
    {
        double[][] Inputs { get; set; }

        int[] Outputs { get; set; }

        Dictionary<string, int> Translator { get; set; }

        void Convert(string path);
    }
}
