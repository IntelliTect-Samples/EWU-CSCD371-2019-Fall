using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
#pragma warning disable CA1710 // Identifiers should have correct suffix
        public sealed class Array<T> : ICollection<T>
#pragma warning restore CA1710 // Identifiers should have correct suffix
        {
            public List<T> Items { get; }

            public int Capacity { get; }

            public int Count => Items.Count;

            public bool IsReadOnly { get; set; }

            public Array(int capacity)
            {
                Items = new List<T>(capacity);
                IsReadOnly = false;
                Capacity = capacity;
            }

            public Array(List<T> items)
            {
                if (items is null)
                {
                    throw new ArgumentNullException(nameof(items));
                }
                Items = items;
                IsReadOnly = false;
                Capacity = items.Capacity;
            }



            public void Clear() => Items.Clear();

            public bool Contains(T item) => Items.Contains(item);

            public void CopyTo(T[] array, int arrayIndex) => Items.CopyTo(array, arrayIndex);

            public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();


            //Not a feature of normal arrays, but needed to implement for collection initializer
            public void Add(T item)
            {
                if (item is null)
                {
                    throw new ArgumentNullException(nameof(item));
                }
                if (Count == Capacity)
                {
                    throw new InvalidOperationException("Array is already full");
                }
                Items.Add(item);
            }


        //Not a feature of normal arrays. Decided explicit implementation of interface
        bool ICollection<T>.Remove(T item)
            {
                if (item is null)
                {
                    throw new ArgumentNullException(nameof(item));
                }
                if (!Items.Contains(item))
                {
                    throw new ArgumentException("Item does not exist in the array.", nameof(item));
                }
                return Items.Remove(item);
            }

            IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();

            public T this[int i]
            {
                get
                {
                    return Items[i];
                }
                set
                {
                    Items[i] = value;
                }
            }


        }
  

}
