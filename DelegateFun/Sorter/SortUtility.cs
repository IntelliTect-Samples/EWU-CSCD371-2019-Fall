using System;

namespace Sorter
{
    public static class SortUtility
    {
        public delegate bool Comparer(int first, int second);
        public static void Sort(int[] array, Comparer compare)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));

            if (array.Length <= 1) return;

            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && compare(key, array[j]))
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
        }
    }
}
