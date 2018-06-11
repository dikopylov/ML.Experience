using System;
using System.Linq;
using ML.Experience.Classifier.Learn;
using System.Collections;

namespace ML.Experience.GridSearch
{
    class GridDimension<TParam> : IGridDimension
    {
        public Action<GridDimensionParameters<TParam>> LearnOption { get; set; }

        public GridDimensionParameters<TParam>[] Criterion { get; set; }

        public IClassifierLearn Classifier { get; set; }

        public int LengthCriterion {
            get
            {
                return Criterion.Length;
            }
        }

        public TParam Value
        {
            get
            {
                return Criterion[count].Value;
            }
        }

        int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }

        public GridDimension(Action<GridDimensionParameters<TParam>> learnOption,
            GridDimensionParameters<TParam>[] criterion,
            IClassifierLearn classifier)
        {
            LearnOption = learnOption;
            Criterion = criterion;
            Classifier = classifier;
        }

        public GridDimension() { }

        public void Reset()
        {
            LearnOption(Criterion[count]);
        }

        public void Next()
        {
            if (count + 1 < Criterion.Length)
                LearnOption(Criterion[++count]);
        }
    }
}