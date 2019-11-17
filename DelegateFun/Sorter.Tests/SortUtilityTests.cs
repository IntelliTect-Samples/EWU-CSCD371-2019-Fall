using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorter;

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

        }
    }
}
