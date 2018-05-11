using Accord.IO;
using System;
using System.Drawing;
using System.IO;

namespace ML.Experience.Converter
{
    class ImgToCSV
    {
        public void Convert(string pathData, string pathResult)
        {
            string[] filesTrain = Directory.GetFiles(pathData);
            Bitmap img;
            int label;
            FileStream csvCreate = new FileStream(pathResult, FileMode.OpenOrCreate);
            csvCreate.Close();
            int[,] Values = new int[filesTrain.Length, 784];

            int k = 0;
            foreach (string file in filesTrain)
            {
                using (StreamReader reader = new StreamReader(new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read)))
                {

                    label = Int32.Parse(Path.GetFileName(file).Split('_')[0]);
                    img = (Bitmap)Image.FromFile(file, true);
                }


                Values[k, 0] = Int32.Parse(Path.GetFileName(file).Split('_')[0]);
                int j = 0;
                for (int Xcount = 0; Xcount < img.Width; Xcount++)
                {
                    for (int Ycount = 0; Ycount < img.Height; Ycount++)
                    {
                        Color pixelColor = img.GetPixel(Ycount, Xcount);
                        int pixelRGBNunmer = pixelColor.G;
                        Values[k, j] = pixelRGBNunmer;

                        j++;
                    }
                }
                k++;
            }

            using (CsvWriter writer = new CsvWriter(pathResult, ','))
            {
                string[] headers = new string[785];
                headers[0] = "label";
                for (int i = 0; i < 784; i++)
                {
                    headers[i + 1] = "pixel" + i;
                }
                writer.WriteHeaders(headers);
                writer.Write(Values);
            }

        }
    }
}
