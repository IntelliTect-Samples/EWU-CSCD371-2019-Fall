using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        private int Width { get; }

        private int Capacity { get; }

        public int Count { get; private set; }

        private List<T> _Collection; //I used a list under the hood, so I do not have to worry about null f or missing items

        public bool IsReadOnly { get; private set; }

        public Array(int width)
        {
            Width = width;
            Count = 0;
            Capacity = width;
            _Collection = new List<T>(width);
            IsReadOnly = false;
        }

        public void Add(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (Count == Capacity)
                throw new InvalidOperationException($"Array is at maximum capacity {nameof(item)}");
            _Collection.Add(item);
            Count++;
        }

        public void Clear()
        {
            _Collection.Clear();
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (_Collection.Contains(item))
                return true;
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _Collection.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (!_Collection.Contains(item))
                throw new ArgumentException($"{nameof(item)} does not exist");
            bool result = _Collection.Remove(item);
            Count--;
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _Collection.GetEnumerator();
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
                return _Collection[i];
            }
            set
            {
                ValidateIndex(i);
                _Collection[i] = value;
            }
        }
    }
}