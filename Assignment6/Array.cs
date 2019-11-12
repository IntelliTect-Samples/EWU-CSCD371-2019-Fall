using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        public int Capacity { get; }
        public bool CapacitySet { get; set; }
        public List<T> Collection { get; set; }

        public int Count => Collection.Count;

        public bool IsReadOnly => false;

        public Array()
        {
            Collection = new List<T>();
            Capacity = 0;
            CapacitySet = false;
        }
        public Array(int i)
        {
            if (i < 0)
            {
                throw new IndexOutOfRangeException("Passed index is out of range");
            }

            Collection = new List<T>();
            Capacity = i;
            CapacitySet = true;
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("T Value being added is null.");
            } else if (Collection.Count < Capacity && CapacitySet == true)
            {
                Collection.Add(item);
            } else if (CapacitySet == false)
            {
                Collection.Add(item);
            }
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("T Value being added is null.");
            }

            return Collection.Contains(item);
        }

        public bool Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("T Value being added is null.");
            }

            return Collection.Remove(item);
        }

        public int IndexOf(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("T Value being added is null.");
            }

            return Collection.IndexOf(item);
        }

        public void Clear()
        {
            Collection.Clear();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex > Count)
            {
                throw new IndexOutOfRangeException("The passed Index is out of bounds");
            }
            Collection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyIterable(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class MyIterable : IEnumerator<T>
        {
            public Array<T> array;
            public int Index;
            public MyIterable(Array<T> array)
            {
                this.array = array;
                Index = 1;
            }
            public T Current {
                get
                {
                    if (Index > 0)
                    {
                        return array.Collection[Index];
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("Passed Index is out of Range");
                    }
                }
            }

            object IEnumerator.Current => Current;

            

            public void Dispose()
            {
                array.Clear();
                Index = 0;
            }

            public bool MoveNext()
            {
                if (Index < array.Count - 1)
                {
                    Index++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                Index = 1;
            }
        }
    }

    
}
