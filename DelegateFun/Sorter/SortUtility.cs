using System;

namespace Sorter {
    public class SortUtility {
        public delegate bool Comparer(int first, int second);
        public static void SelectionSort(int[] array, Comparer comparer) {
            for (int i = 0; i < array.Length - 1; i++) {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++) {
                    if (comparer(array[j], array[minIndex])) {
                        minIndex = j;
                    }
                }
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }
    }
}
