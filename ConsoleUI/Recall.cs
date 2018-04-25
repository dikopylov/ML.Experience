using Accord.Statistics.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Recall : ICommand
    {
        Application app;
        public string Name { get { return GetType().Name; } }

        public string Help { get { return "Метрика качества"; } }
        public string[] Synonyms
        {
            get { return new string[] { "rec" }; }
        }
        public string Description
        {
            get
            {
                return "Полнота";
            }
        }

        public Recall(Application app)
        {
            this.app = app;
        }

        public void Execute(params string[] parameters)
        {
            if (parameters.Length != 0)
            {
                Console.WriteLine("Неверно введена команда");
            }
            else
            {
                try
                {
                    app.AccuracyEvaluation = GeneralConfusionMatrix.Estimate(app.Сlassifier, app.DataTestInputs, app.DataTestOutputs);
                    /// Получаем полноту каждой строки
                    var recalls = app.AccuracyEvaluation.Recall;
                    double result = 0;
                    foreach (var recall in recalls)
                    {
                        result += recall;
                    }
                    /// Выводим макро-усреднение 
                    Console.WriteLine("Precision for {0}: {1}%", app.Сlassifier, Math.Round((result / recalls.Length) * 100, 0));
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("[Пустые параметры данных]: {0}", ex);
                }
            }
        }
    }
}
