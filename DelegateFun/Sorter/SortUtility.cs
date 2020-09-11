using System;

namespace Sorter
{
    public static class SortUtility
    {
        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison
        public delegate bool SortDelegate(int first, int second);

        public static void MergeSort(int[]array, SortDelegate compare)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (compare is null)
            {
                throw new ArgumentNullException(nameof(compare));
            }

            //Recursion Break
            if (array.Length <=1)
            {
                return;
            }

            //get size of both halves of the arrays
            bool isOdd = false;
            if ((array.Length % 2) == 1)
            {
                isOdd = true;
            }

            int size = array.Length / 2;

            int[] left = new int[size];
            int[] right;
            if (isOdd)
            {
                right = new int[size + 1];
            }
            else
            {
                right = new int[size];
            }

            //populate arrays
            for (int i = 0; i < array.Length; i++)
            {
                if (i < size)
                {
                    left[i] = array[i];
                }
                else
                {
                    right[i - size] = array[i];
                }
            }

            MergeSort(left, compare);
            MergeSort(right, compare);
            Merge(array, left, right, compare);
        }

        private static void Merge(int[] array, int[] left, int[] right, SortDelegate compare)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int arrayIndex = 0;

            //while either have more numbers to sort, SORT
            while (leftIndex < left.Length || rightIndex < right.Length)
            {
                if (leftIndex < left.Length && rightIndex < right.Length)
                {
                    if (compare(left[leftIndex], right[rightIndex]))
                    {
                        array[arrayIndex++] = left[leftIndex++];
                    }
                    else
                    {
                        array[arrayIndex++] = right[rightIndex++];
                    }
                }
                else if (leftIndex < left.Length)
                {
                    array[arrayIndex++] = left[leftIndex++];
                }
                else
                {
                    array[arrayIndex++] = right[rightIndex++];
                }
            }

        }
    }
}
