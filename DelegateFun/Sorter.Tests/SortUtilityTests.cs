using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        private static bool IsGreaterThan(int firstNumber, int secondNumber)
        {
            if (firstNumber > secondNumber)
                return true;
            return false;
        }

        public static bool IsLesserThan(int firstNumber, int secondNumber)
        {
            if (firstNumber < secondNumber)
                return true;
            return false;
        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            //Arrange
            int[] unsortedArray = { 5, 2, 4, 1, 3 };
            int[] sortedArray = { 1, 2, 3, 4, 5 };
            //Act
            SortUtility.Sort(unsortedArray, IsLesserThan);
            bool arrayIsSortedAscending = Enumerable.SequenceEqual(unsortedArray, sortedArray);
            //Assert
            Assert.IsTrue(arrayIsSortedAscending);
        }
    }
}