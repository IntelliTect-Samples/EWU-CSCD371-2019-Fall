using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Sorter;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [DataTestMethod]
        [DataRow(new int[] {3, 5, 1, 4, 2}, new int[] {1,2,3,4,5})]
        [DataRow(new int[] {5, 4, 3, 2, 1}, new int[] {1,2,3,4,5})]
        [DataRow(new int[] {1, 2, 3, 4, 5}, new int[] {1,2,3,4,5})]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod(int[] arr, int[] expected)
        {
            var sut = new SortUtility();

            Key key = delegate (int a, int b)
            {
                return a < b;
            };

            sut.QuickSort(arr, key);

            CollectionAssert.AreEqual(expected, arr);
        }

        [DataTestMethod]
        [DataRow(new int[] {3, 5, 1, 4, 2}, new int[] {5,4,3,2,1})]
        [DataRow(new int[] {5, 4, 3, 2, 1}, new int[] {5,4,3,2,1})]
        [DataRow(new int[] {1, 2, 3, 4, 5}, new int[] {5,4,3,2,1})]
        public void SortUtility_ShouldSortDescending_UsingAnAnonymousMethod(int[] arr, int[] expected)
        {
            var sut = new SortUtility();

            Key key = delegate (int a, int b)
            {
                return a > b;
            };

            sut.QuickSort(arr, key);

            CollectionAssert.AreEqual(expected, arr);
        }

        [DataTestMethod]
        [DataRow(new int[] {3, 5, 1, 4, 2}, new int[] {1,2,3,4,5})]
        [DataRow(new int[] {5, 4, 3, 2, 1}, new int[] {1,2,3,4,5})]
        [DataRow(new int[] {1, 2, 3, 4, 5}, new int[] {1,2,3,4,5})]
        public void SortUtility_ShouldSortAscending_UsingLambdaExpression(int[] arr, int[] expected)
        {
            var sut = new SortUtility();

            sut.QuickSort(arr, ((int a, int b) => a < b));

            CollectionAssert.AreEqual(expected, arr);
        }

        [DataTestMethod]
        [DataRow(new int[] {3, 5, 1, 4, 2}, new int[] {5,4,3,2,1})]
        [DataRow(new int[] {5, 4, 3, 2, 1}, new int[] {5,4,3,2,1})]
        [DataRow(new int[] {1, 2, 3, 4, 5}, new int[] {5,4,3,2,1})]
        public void SortUtility_ShouldSortDescending_UsingLambdaExpression(int[] arr, int[] expected)
        {
            var sut = new SortUtility();

            sut.QuickSort(arr, ((int a, int b) => a > b));

            CollectionAssert.AreEqual(expected, arr);
        }

        [DataTestMethod]
        [DataRow(new int[] {3, 5, 1, 4, 2}, new int[] {1,2,3,4,5})]
        [DataRow(new int[] {5, 4, 3, 2, 1}, new int[] {1,2,3,4,5})]
        [DataRow(new int[] {1, 2, 3, 4, 5}, new int[] {1,2,3,4,5})]
        public void SortUtility_ShouldSortAscending_UsingLambdaStatement(int[] arr, int[] expected)
        {
            var sut = new SortUtility();

            sut.QuickSort(arr, ((int a, int b) => { return a < b; }));

            CollectionAssert.AreEqual(expected, arr);
        }

        [DataTestMethod]
        [DataRow(new int[] {3, 5, 1, 4, 2}, new int[] {5,4,3,2,1})]
        [DataRow(new int[] {5, 4, 3, 2, 1}, new int[] {5,4,3,2,1})]
        [DataRow(new int[] {1, 2, 3, 4, 5}, new int[] {5,4,3,2,1})]
        public void SortUtility_ShouldSortDescending_UsingLambdaStatement(int[] arr, int[] expected)
        {
            var sut = new SortUtility();

            sut.QuickSort(arr, ((int a, int b) => { return a > b; }));

            CollectionAssert.AreEqual(expected, arr);
        }

        [TestMethod]
        public void SortUtility_ThrowsExceptionOnNullData()
        {
            var sut = new SortUtility();

            Assert.ThrowsException<ArgumentNullException>(
                    () => sut.QuickSort(null, ((int a, int b) => { return a > b; })));
        }

        [TestMethod]
        public void SortUtility_ThrowsExceptionOnNullKey()
        {
            var sut = new SortUtility();
            var data = new int[] { 1, 5, 4, 2 };

            Assert.ThrowsException<ArgumentNullException>(
                    () => sut.QuickSort(data, null));
        }
    }
}
