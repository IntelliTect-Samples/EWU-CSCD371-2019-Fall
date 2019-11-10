using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        private int Width { get; }

        private int Capacity { get; }

        public int Count { get; private set; }

        private List<T> _Collection;

        public bool IsReadOnly { get; private set; }

        public Array(int width)
        {
            Width = width;
            Count = 0;
            Capacity = width;
            _Collection = new List<T>(width);
            IsReadOnly = false;
        }

        public void Add(T item)
        {
            if (Count == Capacity)
                throw new InvalidOperationException($"Array is at maximum capacity {nameof(item)}");
            _Collection.Add(item);
            Count++;
        }

        public void Clear()
        {
            _Collection.Clear();
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (_Collection.Contains(item))
                return true;
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _Collection.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _Collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}