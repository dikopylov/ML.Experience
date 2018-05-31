using System;
using System.Collections;

namespace ML.Experience.GridSearch
{
    class GridDimensionEnum : IEnumerator
    {
        public IGridDimension[] _collection;

        int position = -1;

        public GridDimensionEnum(IGridDimension[] list)
        {
            _collection = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _collection.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public IGridDimension Current
        {
            get
            {
                try
                {
                    return _collection[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
