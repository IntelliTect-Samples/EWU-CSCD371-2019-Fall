using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        public void Constructor_FixedWidth_NoErrors()
        {
            _ = new Array<int>(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_NegativeWidth_ThrowsException()
        {
            //Arrange
            //Act
            _ = new Array<int>(-1);
            //Assert
        }

        [TestMethod]
        public void Constructor_GoodWidth_ReturnsCorrectCount()
        {
            //Arrange
            Array<int> array = new Array<int>(1);
            //Act
            int count = array.Count;
            //Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Add_OneItem_ReturnsCorrectCount()
        {
            //Arrange
            Array<int> array = new Array<int>(1);
            //Act
            array.Add(1);
            //Assert
            Assert.AreEqual(1, array.Count);
        }

        [TestMethod]
        public void Add_OneItem_ContainsItem()
        {
            //Arrange
            Array<int> array = new Array<int>(1);
            //Act
            array.Add(1);
            //Assert
            Assert.IsTrue(array.Contains(1));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_MoreThanCapacity_ThrowsException()
        {
            //Arrange
            Array<int> array = new Array<int>(0);
            //Act
            array.Add(1);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_NullParameter_ThrowsException()
        {
            //Arrange
            Array<string?> array = new Array<string?>(0);
            //Act
            array.Add(null);
            //Assert
        }

        [TestMethod]
        public void Contains_OneItem_ReturnsTrue()
        {
            //Arrange
            Array<int> array = new Array<int>(1)
            {
                1
            };
            //Act
            bool containsOne = array.Contains(1);
            //Assert
            Assert.IsTrue(containsOne);
        }

        [TestMethod]
        public void Contains_TwoItems_ReturnsTrue()
        {
            //Arrange
            Array<int> array = new Array<int>(2);
            array.Add(1);
            array.Add(2);
            //Act
            bool containsOne = array.Contains(1);
            bool containsTwo = array.Contains(2);
            //Assert
            Assert.IsTrue(containsOne);
            Assert.IsTrue(containsTwo);
        }

        [TestMethod]
        public void Contains_NoItems_ReturnsFalse()
        {
            //Arrange
            Array<int> array = new Array<int>(0);
            //Act
            bool conatinsOne = array.Contains(1);
            //Assert
            Assert.IsFalse(conatinsOne);
        }

        [TestMethod]
        public void Contains_OneItem_ReturnsFalse()
        {
            //Arrange
            Array<int> array = new Array<int>(1);
            array.Add(1);
            //Act
            bool containsTwo = array.Contains(2);
            //Assert
            Assert.IsFalse(containsTwo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Contains_NullParameter_ThrowsException()
        {
            //Arrange
            Array<string?> array = new Array<string?>(0);
            //Act
            array.Contains(null);
            //Assert
        }

        [TestMethod]
        public void Clear_OneItem_ReturnsCorrectCount()
        {
            //Arrange
            Array<int> array = new Array<int>(1);
            array.Add(1);
            //Act
            array.Clear();
            //Assert
            Assert.AreEqual(0, array.Count);
        }

        [TestMethod]
        public void Clear_OneItem_ArrayDoesNotContainItem()
        {
            //Arrange
            Array<int> array = new Array<int>(1);
            array.Add(1);
            //Act
            array.Clear();
            //Assert
            Assert.IsFalse(array.Contains(1));
        }

        [TestMethod]
        public void Clear_TwoItems_ArrayDoesNotContainItems()
        {
            //Arrange
            Array<int> array = new Array<int>(2);
            array.Add(1);
            array.Add(2);
            //Act
            array.Clear();
            //Assert
            Assert.IsFalse(array.Contains(1));
            Assert.IsFalse(array.Contains(2));
        }

        [TestMethod]
        public void CopyTo_EmptyArray_ReturnsCorrectSizeArray()
        {
            //Arrange
            Array<int> array = new Array<int>(0);
            int[] copiedArray = Array.Empty<int>();
            //Act
            array.CopyTo(copiedArray, 0);
            //Assert
            Assert.IsTrue(copiedArray.Length == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CopyTo_NullArray_ThrowsException()
        {
            //Arrange
            Array<int> array = new Array<int>(0);
            int[]? copiedArray = null;
            //Act
#pragma warning disable CS8604 // Intentionall null reference to throw excpetion
            array.CopyTo(copiedArray, 0);
#pragma warning restore CS8604
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyTo_BadIndex_ThrowsException()
        {
            //Arrange
            Array<int> array = new Array<int>(0);
            int[] copiedArray = Array.Empty<int>();
            //Act
            array.CopyTo(copiedArray, -1);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CopyTo_ArrayTooSmall_ThrowsException()
        {
            //Arrange
            Array<int> array = new Array<int>(1);
            array.Add(1);
            int[] copiedArray = Array.Empty<int>();
            //Act
            array.CopyTo(copiedArray, 0);
            //Assert
        }

        [TestMethod]
        public void CopyTo_OneItem_Success()
        {
            //Arrange
            Array<int> array = new Array<int>(1);
            array.Add(1);
            int[] copiedArray = new int[1];
            //Act
            array.CopyTo(copiedArray, 0);
            //Assert
            Assert.AreEqual(1, copiedArray[0]);
        }

        [TestMethod]
        public void CopyTo_TwoItems_Success()
        {
            //Arrange
            Array<int> array = new Array<int>(2);
            array.Add(1);
            array.Add(2);
            int[] copiedArray = new int[2];
            //Act
            array.CopyTo(copiedArray, 0);
            //Assert
            Assert.AreEqual(1, copiedArray[0]);
            Assert.AreEqual(2, copiedArray[1]);
        }

        [TestMethod]
        public void CopyTo_IndexNotZero_Success()
        {
            //Arrange
            Array<int> array = new Array<int>(2);
            array.Add(1);
            array.Add(2);
            int[] copiedArray = new int[3];
            //Act
            array.CopyTo(copiedArray, 1);
            //Assert
            Assert.AreEqual(1, copiedArray[1]);
            Assert.AreEqual(2, copiedArray[2]);
        }

        [TestMethod]
        public void Remove_OneItem_ReturnsTrue()
        {
            //Arrange
            List<int> array = new List<int>(1);
            array.Add(1);
            //Act
            bool removed = array.Remove(1);
            //Assert
            Assert.IsTrue(removed);
        }

        [TestMethod]
        public void Remove_OneItem_ArrayDoesNotContainItem()
        {
            //Arrange
            List<int> array = new List<int>(1);
            array.Add(1);
            //Act
            array.Remove(1);
            //Assert
            Assert.IsFalse(array.Contains(1));
        }

        [TestMethod]
        public void Remove_TwoSameItems_ArrayCountIsOne()
        {
            //Arrange
            Array<int> array = new Array<int>(2);
            array.Add(1);
            array.Add(1);
            //Act
            array.Remove(1);
            //Assert
            Assert.AreEqual(1, array.Count);
        }

        [TestMethod]
        public void Remove_TwoSameItems_ArrayContainsOneOfTheItems()
        {
            //Arrange
            Array<int> array = new Array<int>(2);
            array.Add(1);
            array.Add(1);
            //Act
            array.Remove(1);
            //Assert
            Assert.IsTrue(array.Contains(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Remove_NullParameter_ThrowsException()
        {
            //Arrange
            Array<string?> array = new Array<string?>(0);
            //Act
            _ = array.Remove(null);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Remove_ItemDoesntExist_ThrowsException()
        {
            //Arrange
            Array<int> array = new Array<int>(0);
            //Act
            array.Remove(1);
            //Assert
        }

        [TestMethod]
        public void ForEach_ArrayWithItems_CanIterate()
        {
            //Arrange
            Array<int> array = new Array<int>(2);
            array.Add(1);
            array.Add(2);
            List<int> recievedData = new List<int>();
            //Act
            foreach (int i in array)
            {
                recievedData.Add(i);
            }
            //Assert
            Assert.IsTrue(recievedData.Contains(1));
            Assert.IsTrue(recievedData.Contains(2));
            Assert.IsTrue(recievedData.Count == 2);
        }

        [TestMethod]
        public void IndexOperator_OneItem_ReturnsCorrectItem()
        {
            //Arrange
            Array<int> array = new Array<int>(1);
            array.Add(1);
            //Act
            int result = array[0];
            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void IndexOperator_OneItem_SetsItemCorrectly()
        {
            //Arrange
            Array<int> array = new Array<int>(1);
            array.Add(1);
            //Act
            array[0] = 2;
            //Assert
            Assert.IsTrue(array.Contains(2));
            Assert.IsTrue(array.Count == 1);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(1)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexOperator_GetInvalidIndex_ThrowsException(int invalidIndex)
        {
            //Arrange
            Array<int> array = new Array<int>(0);
            //Act
            _ = array[invalidIndex];
            //Assert
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(1)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexOperator_SetInvalidIndex_ThrowsException(int invalidIndex)
        {
            //Arrange
            Array<int> array = new Array<int>(0);
            //Act
            array[invalidIndex] = 1;
            //Assert
        }
    }
}