using Assignment6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Array.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        public void Array_Constructor_SetsMaxCapacity()
        {
            Array<int> array = new Array<int>(3);

            Assert.AreEqual(3, array.Capacity);
        }

        [TestMethod]
        public void Array_Constructor_CreatesEmptyList()
        {
            Array<int> array = new Array<int>(3);

            Assert.IsNotNull(array.Items);
            Assert.AreEqual(0, array.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Array_Constructor_NullListPassed()
        {
            Array<int> _ = new Array<int>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Array_Constructor_NegativeCapacity()
        {
            Array<int> _ = new Array<int>(-5);
        }

        [TestMethod]
        public void Array_ListConstructor_SetsMaxCapacity()
        {
            List<int> list = new List<int>()
            {
                1,2,3,4,5
            };
            Array<int> array = new Array<int>(list);

            Assert.AreEqual(list.Capacity, array.Capacity);
        }

        [TestMethod]
        public void Array_ListConstructor_SetsItems()
        {
            List<int> list = new List<int>()
            {
                1,2,3,4,5
            };
            Array<int> array = new Array<int>(list);

            Assert.AreEqual(list.Capacity, array.Capacity);
            Assert.AreEqual(list, array.Items);
        }


        [TestMethod]
        public void Array_Clear_ClearsItems()
        {

            List<int> list = new List<int>()
            {
                1,2,3,4,5
            };
            Array<int> array = new Array<int>(list);

            Assert.AreEqual(5, array.Count);

            array.Clear();

            Assert.AreEqual(0, array.Count);
        }

        [TestMethod]
        public void Array_Contains_ItemNotFoundReturnFalse()
        {

            List<int> list = new List<int>()
            {
                1,2,3,4,5
            };
            Array<int> array = new Array<int>(list);

            Assert.IsFalse(array.Contains(6));
        }

        [TestMethod]
        public void Array_Contains_ItemFoundReturnTrue()
        {

            List<int> list = new List<int>()
            {
                1,2,3,4,5
            };
            Array<int> array = new Array<int>(list);

            Assert.IsTrue(array.Contains(3));
        }


        [TestMethod]
        public void Array_CopyTo_CopiesArray()
        {
            List<int> list = new List<int>()
            {
                1,2,3,4,5
            };
            Array<int> array = new Array<int>(list);

            int[] output = new int[array.Count];

            array.CopyTo(output, 0);

            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(output[i], array[i]);
            }
        }

        [TestMethod]
        public void Array_CopyTo_CopiesArrayOffset()
        {
            List<int> list = new List<int>()
            {
                1,2,3,4,5
            };
            Array<int> array = new Array<int>(list);

            int[] output = new int[array.Count+1];

            array.CopyTo(output, 1);

            for (int i = 0; i < array.Count; i++)
            {
                Assert.AreEqual(output[i+1], array[i]);
            }
        }



        [TestMethod]
        public void Array_Foreach_CanIterate()
        {
            List<int> list = new List<int>()
            {
                1,2,3,4,5
            };
            Array<int> array = new Array<int>(list);

            foreach (int item in array)
            {
                Assert.AreEqual(list[item - 1], item);
            }
        }

        [TestMethod]
        public void Array_CollectionInitializer()
        {
            List<int> list = new List<int>()
            {
                1,2,3,4,5
            };
            Array<int> array = new Array<int>(list);

            foreach (int item in array)
            {
                Assert.AreNotEqual(list[item - 1], item);
            }
        }
        [TestMethod]
        public void Array_CollectionInitializer_NoNull()
        {
            List<int> list = new List<int>()
            {
                1,2,3,4,5
            };
            Array<int> array = new Array<int>(list);

            foreach (int item in array)
            {
                Assert.AreNotEqual(list[item - 1], item);
            }
        }
    }
}
