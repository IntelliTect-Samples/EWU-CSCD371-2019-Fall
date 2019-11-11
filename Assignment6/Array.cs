using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        private int Capacity { get; set; }
        private List<T>? Items { get; set; }
        public int Count => Items is null ? throw new NullReferenceException() : Items.Count;
        public bool IsReadOnly => false;

        public Array(int capacity)
        {
            if(capacity < 1)
            {
                throw new ArgumentException("Capacity must be greater than 0", nameof(capacity));
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
            if(Items is null)
            {
                throw new NullReferenceException("Items is null");
            }
            Items.Add(item);
        }

        public void Clear()
        {
            if (Items is null)
            {
                throw new NullReferenceException("Items is null");
            }
            Items.Clear();
        }

        public bool Contains(T item)
        {
            if (Items is null)
            {
                throw new NullReferenceException("Items is null");
            }
            if (Items.Contains(item))
            {
                return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (Items is null)
            {
                throw new NullReferenceException("Items is null");
            }
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array can't be null");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentException("Index must be postive", nameof(arrayIndex));
            }
            if(Count > array.Length - arrayIndex + 1)
            {
                throw new ArgumentException("Not enough space in array", nameof(array));
            }
            Items.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            if (Items is null)
            {
                throw new NullReferenceException("Items is null");
            }
            if (item is null)
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
            if (Items is null)
            {
                throw new NullReferenceException("Items is null");
            }
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                if (Items is null)
                {
                    throw new NullReferenceException("Items is null");
                }
                return Items[index];
            }
            set
            {
                if(Items is null)
                {
                    throw new NullReferenceException("Items is null");
                }
                Items[index] = value;
            }
        }

        public T[] ToArray()
        {
            if (Items is null)
            {
                throw new NullReferenceException("Items is null");
            }
            return Items.ToArray();
        }
    }
}