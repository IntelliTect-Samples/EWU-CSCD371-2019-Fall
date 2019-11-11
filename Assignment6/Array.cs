using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        public int Count => _collection.Count;

        public bool IsReadOnly => _collection.IsReadOnly;

        private ICollection<T> _collection;

        public Array()
        {
            _collection = new List<T>();
        }

        public Array(int size)
        {
            _collection = size < 0 ? new List<T>(size) : throw new ArgumentOutOfRangeException($"{nameof(size)} must be greater than zero.");
        }

        public T this[int index]
        {

            get
            {
                ValidateIndexIsInRange(index);
                return _collection.AsEnumerable().ElementAt(index);
            }
            set
            {
                ValidateIndexIsInRange(index);
                var temp = _collection.ToList();
                temp[index] = value;
                _collection = temp;
            }
        }

        public void Add(T item)
        {
            _collection.Add(item);
        }

        public void Clear()
        {
            _collection.Clear();
        }

        public bool Contains(T item) => _collection.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => _collection.CopyTo(array, arrayIndex);
        

        public IEnumerator<T> GetEnumerator() => _collection.GetEnumerator();

        public bool Remove(T item) => _collection.Remove(item);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void ValidateIndexIsInRange(int index)
        {
            if (index > _collection.Count || index < 0)
                throw new IndexOutOfRangeException($"{nameof(index)} is out of range");
        }
    }
}
