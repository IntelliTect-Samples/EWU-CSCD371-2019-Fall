using System;

namespace Sorter
{
    public class SortUtility
    {
        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison

        public delegate bool CheckInts(int first, int second);

        public int[] SelectionSort(int[]? array, CheckInts? check)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            else if (check is null)
                throw new ArgumentNullException(nameof(check));

            int temp, smallestIndex;
            for(int i = 0; i < array.Length - 1; i++)
            {
                smallestIndex = i;
                for(int j = i + 1; j < array.Length; j++)
                {
                    if (check(array[j], array[smallestIndex]))
                        smallestIndex = j;
                }

                temp = array[smallestIndex];
                array[smallestIndex] = array[i];
                array[i] = temp;
            }

            return array;
        }
    }
}
