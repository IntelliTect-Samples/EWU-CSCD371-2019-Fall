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
        public void ArrayTestGoodCapacity()
        {
            //Arrange

            //Act
            ArrayCollection<string> array = new ArrayCollection<string>(10);

            //Assert
            Assert.IsNotNull(array);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ArrayTestInvalidCapacityThrowsException(int capacity)
        {
            //Arrange

            //Act
            _ = new ArrayCollection<string>(capacity);

            //Assert
        }

        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            ArrayCollection<string> array = new ArrayCollection<string>(1);

            //Act
            array.Add("Item");

            //Assert
            Assert.IsTrue(array.Count == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTestNullItemThrowsException()
        {
            //Arrange
            ArrayCollection<string> array = new ArrayCollection<string>(1);

            //Act
            array.Add(null);

            //Assert
        }

        [TestMethod()]
        public void ClearTest()
        {
            //Arrange
            ArrayCollection<string> array = new ArrayCollection<string>(1);
            array.Add("Item");

            //Act
            array.Clear();

            //Assert
            Assert.IsTrue(array.Count == 0);
        }

        [TestMethod()]
        public void ContainsTest()
        {
            //Arrange
            ArrayCollection<string> array = new ArrayCollection<string>(1);
            array.Add("Item");

            //Act

            //Assert
            Assert.IsTrue(array.Contains("Item"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsNullItem()
        {
            //Arrange
            ArrayCollection<string> array = new ArrayCollection<string>(1);

            //Act
            array.Contains(null);
        }

        [TestMethod()]
        public void CopyToTest()
        {
            //Arrange
            ArrayCollection<string> array = new ArrayCollection<string>(1);
            array.Add("Item");
            string[] destination = new string[1];

            //Act
            array.CopyTo(destination, 0);

            //Assert
            Assert.AreEqual(destination[0], "Item");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CopyToTestNullArrayThrowsException()
        {
            //Arrange
            ArrayCollection<string> array = new ArrayCollection<string>(1);
            array.Add("Item");

            //Act
            array.CopyTo(null, 1);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CopyToTestInvalidIndexBelowRange()
        {
            //Arrange
            ArrayCollection<string> array = new ArrayCollection<string>(1);
            array.Add("Item");
            string[] destination = new string[1];

            //Act
            array.CopyTo(destination, -1);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CopyToTestInvalidIndexAboveRange()
        {
            //Arrange
            ArrayCollection<string> array = new ArrayCollection<string>(1);
            array.Add("Item");
            string[] destination = new string[1];

            //Act
            array.CopyTo(destination, 10);

            //Assert
        }

        [TestMethod()]
        public void RemoveTest()
        {
            //Arrange
            ArrayCollection<string> array = new ArrayCollection<string>(5);
            array.Add("1");
            array.Add("2");
            array.Add("3");

            //Act
            array.Remove("2");

            //Assert
            Assert.IsFalse(array.Contains("2"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveTestNullItemThrowsException()
        {
            //Arrange
            ArrayCollection<string> array = new ArrayCollection<string>(1);

            //Act
            array.Remove(null);

            //Assert
        }

        [TestMethod]
        public void RemoveTestEmptyArray()
        {
            //Arrange
            ArrayCollection<string> array = new ArrayCollection<string>(1);

            //Act

            //Assert
            Assert.IsFalse(array.Remove("Should not exist"));
        }

        [TestMethod]
        public void RemoveTestItemNotInArray()
        {
            //Arrange
            ArrayCollection<string> array = new ArrayCollection<string>(1);
            array.Add("Item");

            //Act

            //Assert
            Assert.IsFalse(array.Remove("Should not exist"));
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            //Arrange
            ArrayCollection<string> array = new ArrayCollection<string>(5);
            array.Add("1");
            array.Add("2");
            array.Add("3");
            array.Add("4");
            array.Add("5");

            string[] plainArray = new string[] { "1", "2", "3", "4", "5" };

            //Act
            var enumerator = array.GetEnumerator();

            //Assert
            for (int ix = 0; ix < 5; ix++)
            {
                Assert.IsTrue(array.Contains(plainArray[ix]));
            }
        }

        [TestMethod]
        public void TestIsReadOnly()
        {
            ArrayCollection<string> array = new ArrayCollection<string>(1);
            Assert.IsFalse(array.IsReadOnly);
        }
    }
}