using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment6;
using System.Collections.Generic;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void ArrayConstructor_BadSize_ThrowsException()
        {
            var sut = new Array<int>(-1);
        }

        [DataTestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        [DataRow(-1)]
        [DataRow(1)]
        public void ArrayIndex_OutOfRange_ThrowsInvalidOperationException(int index)
        {
            var sut = new Array<int>();
            var _ = sut[index];
        }

        [TestMethod]
        public void ArrayIndexer_ReturnsValue_Success()
        {
            int value = 1;
            var sut = new Array<int>(1);
            sut.Add(value);
            Assert.AreEqual(value, sut[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void ArraySet_OutOfRange_ThrowsException()
        {
            var sut = new Array<int>(1);
            sut[1] = 1;
        }

        [TestMethod]
        public void ArraySet_ToList_ReturnsList()
        {
            var sut = new Array<int>(1);
            var listSut = sut.ToList();
            Assert.IsInstanceOfType(listSut, typeof(List<int>));
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Array_Contains_Success(int value)
        {
            var sut = new Array<int>(3)
            {
                1,
                2,
                3,
            };

            Assert.IsTrue(sut.Contains(value));
        }

        [DataTestMethod]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        public void Array_RemoveDoesNotFindValue_ReturnsFalse(int value)
        {
            var sut = new Array<int>(3)
            {
                1,
                2,
                3,
            };

            Assert.IsFalse(sut.Remove(value));
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Array_RemoveFindsValue_ReturnsTrue(int value)
        {
            var sut = new Array<int>(3)
            {
                1,
                2,
                3,
            };

            Assert.IsTrue(sut.Remove(value));
        }

        [TestMethod]
        public void Array_Enumerator_ForEachGetsValues()
        {
            int i = 0;
            var sut = new Array<int>(3)
            {
                1,
                2,
                3,
            };

            foreach (int element in sut)
            {
                Assert.IsTrue(sut.Contains(element));
                Assert.AreEqual(element, sut[i++]);
            }
        }

        [TestMethod]
        public void Array_CopyTo_PreservesOrder()
        {
            var destination = new int[3];
            var sut = new Array<int>(3)
            {
                1,
                2,
                3,
            };

            sut.CopyTo(destination, 0);

            for (int i=0; i<sut.Capacity; i++)
                Assert.AreEqual(sut[i], destination[i]);
        }
    }
}
