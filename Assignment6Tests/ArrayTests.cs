using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment6;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment6.Tests
{
    [TestClass()]
    public class ArrayTests
    {
        [TestMethod()]
        public void ArrayTest()
        {
            //Arrange

            //Act
            Array<String> array = new Array<String>(10);

            //Assert
            Assert.IsNotNull(array);
        }

        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            Array<String> array = new Array<String>(10);

            //Act
            array.Add("Item");

            //Assert
            Assert.AreEqual("Item", array.ToString());
        }

        [TestMethod()]
        public void ClearTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ContainsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CopyToTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Assert.Fail();
        }
    }
}