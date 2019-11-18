using System;

namespace Sorter
{
    public delegate bool Key(int first, int second);

    public class SortUtility
    {
        private static void QuickSort(int[] arr, int l, int r, Key key)
        {
            int piv;
            if (l < r)
            {
                piv = Partition(arr, l, r, key);

                if (piv > 1)
                    QuickSort(arr, l, piv - 1, key);
                if (piv + 1 < r)
                    QuickSort(arr, piv + 1, r, key);
            }
        }

        public void QuickSort(int[] arr, Key? key)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));
            QuickSort(arr, 0, arr.Length-1, key);
        }

        private static int Partition(int[] arr, int l, int r, Key key)
        {
            int piv = arr[r],
                i = l - 1;

            for (int j = l; j < r-1; j++)
            {
                if (key(arr[j], piv))
                {
                    int temp1 = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp1;
                }
            }

            int temp2 = arr[i+1];
            arr[i+1] = arr[r];
            arr[r] = temp2;
            return i + 1;
        }
    }
}
