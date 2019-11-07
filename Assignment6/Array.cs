using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        public int Capacity { get; }
        public int Index { get; set; }
        private T[] Collection { get; set; }
        public Array(int capacity)
        {
            if (!(capacity > 0)) {
                throw new IndexOutOfRangeException("Width must be greater than 0");
            }
            Capacity = capacity;
            Index = 0;
            Collection = new T[capacity];
        }

        public int Count => Index;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Passed in item is null");
            }
            if (!(Count == Capacity))
            {
                Collection[Index] = item;
                Index++;
            }
        }

        public void Clear()
        {   if (Index != 0)
            {
                for (int ix = Index; ix >= 0; ix--)
                {
                    Collection[Index] = default;
                }
            }
        }

        public bool Contains(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Passed in item is null");
            }

            if (Index == 0)
            {
                return false;
            }

            foreach (T collectionItem in Collection)
            {
                if (collectionItem.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array is null");
            }

            if (arrayIndex < 0 || arrayIndex > Capacity)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }

            array[arrayIndex] = Collection[arrayIndex];
        }

        public bool Remove(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Item is null");
            }

            if (Index == 0)
            {
                return false;
            }

            for (int ix = 0; ix < Index; ix++)
            {
                if (Collection[ix].Equals(item))
                {
                    Collection[ix] = default;
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
