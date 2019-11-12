using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-5)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_ZeroAndNegativePassed_Exception(int length)
        {
            Array<string> array = new Array<string>(length);
        }

        [TestMethod]
        public void Constructor_Success()
        {
            Array<string> array1 = new Array<string>(1);
            Array<int> array2 = new Array<int>(6);
            Array<double> array3 = new Array<double>(3);
        }

        [TestMethod]
        public void GetCapacity_Success()
        {
            Array<string> array1 = new Array<string>(1);
            Array<int> array2 = new Array<int>(6);
            Array<double> array3 = new Array<double>(3);

            Assert.AreEqual(1, array1.Capacity);
            Assert.AreEqual(6, array2.Capacity);
            Assert.AreEqual(3, array3.Capacity);
        }

        [TestMethod]
        public void GetCount_Success()
        {
            Array<string> array1 = new Array<string>(5) { "1", "2", "3" };
            Array<int> array2 = new Array<int>(6) { 1, 2, 3, 4 };
            Array<double> array3 = new Array<double>(3) { 1.0, 2.0 };

            Assert.AreEqual(3, array1.Count);
            Assert.AreEqual(4, array2.Count);
            Assert.AreEqual(2, array3.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Add_AtCapacity_Exception()
        {
            Array<string> array = new Array<string>(3) { "1", "2", "3" };
            array.Add("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_PassNull_Exception()
        {
            Array<string> array = new Array<string>(3) { "1"};
            array.Add(null!);
        }

        [TestMethod]
        public void Add_Success()
        {
            Array<string> array = new Array<string>(3);

            array.Add("1");
            array.Add("2");
            array.Add("3");

            Assert.AreEqual(3, array.Count);
            Assert.AreEqual("1", array[0]);
            Assert.AreEqual("2", array[1]);
            Assert.AreEqual("3", array[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Remove_NotInCollection_Exception()
        {
            Array<string> array = new Array<string>(3) { "1", "2", "3" };
            array.Remove("4");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Remove_PassNull_Exception()
        {
            Array<string> array = new Array<string>(3) { "1" };
            array.Remove(null!);
        }

        [TestMethod]
        public void Remove_Success()
        {
            Array<string> array = new Array<string>(3) { "1", "2", "3" };

            array.Remove("2");

            Assert.AreEqual(2, array.Count);
            Assert.AreEqual("1", array[0]);
            Assert.AreEqual("3", array[1]);
        }

        [TestMethod]
        public void Clear_Success()
        {
            Array<string> array = new Array<string>(3) { "1", "2", "3" };

            array.Clear();

            Assert.AreEqual(0, array.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Contains_NotInCollection_Exception()
        {
            Array<string> array = new Array<string>(3) { "1", "2", "3" };
            array.Contains("4");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Contains_PassNull_Exception()
        {
            Array<string> array = new Array<string>(3) { "1" };
            array.Contains(null!);
        }

        [TestMethod]
        public void Contains_Success()
        {
            Array<string> array = new Array<string>(3) { "1", "2", "3" };

            Assert.IsTrue(array.Contains("1"));
            Assert.IsTrue(array.Contains("2"));
            Assert.IsTrue(array.Contains("3"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CopyTo_NullArray_Exception()
        {
            Array<string> array = new Array<string>(6) { "1", "2", "3" };
            string[] strAra = null;

            array.CopyTo(strAra, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyTo_LargerIndex_Exception()
        {
            Array<string> array = new Array<string>(6) { "1", "2", "3" };
            string[] strAra = new string[6] { "4", "5", "6", "", "", "" };

            array.CopyTo(strAra, 7);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyTo_SmallerIndex_Exception()
        {
            Array<string> array = new Array<string>(6) { "1", "2", "3" };
            string[] strAra = new string[3] { "4", "5", "6" };

            array.CopyTo(strAra, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CopyTo_NoRoom_Exception()
        {
            Array<string> array = new Array<string>(6) { "1", "2", "3" };
            string[] strAra = new string[3] { "4", "5", "6" };

            array.CopyTo(strAra, 1);
        }

        [TestMethod]
        public void CopyTo_Success()
        {
            Array<string> array = new Array<string>(6) { "1", "2", "3" };
            string[] strAra = new string[6] { "4", "5", "6", "", "", "" };

            array.CopyTo(strAra, 3);
        }

        [TestMethod]
        public void Iterate_ForEach_Success()
        {
            Array<string> array = new Array<string>(6) { "1", "2", "3" };
            int count = 0;

            foreach (string element in array)
                count++;

            Assert.AreEqual(3, count);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(3)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_IndexOutOfRange_Exception(int index)
        {
            Array<string> array = new Array<string>(6) { "1", "2", "3" };
            string num = array[index];
        }

        [TestMethod]
        public void Get_Success()
        {
            Array<string> array = new Array<string>(6) { "1", "2", "3" };

            Assert.AreEqual("1", array[0]);
            Assert.AreEqual("2", array[1]);
            Assert.AreEqual("3", array[2]);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(3)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Set_IndexOutOfRange_Exception(int index)
        {
            Array<string> array = new Array<string>(3) { "1", "2", "3" };
            array[index] = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Set_Null_Exception()
        {
            Array<string> array = new Array<string>(6) { "1", "2", "3" };
            array[1] = null!;
        }

        [TestMethod]
        public void Set_Success()
        {
            Array<string> array = new Array<string>(6) { "1", "2", "3" };
            array[0] = "";
            array[1] = "";
            array[2] = "";

            Assert.AreEqual("", array[0]);
            Assert.AreEqual("", array[1]);
            Assert.AreEqual("", array[2]);
        }
    }
}
