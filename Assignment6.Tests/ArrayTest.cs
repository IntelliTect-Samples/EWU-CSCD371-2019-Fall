using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTest
    {
        [TestMethod]
        public void Add_Success()
        {
            Array<string> array = new Array<string>();

            array.Add("Hello");

            Assert.IsTrue(array.Contains("Hello"));
        }

        [TestMethod]
        public void Add_Fail()
        {
            Array<string> array = new Array<string>();

            array.Add("no");

            Assert.IsFalse(array.Contains("yes"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_Null()
        {
            Array<string> array = new Array<string>();

            array.Add(null);
        }

        [TestMethod]
        public void Add_CapacityMet()
        {
            Array<string> array = new Array<string>(3);

            array.Add("a");
            array.Add("b");
            array.Add("c");
            array.Add("d");

            Assert.IsFalse(array.Contains("d"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Contains_Null()
        {
            Array<string> array = new Array<string>();

            array.Contains(null);
        }

        [TestMethod]
        public void IndexOf_Success()
        {
            Array<string> array = new Array<string>();

            array.Add("Hey");

            Assert.AreEqual(1, array.IndexOf("Hey"));
        }

        [TestMethod]
        public void IndexOf_Fail()
        {
            Array<string> array = new Array<string>();

            array.Add("Hey");
            array.Add("H");
            array.Add("ey");

            Assert.AreEqual(2, array.IndexOf("Hey"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IndexOf_Null()
        {
            Array<string> array = new Array<string>();

            array.Contains(null);
        }

        [TestMethod]
        public void Remove_Success()
        {
            Array<string> array = new Array<string>();

            array.Add("Cool");

            Assert.IsTrue(array.Remove("Cool"));
        }

        [TestMethod]
        public void Remove_Fail()
        {
            Array<string> array = new Array<string>();

            array.Add("Cool");

            Assert.IsFalse(array.Remove("so"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Remove_Null()
        {
            Array<string> array = new Array<string>();

            array.Remove(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_CapacityNegative()
        {
            Array<string> array = new Array<string>(-5);
        }

        [TestMethod]
        public void Constructor_CapacitySuccess()
        {
            Array<string> array = new Array<string>(5);

            Assert.AreEqual(5, array.Capacity);
        }
    }
}
