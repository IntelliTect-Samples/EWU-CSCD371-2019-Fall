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

        public bool IsReadOnly => throw new NotImplementedException();

        public Array(int capacity)
        {
            Capacity = capacity;
            _InternalCollection = new List<T>(capacity);
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
    }
}
