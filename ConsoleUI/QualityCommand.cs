using Accord.Statistics.Analysis;
using System;

namespace ConsoleUI
{
    class Quality : ICommand
    {

        Application app;
        public string Name { get { return "quality"; } }
        public string Help { get { return "Выбор классификатора"; } }
        public string[] Synonyms
        {
            get { return new string[] { "qual", "qua" }; }
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

        public Quality(Application app)
        {
            this.app = app;
        }

        public void Execute(params string[] parameters)
        {
            const string accuracyStr = "accuracy";
            const string precisionStr = "precision";
            const string recallStr = "recall";
            const string fMeasureStr = "fmeasure";
            ExplainCommand ea = new ExplainCommand(app);
            ea.Execute();
            if (parameters.Length != 1)
            {
                Console.WriteLine("Неверно введена команда");
            }
            else
            {
                app.AccuracyEvaluation = GeneralConfusionMatrix.Estimate(app.Сlassifier, app.DataTestInputs, app.DataTestOutputs);
                switch (parameters[0])
                {
                    case accuracyStr:
                        Console.WriteLine("Accuracy for {0}: {1}%", app.Сlassifier, Math.Round(app.AccuracyEvaluation.Accuracy, 3) * 100);
                        break;
                    case precisionStr:
                        Console.WriteLine("Precision for {0}:", app.Сlassifier);
                        var precisions = app.AccuracyEvaluation.Precision;
                        foreach (double precision in precisions)
                        {
                            Console.WriteLine("{0};", precision);
                        }
                        break;
                    case recallStr:
                        Console.WriteLine("Precision for {0}:", app.Сlassifier);
                        var recalls = app.AccuracyEvaluation.Recall;
                        foreach (double recall in recalls)
                        {
                            Console.WriteLine("{0};", recall);
                        }
                        break;
                    case fMeasureStr:
                        Console.WriteLine("Precision for {0}:", app.Сlassifier);
                        var prec = app.AccuracyEvaluation.Precision;
                        var rec = app.AccuracyEvaluation.Recall;
                        for (int i = 0; i < prec.Length; i++)
                        {
                            //Console.WriteLine("{0}", recall);
                        }
                        break;
                }
            }
        }
    }
}