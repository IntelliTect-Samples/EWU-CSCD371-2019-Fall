using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment6 {
    public class MyArray<TData> : ICollection<TData> {
        private TData[] _Storage;
        public int Capacity { get; }
        public int Count { get; set; }

        public MyArray(int capacity) {
            if (capacity <= 0) {
                throw new ArgumentOutOfRangeException("capacity");
            }
            Count = 0;
            Capacity = capacity;
            _Storage = new TData[capacity];
        }

        public bool IsReadOnly => _Storage.IsReadOnly;

        public void Add(TData item) {
            if (item is null) {
                throw new ArgumentNullException("item");
            }
            for (int i = 0; i < _Storage.Length; i++) {
                //There's an error saying _Storage[i] could be null, but so what if it is?
                //If _Storage[i] is null then it just won't be true, right??
                //Same with default being null, right??
                if (_Storage[i].Equals(default(TData))) {
                    _Storage[i] = item;
                    Count++;
                    return;
                }
            }
            throw new IndexOutOfRangeException("Array is full!");
        }

        public void Clear() {
            _Storage = new TData[Capacity];
            Count = 0;
        }

        public bool Contains(TData item) {
            if (item is null) {
                throw new ArgumentNullException("item");
            }
            return _Storage.Contains(item);
        }

        public void CopyTo(TData[] array, int arrayIndex) {
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

        public bool Remove(TData item) {
            if (item is null) {
                throw new ArgumentNullException("item");
            }
            for (int i = 0; i < _Storage.Length; i++) {
                //There's an error saying _Storage[i] could be null, but so what if it is?
                //If _Storage[i] is null then it just won't be true since I make sure item isn't null, right??
                if (_Storage[i].Equals(item)) {
                    //It says data is non-nullable, but it's definetly able to set _Storage[i] to null...
                    _Storage[i] = default;
                    Count--;
                    return true;
                }
            }
            return false;
        }

        public TData GetData(int index) {
            if (index < 0 || index >= Capacity) {
                throw new IndexOutOfRangeException("Index in GetData is out of bounds!");
            }
            if (_Storage[index] is null) {
                throw new NullReferenceException("_Storage[index] is null!");
            }
            return _Storage[index];
        }

        public IEnumerator<TData> GetEnumerator() {
            foreach (TData d in _Storage) {
                yield return d;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
