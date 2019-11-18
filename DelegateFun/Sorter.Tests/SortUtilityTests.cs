using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            int[] arr = { 3, 4, 1, 8, 10, 2, 100, 33 };
            int[] expectedResults = { 1, 2, 3, 4, 8, 10, 33, 100 };
            SortUtility.ComparisonDel del = delegate(int num1, int num2)
            {
                return num1 > num2;
            };
            SortUtility.InsertionSort(arr, del);
            for(int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(arr[i], expectedResults[i]);
            }
        }

        [TestMethod]
        public void SortUtility_ShouldSortDescending_UsingLambdaExpression()
        {
            int[] arr = { 3, 4, 1, 8, 10, 2, 100, 33 };
            int[] expectedResults = {100, 33, 10, 8, 4, 3, 2, 1};
            SortUtility.InsertionSort(arr, (num1, num2) =>
            {
                return num1 < num2;
            });
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(arr[i], expectedResults[i]);
            }
        }

        [TestMethod]
        public void SortUtility_ShouldSortOddsFirst_NonAscending_UsingLambdaStatement()
        {
            int[] arr = { 3, 4, 1, 8, 10, 2, 100, 33 };

            SortUtility.InsertionSort(arr, (num1, num2) => num2 % 2 != 0);

            //Expecting arr to be sorted as such: { odd, odd, odd, odd, even, even, even, even}
            //The sort does not also do subordering for each group ascending nor descending, just separates them
            bool isEvenFlag = false;
            foreach(int x in arr)
            {
                bool check = x % 2 == 0;
                if (check) isEvenFlag = true;
                if(isEvenFlag)
                {
                    Assert.IsTrue(check);
                }
                else
                {
                    Assert.IsFalse(check);
                }
            }
        }

        public bool CompareNum(int num1, int num2)
        {
            return num1 > num2;
        }
    }
}
