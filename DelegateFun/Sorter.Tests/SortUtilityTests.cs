using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            //Organize
            int[] intArr = { 3, 4, 5, 2, 4, 2, 1};
            SortUtility sortUtil = new SortUtility();

            //Act
            intArr = sortUtil.Sort(intArr, (x, y) => (x > y));

            //Assert
            Assert.AreEqual(1, intArr[0]);
        }
    }
}
