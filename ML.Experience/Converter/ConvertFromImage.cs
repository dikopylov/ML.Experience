using System;
using System.Drawing;
using System.IO;

namespace ML.Experience.Converter
{
    class ConvertFromImage : IConverter<double, int>
    {
        public double[][] Inputs { get; set; }

        public int[] Outputs { get; set; }

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
