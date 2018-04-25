using System;
using ConsoleUI;

namespace ML.Experience
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Application();
            app.AddCommand(new ExitCommand(app));
            app.AddCommand(new ExplainCommand(app));
            app.AddCommand(new HelpCommand(app));
            app.AddCommand(new ClassifierCommand(app));
            app.AddCommand(new EvaluationCommand(app));

            app.Run(Console.In);
        }
    }
}
