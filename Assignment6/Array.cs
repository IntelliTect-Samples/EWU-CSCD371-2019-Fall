using System;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T>
    {
        public Array(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
        }

        public int Length
        {
            get
            {
            }
        }
    }
}
