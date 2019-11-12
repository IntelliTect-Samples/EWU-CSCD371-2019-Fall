using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
#pragma warning disable CA1710 // This was the name given in the assignment

    public class Array<T> : ICollection<T>
#pragma warning restore CA1710
    {
        private int Capacity { get; }

        public int Count { get; private set; }

        private List<T> Collection { get; } //I used a list under the hood, so I do not have to worry about null f or missing items

        public bool IsReadOnly { get; private set; }

        public Array(int capacity)
        {
            Count = 0;
            Capacity = capacity;
            Collection = new List<T>(capacity);
            IsReadOnly = false;
        }

        public void Add(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (Count == Capacity)
                throw new InvalidOperationException($"Array is at maximum capacity {nameof(item)}");
            Collection.Add(item);
            Count++;
        }

        public void Clear()
        {
            Collection.Clear();
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (Collection.Contains(item))
                return true;
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Collection.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (!Collection.Contains(item))
                throw new ArgumentException($"{nameof(item)} does not exist");
            bool result = Collection.Remove(item);
            Count--;
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException(nameof(index));
        }

        public T this[int i]
        {
            get
            {
                ValidateIndex(i);
                return Collection[i];
            }
            set
            {
                ValidateIndex(i);
                Collection[i] = value;
            }
        }
    }
}