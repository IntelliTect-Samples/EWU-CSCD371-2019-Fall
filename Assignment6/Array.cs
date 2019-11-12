using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Assignment6
{
    public class Array<T> : IEnumerable<T>, ICollection<T>
    {
        public int Capacity { get; }
        public List<T> Collection {get;}

        public int Count
        {
            get
            {
                return Collection.Count;
            }
        }

        public bool IsReadOnly { get;}

        public T this[int i]
        {
            get => Collection[i];
            set => Collection.Add(value);
        }

        public Array(int c)
        {
            if(c < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(c));
            }
            this.Capacity = c;
            Collection = new List<T>(c);
        }

        public Array(int c, Collection<T> collection)
        {
            if (c < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(c));
            }
            if(collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            this.Capacity = c;
            Collection = new List<T>(c);
            for(int i = 0; i < Capacity && i < collection.Count; i++)
            {
                Collection.Add(collection[i]);
            }
        }

        public T GetValue(int i)
        {
            if(i >= this.Capacity)
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }
            if(Collection[i] is null)
            {
                throw new NullReferenceException("Null object found at index " + i + ".");
            }
            return Collection[i];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ArrEnumerator(Collection);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public void Add(T item)
        {
            Collection.Add(item);
        }

        public void Clear()
        {
            Collection.Clear();
        }

        public bool Contains(T item)
        {
            return Collection.Contains(item);
        }

        public bool Remove(T item)
        {
            return Collection.Remove(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            foreach (T obj in Collection)
            {
                array.SetValue(obj, arrayIndex);
                arrayIndex++;
            }
        }

        class ArrEnumerator : IEnumerator<T>
        {
            int _Position = -1;
            public List<T> _List;
            public T Current
            {
                get
                {
                    try
                    {
                        return _List[_Position];
                    }
                    catch(IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public ArrEnumerator(List<T> collection)
            {
                _List = collection;
            }


            public bool MoveNext()
            {
                _Position++;
                return (_Position < _List.Count);
            }

            public void Reset()
            {
                _Position = -1;
            }

            public void Dispose()
            {

            }
        }
    }
}
