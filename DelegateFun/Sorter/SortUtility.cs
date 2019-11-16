using System;

namespace Sorter
{
    public delegate bool Compare(int first, int second);

    public class SortUtility
    {
        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison

        public void InsertionSort(int[] array, Compare compare)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (compare(array[j - 1], array[j]))
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
