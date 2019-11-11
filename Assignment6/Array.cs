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

        internal T Get(int index)
        {
            if(index < 0 || index > Capacity - 1) { throw new ArgumentOutOfRangeException(nameof(index)); }

            return _InternalArray[index];
        }

        //TODO index operator
        public T this[int i]
        {
            get { return Get(i); }

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

        public ArrayEnumerator(Array<T> array)
        {
            _Array = array;
            Cur = array.Get(0);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
