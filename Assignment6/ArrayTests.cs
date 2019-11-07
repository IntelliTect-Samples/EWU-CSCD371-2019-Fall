using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment6
{
    [TestClass]
    public class ArrayTests
    {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Array_Add_Success(int item)
        {
            Array<int> array = new Array<int>(3)
            {
                item
            };

            Assert.IsTrue(array.Contains(item));
        }

        [TestMethod]
        public void Array_Clear_Success()
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
        public void Array_Contains_ReturnsItem(int item)
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

        [TestMethod]
        public void Array_Contains_DoesNotContain()
        {

        }

        [TestMethod]
        public void Array_Remove_Success()
        {

        }

        [TestMethod]
        public void Array_Remove_DoesNotContain()
        {

        }
    }
}
