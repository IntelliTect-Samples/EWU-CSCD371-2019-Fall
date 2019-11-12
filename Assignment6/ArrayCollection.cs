using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class ArrayCollection<T> : ICollection<T>
    {
        public int Capacity { get; }
        public int Index { get; set; }
        private ICollection<T> Collection { get; set; }
        public ArrayCollection(int capacity)
        {
            if (!(capacity > 0)) {
                throw new IndexOutOfRangeException("Width must be greater than 0");
            }
            Capacity = capacity;
            Index = 0;
            Collection = new List<T>(Capacity);
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
                Collection.Add(item);
                Index++;
            }
        }

        public void Clear()
        {
            Collection.Clear();
            Index = 0;
        }

        public bool Contains(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Passed in item is null");
            }

            return Collection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array is null");
            }

            if (arrayIndex < 0 || arrayIndex > Capacity || array.Length < Capacity)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }

            Collection.CopyTo(array, arrayIndex);
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

            if (!Contains(item))
            {
                return false;
            }

            Collection.Remove(item);

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(T item in Collection)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Collection.GetEnumerator();
        }
    }
}
