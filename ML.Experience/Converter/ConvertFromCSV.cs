using Accord.IO;
using Accord.Math;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace ML.Experience.Converter
{
    class ConvertFromCSV : IConverter
    {

        public double[][] Inputs { get; set; }

        public int[] Outputs { get; set; }

        public Dictionary<string, int> Translator { get; set; }

        string NameOfLabel { get; set; }

        char Delimeter { get; set; }

        DataTable Data { get; set; }

        public ConvertFromCSV(string nameOfLabel = "", char delimeter = '\0')
        {
            NameOfLabel = nameOfLabel;
            Delimeter = delimeter;
        }

        public void Convert(string path)
        {
            Data = new CsvReader(path, true)
            {
                Delimiter = this.Delimeter
            }.ToTable();

            try
            {
                Outputs = Data.Columns[NameOfLabel].ToArray<int>();
            }
            catch(FormatException)
            {
                ConvertFromString();
            }
            Data.Columns.Remove(NameOfLabel);
            Inputs = Data.ToJagged<double>();
        }

        public void ConvertFromString()
        {
            string[] OutputsToString = Data.Columns[NameOfLabel].ToArray<string>();
            string[] uniqueClass = OutputsToString.Distinct<string>();
            Translator = new Dictionary<string, int>();

            for (int i = 0; i < uniqueClass.Length; i++)
            {
                Translator.Add(uniqueClass[i], i);
            }

            Outputs = new int[OutputsToString.Length];
            for (int i = 0; i < Outputs.Length; i++)
            {
                Outputs[i] = Translator[OutputsToString[i]];
            }
       }
    }
}
