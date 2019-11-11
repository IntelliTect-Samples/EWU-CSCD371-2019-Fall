using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    /*
     * I'm going to assume that inheriting from List<T> and using base class functionality to
     * handle/bypass most of the assignment requirements isn't in the spirit of the assignment.
     */

    /// <summary>
    /// A generically typed, fixed length array.
    /// </summary>
    /// <remarks>
    /// Elements are coalesced toward the beginning of the array. Only existing elements can
    /// be accessed, and any new elements are added at the first available empty index.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public class ArrayCollection<T> : ICollection<T>
    {
        private T[] Data { get; }
        private int _Count;
        public int Count { get => _Count; }
        public int Capacity { get; }
        public bool IsReadOnly { get => false; } // readonly not implemented in this class (yet?)

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="capacity">
        /// Requires a nonzero positive capacity.
        /// </param>
        public ArrayCollection(int capacity)
        {
            if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));

            Capacity = capacity;
            Data = new T[Capacity];
        }

        /// <summary>
        /// Constructor, specifies preexisting data and a desired capacity
        /// </summary>
        /// <remarks>
        /// If capacity is smaller than the array passed in, it will copy what data it can.
        /// Performs a shallow copy.
        /// </remarks>
        /// <param name="data"></param>
        /// <param name="capacity"></param>
        public ArrayCollection(T[] data, int capacity) : this(capacity)
        {
            if (data is null) throw new ArgumentNullException(nameof(data));

            _Count = Math.Min(Capacity, data.Length);
            Array.Copy(data, 0, Data, 0, _Count);
        }

        /// <summary>
        /// Constructor, specifies existing data
        /// </summary>
        /// <remarks>
        /// Will not allocate extra room to grow. Performs a shallow copy.
        /// </remarks>
        /// <param name="data"></param>
        public ArrayCollection(T[] data) : this(data, data?.Length ?? 0) { }

        /// <summary>
        /// Indexing operator
        /// </summary>
        /// <remarks>
        /// Only allows indexing operations on existing elements, and assignment on first empty index.
        /// Will throw exceptions for invalid operations.
        /// </remarks>
        /// <param name="index">
        /// Must be nonzero positive int less or equal to Count
        /// </param>
        /// <returns></returns>
#pragma warning disable CA1065 // It's expected that an indexing operation will throw on invalid index
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _Count) throw new IndexOutOfRangeException();

                return Data[index];
            }
            set
            {
                if (index < 0 || index > _Count) throw new IndexOutOfRangeException();


                if (index == _Count) // allowing insertion into next empty position
                {
                    Add(value); // let add function handle the logic of insertion
                }
                else
                {
                    Data[index] = value;
                }
            }
        }
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations

        /// <summary>
        /// Adds an item to the first empty index.
        /// </summary>
        /// <remarks>
        /// Throws if array is full.
        /// </remarks>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (_Count >= Capacity) throw new InvalidOperationException(message: "Array is full.");

            Data[_Count++] = item;
        }

        /// <summary>
        /// Removes the first instance of the item and shifts elements to fill the hole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>
        /// Boolean indicating if removal was successful.
        /// </returns>
        public bool Remove(T item)
        {
            if (_Count == 0) return false;

            for (int i = 0; i < _Count; i++) //intentionally not using foreach
            {
                if (EqualityComparer<T>.Default.Equals(Data[i], item))
                {
                    Array.Copy(Data, i + 1, Data, i, _Count - i - 1); // shift elements to fill hole
                    Data[_Count - 1] = default!; // erase last element, null is acceptable
                    _Count--;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Overwrites all data in array with default<typeparamref name="T"/> value, and sets Count to 0.
        /// </summary>
        public void Clear()
        {
            // allowing possible null valuetypes, they cannot be accessed externally
            Array.Fill<T>(Data, default!);

            _Count = 0;
        }

        /// <summary>
        /// Searches the array, checking if specified item exists.
        /// </summary>
        /// <remarks>
        /// May perform boxing operations on value types.
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>
        /// Boolean indicating whether the specified item was found.
        /// </returns>
        public bool Contains(T item)
        {
            return Array.Exists<T>(Data, element => EqualityComparer<T>.Default.Equals(element, item));
        }

        /// <summary>
        /// Copies array elements into supplied array, starting at specified index.
        /// </summary>
        /// <remarks>
        /// Only copies to the last existing item. Does not copy over unused elements.
        /// </remarks>
        /// <param name="array">
        /// Cannot be null, must have enough capacity for all elements requested.
        /// </param>
        /// <param name="arrayIndex">
        /// Starting index for the copy operation.
        /// </param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex >= _Count) throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            if (array is null) throw new ArgumentNullException(nameof(array));

            Array.Copy(Data, arrayIndex, array, arrayIndex, _Count - arrayIndex);
        }

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)Data).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Data.GetEnumerator();

        /// <summary>
        /// Converts ArrayCollection into a C# array.
        /// </summary>
        /// <remarks>
        /// Returns a null T[] if trying to cast a null.
        /// Performs a shallow copy into a new array.
        /// </remarks>
        /// <param name="arrayCollection"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Not porting this to different languages.")]
        public static explicit operator T[]?(ArrayCollection<T> arrayCollection)
        {
            if (arrayCollection is null) return null;

            T[] ret = new T[arrayCollection.Capacity];
            arrayCollection.CopyTo(ret, 0);
            return ret;
        }

        /// <summary>
        /// Converts a C# array into an ArrayCollection.
        /// </summary>
        /// <remarks>
        /// Returns null ArrayCollection if trying to cast a null.
        /// Performs a shallow copy of the array.
        /// New ArrayCollection will not have room for growth. Use the constructor with given array and explicit size if that is undesirable.
        /// </remarks>
        /// <param name="array"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Not porting this to different languages.")]
        public static explicit operator ArrayCollection<T>?(T[] array)
        {
            if (array is null) return null;

            return new ArrayCollection<T>(array);
        }
    }
}
