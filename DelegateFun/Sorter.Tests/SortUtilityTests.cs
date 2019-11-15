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
            Assert.IsTrue(IsSorted(testArray));
        }

        [TestMethod]
        public void SelectionSort_ShouldSortAscending_UsingLambdaExpression() {
            //Arrange
            int[] testArray = CreateRandomArray(200);

            //Act
            SelectionSort(testArray, (int first, int second) => first < second);

            //Assert
            Assert.IsTrue(IsSorted(testArray));
        }

        [TestMethod]
        public void SelectionSort_ShouldSortAscending_UsingLambdaStatement() {
            //Arrange
            int[] testArray = CreateRandomArray(200);

            //Act
            SelectionSort(testArray, (int first, int second) => { return first < second; });

            //Assert
            Assert.IsTrue(IsSorted(testArray));
        }

        public int[] CreateRandomArray(int length) {
            Random rand = new Random();
            int[] randomArray = new int[length];
            for (int i = 0; i < length; i++) {
                randomArray[i] = rand.Next();
            }
            return randomArray;
        }

        public bool IsSorted(int[] a) {
            for (int i = 1; i < a.Length; i++) {
                if (a[i] < a[i - 1]) {
                    return false;
                }
            }
            return true;
        }
    }
}
