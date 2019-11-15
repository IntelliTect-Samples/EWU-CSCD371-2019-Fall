using System;

namespace Sorter
{
    public class SortUtility
    {
        public delegate bool SortingFuntion(int firstNumber, int secondNumber);

        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison
        public void Sort(int[] unsortedArray, SortingFuntion sort)
        {
            throw new NotImplementedException();
        }
    }
}