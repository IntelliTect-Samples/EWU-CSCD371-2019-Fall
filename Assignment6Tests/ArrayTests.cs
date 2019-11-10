using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(-100)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Array_Constructor_ArgumentOutOfRangeException(int capacity)
        {
            ArrayCollection<int> array = new ArrayCollection<int>(capacity);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(100)]
        public void Array_Constructor_Qapla(int capacity)
        {
            ArrayCollection<int> array = new ArrayCollection<int>(capacity);
            Assert.AreEqual(capacity, array.Capacity);
        }

    }
}
