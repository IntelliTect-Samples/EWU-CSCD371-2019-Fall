using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        public int Capacity => Values.Length;

        public int Count => Values.Count(element => !(element is null));

        public bool IsReadOnly => false;

        private ValueTuple<T>?[] Values { get; }

        private IEnumerable<T> Elements =>
            Values.Where(element => !(element is null))
                  .Cast<ValueTuple<T>>()
                  .Select(element => element.Item1);

        public Array(int capacity) =>
            Values = capacity >= 0 ? new ValueTuple<T>?[capacity] : throw new ArgumentException("Capacity cannot be negative.", nameof(capacity));

        public void Add(T item)
        {
            for (int i = 0; i < Values.Length; i++)
            {
                if (Values[i] is null)
                {
                    Values[i] = new ValueTuple<T>(item);
                    return;
                }
            }

            throw new InvalidOperationException("Array capacity exceeded.");
        }

        public void Clear()
        {
            for (int i = 0; i < Values.Length; i++)
            {
                Values[i] = null;
            }
        }

        public bool Contains(T item) =>
            Elements.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0) throw new IndexOutOfRangeException();
            if (array.Length - arrayIndex < Count) throw new ArgumentException("Not enough space in array for collection.");

            foreach (var element in Elements) array[arrayIndex++] = element;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Values.Length; i++)
            {
                if (Values[i] is ValueTuple<T> element &&
                    (element.Item1, item) switch {
                        (null, null) => true,
                        (null, _) => false,
                        (_, null) => false,
                        (T t1, T t2) => t1.Equals(t2)
                })
                {
                    Values[i] = null;
                    return true;
                }
            }

            return false;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1065:Do not raise exceptions in unexpected locations", Justification = "Index-related exceptions make sense in an indexing operation.")]
        public T this[int index]
        {
            get => index switch
            {
                int ix when ix < 0 || ix >= Capacity => throw new IndexOutOfRangeException(),
                int ix => Values[ix] switch
                {
                    null => throw new InvalidOperationException("Element does not exist."),
                    ValueTuple<T> element => element.Item1
                }
            };

            set => Values[index] = index switch
            {
                int ix when ix < 0 || ix >= Capacity => throw new IndexOutOfRangeException(),
                _ => new ValueTuple<T>(value)
            };
        }

        public IEnumerator<T> GetEnumerator() =>
            Elements.GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() =>
            GetEnumerator();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Assignment specifies cast operator.")]
        public static explicit operator List<T>(Array<T> array) =>
            new List<T>(array);
    }
}
