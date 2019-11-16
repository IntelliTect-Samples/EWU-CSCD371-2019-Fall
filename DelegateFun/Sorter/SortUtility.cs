using System;

namespace Sorter
{
    public class SortUtility
    {
        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison

        public delegate bool CompareNumbers(int first, int second);

        public static void Sort(int[] items, CompareNumbers compare)
        {
            for (int ix = 0; ix < items.Length - 1; ix++)
            {
                for (int iy = 1; iy < items.Length - 2; iy++)
                {
                    if (compare(items[ix], items[iy]))
                    {
                        int temp = items[ix];
                        items[ix] = items[iy];
                        items[iy] = temp;
                    }
                }
            }
        }
    }
}
