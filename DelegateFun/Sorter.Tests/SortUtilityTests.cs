using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        private static readonly int[] _UnsortedList = new int[] { 4, 37, 1, 10, 5, 8, 24, 9, 3, 7, 2, 11, 6 };

        private static readonly int[] _SortedList = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 24, 37 };
        private static readonly int[] _SortedReverseList = new int[] { 37, 24, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        private static readonly int[] _SortedLexigraphicallyList = new int[] { 1, 10, 11, 2, 24, 3, 37, 4, 5, 6, 7, 8, 9 };

        //should be fine, since int is value type
        private static int[] GetUnsortedList() => (int[])_UnsortedList.Clone();

        [TestMethod]
        public void SortUtility_NullArray_Throws()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
                SortUtility.Sort(null!, (i, j) => i < j)
            );
        }

        [TestMethod]
        public void SortUtility_NullDelegate_Throws()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
               SortUtility.Sort(GetUnsortedList(), null!)
            );
        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            int[] items = GetUnsortedList();

            SortUtility.Sort(items, delegate (int i, int j)
            {
                return i > j;
            });

            Assert.IsTrue(Enumerable.SequenceEqual<int>(items, _SortedList));
        }

        [TestMethod]
        public void SortUtility_ShouldSortDescending_UsingLambaStatement()
        {
            int[] items = GetUnsortedList();

            SortUtility.Sort(items, (i, j) =>
            {
                return i < j;
            });

            Assert.IsTrue(Enumerable.SequenceEqual<int>(items, _SortedReverseList));
        }

        [TestMethod]
        public void SortUtility_ShouldSortLexigraphicallyAscending_UsingLambdaExpression()
        {
            int[] items = GetUnsortedList();

            SortUtility.Sort(items, (i, j) => string.CompareOrdinal($"{i}", $"{j}") > 0);

            Assert.IsTrue(Enumerable.SequenceEqual<int>(items, _SortedLexigraphicallyList));
        }
    }
}
