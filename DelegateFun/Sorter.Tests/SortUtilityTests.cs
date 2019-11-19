using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        [DataRow(new int[] { 1, 34, 46, 2, 9, 3, 5, 3, 93, 0 }, new int[] { 0, 1, 2, 3, 3, 5, 9, 34, 46, 93 })]
        [DataRow(new int[] { 1, 18, 9, 3, 5, 2, 4 }, new int[] { 1, 2, 3, 4, 5, 9, 18 })]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod(int[] input, int[] expected)
        {
            SortUtility sorter = new SortUtility();
            int[] actual = sorter.SelectionSort(input, delegate (int first, int second)
            {
                return first < second;
            });

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 34, 46, 2, 9, 3, 5, 3, 93, 0 }, new int[] { 93, 46, 34, 9, 5, 3, 3, 2, 1, 0 })]
        [DataRow(new int[] { 1, 18, 9, 3, 5, 2, 4 }, new int[] { 18, 9, 5, 4, 3, 2, 1 })]
        public void SortUtility_ShouldSortDecending_UsingLambdaExpression(int[] input, int[] expected)
        {
            SortUtility sorter = new SortUtility();
            int[] actual = sorter.SelectionSort(input, (int first, int second) => first > second);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 34, 46, 2, 9, 3, 5, 3, 93, 0 }, new int[] { 0, 2, 34, 46, 1, 3, 3, 5, 9, 93 })]
        [DataRow(new int[] { 1, 18, 9, 3, 5, 2, 4 }, new int[] { 2, 4, 18, 1, 3, 5, 9 })]
        public void SortUtility_ShouldSortEvensThenOdds_UsingLambdaStatement(int[] input, int[] expected)
        {
            SortUtility sorter = new SortUtility();
            int[] actual = sorter.SelectionSort(input, (int first, int second) =>
            {
                if (first % 2 == 0 && second % 2 == 0)
                    return first < second;

                else if (first % 2 == 0)
                    return true;

                else if (second % 2 == 0)
                    return false;

                return first < second;
            });

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_NullArray_ExceptionThrown()
        {
            SortUtility sorter = new SortUtility();
            int[] actual = sorter.SelectionSort(null, (int first, int second) => first < second);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_NullCheck_ExceptionThrown()
        {
            SortUtility sorter = new SortUtility();
            int[] actual = sorter.SelectionSort(new int[] { 1, 34, 46, 2, 9, 3, 5, 3, 93, 0 }, null);
        }
    }
}
