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
        [ExpectedException(typeof(InvalidOperationException))]
        public void Array_Add_CapacityExceeded()
        {
            Array<int> array = new Array<int>(1);
            ((ICollection<int>)array).Add(1);
            ((ICollection<int>)array).Add(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Array_Add_AddNull()
        {
            Array<string> array = new Array<string>(1);
            ((ICollection<string>)array).Add("hello");
            ((ICollection<string>)array).Add(null);
        }

        [TestMethod]
        public void Array_Add_AddSucceeded()
        {
            Array<string> array = new Array<string>(1);
            ((ICollection<string>)array).Add("hello");

            Assert.IsTrue(array.Contains("hello"));
        }

        [TestMethod]
        public void Array_Add_CollectionInitializer()
        {
            Array<int> array = new Array<int>(6){1,2,3,4,5};
            Assert.IsTrue(array.Contains(4));
            Assert.IsTrue(array.Contains(5));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Array_Add_CollectionInitAddNull()
        {
            Array<string> _ = new Array<string>(5)
            {
                "hello",
                "world",
                null
            };
        }

        [TestMethod]
        public void Array_Add_CollectionInitAddSucceeded()
        {
            Array<string> array = new Array<string>(1)
            {
                "hello"
            };

            Assert.IsTrue(array.Contains("hello"));
        }



        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Array_Remove_RemoveNull()
        {
            Array<string> array = new Array<string>(1)
            {
                "hello"
            };

            ((ICollection<string>)array).Remove(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Array_Remove_ItemNotExist()
        {
            Array<string> array = new Array<string>(1)
            {
                "hello"
            };

            ((ICollection<string>)array).Remove("Test");
        }


        [TestMethod]
        public void Array_Remove_ItemRemoved()
        {
            Array<string> array = new Array<string>(1)
            {
                "hello"
            };

            ((ICollection<string>)array).Remove("hello");

            Assert.AreEqual(0, array.Count);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Array_Get_OutOfBounds()
        {
            Array<int> array = new Array<int>(5) { 1, 2, 3, 4, 5 };

            int _ = array[5];
        }

        [TestMethod]
        public void Array_Get_ReturnsValue()
        {
            Array<int> array = new Array<int>(5) { 1, 2, 3, 4, 5 };

            int value = array[3];

            Assert.AreEqual(4, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Array_Set_OutOfBounds()
        {
            Array<int> array = new Array<int>(5) { 1, 2, 3, 4, 5 };
            array[6] = 3;
        }

        [TestMethod]
        public void Array_Set_SetsValue()
        {
            Array<int> array = new Array<int>(5) { 1, 2, 3, 4, 5 };
            array[3] = 3;
            Assert.AreEqual(3, array[3]);
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
                Assert.AreEqual(list[item - 1], item);
            }
        }
    }
}
