using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        private int Capacity { get; set; }
        private List<T> Items { get; set; }
        public int Count => Items.Count;
        public bool IsReadOnly => false;

        public Array(int capacity)
        {
            if(capacity < 0)
            {
                throw new ArgumentException("Capacity must be positive.", nameof(capacity));
            }
            else
            {
                Capacity = capacity;
                Items = new List<T>(capacity); 
            }
        }

        public void Add(T item)
        {
            if(Capacity == Count)
            {
                throw new InvalidOperationException("Array is a at max capacity.");
            }
            Items.Add(item);
        }

        public void Clear()
        {
            Items.Clear();
        }

        public bool Contains(T item)
        {
            if (Items.Contains(item))
            {
                return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if(array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array can't be null");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentException("Index must be postive", nameof(arrayIndex));
            }
            for (int i = 0; i < Items.Count; i++)
            {
                array[i + arrayIndex] = Items[i];
            }
        }

        public bool Remove(T item)
        {
            if(item is null)
            {
                throw new ArgumentNullException(nameof(item), "Item can't be null");
            }
            if (Items.Remove(item))
            {
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}