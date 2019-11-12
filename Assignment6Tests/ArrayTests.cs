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
            ArrayCollection<int> testArray = new ArrayCollection<int>(count);
            //Act

            //Assert
            Assert.AreEqual(count, testArray.Capacity);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-24)]
        [DataRow(-1000)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Array_Constructor_CapacityLessThan1_ThrowsException(int count)
        {
            //Organize
            _ = new ArrayCollection<int>(count);
            //Act

            //Assert
        }

        [TestMethod]
        public void Array_Constructor_CollectionInitializer()
        {
            //Organize
            ArrayCollection<int> testArray = new ArrayCollection<int>(10)
            {
                3,
                4,
                5
            };

            //Act

            //Assert
            Assert.IsTrue(testArray.Contains(3));
            Assert.IsTrue(testArray.Contains(4));
            Assert.IsTrue(testArray.Contains(5));
        }

        [TestMethod]
        public void Array_Add_AddsValue_ToCollection()
        {
            //Organize
            var testArray = new ArrayCollection<string>(10);
            
            //Act
            testArray.Add("Test item");

            //Assert
            Assert.IsTrue(testArray.Contains("Test item"));
        }

        [TestMethod]
        public void Array_Add_AddsValue_IncrementsCount()
        {
            //Organize
            var testArray = new ArrayCollection<string>(10);
            int initialCount = testArray.Count;

            //Act
            testArray.Add("Test item");

            //Assert
            Assert.AreNotEqual(initialCount, testArray.Count);
        }

        [TestMethod]
        public void Array_Add_FullCapacity_DoesntAddItem()
        {
            //Organize
            var testArray = new ArrayCollection<string>(1);

            //Act
            testArray.Add("Test item");
            testArray.Add("Test item 2");
            //Assert
            Assert.IsFalse(testArray.Count == 2);
        }

        [TestMethod]
        public void Array_Contains_ItemExists_ReturnsTrue()
        {
            //Organize
            var testArray = new ArrayCollection<string>(10);

            //Act
            testArray.Add("Test item");

            //Assert
            Assert.IsTrue(testArray.Contains("Test item"));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Array_Contains_ItemDoesntExist_ThrowsException()
        {
            //Organize
            var testArray = new ArrayCollection<string>(10);

            //Act

            //Assert
            Assert.IsTrue(testArray.Contains("Test item"));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Array_Clear_Clears_Items()
        {
            //Organize
            var testArray = new ArrayCollection<string>(5);

            testArray.Add("test string");
            testArray.Add("test string");
            testArray.Add("test string");
            testArray.Add("test string");
            testArray.Add("test string");

            //Act
            testArray.Clear();
            testArray.Contains("test string");
            //Assert

        }

        [TestMethod]
        public void Array_Clear_ResetsCount()
        {
            //Organize
            var testArray = new ArrayCollection<string>(5);

            testArray.Add("test string");
            testArray.Add("test string");
            testArray.Add("test string");
            testArray.Add("test string");
            testArray.Add("test string");

            //Act
            testArray.Clear();
            //Assert
            Assert.AreEqual(0, testArray.Count);
        }

        [TestMethod]
        public void Array_CopyTo_CopiesToArray()
        {
            //Organize
            ArrayCollection<int> testArray = new ArrayCollection<int>(6)
            {
                3,
                4,
                2,
                7,
                11,
                18
            };

            var intArray = new int[6];

            //Act
            testArray.CopyTo(intArray, 0);

            //Assert
            Assert.AreEqual(7, intArray[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Array_Remove_RemoveItem_Contains_ThrowsException()
        {
            //Organize
            ArrayCollection<int> testArray = new ArrayCollection<int>(6)
            {
                3,
                4,
                2,
                7,
                11,
                18
            };

            //Act
            testArray.Remove(3);

            testArray.Contains(3);
            //Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Array_Remove_ItemDoesntExist_ThrowsException()
        {
            //Organize
            ArrayCollection<int> testArray = new ArrayCollection<int>(6)
            {
                3,
                4,
                2,
                7,
                11,
                18
            };

            //Act
            testArray.Remove(22);
            //Assert

        }

        [TestMethod]
        public void Array_IndexOperator_ReturnsCorrectValue()
        {
            //Organize
            ArrayCollection<int> testArray = new ArrayCollection<int>(6)
            {
                3,
                4,
                2,
                7,
                11,
                18
            };

            //Act

            //Assert
            Assert.AreEqual(4, testArray[1]);
        }
    }
}
