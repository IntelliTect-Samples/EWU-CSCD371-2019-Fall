using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        private static readonly int[] _UnsortedList = new int[] { 4, 1, 10, 5, 8, 9, 3, 7, 2, 6 };

        private static readonly int[] _SortedList = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private static readonly int[] _SortedReverseList = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        private static readonly int[] _SortedLexigraphicallyList = new int[] { 1, 10, 2, 3, 4, 5, 6, 7, 8, 9 };

        //should be fine, since int is value type
        private static int[] GetUnsortedList() => (int[])_UnsortedList.Clone();


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_NullArray_Throws()
        {
            SortUtility.Sort(null!, (i,j) => i < j);

            // should throw and exit before reaching this statement
            Assert.Fail();
        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            int[] items = GetUnsortedList();

            SortUtility.Sort(items, delegate (int i, int j)
            {
                return i > j;
            });

            for (int i = 0; i < items.Length; i++)
            {
                Assert.AreEqual<int>(_SortedList[i], items[i]);
            }
        }

        [TestMethod]
        public void SortUtility_ShouldSortDescending_UsingLambaStatement()
        {
            int[] items = GetUnsortedList();

            SortUtility.Sort(items, (i, j) =>
            {
                return i < j;
            });

            for (int i = 0; i < items.Length; i++)
            {
                Assert.AreEqual<int>(_SortedReverseList[i], items[i]);
            }
        }

        [TestMethod]
        public void SortUtility_ShouldSortLexigraphicallyAscending_UsingLambdaExpression()
        {
            int[] items = GetUnsortedList();

            SortUtility.Sort(items, (i, j) => string.CompareOrdinal($"{i}", $"{j}") > 0);

            for (int i = 0; i < items.Length; i++)
            {
                Assert.AreEqual<int>(_SortedLexigraphicallyList[i], items[i]);
            }
        }
    }
}
