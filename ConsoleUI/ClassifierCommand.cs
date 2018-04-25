using System;
using Accord.MachineLearning;

namespace ConsoleUI
{
    public class ClassifierCommand : ICommand
    {
        Application app;
        public string Name { get { return "clf"; } }
        public string Help { get { return "Выбор классификатора"; } }
        public string[] Synonyms
        {
            get { return new string[] { "choose_clf" }; }
        }
        public string Description
        {
            get
            {
                return String.Concat("Выбор классификатора из двух возможных вариантов:",
                  "\nМетод к-ближайших соседей(команда: knn <число k>)",
                  "\nНаивный Байесовский классификатор(команда: nb)");
            }
        }

        public ClassifierCommand(Application app)
        {
            this.app = app;
        }

        public void Execute(params string[] parameters)
        {
            const string knnStr = "knn";
            const string nbStr = "nb";
            if (parameters.Length == 1 && parameters[0] == nbStr)
            {

            }
            else if (parameters.Length == 2 && parameters[0] == knnStr)
            {
                try
                {
                    var knn = new KNearestNeighbors(k: Convert.ToInt32(parameters[1]));
                    app.Сlassifier = knn.Learn(app.DataTrainInputs, app.DataTrainOutputs);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("[Неверное число k]: {0}", ex);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("[Пустые параметры данных]: {0}", ex);
                }
            }
            else
            {
                Console.WriteLine("Ошибка в использовании команды");
            }
        }
    }
}
