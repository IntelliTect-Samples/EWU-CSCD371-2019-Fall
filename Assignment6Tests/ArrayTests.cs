using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(20)]
        [DataRow(200)]
        public void Array_Constructor_SetsCount(int count)
        {
            //Organize
            Array<int> testArray = new Array<int>(count);
            //Act

            //Assert
            Assert.AreEqual(count, testArray.Capacity);
        }
    }
}
