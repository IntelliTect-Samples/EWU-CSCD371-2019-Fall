using System;

namespace Sorter
{
    public class SortUtility
    {
        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison
        public delegate bool IsLowerOrHigher(int x, int y);

        public int[] SelectionSort(int[] ara, IsLowerOrHigher isLowerOrHigher)
        {
            if (ara == null)
                throw new ArgumentNullException("The Integer Array is Null.");
            else if (isLowerOrHigher == null)
                throw new ArgumentNullException("The Delegator is Null.");

            for (int i = 0; i < ara.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < ara.Length; j++)
                {
                    if (isLowerOrHigher(ara[j], ara[min]))
                    {
                        min = j;
                    }
                }
                int temperary = ara[min];
                ara[min] = ara[i];
                ara[i] = temperary;
            }
            return ara;
        }
    }
}
