using System;
using System.Linq;
using ML.Experience.Classifier.Learn;
using System.Collections;
using ML.Experience.GridDimension;

namespace ML.Experience.GridDimension
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

        public object Value
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

        public void Back()
        {
            if (count - 1 > 0)
                LearnOption(Criterion[--count]);
        }
    }
}