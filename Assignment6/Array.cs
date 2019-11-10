using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment6 {
    public class Array<Data> : ICollection<Data> {
        private Data[] _Storage;
        public int Capacity { get; set; }

        public Array(int capacity) {
            if (capacity <= 0) {
                throw new ArgumentOutOfRangeException("capacity");
            }
            Capacity = capacity;
            _Storage = new Data[capacity];
        }

        public int Count => _Storage.Length;

        public bool IsReadOnly => _Storage.IsReadOnly;

        public void Add(Data item) {
            if (item is null) {
                throw new ArgumentNullException("item");
            }
            for (int i = 0; i < _Storage.Length; i++) {
                if (_Storage[i].Equals(default(Data))) {
                    _Storage[i] = item;
                }
            }
        }

        public void Clear() {
            _Storage = new Data[Capacity];
        }

        public bool Contains(Data item) {
            // already throws ArgumentNullException
            return _Storage.Contains(item);
        }

        public void CopyTo(Data[] array, int arrayIndex) {
            if (arrayIndex < 0 || arrayIndex >= _Storage.Length) {
                throw new IndexOutOfRangeException("Index passed into CoptTo is out of range!");
            }
            if (array is null) {
                throw new NullReferenceException("Array passed into CopyTo is null!");
            }
            array = new Data[_Storage.Length - arrayIndex];
            for (int i = arrayIndex, j = 0; i < _Storage.Length; i++, j++) {
                array[j] = _Storage[i];
            }
        }

        public bool Remove(Data item) {
            if (item is null) {
                throw new ArgumentNullException("item");
            }
            for (int i = 0; i < _Storage.Length; i++) {
                if (_Storage[i].Equals(item)) {
                    _Storage[i] = default;
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<Data> GetEnumerator() => (IEnumerator<Data>) _Storage.AsEnumerable();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
