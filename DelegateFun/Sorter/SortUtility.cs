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
            return new int[1];
        }
    }
}
