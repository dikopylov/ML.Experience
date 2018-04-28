using Accord.IO;
using Accord.Math;
using System.Data;

namespace ML.Experience
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dataTrain = new CsvReader(@"H:\Documents\Visual Studio 2015\Projects\ML\ML\CSV\train\train.csv", true).ToTable();
            DataTable dataTest = new CsvReader(@"H:\Documents\Visual Studio 2015\Projects\ML\ML\CSV\test\testWithLabels.csv", true).ToTable();

            // I/O data //
            int[] trainOutputs = dataTrain.Columns["label"].ToArray<int>();
            dataTrain.Columns.Remove("label");
            double[][] trainInputs = dataTrain.ToJagged<double>();

            int[] testOutputs = dataTest.Columns["label"].ToArray<int>();
            dataTest.Columns.Remove("label");
            double[][] testInputs = dataTest.ToJagged<double>();
            // I/O data //
        }
    }
}
