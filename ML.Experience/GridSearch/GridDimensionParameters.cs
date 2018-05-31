using System.Collections.Generic;

namespace ML.Experience.GridSearch
{
    class GridDimensionParameters<TParam>
    {
        public string Name { get; set; }

        public TParam Value { get; set; }

        public GridDimensionParameters(string name, TParam value)
        {
            Name = name;
            Value = value;
        }

        public GridDimensionParameters(string name)
        {
            Name = name;
        }

        public GridDimensionParameters()
        {

        }

        static public GridDimensionParameters<int>[] Range(string name, int start, int finish, int step = 1)
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
