using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static Sorter.SortUtility;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            int[] arr = { 9, 1, 3, 4, 2, 5, 7, 8, 6 };
            int[] orderArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            SortUtility sortUtility = new SortUtility();
            MyFunc myFunc = delegate (int first, int second) { return first < second; };

            arr = sortUtility.Sort(arr, myFunc);

            Assert.IsTrue(arr.SequenceEqual(orderArr));
        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingALambdaStatement()
        {
            int[] arr = { 9, 1, 3, 4, 2, 5, 7, 8, 6 };
            int[] orderArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            SortUtility sortUtility = new SortUtility();
            arr = sortUtility.Sort(arr, (int first, int second) => { return first < second; });

            Assert.IsTrue(arr.SequenceEqual(orderArr));
        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingALambdaExpression()
        {
            int[] arr = { 9, 1, 3, 4, 2, 5, 7, 8, 6 };
            int[] orderArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            SortUtility sortUtility = new SortUtility();
            arr = sortUtility.Sort(arr, (int first, int second) => first < second);

            Assert.IsTrue(arr.SequenceEqual(orderArr));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_ShouldSortAscending_PassingNull()
        {
            SortUtility sortUtility = new SortUtility();

            sortUtility.Sort(null, (int first, int second) => { return first < second; });
        }
    }
}
