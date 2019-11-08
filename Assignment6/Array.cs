using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6 {
    public class Array<T> : ICollection<T> {
        private ICollection<T> _Storage;
        public int Capacity { get; set; }

        public Array(int capacity) {
            Capacity = capacity;
            _Storage = new T[capacity];
        }

        public int Count => _Storage.Count;

        public bool IsReadOnly => _Storage.IsReadOnly;

        public void Add(T item) {
            if (item is null) {
                return;
            }

        }

        public void Clear() {
            _Storage = new T[Capacity];
        }

        public bool Contains(T item) {
            if (item is null) {
                return false;
            }
            foreach (T stored in _Storage) {
                if (item.Equals(stored)) {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex) {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator() {
            throw new NotImplementedException();
        }

        public bool Remove(T item) {
            if (item is null) {
                return false;
            }
            foreach (T stored in _Storage) {
                if (item.Equals(stored)) {
                    //somehow need to remove item here....
                    return true;
                }
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }
    }
}
