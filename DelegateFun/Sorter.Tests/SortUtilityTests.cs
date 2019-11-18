using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            // Arrange
            int[] test = { 4, 2, 3, 1 };
            int[] expected = { 1, 2, 3, 4 };

            // Act
            SortUtility.SelectionSort(test, delegate (int first, int second)
            {
                return first < second;
            });

            // Assert
            CollectionAssert.AreEqual(test, expected);
        }

        [TestMethod]
        public void SortUtility_SortDescending_UsingLambdaExpression()
        {
            // Arrange
            int[] test = { 1, 4, 2, 3 };
            int[] expected = { 4, 3, 2, 1 };

            // Act
            SortUtility.SelectionSort(test, (int first, int second) => first > second);

            // Assert
            CollectionAssert.AreEqual(test, expected);

        }

        [TestMethod]
        public void SortUtility_SortDescendingAlphabetical_UsingLambdaStatement()
        {
            // Arrange
            int[] test = { 1, 4, 2, 3 };
            int[] expected = { 4, 3, 2, 1 };

            // Act
            SortUtility.SelectionSort(test, (int first, int second) =>
            {
                return first.ToString().CompareTo(second.ToString()) > 0;
            });

            // Assert
            CollectionAssert.AreEqual(test, expected);

        }
    }
}
