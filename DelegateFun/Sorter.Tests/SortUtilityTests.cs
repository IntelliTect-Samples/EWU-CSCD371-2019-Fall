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
            int[] intArr = { 3, 4, 5, 2, 4, 2, 1 };
            int[] correctArr = { 1, 2, 2, 3, 4, 4, 5 };
            SortUtility sortUtil = new SortUtility();

            //Act
            intArr = sortUtil.Sort(intArr,  delegate(int first, int second)
            {
                return first > second;
            });

            //Assert
            CollectionAssert.AreEqual(correctArr, intArr);
        }

        [TestMethod]
        public void SortUtility_ShouldSortDescending_UsingLambdaStatement()
        {
            //Organize
            int[] intArr = { 3, 4, 5, 2, 4, 2, 1 };
            int[] correctArr = { 5, 4, 4, 3, 2, 2, 1 };
            SortUtility sortUtil = new SortUtility();

            //Act
            intArr = sortUtil.Sort(intArr, (x, y) =>
            {
                return x < y;
            });

            //Assert
            CollectionAssert.AreEqual(correctArr, intArr);
        }

        [TestMethod]
        public void SortUtility_ShouldSortLexicographically_UsingLambdaExpression()
        {
            //Organize
            int[] intArr = { 3, 4, 5, 2, 4, 2, 111, 1111 };
            int[] correctArr = { 111, 1111, 2, 2, 3, 4, 4, 5 };
            SortUtility sortUtil = new SortUtility();

            //Act
            intArr = sortUtil.Sort(intArr, (x, y) => x.ToString().CompareTo(y.ToString()) > 0);

            //Assert
            CollectionAssert.AreEqual(correctArr, intArr);

        }
    }
}
