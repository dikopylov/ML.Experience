using System;
using System.Linq;
using ML.Experience.Classifier.Learn;
using System.Collections;

namespace ML.Experience.GridSearch
{
    class GridDimension<TParam> : IGridDimension, IEnumerable
    {
        IClassifierLearn[] clf;

        public int Length
        {
            get { return clf.Length; }
        }

        public IClassifierLearn this[int index]
        {
            get
            {
                return clf[index];
            }
            set
            {
                clf[index] = value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return clf.GetEnumerator();
        }

        public Func<GridDimensionParameters<TParam>, IClassifierLearn> LearnOption { get; set; }

        public GridDimensionParameters<TParam>[] Criterion { get; set; }

        public GridDimension(Func<GridDimensionParameters<TParam>, IClassifierLearn> learnOption,
            GridDimensionParameters<TParam>[] criterion)
        {
            LearnOption = learnOption;
            Criterion = criterion;
        }

        public GridDimension() { }

        public IClassifierLearn[] Fit()
        {
            IClassifierLearn[] LearnModel = new IClassifierLearn[Criterion.Length];

            for (int i = 0; i < Criterion.Length; i++)
            {
                LearnModel[i] = LearnOption(Criterion[i]);
            }
            return LearnModel;
        }
    }
}