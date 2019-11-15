using System;

namespace Sorter
{
    public class SortUtility
    {
        public delegate bool SortOrder(int first, int second);
        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison
        public int[] Sort(int[] array, SortOrder sortOrder)
        {
            if(array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }


            //Insertion Sort
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0 && sortOrder(array[j-1], array[j]); j--)
                {
                    var temp = array[j - 1];
                    array[j - 1] = array[j];
                    array[j] = temp;
                }
            }

            return array;
        }
    }
}
