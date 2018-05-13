using Accord.IO;
using Accord.Math;
using System;
using System.Data;
using System.Linq;


namespace ML.Experience.Converter
{
    class ConvertFromCSV : IConverter<double, int>
    {

        public double[][] Inputs { get; set; }

        public int[] Outputs { get; set; }

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

            Outputs = Data.Columns[NameOfLabel].ToArray<int>();
            Data.Columns.Remove(NameOfLabel);
            Inputs = Data.ToJagged<double>();
        }
    }
}
