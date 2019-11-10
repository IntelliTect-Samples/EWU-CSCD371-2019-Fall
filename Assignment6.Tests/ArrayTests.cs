using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeclareArray_InvalidSize_ThrowsException()
        {
            new Array<int>(0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_AddsItemPastCapacity_ThrowsException()
        {
            var sut = new Array<int>(1);
            int item = 42;

            sut.Add(item);
            sut.Add(item);
        }

        [TestMethod]
        public void Add_AddsItemAndIncrementsCount()
        {
            var sut = new Array<int>(5);
            int item = 42;

            sut.Add(item);

            Assert.AreEqual<int>(item, sut[0]);
            Assert.AreEqual<int>(1, sut.Count);
        }

        [TestMethod]
        public void IndexOperator_AssignsValueInsideArray()
        {
            var sut = new Array<int>(5);
            int item = 42;

            sut[2] = item;

            Assert.AreEqual<int>(item, sut[2]);
            Assert.AreEqual<int>(1, sut.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexOperator_GetUsingInvalidIndex_ThrowsException()
        {
            var sut = new Array<int>(5);

            int item = sut[5];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexOperator_SetUsingInvalidIndex_ThrowsException()
        {
            var sut = new Array<int>(5);

            sut[5] = 42;
        }

        [TestMethod]
        public void IndexOperator_GetUsingValidIndex_ReturnsValue()
        {
            var sut = new Array<int>(2);
            sut.Add(42);

            Assert.AreEqual<int>(42, sut[0]);
        }

        [TestMethod]
        public void IndexOperator_GetUsingInvalidIndex_ReturnsDefaultValue()
        {
            var sut = new Array<int>(2);

            Assert.AreEqual<int>(0, sut[1]);
        }

        [TestMethod]
        public void IndexOperator_GetUsingInvalidIndexAndString_ReturnsDefaultValue()
        {
            var sut = new Array<string>(2);

            Assert.AreEqual<string>(null!, sut[1]);
        }

        [TestMethod]
        public void Clear_ClearsArray_ReturnsCountOfZero()
        {
            var sut = new Array<int>(2);
            int item = 42;

            sut.Add(item);
            sut.Add(item);
            sut.Clear();

            Assert.AreEqual<int>(0, sut.Count);
        }

        [TestMethod]
        [DataRow(42, true)]
        [DataRow(7, false)]
        public void Contains_CheckIfValueIsStoredInArray(int expectedInt, bool expectedBool)
        {
            var sut = new Array<int>(2);
            int item = 42;
            sut.Add(item);

            Assert.AreEqual(expectedBool, sut.Contains(expectedInt));
        }

        [TestMethod]
        public void Remove_UsingValueType()
        {
            var sut = new Array<int>(5);
            sut.Add(5);
            sut.Add(15);
            sut.Add(25);
            sut.Add(35);
            sut.Add(5);

            sut.Remove(5);

            Assert.AreEqual<int>(4, sut.Count);
        }

        [TestMethod]
        public void Remove_UsingString()
        {
            var sut = new Array<string>(5);
            sut.Add("1");
            sut.Add("2");
            sut.Add("3");
            sut.Add("4");
            sut.Add("5");

            sut.Remove("3");

            Assert.AreEqual<int>(4, sut.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CopyTo_UsingNullArray_ThrowsException()
        {
            var sut = new Array<int>(2);

            sut.CopyTo(null!, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyTo_UsingInvalidIndex_ThrowsException()
        {
            var sut = new Array<int>(2);
            var array = new int[2];

            sut.CopyTo(array, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CopyTo_UsingArrayWithNotEnoughSpace_ThrowsException()
        {
            var sut = new Array<int>(2);
            var array = new int[1];
            sut.Add(1);
            sut.Add(2);

            sut.CopyTo(array, 0);
        }

        [TestMethod]
        public void CopyTo_CopyArray_Success()
        {
            var sut = new Array<int>(2);
            var array = new int[2];
            sut[1] = 7;
            sut[0] = 42;

            sut.CopyTo(array, 0);

            Assert.AreEqual<int>(sut[0], array[0]);
            Assert.AreEqual<int>(sut[1], array[1]);
        }

        [TestMethod]
        public void GetEnumerator_ForEachLoopWorks()
        {
            var sut = new Array<int>(5);
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
            sut.Add(4);
            sut.Add(5);
            int sum = 0;

            foreach (int i in sut)
            {
                sum += i;
            }

            Assert.AreEqual<int>(15, sum);
        }

        [TestMethod]
        public void CollectionInitializerTest()
        {
            var sut = new Array<string>(5) { "1", "3" };

            Assert.AreEqual<int>(2, sut.Count);
            Assert.AreEqual<string>("1", sut[0]);
            Assert.AreEqual<string>("3", sut[1]);
        }
    }
}
