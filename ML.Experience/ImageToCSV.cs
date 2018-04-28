using Accord.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Experience
{
    /// <summary>
    /// Конвертация MNIST
    /// </summary>
    class ImageToCSV
    {
        /// <summary>
        /// Создание заголовка для каждого пикселя
        /// </summary>
        string[] Pixel
        {
            get
            {
                string[] pixel = new string[28 * 28];
                for (int i = 0; i < 28 * 28; i++)
                {
                    pixel[i] = "pixel" + i;
                }
                return pixel;
            }
        }

        /// <summary>
        /// Поле содержит значение каждого пикселя
        /// Двумерный массив используется для грамотной записи данных в файл
        /// </summary>
        int[,] Values { get; } = new int[1, 28 * 28];

        /// <summary>
        /// Инициализация всех изображений
        /// </summary>
        /// <param name="n">кол-во изображений</param>
        /// <param name="path">путь</param>
        /// <returns></returns>
        public Bitmap[] InitImages(int n = 350, string path = @"H:\Documents\Visual Studio 2015\Projects\ML\ML\Image\mnist\testSample")
        {
            string[] filename = new string[n];
            Bitmap[] img = new Bitmap[n];

            for (int i = 0; i < n; i++)
            {
                int k = i + 1;
                string nameImg = "img_" + k + ".jpg";
                filename[i] = Path.Combine(path, nameImg);
                using (StreamReader reader = new StreamReader(new FileStream(filename[i], FileMode.Open, FileAccess.Read, FileShare.Read)))
                {
                    img[i] = (Bitmap)Image.FromFile(filename[i], true);
                }
            }
            return img;
        }

        /// <summary>
        /// Получение всех пикселей изображения
        /// </summary>
        /// <param name="img">массив изображений</param>
        public void GetPixelImages(Bitmap[] img)
        {
            int k = 0;
            foreach (Bitmap picture in img)
            {
                for (int y = 0; y < picture.Height; y++)
                {
                    for (int x = 0; x < picture.Width; x++)
                    {
                        Color color = picture.GetPixel(x, y);
                        Values[0, k++] = (color.R + color.G + color.B) / 3;
                    }
                }
            }
            //return Values;
        }

        /// <summary>
        /// Получение всех пикселей изображения
        /// </summary>
        /// <param name="img">изображение</param>
        public void GetPixelImage(Bitmap img)
        {
            int k = 0;
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color color = img.GetPixel(x, y);
                    Values[0, k++] = (color.R + color.G + color.B) / 3;
                }
            }
            // return values;
        }


        public void SaveCSV(string path = @"H:\Documents\Visual Studio 2015\Projects\ML\ML\CSV\testConverted\")
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

            FileStream csvCreate = new FileStream(path + timeAfter + ".csv", FileMode.CreateNew); //создание нового файла
            csvCreate.Close();
            using (CsvWriter writer = new CsvWriter(path + timeAfter + ".csv", ','))
            {
                writer.WriteHeaders(Pixel);
                writer.Write(Values);
            }
        }
    }
}
