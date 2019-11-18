using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            int[] array = { 5, 4, 21, 64, 7, 28, 0, 84, 123, 42};
            int[] expectedResult = { 0, 4, 5, 7, 21, 28, 42, 64, 84, 123};

            SortUtility.Sort(array, delegate(int first, int second) 
            {
                return first < second;
            });

            CollectionAssert.AreEqual(expectedResult, array);
        }

        [TestMethod]
        public void SortUtility_ShouldSortDescending_UsingLambdaExpression()
        {
            int[] array = { 5, 4, 21, 64, 7, 28, 0, 84, 123, 42 };
            int[] expectedResult = { 123, 84, 64, 42, 28, 21, 7, 5, 4, 0 };

            SortUtility.Sort(array, (first, second) => first > second);

            CollectionAssert.AreEqual(expectedResult, array);
        }

        [TestMethod]
        public void SortUtility_ShouldSortAlphabeticalAscending_UsingLambdaStatement()
        {
            int[] array = { 5, 4, 21, 64, 7, 28, 0, 84, 123, 42 };
            int[] expectedResult = { 0, 123, 21, 28, 4, 42, 5, 64, 7, 84 };

            SortUtility.Sort(array, (first, second) =>
            {
                int comparison = second.ToString().CompareTo(first.ToString());
                return comparison > 0;
            });

            CollectionAssert.AreEqual(expectedResult, array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_UsingNullArray_ThrowsException()
        {
            SortUtility.Sort(null!, (first, second) => first < second);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_UsingNullDelegate_ThrowsException()
        {
            int[] array = { 5, 4, 21, 64, 7, 28, 0, 84, 123, 42 };

            SortUtility.Sort(array, null!);
        }
    }
}
