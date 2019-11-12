using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        private ICollection<T> _Data;
        public int Capacity { get; }  = 0;

        public Array()
        {
            _Data = new List<T>();
        }

        public Array(int capacity)
        {
            if (capacity < 0)
                throw new System.ArgumentOutOfRangeException(nameof(capacity));
            _Data = new List<T>(capacity);
            Capacity = capacity;
        }

        public Array(ICollection<T> collection)
        {
            _Data = new List<T>(collection);
            Capacity = collection.Count;
        }

        public Array(ICollection<T> collection, int capacity)
        {
            if (capacity < 0)
                throw new System.ArgumentOutOfRangeException(nameof(capacity));
            if (collection is null || !collection.Any())
                throw new System.ArgumentNullException(nameof(collection));
            _Data = collection;
            Capacity = capacity;
        }

        /*
         * Note:
         * Will lose data if resized to a smaller length and
         * data is already set at end of array.
         */
        public void Resize(int length)
        {
            if (length < 0)
                throw new System.ArgumentOutOfRangeException(nameof(length));
            var tmp = new T[length];
            var __Data = _Data.ToList();
            for (int i = 0; i < length; i++)
                tmp[i] = __Data[i];
            _Data = tmp as ICollection<T>;
        }

        public List<T> ToList() =>
            new List<T>(_Data);

        public T this[int key]
        {
            get
            {
                if (key >= Capacity || key < 0)
                    throw new System.InvalidOperationException(nameof(key));
                if (_Data.AsEnumerable().ElementAt(key) is T data)
                    return data;
                else
                    throw new System.InvalidOperationException(nameof(key));
            }
            set
            {
                if (key >= Capacity || key < 0)
                    throw new System.InvalidOperationException(nameof(key));
                var __Data = _Data.ToList();
                __Data[key] = value;
                _Data = (ICollection<T>)__Data;
            }
        }

        public int Count
        {
            get
            {
                return _Data.Count;
            }
        }


        public void Clear() => _Data.Clear();

        public bool Remove(T item)
        {
            if (item is null)
                throw new System.ArgumentNullException(nameof(item));
            return ((ICollection<T>)_Data).Remove(item);
        }

        public bool Contains(T item)
        {
            if (item is null)
                throw new System.ArgumentNullException(nameof(item));
            return _Data.Contains(item);
        }

        public void CopyTo(T[] data, int index) =>
            ((ICollection<T>)_Data).CopyTo(data, index);

        public void Add(T value)
        {
            if (value is null) 
                throw new System.ArgumentNullException(nameof(value));
            else if (_Data.Count == Capacity)
                throw new System.InvalidOperationException(nameof(value));
            ((ICollection<T>)_Data).Add(value);
        }

        public bool IsReadOnly => _Data.IsReadOnly;

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in _Data)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();
    }
}
