using Assignment6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace Assignmnet6.tests {
    [TestClass]
    public class ArrayTests {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_ThrowsArgumentNullException() {
            //Arrange

            //Act
            MyArray<int> array = new MyArray<int>(-1);

            //Assert
        }

        [TestMethod]
        public void Constructor_CreatesNewArray() {
            //Arrange
            MyArray<int> array = new MyArray<int>(10);

            //Act

            //Assert
            Assert.AreEqual(10, array.Capacity);
            Assert.AreEqual(10, array.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_ThrowsArgumentNullException() {
            //Arrange
            MyArray<int?> array = new MyArray<int?>(10)
            {

                //Act
                null
            };

            //Assert
        }

        [TestMethod]
        public void Add_AddsItemsCorrectly() {
            //Arrange

            //Act
            MyArray<int?> array = CreateIntMyArray(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //Assert
            for (int i = 1; i <= 10; i++) {
                Assert.IsTrue(array.Contains(i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Add_ThrowsExceptionForFullArray() {
            //Arrange

            //Act
            MyArray<int?> array = CreateIntMyArray(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });

            //Assert
        }

        [TestMethod]
        public void Clear_Clears() {
            //Arrange
            MyArray<int?> array = CreateIntMyArray(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //Act
            array.Clear();

            //Assert
            for (int i = 1; i <= 10; i++) {
                Assert.IsFalse(array.Contains(i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Contains_ThrowsArgumentNullException() {
            //Arrange
            MyArray<int?> array = CreateIntMyArray(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //Act
            array.Contains(null);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CopyTo_ThrowsIndexOutOfRangeExceptionForNegative() {
            //Arrange
            MyArray<int?> array = CreateIntMyArray(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //Act
            array.CopyTo(new int?[0], -1);

            //Arrange
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CopyTo_ThrowsIndexOutOfRangeExceptionForTooBigIndex() {
            //Arrange
            MyArray<int?> array = CreateIntMyArray(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //Act
            array.CopyTo(new int?[0], 11);

            //Arrange
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CopyTo_ThrowsNullReferenceException() {
            //Arrange
            MyArray<int?> array = CreateIntMyArray(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //Act
            array.CopyTo(null, 1);

            //Assert
        }

        [TestMethod]
        public void CopyTo_CopiesEntireCorrectly() {
            //Arrange
            int[] origional = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MyArray<int?> array = CreateIntMyArray(10, origional);
            int?[] array2 = new int?[array.Capacity];

            //Act
            array.CopyTo(array2, 0);

            //Assert
            for (int i = 0; i < origional.Length; i++) {
                Assert.AreEqual(origional[i], array2[i]);
            }
        }
        [TestMethod]
        public void CopyTo_CopiesPartialCorrectly() {
            //Arrange
            int[] origional = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MyArray<int?> array = CreateIntMyArray(10, origional);
            int?[] array2 = new int?[array.Capacity - 5];

            //Act
            array.CopyTo(array2, 5);

            //Assert
            for (int i = 5; i < origional.Length; i++) {
                Assert.AreEqual(origional[i], array2[i - 5]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Remove_ThrowsArgumentNullException() {
            //Arrange
            MyArray<int?> array = CreateIntMyArray(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //Act
            array.Remove(null);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Remove_RemovesAtZero() {
            //Arrange
            MyArray<int?> array = CreateIntMyArray(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //Act
            bool didRemove = array.Remove(1);

            //Assert
            Assert.IsTrue(didRemove);
            array.GetData(0);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Remove_RemovesAtEnd() {
            //Arrange
            MyArray<int?> array = CreateIntMyArray(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //Act
            bool didRemove = array.Remove(10);

            //Assert
            Assert.IsTrue(didRemove);
            array.GetData(9);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Remove_RemovesInMiddle() {
            //Arrange
            MyArray<int?> array = CreateIntMyArray(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //Act
            bool didRemove = array.Remove(5);

            //Assert
            Assert.IsTrue(didRemove);
            array.GetData(4);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetData_ThrowsIndexOutOfRangeExceptionForTooBigIndex() {
            //Arrange
            MyArray<int?> array = CreateIntMyArray(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //Act
            array.CopyTo(new int?[0], 10);

            //Arrange
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetData_ThrowsIndexOutOfRangeExceptionForTooSmallIndex() {
            //Arrange
            MyArray<int?> array = CreateIntMyArray(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //Act
            array.CopyTo(new int?[0], -1);

            //Arrange
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetData_ThrowsNullReferecnceException() {
            //Arrange
            MyArray<int?> array = CreateIntMyArray(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //Act
            array.Remove(6);
            array.GetData(5);

            //Arrange
        }

        [TestMethod]
        public void GetData_GetsData() {
            //Arrange
            MyArray<int?> array = CreateIntMyArray(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //Act

            //Assert
            Assert.AreEqual(array.GetData(3), 4);
        }

        [TestMethod]
        public void IEnumerator_Works() {
            //Arrange
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MyArray<int?> array = CreateIntMyArray(10, a);
            ArrayList list = new ArrayList();

            //Act
            foreach (int item in array) {
                list.Add(item);
            }
            object[] b = list.ToArray();

            //Assert
            for (int i = 0; i < list.Count; i++) {
                Assert.AreEqual(a[i], b[i]);
            }
        }

        private MyArray<int?> CreateIntMyArray(int capacity, int[] values) {
            MyArray<int?> array = new MyArray<int?>(capacity);

            foreach (int value in values) {
                array.Add(value);
            }

            return array;
        }
    }
}
