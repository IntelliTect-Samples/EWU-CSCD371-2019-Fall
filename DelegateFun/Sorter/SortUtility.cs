using System;

namespace Sorter
{
    public delegate bool Key(int first, int second);

    public class SortUtility
    {
        private Key? _Key; 

        public static void Main(string[] args)
        {
            var sorter = new SortUtility();

            var arr = new int[]
            {
                3, 4, 2, 5, 1
            };

            Key k = (int a, int b) => a < b;

            sorter.QuickSort(arr, k);
            foreach (int i in arr)
                Console.WriteLine($"Value: {i}");
        }

        private void QuickSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int piv = Partition(arr, l, r);

                QuickSort(arr, l, piv - 1);
                QuickSort(arr, piv + 1, r);
            }
        }

        public void QuickSort(int[] arr, Key? key)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key));
            _Key = key;
            QuickSort(arr, 0, arr.Length-1);
        }

        private int Partition(int[] arr, int l, int r)
        {
            int piv = arr[r],
                i = l - 1,
                temp;

            for (int j = l; j < r; j++)
            {
                if (_Key(arr[j], piv))
                {
                    temp = arr[++i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[i+1];
            arr[i+1] = arr[r];
            arr[r] = temp;
            return i + 1;
        }
    }
}
