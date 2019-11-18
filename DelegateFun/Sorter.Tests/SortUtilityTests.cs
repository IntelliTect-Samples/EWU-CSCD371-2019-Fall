using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Sorter;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [DataTestMethod]
        [DataRow(new int[] {3, 5, 1, 4, 2})]
        [DataRow(new int[] {5, 4, 3, 2, 1})]
        [DataRow(new int[] {1, 2, 3, 4, 5})]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod(int[] arr)
        {
            var sut = new SortUtility();

            Key key = delegate (int a, int b)
            {
                return a > b;
            };

            int[] expected = arr;
            
            Array.Sort(expected);

            sut.QuickSort(arr, key);

            Assert.AreEqual(expected, arr);
        }

        [DataTestMethod]
        [DataRow(new int[] {3, 5, 1, 4, 2})]
        [DataRow(new int[] {5, 4, 3, 2, 1})]
        [DataRow(new int[] {1, 2, 3, 4, 5})]
        public void SortUtility_ShouldSortDescending_UsingAnAnonymousMethod(int[] arr)
        {
            var sut = new SortUtility();

            Key key = delegate (int a, int b)
            {
                return a < b;
            };

            int[] expected = arr;
            
            Array.Sort(expected);
            Array.Reverse(expected);

            sut.QuickSort(arr, key);

            Assert.AreEqual(expected, arr);
        }

        [DataTestMethod]
        [DataRow(new int[] {3, 5, 1, 4, 2})]
        [DataRow(new int[] {5, 4, 3, 2, 1})]
        [DataRow(new int[] {1, 2, 3, 4, 5})]
        public void SortUtility_ShouldSortAscending_UsingLambdaExpression(int[] arr)
        {
        }

        [DataTestMethod]
        [DataRow(new int[] {3, 5, 1, 4, 2})]
        [DataRow(new int[] {5, 4, 3, 2, 1})]
        [DataRow(new int[] {1, 2, 3, 4, 5})]
        public void SortUtility_ShouldSortDescending_UsingLambdaExpression(int[] arr)
        {
        }

        [DataTestMethod]
        [DataRow(new int[] {3, 5, 1, 4, 2})]
        [DataRow(new int[] {5, 4, 3, 2, 1})]
        [DataRow(new int[] {1, 2, 3, 4, 5})]
        public void SortUtility_ShouldSortAscending_UsingLambdaStatement(int[] arr)
        {
        }

        [DataTestMethod]
        [DataRow(new int[] {3, 5, 1, 4, 2})]
        [DataRow(new int[] {5, 4, 3, 2, 1})]
        [DataRow(new int[] {1, 2, 3, 4, 5})]
        public void SortUtility_ShouldSortDescending_UsingLambdaStatement(int[] arr)
        {
        }
    }
}
