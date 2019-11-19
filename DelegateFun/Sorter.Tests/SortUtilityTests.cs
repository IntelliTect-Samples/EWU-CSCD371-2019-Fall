using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [DataTestMethod]
        [DataRow(new int[] { 4, 7, 2, 8, 9 }, new int[] { 2, 4, 7, 8, 9 })]
        [DataRow(new int[] { 12, 17, 23, 18, 29 }, new int[] { 12, 17, 18, 23, 29 })]
        [DataRow(new int[] { 4, 37, 56, 13, 1 }, new int[] { 1, 4, 13, 37, 56 })]
        public void SortUtility_ShouldSort_UsingAnAnonymousMethod(int[] toBeSorted, int[] expected)
        {
            SortUtility sortUtility = new SortUtility();
            toBeSorted = sortUtility.SelectionSort(toBeSorted, delegate (int x, int y)
            {
                if (x < y)
                    return true;
                else
                    return false;
            });

            CollectionAssert.AreEqual(expected, toBeSorted);
        }

        [DataTestMethod]
        [DataRow(new int[] { 4, 7, 2, 8, 9 }, new int[] { 9, 8, 7, 4, 2 })]
        [DataRow(new int[] { 12, 17, 23, 18, 29 }, new int[] { 29, 23, 18, 17, 12 })]
        [DataRow(new int[] { 4, 37, 56, 13, 1 }, new int[] { 56, 37, 13, 4, 1 })]
        public void SortUtility_ShouldSortDescending_UsingLambdaNotation(int[] toBeSorted, int[] expected)
        {
            SortUtility sortUtility = new SortUtility();
            toBeSorted = sortUtility.SelectionSort(toBeSorted, (int x, int y) => x > y);

            CollectionAssert.AreEqual(expected, toBeSorted);
        }

        [DataTestMethod]
        [DataRow(new int[] { 4, 7, 2, 8, 9 }, new int[] { 7, 9, 2, 4, 8 })]
        [DataRow(new int[] { 12, 17, 23, 18, 29 }, new int[] { 17, 23, 29, 12, 18 })]
        [DataRow(new int[] { 4, 37, 56, 13, 1 }, new int[] { 1, 13, 37, 4, 56 })]
        public void SortUtility_ShouldSortOddsThenEvens_UsingLambdaStatement(int[] toBeSorted, int[] expected)
        {
            SortUtility sortUtility = new SortUtility();
            toBeSorted = sortUtility.SelectionSort(toBeSorted, (int x, int y) =>
            {
                if (x % 2 == 1 && y % 2 == 1)
                    return x < y;
                else if (x % 2 == 1)
                    return true;
                else if (y % 2 == 1)
                    return false;
                else
                    return x < y;
            });

            CollectionAssert.AreEqual(expected, toBeSorted);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_IntNull()
        {
            SortUtility sortUtility = new SortUtility();
            sortUtility.SelectionSort(null, (int x, int y) => x > y);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_DelegateNull()
        {
            SortUtility sortUtility = new SortUtility();
            sortUtility.SelectionSort(new int[] { 2, 4, 3 }, null);
        }
    }
}
