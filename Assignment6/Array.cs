using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment6
{
    public class Array<T> : ICollection<T>, IReadOnlyArray<T>
    {
        public int Capacity { get; }

        private List<T> _Value;

        public Array(int capacity)
        {
            Capacity = capacity;
            _Value = Capacity > 0 ? new List<T>(capacity) : throw new ArgumentOutOfRangeException(nameof(capacity));
        }

        public int Count => _Value.Count;

        public bool IsReadOnly => false;

        private List<T> ValueCast => _Value.Cast<T>().ToList();

        public void Add(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            if (Count >= Capacity)
                throw new ArgumentOutOfRangeException(nameof(item), "Array capacity reached");

            _Value.Add(item);
        }

        public void Clear()
        {
            _Value.Clear();
        }

        public bool Contains(T item)
        {
            return ValueCast.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            if (arrayIndex > Capacity || arrayIndex < 0 || arrayIndex > array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            _Value.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _Value.Remove(item);
        }

        public IEnumerator GetEnumerator() => ValueCast.GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => (IEnumerator<T>)GetEnumerator();

        public T this[int key]
        {
            get
            {
                if (key >= Capacity || key < 0)
                    throw new ArgumentOutOfRangeException(nameof(key));
                return _Value[key];
            }
            set
            {
                if (key >= Capacity || key < 0)
                    throw new ArgumentOutOfRangeException(nameof(key));
                var data = _Value.ToList();
                data[key] = value;
                _Value = data;
            }
        }
    }
}
