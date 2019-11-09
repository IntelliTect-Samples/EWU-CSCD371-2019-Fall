using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        private int Capacity { get; set; }
        private List<T>? Items { get; set; }
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
            if (Items is null)
                return;

            Items.Add(item);
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

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            if(Items is null)
            {
                throw new ArgumentNullException("Items is null", nameof(Items));
            }
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}