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
            //Organize
            int[] intArr = { 3, 4, 5, 2, 4, 2, 1};
            SortUtility sortUtil = new SortUtility();

            //Act
            intArr = sortUtil.Sort(intArr,  delegate(int first, int second)
            {
                return first > second;
            });

            //Assert
            Assert.AreEqual(1, intArr[0]);
        }

        [TestMethod]
        public void SortUtility_ShouldSortDescending_UsingLambdaStatement()
        {
            //Organize
            int[] intArr = { 3, 4, 5, 2, 4, 2, 1 };
            SortUtility sortUtil = new SortUtility();

            //Act
            intArr = sortUtil.Sort(intArr, (x, y) =>
            {
                return x < y;
            });

            //Assert
            Assert.AreEqual(5, intArr[0]);
        }

        [TestMethod]
        public void SortUtility_ShouldSortLexicographically_UsingLambdaExpression()
        {
            //Organize
            int[] intArr = { 3, 4, 5, 2, 4, 2, 111, 1111 };
            SortUtility sortUtil = new SortUtility();

            //Act
            intArr = sortUtil.Sort(intArr, (x, y) => x.ToString().CompareTo(y.ToString()) > 0);

            //Assert
            Assert.AreEqual(111, intArr[0]);

        }
    }
}
