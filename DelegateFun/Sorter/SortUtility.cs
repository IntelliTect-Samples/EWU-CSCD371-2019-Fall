using System;

namespace Sorter
{
    public static class SortUtility
    {
        public delegate bool SortOrdering(int i, int j);

        // selection sort
        public static void Sort(int[] items, SortOrdering compare)
        {
            if (items is null) throw new ArgumentNullException(nameof(items));

            for (int i = 0; i < items.Length; i++)
            {
                int target = i;

                for (int j = i + 1; j < items.Length; j++)
                {
                    if (compare(items[target], items[j])) target = j;
                }

                if (target != i)
                {
                    int temp = items[i];
                    items[i] = items[target];
                    items[target] = temp;
                }
            }
        }
    }
}
