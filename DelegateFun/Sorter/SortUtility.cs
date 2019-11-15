namespace Sorter
{
    public static class SortUtility
    {
        public delegate bool SortingFuntion(int firstNumber, int secondNumber);

        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison
        public static void Sort(int[] unsortedArray, SortingFuntion sort)
        {
            //implement selection sort
            for (int firstIndex = 0; firstIndex < unsortedArray.Length - 1; firstIndex++)
            {
                int targetIndex = firstIndex;
                for (int secondIndex = firstIndex + 1; secondIndex < unsortedArray.Length; secondIndex++)
                {
                    if (sort(unsortedArray[secondIndex], unsortedArray[targetIndex]))
                        targetIndex = secondIndex;
                }
                int temp = unsortedArray[firstIndex];
                unsortedArray[firstIndex] = unsortedArray[targetIndex];
                unsortedArray[targetIndex] = temp;
            }
        }
    }
}