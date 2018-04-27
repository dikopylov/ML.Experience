using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.IO;
using Accord.Math;

namespace ConsoleUI
{
    public class TrainingCommand : ICommand
    {
        Application app;
        public string Name { get { return "training"; } }
        public string Help { get { return "Добавление обучающей выборки"; } }
        public string[] Synonyms { get { return new string[] { "train" }; } }
        public string Description { get { return @"Команда: training <""путь до файла""> <наличие заголовков: true или false> <при наличии заголовка индекс целевого столбца, если он существует>"; } }
        public TrainingCommand(Application app)
        {
            this.app = app;
        }
        public void Execute(params string[] parameters)
        {   
            /// Обработка пути  
            string path = "";
            int k = 0;
            foreach (string param in parameters)
            {
                if (param.Contains("\""))
                {
                    k++;
                    if (k > 1)
                    {
                        path += " " + param;
                    }
                    else
                    {
                        path += param;
                    }
                }
                else if (k == 1)
                {
                    path += " " + param;
                }
                else if (k > 1)
                {
                    k++;
                }
            }
            path = path.Replace("\"", "");
            /// train "H:\Documents\Visual Studio 2015\Projects\ML.Experience\CSV\Iris\IrisTrain.csv" true 4
            /// train "H:\Documents\Visual Studio 2015\Projects\ML.Experience\CSV\Mnist\MnistTrainLite.csv" true 0
            if (path != null && k - 1 == 2)
            {
                try
                {
                    DataTable dataTrain = new CsvReader(@path, Convert.ToBoolean(parameters[parameters.Length - 2])).ToTable();
                    app.DataTrainInputs = dataTrain.ToJagged<double>();
                }                
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                }
                
            }
            else if(path != null && k - 1 == 3)
            {
                try
                {
                    DataTable dataTrain = new CsvReader(@path, Convert.ToBoolean(parameters[parameters.Length - 2])).ToTable();
                    app.DataTrainInputs = dataTrain.ToJagged<double>();

                    if (Convert.ToInt32(parameters[parameters.Length - 1]) > -1)
                    {
                        app.DataTrainOutputs = dataTrain.Columns[Convert.ToInt32(parameters[parameters.Length - 1])].ToArray<int>();
                    }

                    app.DataTrainOutputs = dataTrain.Columns[Convert.ToInt32(parameters[parameters.Length - 1])].ToArray<int>();
                    dataTrain.Columns.RemoveAt(Convert.ToInt32(parameters[parameters.Length - 1]));
                    app.DataTrainInputs = dataTrain.ToJagged<double>();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                Console.WriteLine("Неверно введена команда");
            }
        }
    }
}
