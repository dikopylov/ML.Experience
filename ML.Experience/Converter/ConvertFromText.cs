using System.Data;
using System.IO;
using Framework = Accord.MachineLearning;

namespace ML.Experience.Converter
{
    class ConvertFromText : IConverter<double, int>
    {
        public double[][] Inputs { get; set; }

        public int[] Outputs { get; set; }

        bool IsTrain { get; set; }

        public Framework.BagOfWords Codebook { get; set; }

        public ConvertFromText(bool isTrain = true)
        {
            
            IsTrain = isTrain;
        }

        public void Convert(string path)
        {
            var dir = Directory.GetDirectories(path);
            string[][] files = new string[dir.Length][];
            string[][] words = new string[dir.Length][];
            for (int i = 0; i < dir.Length; i++)
            {
                files[i] = Directory.GetFiles(dir[i]);
            }

            string[,] dataTestInputs = new string[dir.Length, files[0].Length];
            Outputs = new int[dir.Length];

            for (int k = 0; k < files.Length; k++)
            {
                for (int i = 0; i < files[k].Length; i++)
                {
                    using (StreamReader sr = new StreamReader(files[k][i]))
                    {
                        Outputs[k] = k;
                        dataTestInputs[k, i] = sr.ReadToEnd();
                        words[k] = Framework.Tools.Tokenize(dataTestInputs[k, i]);
                    }
                }
            }

            if (IsTrain)
            {
                Codebook.Learn(words);
            }

            Inputs = Codebook.Transform(words);
        }
    }
}
