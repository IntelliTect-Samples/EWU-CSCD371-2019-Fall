using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment6 {
    public class MyArray<Data> : ICollection<Data> {
        private Data[] _Storage;
        public int Capacity { get; set; }

        public MyArray(int capacity) {
            if (capacity <= 0) {
                throw new ArgumentOutOfRangeException("capacity");
            }
            Capacity = capacity;
            _Storage = new Data[capacity];
        }

        public bool IsReadOnly => _Storage.IsReadOnly;

        public int Count => Capacity;

        public void Add(Data item) {
            if (item is null) {
                throw new ArgumentNullException("item");
            }

            for (int i = 0; i < _Storage.Length; i++) {
                if (_Storage[i].Equals(default(Data))) {
                    _Storage[i] = item;
                    return;
                }
            }
            throw new IndexOutOfRangeException("Array is full!");
        }

        public void Clear() {
            _Storage = new Data[Capacity];
        }

        public bool Contains(Data item) {
            if (item is null) {
                throw new ArgumentNullException("item");
            }
            return _Storage.Contains(item);
        }

        public void CopyTo(Data[] array, int arrayIndex) {
            if (arrayIndex < 0 || arrayIndex >= _Storage.Length) {
                throw new IndexOutOfRangeException("Index passed into CoptTo is out of range!");
            }
            if (array is null) {
                throw new NullReferenceException("Array passed into CopyTo is null!");
            }
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

        public Data GetData(int index) {
            if (index < 0 || index >= Capacity) {
                throw new IndexOutOfRangeException("Index in GetData is out of bounds!");
            }
            if (_Storage[index] is null) {
                throw new NullReferenceException("_Storage[index] is null!");
            }
            return _Storage[index];
        }

        public IEnumerator<Data> GetEnumerator() {
            foreach (Data d in _Storage) {
                yield return d;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
