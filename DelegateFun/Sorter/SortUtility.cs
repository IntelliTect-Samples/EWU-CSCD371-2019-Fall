using System;

namespace Sorter
{
    public class SortUtility
    {
        public delegate bool Key(int first, int second);

        private void QuickSort(int[] arr, Key key, int l, int r)
        {
            if (l < r)
            {
                int piv = Partition(arr, l, r);

                if (piv > 1) QuickSort(int[] arr, l, piv - 1);
                if (piv + 1 < r) QuickSort(int[] arr, piv + 1, r);
            }
        }

        public void QuickSort(int[] arr, Key key) =>
            QuickSort(arr, 0, arr.Length-1);

        private void Partition(int[] arr, int l, int r)
        {
            int piv = arr[l];
            while (true)
            {
                while (arr[l] < piv) l++;
                while (arr[r] > piv) r++;
                if (l < r)
                {
                    if (arr[l] == arr[r]) return r;

                    int temp = arr[l];
                    arr[l] = arr[r];
                    arr[r] = temp;
                }
                else
                    return r;
            }
        }
    }
}
