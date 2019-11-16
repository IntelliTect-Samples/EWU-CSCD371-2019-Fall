using System;
using System.Reflection;

namespace Sorter
{
    public class SortUtility
    {
        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison
    
        public delegate bool MyFunc(int first, int second);

        public int[] Sort(int[] items, MyFunc myFunc)
        {
            if(items is null)
            {
                throw new ArgumentNullException(nameof(items), "The array cannot be null");
            }


            for(int i = 0; i < items.Length; i++)
            {
                int index = i;

                for(int j = i + 1; j < items.Length; j++)
                {
                    if(myFunc(items[j],items[index]))
                    {
                        index = j;
                    }
                }

                int temp = items[i];
                items[i] = items[index];
                items[index] = temp;

            }

            return items;
        }
    }
}
