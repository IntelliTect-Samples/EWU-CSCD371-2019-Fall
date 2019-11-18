using System;

namespace Sorter
{
    public class SortUtility
    {
        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison

        //Will return true if num1 is greater than num2
        public delegate bool ComparisonDel(int num1, int num2);
        public static void InsertionSort(int[] arr, ComparisonDel comparison)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int num2 = arr[i];
                int j = i - 1;

                while(j>=0 && comparison(arr[j], num2))
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = num2;
            }
        }

    }
}
