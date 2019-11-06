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

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        [DataRow(-1)]
        [DataRow(1)]
        public void ArrayIndex_OutOfRange_ThrowsInvalidOperationException(int index)
        {
            var sut = new Array<int>();
            var _ = sut[index];
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

        [TestMethod]
        public void ArraySet_ToList_ListHasSameLength()
        {
            var sut = new Array<int>(1);
            var listSut = sut.ToList();
            Assert.AreEqual(listSut.Count, sut.Capacity);
        }
    }
}
