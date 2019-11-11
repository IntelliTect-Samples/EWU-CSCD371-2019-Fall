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
        public int Capacity { get; }
        public bool IsReadOnly { get => false; } // readonly not implemented in this class (yet?)

        public ArrayCollection(int capacity)
        {
            if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));

            Capacity = capacity;
            Data = new T[Capacity];
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
            if (_Count >= Capacity) throw new InvalidOperationException(message: "Array is full.");

            Data[_Count++] = item;
        }

        public bool Remove(T item)
        {
            if (_Count == 0) return false;

            for (int i = 0; i < _Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(Data[i], item))
                {
                    Array.Copy(Data, i + 1, Data, i, _Count - i - 1); // shift elements to fill hole
                    _Count--;
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            // allowing possible null valuetypes, they cannot be accessed externally
            Array.Fill<T>(Data, default!);

            _Count = 0;
        }

        public bool Contains(T item)
        {
            return Array.Exists<T>(Data, element => EqualityComparer<T>.Default.Equals(element, item));
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex >= _Count) throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            if (array is null) throw new ArgumentNullException(nameof(array));

            Array.Copy(Data, arrayIndex, array, arrayIndex, _Count - arrayIndex);
        }

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)Data).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Data.GetEnumerator();
    }
}
