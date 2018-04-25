using Accord.Statistics.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Precision : ICommand
    {
        Application app;
        public string Name { get { return GetType().Name; } }
        public string Help { get { return "Точность"; } }
        public string[] Synonyms { get { return new string[] { }; } }
        public string Description { get { return "Метрика качества"; } }

        public Precision(Application app)
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
                    /// Получаем точность каждой строки
                    var precisions = app.AccuracyEvaluation.Precision;
                    double result = 0;
                    foreach (var precision in precisions)
                    {
                        result += precision;
                    }
                    /// Выводим макро-усреднение 
                    Console.WriteLine("Precision for {0}: {1}%", app.Сlassifier, Math.Round((result / precisions.Length) * 100, 0));
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("[Пустые параметры данных]: {0}", ex);
                }
            }
        }
    }
}
