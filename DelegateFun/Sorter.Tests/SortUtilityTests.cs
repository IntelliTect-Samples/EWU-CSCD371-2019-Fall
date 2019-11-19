using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorter.Tests
{

    [TestClass]
    public class SortUtilityTests
    {

        [DataTestMethod]
        [DataRow(new[] {0})]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_GivenNull_ThrowsException(int[] array)
        {
            var sortUtility = new SortUtility();
            if (array is null)
            {
                sortUtility.InsertionSort(null, (x, y) => x > y);
            }

            sortUtility.InsertionSort(array, null);
        }

        [DataTestMethod]
        [DataRow(new[] {3, 2, 5, 8, 7, 1, 9, 4, 0, 6}, new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9})]
        [DataRow(new[] {10, 1238, 23, 29, 0, 13, 2}, new[] {0, 2, 10, 13, 23, 29, 1238})]
        [DataRow(new[] {0, 0, 0, 1, 2, 1, 0, 0, 0}, new[] {0, 0, 0, 0, 0, 0, 1, 1, 2})]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod(int[] array, int[] expected)
        {
            var sortUtility = new SortUtility();

            Comparison comparison = delegate(int x, int y)
            {
                if (x < y) return true;
                return false;
            };

            sortUtility.InsertionSort(array, comparison);

            CollectionAssert.AreEqual(expected, array);
        }

        [DataTestMethod]
        [DataRow(new[] {1, 3, 5, 7, 9}, new[] {9, 7, 5, 3, 1})]
        [DataRow(new[] {10, 100, 1000, 10000, 1, 0, 5}, new[] {10000, 1000, 100, 10, 5, 1, 0})]
        public void SortUtility_ShouldSortDescending_UsingLambdaExpression(int[] array, int[] expected)
        {
            var sortUtility = new SortUtility();

            sortUtility.InsertionSort(array, (x, y) => x > y);

            CollectionAssert.AreEqual(expected, array);
        }

        [DataTestMethod]
        [DataRow(new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20},
            new[] {10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0})]
        [DataRow(new[] {0, 20, 1, 19, 2, 18, 3, 17, 4, 16, 5, 15, 6, 14, 7, 13, 8, 12, 9, 11, 10},
            new[] {10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0})]
        public void SortUtility_ShouldAscendAbove10_ThenDescend(int[] array, int[] expected)
        {
            var sortUtility = new SortUtility();

            sortUtility.InsertionSort(array,
                                      (x, y) =>
                                      {
                                          if (x < 10 || y < 10)
                                          {
                                              return x > y;
                                          }

                                          return x < y;
                                      });

            CollectionAssert.AreEqual(expected, array);
        }

    }

}
