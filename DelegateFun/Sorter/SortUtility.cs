using System;

namespace Sorter
{
    public static class SortUtility
    {
        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison

        public delegate bool CompareNumbers(int first, int second);

        public static void Sort(int[] items, CompareNumbers compare)
        {
            int temp, i, j;

            if (compare is null) { throw new ArgumentNullException(nameof(compare)); }

            if (items is null) { throw new ArgumentNullException(nameof(items)); }

            for (i = 1; i < items.Length; i++)
            {
                temp = items[i];
                j = i - 1;

                while (j >= 0 && compare(items[j], temp))
                {
                    items[j + 1] = items[j];
                    j -= 1;
                }
                items[j + 1] = temp;
            }
        }
    }
}
