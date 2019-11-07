using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        public int Count => 0;

        public bool IsReadOnly => false;

        private ICollection<T> MyArray;

        public Array()
        {
            MyArray = new List<T>();
        }

        public void Add(T item)
        {
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
            MyArray.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            return MyArray.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
