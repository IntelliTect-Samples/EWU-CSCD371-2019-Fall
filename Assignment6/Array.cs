using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        public int Count => MyArray.Count;
        public int Capacity { get; }
        public bool IsReadOnly => false;

        private ICollection<T> MyArray { get; set; }

        public Array(int width)
        {
            if(width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), "The width cannot be less than 0");
            }

            Capacity = width;
            MyArray = new List<T>(width);
        }

        public void Add(T item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item), "The item cannot be null");
            }

            if(Count == Capacity)
            {
                throw new ArgumentException(nameof(item), "Array is at full capacity");
            }

            MyArray.Add(item);
        }

        public void Clear()
        {
            MyArray.Clear();
        }

        public bool Contains(T item)
        {
            return MyArray.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if(array is null)
            {
                throw new ArgumentNullException(nameof(array), "The array cannot be null");
            }

            if(arrayIndex < 0 || arrayIndex > Capacity)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "The arrayIndex is out of bounds");
            }

            MyArray.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return MyArray.GetEnumerator();
        }

        public bool Remove(T item)
        {
            return MyArray.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return MyArray.GetEnumerator();
        }
    }
}
