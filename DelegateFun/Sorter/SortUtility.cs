using System;

namespace Sorter
{

    public delegate bool Comparison(int a, int b);

    public class SortUtility
    {

        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison
        public void InsertionSort(int[] array, Comparison comparison)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (comparison is null) throw new ArgumentNullException(nameof(comparison));

            for (var x = 1; x < array.Length; x++)
            {
                var current = array[x];
                var temp    = 0;
                for (var y = x - 1; y >= 0 && temp != 1;)
                {
                    if (comparison(current,array[y]))
                    {
                        array[y + 1] = array[y];
                        y--;
                        array[y + 1] = current;
                    } else
                    {
                        temp = 1;
                    }
                }
            }
        }

    }

}
