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
        public string Description { get { return "\nКоманда: training <путь до файла> <наличие заголовков: 0 или 1> <при наличии заголовка индекс целевого столбца, если он существует>"; } }
        public TrainingCommand(Application app)
        {
            this.app = app;
        }
        public void Execute(params string[] parameters)
        {
            if (parameters.Length == 2)
            {
                try
                {
                    DataTable dataTrain = new CsvReader(@parameters[0], Convert.ToBoolean(parameters[1])).ToTable();
                    app.DataTrainInputs = dataTrain.ToJagged<double>();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("[Наличие заголовков: 0 или 1]: {0}", ex);
                }
                
            }
            else if(parameters.Length == 3)
            {
                DataTable dataTrain = new CsvReader(@parameters[0], Convert.ToBoolean(parameters[1])).ToTable();
                app.DataTrainInputs = dataTrain.ToJagged<double>();

                app.DataTrainOutputs = dataTrain.Columns[Convert.ToInt32(parameters[2])].ToArray<int>();
                dataTrain.Columns.RemoveAt(Convert.ToInt32(parameters[2]));
                app.DataTrainInputs = dataTrain.ToJagged<double>();
            }
            else
            {
                Console.WriteLine("Неверно введена команда");
            }
        }
    }
}
