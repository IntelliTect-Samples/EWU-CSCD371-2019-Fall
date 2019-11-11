using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        public void Array_Constructor_CreatesSuccessfully()
        {
            // Arrange
            Array<string> sut = new Array<string>(12);

            // Act


            // Assert
            Assert.IsNotNull(sut);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Array_Constructor_ThrowsException()
        {
            // Arrange
            Array<string> sut = new Array<string>(-12);

            // Act

            // Assert
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(100)]
        [DataRow(110000)]
        public void Array_Add_AddsSuccessfully(int capacity)
        {
            // Arrange
            Array<int> sut = new Array<int>(capacity);

            // Act
            int i = 0;
            while(i < capacity)
            {
                sut.Add(i);
                i++;
            }

            // Assert
            i = 0;
            foreach(int value in sut)
            {
                Assert.AreEqual(i, value);
                i++;
            }

            Assert.AreEqual(capacity, sut.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Array_Add_ArrayMaxCapacityThrowsException()
        {
            // Arrange
            int capacity = 1;
            Array<int> sut = new Array<int>(capacity);

            // Act
            int i = 0;
            while (i < capacity)
            {
                sut.Add(i);
                i++;
            }

            // adding one more, throws here.
            sut.Add(42);

            // Assert

        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(-100)]
        [DataRow(0)]
        [ExpectedException(typeof(ArgumentException))]
        public void Array_Add_InvalidCapacityThrowsException(int capacity)
        {
            // Arrange
            Array<int> sut = new Array<int>(capacity);

            // Act

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Array_Add_ItemsIsNull()
        {
            // Arrange
            Array<int> sut = null;

            // Act
            sut.Add(1);

            // Assert

        }

        [TestMethod]
        public void Array_Clear_ClearsSuccessfully()
        {
            // Arrange
            int capacity = 12;
            Array<int> sut = new Array<int>(capacity);

            // Act
            int i = 0;
            while (i < capacity)
            {
                sut.Add(i);
                i++;
            }

            sut.Clear();

            // Assert
            Assert.AreEqual(0, sut.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Array_Clear_ItemsIsNull()
        {
            // Arrange
            Array<int> sut = null;

            // Act
            sut.Clear();

            // Assert
            
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Array_Contains_ItemsIsNull()
        {
            // Arrange
            Array<int> sut = null;

            // Act
            sut.Contains(12);

            // Assert

        }

        [TestMethod]
        public void Array_Contains_FindsTarget()
        {
            // Arrange
            int capacity = 12;
            Array<int> sut = new Array<int>(capacity);
            int i = 0;
            while (i < capacity)
            {
                sut.Add(i);
                i++;
            }

            // Act
            bool testVar = sut.Contains(10);

            // Assert
            Assert.IsTrue(testVar);
        }

        [TestMethod]
        public void Array_Contains_TargetNotInArray()
        {
            // Arrange
            int capacity = 12;
            Array<int> sut = new Array<int>(capacity);
            int i = 0;
            while (i < capacity)
            {
                sut.Add(i);
                i++;
            }

            // Act
            bool testVar = sut.Contains(100);

            // Assert
            Assert.IsFalse(testVar);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Array_CopyTo_ItemsIsNull()
        {
            // Arrange
            Array<int> sut = null;
            int[] temp = { 1, 2, 3 };

            // Act
            sut.CopyTo(temp, 1);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Array_CopyTo_ArrayIsNull()
        {
            // Arrange
            int capacity = 12;
            Array<int> sut = new Array<int>(capacity);
            int i = 0;
            while (i < capacity)
            {
                sut.Add(i);
                i++;
            }

            // Act
            sut.CopyTo(null, 1);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Array_CopyTo_IndexInvalid()
        {
            // Arrange
            int capacity = 12;
            Array<int> sut = new Array<int>(capacity);
            int i = 0;
            while (i < capacity)
            {
                sut.Add(i);
                i++;
            }
            int[] temp = { 1, 2, 3 };

            // Act
            sut.CopyTo(temp, 1);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Array_CopyTo_NotEnoughRoom()
        {
            // Arrange
            int capacity = 12;
            Array<int> sut = new Array<int>(capacity);
            int i = 0;
            while (i < capacity)
            {
                sut.Add(i);
                i++;
            }
            int[] temp = new int[1];

            // Act
            sut.CopyTo(temp, 0);

            // Assert

        }

        [TestMethod]
        public void Array_CopyTo_CopiesSuccessfully()
        {
            // Arrange
            int capacity = 12;
            Array<int> sut = new Array<int>(capacity);
            int i = 0;
            while (i < capacity)
            {
                sut.Add(i);
                i++;
            }
            int[] temp = new int[capacity];

            // Act
            sut.CopyTo(temp, 0);

            // Assert
            CollectionAssert.AreEqual(temp, sut.ToArray());
        }

        [DataTestMethod]
        [DataRow(100)]
        public void Array_Remove_RemovesSuccessfully(int capacity)
        {
            // Arrange
            Array<int> sut = new Array<int>(capacity);

            // Act
            int i = 0;
            while (i < capacity)
            {
                sut.Add(i);
                i++;
            }

            // Assert
            Assert.IsTrue(sut.Remove(42));
            Assert.IsTrue(sut.Remove(0));
            Assert.IsTrue(sut.Remove(99));
        }

        [DataTestMethod]
        [DataRow(100)]
        public void Array_Remove_TargetNotFound(int capacity)
        {
            // Arrange
            Array<int> sut = new Array<int>(capacity);

            // Act
            int i = 0;
            while (i < capacity)
            {
                sut.Add(i);
                i++;
            }

            // Assert
            Assert.IsFalse(sut.Remove(430));
            Assert.IsFalse(sut.Remove(1233));
            Assert.IsFalse(sut.Remove(20200));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Array_Remove_ItemsIsNull()
        {
            // Arrange
            Array<int> sut = null;

            // Act
            sut.Remove(1);
           
            // Assert
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Array_Remove_ItemIsNull()
        {
            // Arrange
            int capacity = 12;
            Array<Object> sut = new Array<Object>(capacity);
            int i = 0;
            while (i < capacity)
            {
                sut.Add(i);
                i++;
            }

            Object toRemove = null;

            // Act
            sut.Remove(toRemove);

            // Assert

        }
    }
}
