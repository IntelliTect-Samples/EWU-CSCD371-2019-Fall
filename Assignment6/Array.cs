using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        public int Capacity { get; }

        public int Count => InternalCollection.Count;

        public bool IsReadOnly => false;
        
        private Dictionary<int, T> InternalCollection { get; }

        public Array(int capacity)
        {
            Capacity = (capacity > 0) ? capacity : throw new ArgumentOutOfRangeException(nameof(capacity));
            InternalCollection = new Dictionary<int, T>();
        }

        public T this[int index]
        {
            get
            {
                if (!IndexInRange(index)) throw new ArgumentOutOfRangeException(nameof(index));

                InternalCollection.TryGetValue(index, out T value);

                return value;
            }

            set
            {
                if (!IndexInRange(index)) throw new ArgumentOutOfRangeException(nameof(index));

                if (value is null) throw new ArgumentNullException(nameof(value));

                if (InternalCollection.ContainsKey(index))
                {
                    InternalCollection[index] = value;
                }
                else
                {
                    InternalCollection.Add(index, value);
                }
            }
        }

        private bool IndexInRange(int index)
        {
            if (index < 0 || index >= Capacity)
            {
                return false;
            }

            return true;
        }

        public void Add(T item)
        {
            if (Count >= Capacity) throw new InvalidOperationException("Capacity reached");

            if (item is null) throw new ArgumentNullException(nameof(item));

            for (int i = 0; i < Capacity; i++)
            {
                if (!InternalCollection.ContainsKey(i))
                {
                    InternalCollection.Add(i, item);
                    return;
                }
            }
        }

        public void Clear() => InternalCollection.Clear();

        public bool Contains(T item) => InternalCollection.ContainsValue(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));

            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            if (Count > (array.Length - arrayIndex)) throw new ArgumentException("Not enough space in target array");

            for (int i = 0; i < Capacity; i++)
            {
                if (InternalCollection.ContainsKey(i))
                {
                    array[arrayIndex] = InternalCollection[i];
                    arrayIndex++;
                }
            }
        }

        public bool Remove(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            foreach (KeyValuePair<int, T> kvp in InternalCollection)
            {
                if (item.Equals(kvp.Value))
                {
                    return InternalCollection.Remove(kvp.Key);
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator() => InternalCollection.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
