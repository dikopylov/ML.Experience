using Accord.IO;
using System;
using System.Drawing;
using System.IO;

namespace ML.Experience.Converter
{
    /// <summary>
    /// Конвертация MNIST
    /// </summary>
    class ImageToCSV
    {
        /// <summary>
        /// Создание заголовка для каждого пикселя
        /// </summary>
        string[] Headers
        {
            get
            {
                string[] header = new string[28 * 28 + 1];
                header[0] = "label";
                for (int i = 1; i < 28 * 28 + 1; i++)
                {
                    header[i] = "pixel" + (i - 1);
                }           
                return header;
            }
        }

        /// <summary>
        /// Поле содержит значение каждого пикселя
        /// Двумерный массив используется для грамотной записи данных в файл
        /// </summary>
        ///int[,] Values { get; } = new int[1, 28 * 28];

        /// <summary>
        /// Инициализация всех изображений
        /// </summary>
        /// <param name="n">кол-во изображений</param>
        /// <param name="path">путь</param>
        /// <returns></returns>
        public Bitmap[] InitImages(string path = @"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Mnist\ImageTest\")
        {
            string[] filesTrain = Directory.GetFiles(@"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Mnist\ImageTest\");
            Bitmap[] img = new Bitmap[filesTrain.Length];

            int i = 0;
            foreach (string file in filesTrain)
            {
                using (StreamReader reader = new StreamReader(new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read)))
                {
                    img[i] = (Bitmap)Image.FromFile(file, true);
                }
                i++;
            }
            return img;
        }

        /// <summary>
        /// Получение всех пикселей изображения
        /// </summary>
        /// <param name="img">массив изображений</param>
        public int[,] GetPixelImages(Bitmap[] img)
        {
            int[,] Values = new int[img.Length, img[0].Size.Width * img[0].Size.Height + 1];
            foreach (Bitmap picture in img)
            {
                for (int y = 0; y < picture.Height; y++)
                {
                    for (int x = 0; x < picture.Width; x++)
                    {
                        Color color = picture.GetPixel(x, y);
                        Values[y,x] = (color.R + color.G + color.B) / 3;
                    }
                }
            }
            return Values;
        }

        ///// <summary>
        ///// Получение всех пикселей изображения
        ///// </summary>
        ///// <param name="img">изображение</param>
        //public void GetPixelImage(Bitmap img)
        //{
        //    int[] Values = new int[img.Size];
        //    for (int y = 0; y < img.Height; y++)
        //    {
        //        for (int x = 0; x < img.Width; x++)
        //        {
        //            Color color = img.GetPixel(x, y);
        //            Values[y, x] = (color.R + color.G + color.B) / 3;
        //        }
        //    }
        //}


        public void SaveCSV(Bitmap[] img, int[,] Values, string path = @"H:\Documents\Visual Studio 2015\Projects\ML.Experience\Data\Mnist\ImageTestConvert\MnistTest.csv")
        {
            string timeBefore = DateTime.Now.ToString();
            string timeAfter = "";

            foreach (char c in timeBefore)
            {
                if (c == ' ')
                    timeAfter += '-';
                else if (c == ':')
                    timeAfter += '_';
                else
                    timeAfter += c;
            }

            //создание нового файла
            FileStream csvCreate = new FileStream(path, FileMode.OpenOrCreate);
            csvCreate.Close();

            using (CsvWriter writer = new CsvWriter(path, ','))
                {
                    writer.WriteHeaders(Headers);
                }
            

            //for(int i = 0; i < Values.Length; i++)
            //{
                using (CsvWriter writer = new CsvWriter(path, ','))
                {
                    writer.Write(Values);
                }
          //  }
        }
    }
}
