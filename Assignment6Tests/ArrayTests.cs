using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

#pragma warning disable CS8604

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

        [TestMethod]
        public void Array_ICollectionConstructor_Qapla()
        {
            ICollection<int> collection = new List<int>() { 1, 2, 3 };
            ArrayCollection<int> intCol = new ArrayCollection<int> (collection);
            Assert.IsTrue(intCol.Contains(1));
            Assert.IsTrue(intCol.Contains(2));
            Assert.IsTrue(intCol.Contains(3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Array_ICollectionConstructor_NullCollection()
        {
            ICollection<int>? collection = null;
            ArrayCollection<int> intCol = new ArrayCollection<int>(collection);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Array_Add_FullCollection()
        {
            ICollection<int> collection = new List<int>(3) { 1, 2, 3 };
            ArrayCollection<int> intCol = new ArrayCollection<int>(collection);
            intCol.Add(4);
        }

        [TestMethod]
        public void Array_Add_Qapla()
        {
            ArrayCollection<int> intCol = new ArrayCollection<int>(1);
            intCol.Add(1);
            Assert.IsTrue(intCol.Contains(1));
        }

        [TestMethod]
        public void Array_Clear_Qapla()
        {
            ArrayCollection<int> intCol = new ArrayCollection<int>(3);
            intCol.Add(1);
            intCol.Add(2);
            intCol.Add(3);
            intCol.Clear();
            Assert.IsTrue(intCol.Count == 0);
        }

        [TestMethod]
        public void Array_Contains_Qapla()
        {
            ArrayCollection<int> intCol = new ArrayCollection<int>(3);
            intCol.Add(1);
            intCol.Add(2);
            intCol.Add(3);
            Assert.IsTrue(intCol.Contains(1));
            Assert.IsFalse(intCol.Contains(4));
        }

        [TestMethod]
        public void Array_CopyTo_Qapla()
        {
            ArrayCollection<int> intCol = new ArrayCollection<int>(4);
            int[] intArray = new int[4];
            intCol.CopyTo(intArray, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Array_CopyTo_OutOfBounds()
        {
            ArrayCollection<int> intCol = new ArrayCollection<int>(3);
            int[] intArray = new int[4];
            intCol.CopyTo(intArray, 4);
        }

        [TestMethod]
        public void Array_Remove_Qapla()
        {
            ArrayCollection<int> intCol = new ArrayCollection<int>(3);
            intCol.Add(1);
            intCol.Add(2);
            intCol.Add(3);
            Assert.IsTrue(intCol.Remove(1));
            Assert.IsFalse(intCol.Remove(4));
        }

        [TestMethod]
        public void Array_IndexOperator_Get()
        {
            ArrayCollection<int> intCol = new ArrayCollection<int>(3);
            intCol.Add(1);
            intCol.Add(2);
            intCol.Add(3);
            Assert.AreEqual(intCol[0], 1);
            Assert.AreEqual(intCol[1], 2);
            Assert.AreEqual(intCol[2], 3);
        }

        [TestMethod]
        public void Array_IndexOperator_Set()
        {
            ArrayCollection<int> intCol = new ArrayCollection<int>(3);
            intCol.Add(1);
            intCol.Add(2);
            intCol.Add(3);
            Assert.AreEqual(intCol[0], 1);
            intCol[0] = 5;
            Assert.AreEqual(intCol[0], 5);
        }



    }
}
