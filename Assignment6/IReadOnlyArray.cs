using System.Collections.Generic;

namespace Assignment6
{
    interface IReadOnlyArray<out T> : IEnumerable<T>
    {
        public int Count { get; }

        public T this[int index] { get; }
    }
}
