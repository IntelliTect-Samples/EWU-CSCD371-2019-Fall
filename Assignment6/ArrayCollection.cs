using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    /*
     * I'm going to assume that inheriting from List<T> and using base class functionality to
     * handle/bypass most of the assignment requirements isn't in the spirit of the assignment.
     */

    // fixed-length generic array
    public class ArrayCollection<T> : ICollection<T>
    {
        private T[] Data { get; }
        private int _Count;
        public int Count { get => _Count; }
        private readonly int _Capacity;
        public int Capacity { get => _Capacity; }
        public bool IsReadOnly { get => false; } // readonly not implemented in this class (yet?)

        public ArrayCollection(int capacity)
        {
            if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));

            _Capacity = capacity;
            Data = new T[_Capacity];
        }

        // only allows indexing operations on existing elements, and assignment on next empty index
#pragma warning disable CA1065 // It's expected that an indexing operation will throw on invalid index
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _Count) throw new IndexOutOfRangeException();

                return Data[index];
            }
            set
            {
                if (index < 0 || index > _Count ) throw new IndexOutOfRangeException();

                
                if (index == _Count) // allowing insertion into next empty position
                {
                    Add(value); // let add function handle the logic of insertion
                }
                else
                {
                    Data[index] = value;
                }
            }
        }
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations

        public void Add(T item)
        {
            if (_Count >= _Capacity) throw new InvalidOperationException(message: "Array is full.");

            Data[_Count++] = item;
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            //allowing possible null valuetypes, they cannot be accessed externally
            for (int i = 0; i < _Count; Data[i++] = default!) ;

            _Count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _Count; i++)
            {
                if (Data[i]?.Equals(item) ?? false) return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
