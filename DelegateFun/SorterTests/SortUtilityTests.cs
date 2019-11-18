using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sorter.Tests
{
    [TestClass()]
    public class SortUtilityTests
    {
        [TestMethod]
        public void SortAscendingMethod()
        {
            //Arrange
            int[] items = generateArray();

            //Act
            SortUtility.Sort(items, delegate (int first, int second)
            {
                return first > second;
            });

            //Assert
            for (int ix = 0; ix < items.Length - 1; ix++)
            {
                Assert.IsTrue(items[ix] <= items[ix + 1]);
            }
        }

        [TestMethod]
        public void SortAscendingLambdaStatement()
        {
            //Arrange
            int[] items = generateArray();

            //Act
            SortUtility.Sort(items, (first, second) =>
            {
                return first > second;
            });

            //Assert
            for (int ix = 0; ix < items.Length - 1; ix++)
            {
                Assert.IsTrue(items[ix] <= items[ix + 1]);
            }
        }

        [TestMethod]
        public void SortAscendingLambdaExpression()
        {
            //Arrange
            int[] items = generateArray();

            //Act
            SortUtility.Sort(items, (first, second) => first > second);

            //Assert
            for (int ix = 0; ix < items.Length - 1; ix++)
            {
                Assert.IsTrue(items[ix] <= items[ix + 1]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortNullArrayThrowsException()
        {
            //Arrange

            //Act
            SortUtility.Sort(null, (first, second) => first > second);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullDelegateThrowsException()
        {
            //Arrange
            int[] items = generateArray();

            //Act
            SortUtility.Sort(items, null);

            //Assert
        }

        public int[] generateArray()
        {
            int[] result = new int[10];
            Random random = new Random();

            for (int ix = 0; ix < result.Length; ix++)
            {
                result[ix] = random.Next(1, 26);
            }

            return result;
        }
    }
}