using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        public void Sort_UsingAnAnonymousMethod_ShouldSortAscending()
        {
            //Arrange
            int[] unsortedArray = { 5, 2, 4, 1, 3 };
            int[] sortedArray = { 1, 2, 3, 4, 5 };
            //Act
            SortUtility.Sort(unsortedArray, delegate (int first, int second)
                {
                    return first < second;
                });
            bool arrayIsSortedAscending = Enumerable.SequenceEqual(unsortedArray, sortedArray);
            //Assert
            Assert.IsTrue(arrayIsSortedAscending);
        }

        [TestMethod]
        public void Sort_UsingAnAnonymousMethod_ShouldSortDescending()
        {
            //Arrange
            int[] unsortedArray = { 5, 2, 4, 1, 3 };
            int[] sortedArray = { 5, 4, 3, 2, 1 };
            //Act
            SortUtility.Sort(unsortedArray, delegate(int first, int second) 
                {
                    return first > second;
                });
            bool arrayIsSortedDescending = Enumerable.SequenceEqual(unsortedArray, sortedArray);
            //Assert
            Assert.IsTrue(arrayIsSortedDescending);
        }

        [TestMethod]
        public void Sort_UsingAnAnonymousMethod_ShouldSortLexicographicly()
        {
            //Arrange
            int[] unsortedArray = { 300, 7000, 20, 1000};
            int[] sortedArray = { 1000, 20, 300, 7000};
            //Act
            SortUtility.Sort(unsortedArray, delegate (int first, int second)
            {
                string firstString = first.ToString();
                string secondString = second.ToString();
                int res = string.Compare(firstString,secondString);
                if (res < 0)
                    return true;
                return false;
            });
            bool arrayIsSortedLexicographicly = Enumerable.SequenceEqual(unsortedArray, sortedArray);
            //Assert
            Assert.IsTrue(arrayIsSortedLexicographicly);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_NullArray_ThrowsException()
        {
            //Arrange
            int[]? nullArray = null;
            //Act
#pragma warning disable CS8604 // Possible null reference argument.
            SortUtility.Sort(nullArray, delegate (int first, int second)
#pragma warning restore CS8604 // Passing null for testing purposes
            {
                    return false;
                });
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_NullDelegate_ThrowsException()
        {
            //Arrange
            int[]? array = Array.Empty<int>();
            //Act
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            SortUtility.Sort(array, null);
#pragma warning restore CS8625 // Passing null for testing purposes
            //Assert
        }
    }
}