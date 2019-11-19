using System;

namespace Sorter
{
    public delegate bool Key(int first, int second);

    public class SortUtility
    {
        public void QuickSort(int[] arr, int l, int r, Key key)
        {
            if (l < r)
            {
                int part = Partition(arr, l, r, key);

                QuickSort(arr, l, part - 1, key);
                QuickSort(arr, part + 1, r, key);
            }
        }

        public void QuickSort(int[] arr, Key key)
        {
            if (arr is null)
                throw new ArgumentNullException(nameof(arr));

            QuickSort(arr, 0, arr.Length - 1, key);
        }

        private static int Partition(int[] arr, int l, int r, Key key)
        {
            int piv = arr[r],
                i = l - 1,
                temp;

            for (int j = l; j < r; j++)
            {
                if (key(arr[j], piv))
                {
                    temp = arr[++i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[i+1];
            arr[i+1] = arr[r];
            arr[r] = temp;

            return i+1;
        }
    }
}
