using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        private int _size = 0;

        public int Count => _Collection.Count;

        public bool IsReadOnly => _Collection.IsReadOnly;

        private ICollection<T> _Collection;

        public Array()
        {
            _Collection = new List<T>();
        }

        public Array(int size)
        {
            _Collection = size > 0 ? new List<T>(size) : throw new ArgumentOutOfRangeException($"{nameof(size)} must be greater than zero.");
            _size = size;
        }

        public T this[int index]
        {

            get
            {
                ValidateIndexIsInRange(index);
                return _Collection.AsEnumerable().ElementAt(index);
            }
            set
            {
                ValidateIndexIsInRange(index);
                ((List<T>)_Collection)[index] = value;
            }
        }

        public void Add(T item)
        {
            if (this._size == _Collection.Count)
                throw new InvalidOperationException($"cannot add {nameof(item)}");
            _Collection.Add(item);
        }

        public void Clear()
        {
            _Collection.Clear();
        }

        public bool Contains(T item) => _Collection.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => _Collection.CopyTo(array, arrayIndex);
        
        public IEnumerator<T> GetEnumerator() => _Collection.GetEnumerator();

        public bool Remove(T item) => _Collection.Remove(item);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void ValidateIndexIsInRange(int index)
        {
            if (index > _Collection.Count || index < 0)
                throw new IndexOutOfRangeException($"{nameof(index)} is out of range");
        }
    }
}
