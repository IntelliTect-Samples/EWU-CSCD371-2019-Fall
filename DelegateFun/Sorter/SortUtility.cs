using System;

namespace Sorter
{
    public class SortUtility
    {
        public delegate bool Comparer(int first, int second);

        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison
        public static void InsertionSort(int[] items, Comparer comparer)
        {
            int i;
            int j;
            int temp;

            if(comparer is null) { throw new ArgumentNullException(nameof(comparer)); }

            if (items is null) { return; }

            for(i = 1; i < items.Length; i++)
            {
                temp = items[i];
                j = i - 1;

                while (j >= 0 && comparer(items[j], temp))
                {
                    items[j + 1] = items[j];
                    j = j - 1;
                }
                items[j + 1] = temp;
            }
        }
    }
}
