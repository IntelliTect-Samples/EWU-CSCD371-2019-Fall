using System;

namespace Sorter
{
    public static class SortUtility
    {
        public delegate bool Compare(int num1, int num2);

        public static void Sort(int[]? arr, Compare comparer)
        {
            if (arr is null)
                throw new ArgumentNullException(nameof(arr));
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (comparer(arr[j], arr[min_idx]))
                        min_idx = j;

                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
        }
    }
}
