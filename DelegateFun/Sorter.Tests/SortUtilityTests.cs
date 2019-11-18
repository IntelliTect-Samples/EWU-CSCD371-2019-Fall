using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        // contains a variety of values for testing
        private static int[] UnsortedList { get; } = new int[] { 4, 37, 1, 10, 5, 8, 24, 9, 3, 7, -6, 2, 11, 6 };

        private static int[] SortedList { get; } = new int[] { -6, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 24, 37 };
        private static int[] SortedReverseList { get; } = new int[] { 37, 24, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, -6 };
        private static int[] SortedLexigraphicallyList { get; } = new int[] { -6, 1, 10, 11, 2, 24, 3, 37, 4, 5, 6, 7, 8, 9 };

        //should be fine, since int is value type
        private static int[] GetUnsortedList() => (int[])UnsortedList.Clone();

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

            CollectionAssert.AreEqual(SortedList, items);
        }

        [TestMethod]
        public void SortUtility_ShouldSortDescending_UsingLambaStatement()
        {
            int[] items = GetUnsortedList();

            SortUtility.Sort(items, (i, j) =>
            {
                return i < j;
            });

            CollectionAssert.AreEqual(SortedReverseList, items);
        }

        [TestMethod]
        public void SortUtility_ShouldSortLexigraphicallyAscending_UsingLambdaExpression()
        {
            int[] items = GetUnsortedList();

            SortUtility.Sort(items, (i, j) => string.CompareOrdinal($"{i}", $"{j}") > 0);

            CollectionAssert.AreEqual(SortedLexigraphicallyList, items);
        }
    }
}
