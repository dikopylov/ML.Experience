using System.Collections.Generic;

namespace ML.Experience.GridSearch
{
    class Parameters<TParam>
    {
        public string Name { get; set; }

        public TParam Value { get; set; }

        public Parameters(string name, TParam value)
        {
            Name = name;
            Value = value;
        }

        public Parameters(string name)
        {
            Name = name;
        }

        public Parameters()
        {

        }

        static public Parameters<int>[] Range(string name, int start, int finish, int step = 1)
        {
            List<Parameters<int>> range = new List<Parameters<int>>();
            for (int i = start; i < finish; i += step)
            {
                range.Add(new Parameters<int>(name, i));
            }

            return range.ToArray();
        }

    }
}
