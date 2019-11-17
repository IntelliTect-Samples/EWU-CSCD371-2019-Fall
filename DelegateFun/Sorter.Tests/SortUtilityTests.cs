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
            //Arrange
            int[] items = { 25, 34, 2, 5, 0 };

            //Act
            SortUtility.InsertionSort(items,
                delegate(int first, int second)
                {
                    return first > second;
                }
            );

            //Assert
            Assert.AreEqual("0, 2, 5, 25, 34", string.Join(", ", items));
        }

        [TestMethod]
        public void SortUtility_ShouldSortDescending_UsingLamdaExpression()
        {
            //Arrange
            int[] items = { 25, 34, 2, 5, 0 };

            //Act
            SortUtility.InsertionSort(items, (first, second) => second > first);

            //Assert
            Assert.AreEqual("34, 25, 5, 2, 0", string.Join(", ", items));
        }

        [TestMethod]
        public void SortUtility_ShouldSortLexicographically_UsingLamdaStatement()
        {
            //Arrange
            int[] items = { 25, 34, 2, 5, 0 , 2345, 234, 2555};

            //Act
            SortUtility.InsertionSort(items,
                (first, second) =>
                {
                    bool greater = first > second;
                    string numFirst = first.ToString();
                    string numSecond = second.ToString();

                    int comp = 0;
                    for (int i = 0; i < numFirst.Length && i < numSecond.Length; i++)
                    {
                        comp = numFirst.ToCharArray()[i].CompareTo(numSecond.ToCharArray()[i]);

                        if (comp > 0) { return true; }
                        if (comp < 0) { return false; }
                    }

                    return numFirst.Length > numSecond.Length;
                }
            );

            //Assert
            Assert.AreEqual("0, 2, 234, 2345, 25, 2555, 34, 5", string.Join(", ", items));
        }

        [TestMethod]
        public void SortUtility_ShouldIgnoreEmptyArray()
        {
            //Arrange
            int[] items = Array.Empty<int>();

            //Act
            SortUtility.InsertionSort(items, (first, second) => first > second);

            //Assert
            Assert.AreEqual(Array.Empty<int>(), items);
        }

        [TestMethod]
        public void SortUtility_ShouldIgnoreNullArray()
        {
            //Arrange
            int[]? items = null;

            //Act
            SortUtility.InsertionSort(items!, (first, second) => first > second);

            //Assert
            Assert.AreEqual(null, items);
        }

        [TestMethod]
        public void SortUtility_ShouldExcept_WithNullComparer()
        {
            //Arrange
            int[]? items = null;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => SortUtility.InsertionSort(items!, null!));
        }
    }
}
