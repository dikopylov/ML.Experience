using ML.Experience.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ML.Experience.Converter
{
    class ConvertFromImage : IConverter
    {
        public static implicit operator LearnData(ConvertFromImage convert)
        {
            return new LearnData
            {
                Inputs = convert.Inputs,
                Outputs = convert.Outputs
            };
        }

        public static implicit operator ConvertFromImage(LearnData convert)
        {
            return new ConvertFromImage
            {
                Inputs = convert.Inputs,
                Outputs = convert.Outputs
            };
        }

        public static implicit operator PredictData(ConvertFromImage convert)
        {
            return new PredictData
            {
                Inputs = convert.Inputs
            };
        }

        public static implicit operator ConvertFromImage(PredictData convert)
        {
            return new ConvertFromImage
            {
                Inputs = convert.Inputs
            };
        }
        public double[][] Inputs { get; set; }

        public int[] Outputs { get; set; }

        public Dictionary<string, int> Translator { get; set; }

        public void Convert(string pathData)
        {
            string[] files = Directory.GetFiles(pathData);
            Bitmap img;
            int label;
            double[] pixelRGBNumbers;
            Inputs = new double[files.Length][];
            Outputs = new int[files.Length];           
            for (int k = 0; k < files.Length; k++)
            {

                using (StreamReader reader = new StreamReader(new FileStream(files[k], FileMode.Open, FileAccess.Read, FileShare.Read)))
                {
                    label = Int32.Parse(Path.GetFileName(files[k]).Split('_')[0]);
                    img = (Bitmap)Image.FromFile(files[k], true);
                }

                pixelRGBNumbers = new double[img.Width * img.Height];
                Outputs[k] = label;


                for (int Xcount = 0, j = 0; Xcount < img.Width; Xcount++)
                {
                    for (int Ycount = 0; Ycount < img.Height; Ycount++, j++)
                    {
                        Color pixelColor = img.GetPixel(Ycount, Xcount);
                        pixelRGBNumbers[j] = pixelColor.G;
                    }
                }

                Inputs[k] = new double[pixelRGBNumbers.Length];
                Inputs[k] = pixelRGBNumbers;
            }
        }
    }
}
