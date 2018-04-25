using Accord.Statistics.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Accuracy : ICommand
    {
        Application app;
        public string Name { get { return GetType().Name; } }
        public string Help { get { return "Метрика качества"; } }
        public string[] Synonyms
        {
            get { return new string[] { "acc" }; }
        }
        public string Description
        {
            get
            {
                return "Доля правильных ответов - Accuracy (команда: accuracy)";
            }
        }

        public Accuracy(Application app)
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
                    Console.WriteLine("Accuracy for {0}: {1}%", app.Сlassifier, Math.Round(app.AccuracyEvaluation.Accuracy, 3) * 100);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("[Пустые параметры данных]: {0}", ex);
                }
            }
        }
    }
}
