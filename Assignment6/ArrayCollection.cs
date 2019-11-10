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
        private readonly List<T> _Data;
        private int _Count;
        public int Count { get => _Count; }
        public int Capacity { get => _Data.Capacity; }
        public bool IsReadOnly { get => false; } // readonly not implemented in this class (yet?)

        public ArrayCollection(int capacity)
        {
#warning do arg checks
            _Count = 0;
            _Data = new List<T>(capacity);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1065:Do not raise exceptions in unexpected locations", Justification = "just non-implementation while WIP")]
        public T this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
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
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
