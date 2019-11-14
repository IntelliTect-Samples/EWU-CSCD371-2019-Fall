using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
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
        public void SortUtility_ShouldSortDescending_UsingALambdaStatement()
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
        public void SortUtility_ShouldSortDescending_UsingALambdaExpression()
        {
            var list = new[] { 5, 2, 7, 8, 3, 6, 1, 9, 0, 4 };
            var correct = new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

            int[] sorted = SortUtility.Sort(list, (i, j) => i > j);

            Assert.IsTrue(Enumerable.SequenceEqual(correct, sorted));
        }
    }
}
