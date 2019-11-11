using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        private T[] _InternalArray;

        public int Count { get; }
        public int Capacity { get; }
        public bool IsReadOnly { get; }

        public Array(int capacity)
        {
            if(capacity < 1) { throw new ArgumentOutOfRangeException(nameof(capacity)); }

            Capacity = capacity;

            _InternalArray = new T[Capacity];
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public T this[int i]
        {
            get { return _InternalArray[i]; }

        }

        //TODO index operator

        class ArrayEnumerator : IEnumerator<T>
        {
            public T Current => throw new NotImplementedException();
            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
