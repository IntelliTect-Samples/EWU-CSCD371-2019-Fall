﻿using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        private ICollection<T> Data;
        public readonly int Capacity = 0;

        public Array()
        {
            Data = new List<T>();
        }

        public Array(int size)
        {
            if (size < 0)
                throw new System.ArgumentOutOfRangeException(nameof(size));
            Data = new List<T>(size);
            Capacity = size;
        }

        public Array(ICollection<T> collection) =>
            Data = collection;

        /*
         * Note:
         * Will lose data if resized to a smaller length and
         * data is already set at end of array.
         */
        public void Resize(int length)
        {
            if (length < 0)
                throw new System.ArgumentOutOfRangeException(nameof(length));
            var tmp = new T[length];
            var _Data = Data.ToList();
            for (int i = 0; i < length; i++)
                tmp[i] = _Data[i];
            Data = tmp as ICollection<T>;
        }

        public List<T> ToList() =>
            new List<T>(Data);

        public T this[int key]
        {
            get
            {
                if (key >= Capacity || key < 0)
                    throw new System.InvalidOperationException(nameof(key));
                if (Data.AsEnumerable().ElementAt(key) is T data)
                    return data;
                else
                    throw new System.InvalidOperationException(nameof(key));
            }
            set
            {
                if (key >= Capacity || key < 0)
                    throw new System.InvalidOperationException(nameof(key));
                var _Data = Data.ToList();
                _Data[key] = value;
                Data = (ICollection<T>)_Data;
            }
        }

        public int Count
        {
            get
            {
                return Capacity;
            }
        }

        public void Clear() =>
            ((ICollection<T>)Data).Clear();

        public bool Remove(T item) =>
            ((ICollection<T>)Data).Remove(item);

        public bool Contains(T item) =>
            ((ICollection<T>)Data).Contains(item);

        public void CopyTo(T[] data, int index) =>
            ((ICollection<T>)Data).CopyTo(data, index);

        public void Add(T value)
        {
            if (value is null) 
                throw new System.ArgumentNullException(nameof(value));
            else if (Data.Count == Capacity)
                throw new System.InvalidOperationException(nameof(value));
            ((ICollection<T>)Data).Add(value);
        }

        public bool IsReadOnly => Data.IsReadOnly;

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in Data)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();
    }
}
