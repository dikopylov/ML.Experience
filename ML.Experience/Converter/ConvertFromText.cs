using ML.Experience.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Framework = Accord.MachineLearning;

namespace ML.Experience.Converter
{
    class ConvertFromText : IConverter
    {


        public static implicit operator LearnData(ConvertFromText convert)
        {
            return new LearnData
            {
                Inputs = convert.Inputs,
                Outputs = convert.Outputs
            };
        }

        public static implicit operator ConvertFromText(LearnData convert)
        {
            return new ConvertFromText
            {
                Inputs = convert.Inputs,
                Outputs = convert.Outputs
            };
        }

        public static implicit operator PredictData(ConvertFromText convert)
        {
            return new PredictData
            {
                Inputs = convert.Inputs
            };
        }

        public static implicit operator ConvertFromText(PredictData convert)
        {
            return new ConvertFromText
            {
                Inputs = convert.Inputs
            };
        }
        public double[][] Inputs { get; set; }

        public int[] Outputs { get; set; }

        public Dictionary<string, int> Translator { get; set; }

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

            string[,] dataInputs = new string[dir.Length, files[0].Length];
            Outputs = new int[dir.Length];
            Translator = new Dictionary<string, int>();

            for (int k = 0; k < files.Length; k++)
            {
                for (int i = 0; i < files[k].Length; i++)
                {
                    using (StreamReader sr = new StreamReader(files[k][i]))
                    {
                        var split = files[k][i].Split('\\');
                        try
                        {
                            Translator.Add(split[split.Length - 2], k);
                        }
                        catch(ArgumentException)
                        {
                            Outputs[k] = k;
                        }
                        Outputs[k] = Translator[split[split.Length - 2]];
                        dataInputs[k, i] = sr.ReadToEnd();
                        words[k] = Framework.Tools.Tokenize(dataInputs[k, i]);
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
