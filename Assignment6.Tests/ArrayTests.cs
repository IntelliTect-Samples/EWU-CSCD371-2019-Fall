using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-10000)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArrayNegWidthThrowException(int width)
        {
            _ = new Array<int>(width);
        }


        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void ArrayAddSuccess(int item)
        {
            Array<int> array = new Array<int>(3)
            {
                item
            };

            Assert.IsTrue(array.Contains(item));
        }

        [TestMethod]        
        [ExpectedException(typeof(ArgumentException))]
        public void ArrayAddCapacityIsFull()
        {
            Array<int> array = new Array<int>(3)
            {
                1,
                2,
                3
            };

            array.Add(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArrayAddNullItem()
        {
            Array<String> array = new Array<String>(3)
            {
                "1",
                "2"
            };
            string item = null;
            array.Add(item);
        }

        [TestMethod]
        public void ArrayClearSuccess()
        {
            Array<int> array = new Array<int>(2)
            {
                1,
                2
            };
            array.Clear();

            Assert.IsTrue(array.Count == 0);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        public void ArrayContainsReturnsItem(int item)
        {
            Array<int> array = new Array<int>(5)
            {
                1,
                2,
                3,
                4,
                5
            };

            Assert.IsTrue(array.Contains(item));
        }

        [DataTestMethod]
        [DataRow(6)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        public void ArrayContainsDoesNotContain(int item)
        {
            Array<int> array = new Array<int>(5)
            {
                1,
                2,
                3,
                4,
                5
            };

            Assert.IsFalse(array.Contains(item));
        }

        [TestMethod]
        public void ArrayCopyToSuccess()
        {
            Array<int> arr = new Array<int>(3)
            {
                1
            };

            int[] intArray = new int[3];
            arr.CopyTo(intArray, 0);

            Assert.AreEqual(1, intArray[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArrayCopyToThrowsException()
        {
            Array<int> arr = new Array<int>(3)
            {
                1
            };

            int[] intArray = null;
            arr.CopyTo(intArray, 0);

            Assert.AreEqual(1, intArray[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArrayCopyToIndexOutOfBounds()
        {
            Array<int> arr = new Array<int>(3)
            {
                1
            };

            int[] intArray = new int[3];
            arr.CopyTo(intArray, 4);

            Assert.AreEqual(1, intArray[0]);
        }

        [TestMethod]
        public void ArrayGetEnumeratorSuccess()
        {
            Array<int> arr = new Array<int>(3)
            {
                1,
                2
            };

            Assert.IsNotNull(arr.GetEnumerator());
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        public void ArrayRemoveSuccess(int item)
        {
            Array<int> array = new Array<int>(5)
            {
                1,
                2,
                3,
                4,
                5
            };

            Assert.IsTrue(array.Remove(item));
        }

        [DataTestMethod]
        [DataRow(6)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        public void ArrayRemovesDoesNotContain(int item)
        {
            Array<int> array = new Array<int>(5)
            {
                1,
                2,
                3,
                4,
                5
            };

            Assert.IsFalse(array.Remove(item));
        }

        [TestMethod]
        public void ArrayIEnumurableGetEnumeratorSuccess()
        {
            Array<int> arr = new Array<int>(3)
            {
                1,
                2
            };

            Assert.IsNotNull(arr.GetEnumerator());
        }
    }
}
