using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        private readonly int[] _Array = new int[] { 7, 8, 9, 1, 2, 6, 4, 5, -2, 0 };


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_NullArray_ThrowsException()
        {
            int[]? arr = null;
            SortUtility.MergeSort(arr!, (first, second) => first < second);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_NullDelegate_ThrowsException()
        {
            SortUtility.MergeSort(_Array, null!);
        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingLambdaExpression()
        {
            int[] sortedArray = new int[] { -2, 0, 1, 2, 4, 5, 6, 7, 8, 9 };
            SortUtility.MergeSort(_Array, (first, second) => first < second);


            CollectionAssert.AreEqual(_Array, sortedArray);
        }

        [TestMethod]
        public void SortUtility_ShouldSortDescending_UsingLambdaStatement()
        {
            int[] sortedArray = new int[] { 9, 8, 7, 6, 5, 4, 2, 1, 0, -2 };
            SortUtility.MergeSort(_Array, (first, second) =>
            {
                return first > second;
            });


            CollectionAssert.AreEqual(_Array, sortedArray);
        }


        [TestMethod]
        public void SortUtility_ShouldSortLexicographically_UsingAnonymousMethod()
        {


            int[] sortedArray = new int[] { -2, 0, 1, 2, 4, 5, 6, 7, 8, 9 };
            SortUtility.MergeSort(_Array, delegate (int first, int second)
            {
                return (string.CompareOrdinal($"{first}", $"{second}") <= 0);
            });

            CollectionAssert.AreEqual(_Array, sortedArray);
        }
    }
}
