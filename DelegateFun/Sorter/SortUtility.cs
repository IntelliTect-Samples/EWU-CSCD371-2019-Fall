using System;

namespace Sorter
{
    public class SortUtility
    {
        public delegate bool SortFunc(int first, int second);

        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison

        public static int[] SelectionSort(int[] items, SortFunc compare)
        {
            int smallest;
            for(int i = 0; i < items.Length; i++)
            {
                smallest = i;
                for(int j = i + 1; j < items.Length; j++)
                {
                    if(compare(items[j], items[smallest]))
                    {
                        smallest = j;
                    }
                }
                int temp = items[i];
                items[i] = items[smallest];
                items[smallest] = temp;
            }
            return items;
        }
    }
}
