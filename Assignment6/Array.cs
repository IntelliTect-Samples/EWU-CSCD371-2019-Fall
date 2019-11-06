using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        private ICollection<T> Data;

        public Array()
        {
            Data = new List<T>();
        }

        public Array(int size)
        {
            if (size < 0)
                throw new System.ArgumentOutOfRangeException(nameof(size));
            Data = new List<T>(size);
        }

        public Array(ICollection<T> collection) =>
            Data = collection;

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
            for (int i = 0; i < length; i++)
                tmp[i] = Data[i];
            Data = tmp;
        }

        public List<T> ToList() =>
            new List<T>(Data);

        public T this[int key]
        {
            get
            {
                if (key >= _Length || key < 0)
                    throw new System.InvalidOperationException(nameof(key));
                if (Data[key] is T data)
                    return data;
                else
                    throw new System.InvalidOperationException(nameof(key));
            }
            set
            {
                if (key >= _Length || key < 0)
                    throw new System.InvalidOperationException(nameof(key));
                Data[key] = value;
            }
        }

        public int Capacity
        {
            get
            {
                return Data.Length;
            }
        }
    }
}
