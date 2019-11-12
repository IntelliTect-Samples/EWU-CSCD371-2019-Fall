using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
#pragma warning disable CA1710 // Identifiers should have correct suffix. File name and class name should match, so I left it as it was.
    public class Array<T> : ICollection<T>
#pragma warning restore CA1710 // Identifiers should have correct suffix
    {
        private List<T> Items { get; }
        public int Capacity { get; }

        public int Count => Items.Count;

        public bool IsReadOnly => false;

        public Array(int length)
        {
            if (length <= 0)
#pragma warning disable CA1303 // Do not pass literals as localized parameters. All examples in class and other people's assignment's use literals, so I figured I should disable this.
                throw new ArgumentOutOfRangeException(nameof(length), "Cannot have an Array length less than 1.");

            Capacity = length;
            Items = new List<T>(Capacity);
        }

        public void Add(T item)
        {
            if (Items.Count >= Capacity)
                throw new ArgumentOutOfRangeException(nameof(item), "Array is at max length.");

            else if (item is null)
                throw new ArgumentNullException(nameof(item), "The passed in Item is null.");

            Items.Add(item);
        }

        public bool Remove(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item), "The item to be removed is null.");

            else if (!Items.Contains(item))
                throw new ArgumentException("That item is not in the array.", nameof(item)); // I assume "Throw an exception if an item doesn't exist" applies here to.

            return Items.Remove(item);
        }

        public void Clear()
        {
            Items.Clear();
        }

        public bool Contains(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item), "The item passed in was null.");

            else if (!Items.Contains(item))
                throw new ArgumentException("That item is not in the array.", nameof(item));

            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array), "The passed in array was null.");

            else if (arrayIndex >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index position is greater than the arrays length.");

            else if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index position is less than 0.");

            else if ((arrayIndex + Count) > array.Length)
                throw new ArgumentException("There's  not enough space.", nameof(array));

            Items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0)
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations. This exception matches standard array behavior.
                    throw new IndexOutOfRangeException("Index is less than 0.");

                else if (index >= Count)
                    throw new IndexOutOfRangeException("Index is greater than the size of the array.");

                return Items[index];
            }

            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value), "The passed in value is null.");

                else if (index < 0)
                    throw new IndexOutOfRangeException("Index is less than 0.");

                else if (index >= Capacity)
                    throw new IndexOutOfRangeException("Index is greater than the maximum size of the array.");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations

                Items[index] = value;
            }
        }
    }
}
