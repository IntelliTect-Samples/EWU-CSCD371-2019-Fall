using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [DataTestMethod]
        [DataRow(new int[]{ 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [DataRow(new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 6, 2, 5, 7, 3, 9, 8, 4, 10, 1 })]
        [DataRow(new int[]{ 1, 123, 112343, 32987421, 432814732 }, new int[] { 432814732, 112343, 123, 1, 32987421 })]
        public void InsertionSort_ShouldSortAscending_UsingAnAnonymousMethod(int[] expected, int[] actual)
        {
            SortUtility sortUtility = new SortUtility();
            Compare compare = delegate(int num1, int num2) { return num1 > num2; };

            sortUtility.InsertionSort(actual, compare);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 6, 2, 5, 7, 3, 9, 8, 4, 10, 1 })]
        [DataRow(new int[] { 1, 123, 112343, 32987421, 432814732 }, new int[] { 432814732, 112343, 123, 1, 32987421 })]
        public void InsertionSort_ShouldSortAscending_UsingALambdaExpression(int[] expected, int[] actual)
        {
            SortUtility sortUtility = new SortUtility();
            Compare compare = (num1, num2) => num1 > num2;

            sortUtility.InsertionSort(actual, compare);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 6, 2, 5, 7, 3, 9, 8, 4, 10, 1 })]
        [DataRow(new int[] { 1, 123, 112343, 32987421, 432814732 }, new int[] { 432814732, 112343, 123, 1, 32987421 })]
        public void InsertionSort_ShouldSortAscending_UsingALambdaStatement(int[] expected, int[] actual)
        {
            SortUtility sortUtility = new SortUtility();

            sortUtility.InsertionSort(actual, (num1, num2) => num1 > num2);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, new int[] { 6, 2, 5, 7, 3, 9, 8, 4, 10, 1 })]
        [DataRow(new int[] { 432814732, 32987421, 112343, 123, 1 }, new int[] { 432814732, 112343, 123, 1, 32987421 })]
        public void InsertionSort_ShouldSortDescending_UsingAnAnonymousMethod(int[] expected, int[] actual)
        {
            SortUtility sortUtility = new SortUtility();
            Compare compare = delegate (int num1, int num2) { return num1 < num2; };

            sortUtility.InsertionSort(actual, compare);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, new int[] { 6, 2, 5, 7, 3, 9, 8, 4, 10, 1 })]
        [DataRow(new int[] { 432814732, 32987421, 112343, 123, 1 }, new int[] { 432814732, 112343, 123, 1, 32987421 })]
        public void InsertionSort_ShouldSortDescending_UsingALambdaExpression(int[] expected, int[] actual)
        {
            SortUtility sortUtility = new SortUtility();
            Compare compare = (num1, num2) => num1 < num2;

            sortUtility.InsertionSort(actual, compare);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, new int[] { 6, 2, 5, 7, 3, 9, 8, 4, 10, 1 })]
        [DataRow(new int[] { 432814732, 32987421, 112343, 123, 1 }, new int[] { 432814732, 112343, 123, 1, 32987421 })]
        public void InsertionSort_ShouldSortDescending_UsingALambdaStatement(int[] expected, int[] actual)
        {
            SortUtility sortUtility = new SortUtility();

            sortUtility.InsertionSort(actual, (num1, num2) => num1 < num2);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
