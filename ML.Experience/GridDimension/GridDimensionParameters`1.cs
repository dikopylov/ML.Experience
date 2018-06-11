using System.Collections.Generic;

namespace ML.Experience.GridDimension
{
    class GridDimensionParameters<TParam>
    {
        public TParam Value { get; set; }

        public GridDimensionParameters(TParam value)
        {
            Value = value;
        }

        public GridDimensionParameters()
        {

        }

        static public GridDimensionParameters<int>[] Range(int start, int finish, int step = 1)
        {
            List<GridDimensionParameters<int>> range = new List<GridDimensionParameters<int>>();
            for (int i = start; i < finish; i += step)
            {
                range.Add(new GridDimensionParameters<int>(i));
            }

            return range.ToArray();
        }

    }
}
