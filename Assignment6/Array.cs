using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Assignment6
{

    public class ArrayCollection<T> : ICollection<T>
    {

        // ReSharper disable once InconsistentNaming
        private T[] _Array;

        public int  Capacity   { get; }
        public bool IsReadOnly { get; }
        public int  Count      { get; private set; }

        public ArrayCollection(int capacity, bool isReadOnly = false)
        {
            if (capacity <= 0) throw new ArgumentException("must be > 0", nameof(capacity));

            _Array     = new T[capacity];
            Capacity   = capacity;
            IsReadOnly = isReadOnly;
        }

        public T this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _Array.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private T Get(int index)
        {
            if (index >= Capacity || index < 0) throw new IndexOutOfRangeException();

            var item = _Array[index];
            if (item is null) throw new ArgumentException("No item at given index", nameof(index));
            return item;
        }

        public void Add(T item)
        {
            if (Count == Capacity) throw new Exception("Array is full");

            var index = 0;
            while (_Array[index] != null)
            {
                index++;
            }

            Set(index, item);
        }

        private void Set(int index, T item)
        {
            if (index >= Capacity || index < 0) throw new IndexOutOfRangeException();
            if (item is null) throw new ArgumentNullException(nameof(index));
            if (IsReadOnly) throw new ReadOnlyException("Array is marked as Read Only");

            _Array[index] = item;
            Count++;
        }

        public void Clear()
        {
            _Array = new T[Capacity];
            Count  = 0;
        }

        public bool Contains(T item)
        {
            return _Array.Contains(item);
        }

        public void CopyTo(T[] array, int index)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (index >= Capacity || index < 0) throw new ArgumentOutOfRangeException(nameof(index));
            if (Count > array.Length)
                throw new ArgumentException("Current array contains more items than passed array can hold.",
                                            nameof(array));
            for (var x = 0; x < Capacity; x++)
            {
                if (_Array[x] != null) array[x + index] = _Array[x];
            }
        }

        public bool Remove(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            for (var x = 0; x < Capacity; x++)
            {
                if (!_Array[x]!.Equals(item)) continue;
                _Array[x] = default;
                Count--;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return _Array.ToString();
        }

    }

}
