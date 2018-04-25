using Accord.Statistics.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Fmeasure : ICommand
    {
        Application app;
        public string Name { get { return GetType().Name; } }
        public string Help { get { return "Гармоническое среднее между точностью и полнотой"; } }
        public string[] Synonyms { get { return new string[] { }; } }
        public string Description { get { return "Метрика качества"; } }

        public Fmeasure(Application app)
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
                    /// Получаем полноту каждой строки
                    var recalls = app.AccuracyEvaluation.Recall;
                    double result = 0;
                    double[] fMeasure = new double[precisions.Length];
                    /// Гармоническое среднее для каждой строки
                    for (int i = 0; precisions.Length > i && recalls.Length > i; i++)
                    {
                        fMeasure[i] = 2 * precisions[i] * recalls[i] / (precisions[i] + recalls[i]);
                        result += fMeasure[i];
                    }                  
                    /// Выводим среднее арифметическое гармонического числа
                    Console.WriteLine("F-Measure for {0}: {1}%", app.Сlassifier, Math.Round((result / fMeasure.Length) * 100, 0));
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("[Пустые параметры данных]: {0}", ex);
                }
            }
        }
    }
}