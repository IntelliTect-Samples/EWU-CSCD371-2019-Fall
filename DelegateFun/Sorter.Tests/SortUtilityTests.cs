using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Sorter.SortUtility;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        static Random _Random = new Random();

        private int[] GetArray()
        {
            int[] intArray = Enumerable
            .Repeat(0, 100)
            .Select(i => _Random.Next(0, 100))
            .ToArray();
            return intArray;
        }

        public static bool GreaterThan(int first, int second) => first > second;
        public static bool LessThan(int first, int second) => first < second;
        public static bool Alphabetical(int first, int second) =>
            (string.Compare(first.ToString(), second.ToString(), StringComparison.CurrentCulture)) > 0;



        public static bool IsSorted(int[] array, Func<int, int, bool> compare)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (compare(array[i], array[i + 1]))
                    return false;
            }
            return true;
        }

        Compare _Comparer = delegate (int num1, int num2)
        {
            return num1 < num2;
        };

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            int[] items = GetArray();
            SortUtility.Sort(items, _Comparer);

            Assert.IsTrue(IsSorted(items, GreaterThan));
        }

        [TestMethod]
        public void SortUtility_ShouldSortDescending_UsingLambdaExpression()
        {
            int[] items = GetArray();

            SortUtility.Sort(items,
                (int num1, int num2) => num1 > num2);

            Assert.IsTrue(IsSorted(items, LessThan));
        }

        [TestMethod]
        public void SortUtility_ShouldSortAlphabetically_UsingLambdaStatement()
        {
            int[] items = GetArray();

            SortUtility.Sort(items,
                (int num1, int num2) =>
                {
                    return string.Compare(num1.ToString(), num2.ToString(), StringComparison.Ordinal) < 0;
                });

            Assert.IsTrue(IsSorted(items, Alphabetical));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_PassedArrayIsNull_ThrowsException()
        {
            int[] items = null;

            SortUtility.Sort(items, _Comparer);
        }
    }
}
