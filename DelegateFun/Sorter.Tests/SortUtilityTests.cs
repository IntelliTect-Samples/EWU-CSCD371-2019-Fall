using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        public void Sort_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            var list = new[] { 5, 2, 7, 8, 3, 6, 1, 9, 0, 4 };
            var correct = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[] sorted = SortUtility.Sort(list, delegate(int i, int j)
                    {
                        return i < j;
                    });

            Assert.IsTrue(Enumerable.SequenceEqual(correct, sorted));
        }

        [TestMethod]
        public void Sort_ShouldSortDescending_UsingALambdaStatement()
        {
            var list = new[] { 5, 2, 7, 8, 3, 6, 1, 9, 0, 4 };
            var correct = new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

            int[] sorted = SortUtility.Sort(list, (i, j) =>
                    {
                        return i > j;
                    });

            Assert.IsTrue(Enumerable.SequenceEqual(correct, sorted));
        }

        [TestMethod]
        public void Sort_ShouldSortIdkInSomeOrder_UsingALambdaExpression()
        {
            var list = new[] { 5, 2, 7, 8, 3, 6, 1, 9, 0, 4 };
            var correct = new[] { 1, 0, 2, 3, 4, 5, 6, 9, 8, 7 };

            int[] sorted = SortUtility.Sort(list, (i, j) => i/2 <= j/3);

            Assert.IsTrue(Enumerable.SequenceEqual(correct, sorted));
        }

        [TestMethod]
        public void Sort_NullCompare_ThrowsException()
        {
            var list = new[] { 1, 2, 3 };

            Assert.ThrowsException<ArgumentNullException>(() => SortUtility.Sort(list, null!));
        }

        [TestMethod]
        public void Sort_NullList_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => SortUtility.Sort(null!, (i, j) => false));
        }
    }
}
