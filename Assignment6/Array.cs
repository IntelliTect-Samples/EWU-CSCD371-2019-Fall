using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        private T[] _InternalArray;

        public int Count { get; private set; }
        public int Capacity { get; }
        public bool IsReadOnly { get; }

        public Array(int capacity)
        {
            if(capacity < 1) { throw new ArgumentOutOfRangeException(nameof(capacity)); }

            Capacity = capacity;
            Count = 0;
            IsReadOnly = false;

            _InternalArray = new T[Capacity];
        }

        public void Add(T item)
        {
            if (item is null) { throw new ArgumentNullException(nameof(item)); }

            int openIndex = 0;
            while (_InternalArray[openIndex] is T)
            {
                if (openIndex > Capacity - 1)
                {
                    throw new ArgumentException("No Room For Item.", nameof(item));
                }
                else
                {
                    openIndex++;
                }
            }

            _InternalArray[openIndex] = item;
            Count++;
        }

        public void Clear()
        {
            _InternalArray = new T[Capacity];
            Count = 0;
        }

        public bool Contains(T item)
        {
            foreach (T t in this)
            {
                if (t!.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null) { throw new ArgumentNullException(nameof(array)); }
            if (arrayIndex < 0 || arrayIndex > Count - 1) { throw new ArgumentOutOfRangeException(nameof(arrayIndex)); }
            if (array.Length < Count) { throw new ArgumentException("Passed in array is too small.", nameof(array)); }

            for (int i = 0; i < Count + arrayIndex; i++)
            {
                array[i] = GetValue(i + arrayIndex);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ArrayEnumerator<T>(this);
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        internal T GetValue(int index)
        {
            if (index < 0 || index > Capacity - 1) { throw new ArgumentOutOfRangeException(nameof(index)); }

            T temp = _InternalArray[index];

            if (temp is null)
            {
                throw new ArgumentException("Value Doesn't Exist.", nameof(index));
            }
            else
            {
                return temp;
            }
        }

        internal void SetValue(int index, T value)
        {
            if (value is null) { throw new ArgumentNullException(nameof(value)); }
            if (index < 0 || index > Capacity - 1) { throw new ArgumentOutOfRangeException(nameof(index)); }

            _InternalArray[index] = value;
            Count++;
        }

        public T this[int i]
        {
            get => GetValue(i);
            set => SetValue(i, value);
        }
    }

    internal class ArrayEnumerator<T> : IEnumerator<T>
    {
        private Array<T> _Array;
        private T Cur { get; set; }
        public T Current
        {
            get { return Cur; }
        }
        object? IEnumerator.Current
        {
            get { return Current; }
        }
        private int CurIndex { get; set; }

        public ArrayEnumerator(Array<T> array)
        {
            _Array = array;
            Cur = default!;
            CurIndex = -1;
        }

        public void Dispose()
        {
            //nothing needs to be disposed
        }

        public bool MoveNext()
        {
            if(++CurIndex >= _Array.Count)
            {
                return false;
            }
            else
            {
                Cur = _Array[CurIndex];
                return true;
            }
        }

        public void Reset()
        {
            Cur = default!;
            CurIndex = -1;
        }
    }
}
