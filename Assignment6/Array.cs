using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        private T[] _InternalArray;

        public int Count { get; }
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
            throw new NotImplementedException();
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
            if (index < 0 || index > Capacity - 1) { throw new ArgumentOutOfRangeException(nameof(index)); }

            _InternalArray[index] = value;
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
        private int _CurIndex;

        public ArrayEnumerator(Array<T> array)
        {
            _Array = array;
            Cur = array.GetValue(0);
            _CurIndex = 0;
        }

        public void Dispose()
        {
            //nothing needs to be disposed
        }

        public bool MoveNext()
        {
            if(++_CurIndex >= _Array.Count)
            {
                return false;
            }
            else
            {
                Cur = _Array[_CurIndex];
                return true;
            }
        }

        public void Reset()
        {
            Cur = _Array.GetValue(0);
            _CurIndex = 0;
        }
    }
}
