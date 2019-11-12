using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_SizeOutOfRange()
        {
            var sut = new Array<int>(-1);
        }

        [DataTestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        [DataRow(-2)]
        [DataRow(2)]
        public void Index_Get_OutOfRangeException(int index)
        {
            var sut = new Array<int>(1)
            {
                1
            };

            var num = sut[index];
        }

        [DataTestMethod]
        [DataRow(0,1)]
        [DataRow(1,2)]
        [DataRow(2,3)]
        public void Index_Get_Success(int index, int expected)
        {
            var sut = new Array<int>(3)
            {
                1,
                2,
                3
            };

            Assert.AreEqual(expected, sut[index]);
        }

        [DataTestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        [DataRow(-2)]
        [DataRow(2)]
        public void Index_Set_OutOfRangeException(int index)
        {
            var sut = new Array<int>(1)
            {
                1
            };

            sut[index] = 1;
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        public void Index_Set_Success(int index)
        {
            var sut = new Array<int>(3)
            {
                1,
                2,
                3
            };

            sut[index] = 4;

            Assert.AreEqual(4, sut[index]);
        }



        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Add_Success(int item)
        {
            var sut = new Array<int>(4)
            {
                1,
                2,
                3
            };

            sut.Add(item);

            Assert.AreEqual(sut.Count, 4);
            Assert.AreEqual(sut[3], item);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_OutOfRange()
        {
            var sut = new Array<int>(1);

            sut.Add(1);
            sut.Add(1);
        }

        [TestMethod]
        public void Clear_Success()
        {
            var sut = new Array<int>(3)
            {
                1,
                2,
                3
            };

            sut.Clear();

            Assert.AreEqual(0, sut.Count);

        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Contains_Success(int item)
        {
            var sut = new Array<int>(3)
            {
                1,
                2,
                3
            };

            bool doesContain = sut.Contains(item);

            Assert.IsTrue(doesContain);
        }

        [TestMethod]
        public void CopyTo_Success()
        {
            var sut = new Array<int>(3)
            {
                1,
                2,
                3
            };
            var target = new int[3];

            sut.CopyTo(target, 0);

            CollectionAssert.AreEqual(sut.ToArray(), target);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Remove_Success(int item)
        {
            var sut = new Array<int>(3)
            {
                1,
                2,
                3
            };

            sut.Remove(item);

            Assert.IsFalse(sut.Contains(item));
        }
    }
}
