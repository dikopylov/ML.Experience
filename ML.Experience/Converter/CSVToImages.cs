using Accord.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Experience.Converter
{
    class CSVToImages
    {

        public CSVToImages(string pathData, string pathResults)
        {
            int[][] data = new CsvReader(pathData, true).ToJagged<int>();

            //создаем объект Bitmap, размеры картинки - квадратный корень из количества пикселей в csv
            Bitmap img = new Bitmap((int)Math.Sqrt(data[0].Length), (int)Math.Sqrt(data[0].Length));
            foreach (int[] rowOfPixels in data)
            {

                int i = 1;
                for (int Xcount = 0; Xcount < img.Width; Xcount++)
                {
                    for (int Ycount = 0; Ycount < img.Height; Ycount++)
                    {

                        img.SetPixel(Ycount, Xcount, Color.FromArgb(0, rowOfPixels[i], rowOfPixels[i], rowOfPixels[i]));
                        i++;
                    }
                }

                img.Save(@pathResults + rowOfPixels[0] + "__" + RandomToken.RandomString(30) + ".jpg");
            }
        }
    }
}
