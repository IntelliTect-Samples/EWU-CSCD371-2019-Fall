using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class ArrayCollection<T> : ICollection<T> // where T: struct // class // new()
    {
        private List<T> Data { get; }
        private readonly int _Count; // preventing outside classes from modifying count
        public int Count { get => _Count; } // public facing readonly count
        public bool IsReadOnly { get; } // only allowed to read data from array
        public int Capacity { get => Data.Capacity; }

        public ArrayCollection(int capacity, bool isReadOnly = false)
        {
            _Count = 0;
            IsReadOnly = isReadOnly;
            Data = new List<T>(capacity); // need to add a buffer to prevent cap increase?
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
