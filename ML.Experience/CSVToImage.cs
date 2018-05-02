using Accord.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Experience
{
    class CSVToImages
    {

        public CSVToImages(string path)
        {
            int[][] data = new CsvReader(path, true).ToJagged<int>();

            //создаем объект Bitmap, размеры картинки - квадратный корень из количества пикселей в csv
            Bitmap img = new Bitmap((int)Math.Sqrt(data[0].Length), (int)Math.Sqrt(data[0].Length));
            foreach(int[] rowOfPixels in data)
            {

                for (int i = 1; i < rowOfPixels.Length; i++)
                {
                    for (int Xcount = 0; Xcount < img.Width; Xcount++)
                    {
                        for (int Ycount = 0; Ycount < img.Height; Ycount++)
                        {
                            if (rowOfPixels[i] == 0)
                            {
                                rowOfPixels[i] = 255;
                            }
                            img.SetPixel(Xcount, Ycount, Color.FromArgb(0, rowOfPixels[i], rowOfPixels[i], rowOfPixels[i]));
                        }
                    }
                }
                img.Save(@"C:\Projects\ML.Experience-master\Data\Mnist\ResultImages\" + rowOfPixels[0] + "__" + RandomToken.RandomString(30) +".jpg");
            }
        }
    }
}
