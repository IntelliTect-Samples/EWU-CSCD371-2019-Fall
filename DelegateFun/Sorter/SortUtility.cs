using System;
using System.Collections.Generic;

namespace Sorter
{
    public class SortUtility
    {
        public delegate bool Compare(int i, int j);

        public static int[] Sort(int[] intArray, Compare compare) => intArray switch
        {
            int[] list when list.Length <= 1 => list,
            int[] list => Merge(Sort(list[..(list.Length/2)], compare),
                                Sort(list[(list.Length/2)..], compare),
                                compare)
        };

        private static int[] Merge(int[] listA, int[] listB, Compare compare)
        {
            var list = new int[listA.Length + listB.Length];

            int a = 0, b = 0, i = 0;
            while (a < listA.Length && b < listB.Length)
                list[i++] = compare(listA[a], listB[b]) ? listA[a++] : listB[b++];

            while ( a < listA.Length)
                list[i++] = listA[a++];

            while ( b < listB.Length)
                list[i++] = listB[b++];

            return list;
        }
    }
}
