using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        private bool IsGreaterThan(int firstNumber, int secondNumber)
        {
            if (firstNumber > secondNumber)
                return true;
            return false;
        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            //Arrange
            SortUtility sortUtility = new SortUtility();
            int[] unsortedArray = { 5, 2, 4, 1, 3 };
            int[] sortedArray = { 1, 2, 3, 4, 5 };
            //Act
            sortUtility.Sort(unsortedArray, IsGreaterThan);
            bool arrayIsSortedAscending = Enumerable.SequenceEqual(unsortedArray, sortedArray);
            //Assert
            Assert.IsTrue(arrayIsSortedAscending);
        }
    }
}