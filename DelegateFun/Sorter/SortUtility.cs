using System;

namespace Sorter
{
    public class SortUtility
    {
        public delegate bool SortFunc(int first, int second);

        public int[] Sort(int[] ints, SortFunc sort)
        {
            if(ints is null) { throw new ArgumentNullException(nameof(ints)); }

            for(int i = ints.Length - 1; i >=  0; i--)
            {
                
                for(int j = 1; j <= i; j++)
                {
                    if(sort(ints[j-1], ints[j]))
                    {
                        int temp = ints[j - 1];
                        ints[j - 1] = ints[j];
                        ints[j] = temp;
                    }
                }
            }

            return ints;
        }
    }
}
