using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T>
    {
        private int _Length = 0;
        private T[]? Data;

        public Array()
        {
            _Length = 0;
        }

        public Array(int size)
        {
            if (size < 0)
                throw new System.ArgumentOutOfRangeException(nameof(size));
            else
                _Length = size;
        }

        public void Resize(int length)
        {
        }

        public List<T> ToList()
        {
            return new List<T>();
        }

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

        public int Length
        {
            get
            {
                return _Length;
            }
        }
    }
}
