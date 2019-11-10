using System;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS8653
#pragma warning disable CS8602
#pragma warning disable CA2208
#pragma warning disable CA1303

namespace Assignment6
{
    public class ArrayCollection<T> : ICollection<T>
    {
        public int Count => _Data.Count;
        public bool IsReadOnly => false;
        public int Capacity { get; } 
        private readonly List<T> _Data;
        public ArrayCollection(int cap)
        {
            if(cap < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cap));
            }
            Capacity = cap;
            _Data = new List<T>(cap);
        }

        public ArrayCollection(ICollection<T> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException("Collection is null", nameof(collection));
            }
            _Data = new List<T>(collection.Count);
            Capacity = collection.Count;
            foreach(T item in collection)
            {
                _Data.Add(item);
            }
        }

        public void Add(T item)
        {
            if(Capacity == Count)
            {
                throw new ArgumentException("Array at max capacity.", nameof(item));
            }
            _Data.Add(item);
        }

        public void Clear()
        {
            _Data.Clear();
        }

        public bool Contains(T item)
        {
            return _Data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if(arrayIndex < 0 || arrayIndex > Capacity)
            {
                throw new ArgumentOutOfRangeException("Index is out of bounds of this array.", nameof(arrayIndex));
            }
            _Data.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _Data.GetEnumerator();
        }

        public bool Remove(T item)
        {
            return _Data.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Data.GetEnumerator();
        }

        public T this[int index]
        {
            get { return _Data[index]; }
            set { _Data[index] = value; }
        }


    }
}
