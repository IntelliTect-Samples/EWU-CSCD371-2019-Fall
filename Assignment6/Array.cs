using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        public int Count { get; set; }
        private ICollection<T> _InternalCollection;
        public int Capacity { get; }

        public bool IsReadOnly => false;

        public Array(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            _InternalCollection = new List<T>(capacity);
            Capacity = capacity;
        }

        public void Add(T item)
        {
            if(Count < Capacity)
            {
                this._InternalCollection.Add(item);
                this.Count++;
            }
        }

        public void Clear()
        {
            _InternalCollection.Clear();
            Count = 0;
        }

        public bool Contains(T item)
        {
            if(!_InternalCollection.Contains(item))
            {
                throw new ArgumentException("Array.Contains method item not found");
            }
            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this._InternalCollection.GetEnumerator();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get
            {
                return ((List<T>)_InternalCollection)[index];
            }

            set
            {
                ((List<T>)_InternalCollection)[index] = value;
            }
        }
    }
}
