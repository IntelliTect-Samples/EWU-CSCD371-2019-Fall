using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Sorter.SortUtility;

namespace Sorter.Tests {
    [TestClass]
    public class SortUtilityTests {
        [TestMethod]
        public void SelectionSort_ShouldSortAscending_UsingAnAnonymousMethod() {
            //Arrange
            int[] testArray = CreateRandomArray(200);

            //Act
            SelectionSort(testArray, delegate (int first, int second) { return first < second; });

            //Assert
            Assert.IsTrue(IsSortedNumberValueInOrder(testArray));
        }

        [TestMethod]
        public void SelectionSort_ShouldSortAscending_UsingLambdaExpression() {
            //Arrange
            int[] testArray = CreateRandomArray(200);

            //Act
            SelectionSort(testArray, (int first, int second) => first > second);

            //Assert
            Assert.IsTrue(IsSortedNumberValueInOrderReverse(testArray));
        }

        [TestMethod]
        public void SelectionSort_ShouldSortAscending_UsingLambdaStatement() {
            //Arrange
            int[] testArray = CreateRandomArray(200);

            //Act
            SelectionSort(testArray, (int first, int second) =>
            {
                if (first.ToString().Length == second.ToString().Length) {
                    return first < second;
                } else {
                    return first.ToString().Length > second.ToString().Length;
                }
            });
            Console.WriteLine(string.Join(",", testArray));
            //Assert
            Assert.IsTrue(IsSortedNumberLengthInOrderReverseThenNumberValueInOrder(testArray));
        }

        public int[] CreateRandomArray(int length) {
            Random rand = new Random();
            int[] randomArray = new int[length];
            for (int i = 0; i < length; i++) {
                randomArray[i] = rand.Next(9999);
            }
            return randomArray;
        }

        public bool IsSortedNumberValueInOrder(int[] a) {
            for (int i = 1; i < a.Length; i++) {
                if (a[i] < a[i - 1]) {
                    return false;
                }
            }
            return true;
        }

        public bool IsSortedNumberValueInOrderReverse(int[] a) {
            for (int i = 1; i < a.Length; i++) {
                if (a[i] > a[i - 1]) {
                    return false;
                }
            }
            return true;
        }

        public bool IsSortedNumberLengthInOrderReverseThenNumberValueInOrder(int[] a) {
            for (int i = 1; i < a.Length; i++) {
                if (a[i].ToString().Length > a[i - 1].ToString().Length || (a[i].ToString().Length == a[i - 1].ToString().Length && a[i] < a[i - 1])) {
                    return false;
                }
            }
            return true;
        }
    }
}
