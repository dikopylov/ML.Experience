using Accord.Statistics.Analysis;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleUI
{
    public class EvaluationCommand : ICommand
    {

        Application app;
        public string Name { get { return "evaluation"; } }
        public string Help { get { return "Выбор метрики качества алгоритма"; } }
        public string[] Synonyms
        {
            get { return new string[] { "quality", "eval" }; }
        }
        public string Description
        {
            get
            {
                return String.Concat("Выбор метрики качества алгоритма:",
                  "\nДоля правильных ответов - Accuracy (команда: accuracy)",
                  "\nТочность - Precision (команда: precision)",
                  "\nПолнота - Recall (команда: recall)",
                  "\nГармоническое среднее между точностью и полнотой - F-measure (команда: fmeasure)");
            }
        }

        public EvaluationCommand(Application app)
        {
            this.app = app;
        }

        public void Execute(params string[] parameters)
        {
            if (parameters.Length != 1)
            {
                Console.WriteLine("Неверно введена команда");
            }
            else
            {
                List<ICommand> metricsEvaluation = new List<ICommand>(new ICommand[] { new Accuracy(app), new Precision(app), new Recall(app), new Fmeasure(app) }); 
                /// Объект для перевода регистра (от example к Example)
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                string parameter = ti.ToTitleCase(parameters[0].ToLower());
                foreach (var metricEvaluation in metricsEvaluation)
                {
                    if (parameter.Equals(metricEvaluation.Name))
                    {
                        metricEvaluation.Execute();
                    }
                }
            }
        }
    }
}