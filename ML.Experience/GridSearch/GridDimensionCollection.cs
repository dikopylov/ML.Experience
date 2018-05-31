using System.Collections;

namespace ML.Experience.GridSearch
{
    class GridDimensionCollection : IEnumerable
    {
        private IGridDimension[] _collection;

        public int Length
        {
            get
            {
                return _collection.Length;
            }
        }


        public GridDimensionCollection(IGridDimension[] pArray)
        {
            _collection = new IGridDimension[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _collection[i] = pArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public GridDimensionEnum GetEnumerator()
        {
            return new GridDimensionEnum(_collection);
        }
    }
}
