using Assignment6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;

namespace ArrayTests
{
    [TestClass]
    public class ArrayTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArrayConstructor_NegativeCapacityArgument()
        {
            Array<int?> arr = new Array<int?>(-5);
        }

        [TestMethod]
        public void ArrayConstructor_ValidArguments()
        {
            int expectedCapacity = 5;

            Array<int?> arr = new Array<int?>(5);

            Assert.AreEqual(expectedCapacity, arr.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArrayConstructor_Collection_NullArgument()
        {
            Array<string> arr = new Array<string>(5, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArrayConstructor_Collection_OutOfRangeArgument()
        {
            Array<string> arr = new Array<string>(-5, new Collection<string> { "word1", "word2"});
        }

        [TestMethod]
        public void ArrayConstructor_Collection_ValidArguments()
        {
            int expectedCapacity = 2;
            Collection<string> c = new Collection<string> { "word1", "word2", "word3", "word4" };
            Array<string> arr = new Array<string>(2, c);

            Assert.AreEqual(expectedCapacity, arr.Capacity);
            for(int i = 0; i < arr.Capacity; i++)
            {
                Assert.AreEqual(c[i], arr[i]);
            }
        }

        [TestMethod]
        public void Array_GetValue()
        {
            Array<string> arr = new Array<string>(10);

            string word = "Word ";
            for(int i = 0; i < arr.Capacity; i++)
            {
                arr.Add(word + i);
            }

            foreach(string s in arr)
            {
                Assert.IsNotNull(s);
            }
            Console.WriteLine(arr.Capacity + " -- " + arr.Collection.Capacity);
            Assert.AreEqual("Word 0", arr[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Array_GetNull()
        {
            Array<int?> arr = new Array<int?>(10);

            arr.Add(1);
            arr.Add(2);
            arr.Add(null);

            arr.GetValue(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Array_GetOutOfRange()
        {
            Array<int?> arr = new Array<int?>(10);

            arr.GetValue(10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Array_GetMissingItem()
        {
            Array<int?> arr = new Array<int?>(10);

            arr.GetValue(2);
        }

        [TestMethod]
        public void Array_Clear()
        {
            Array<int?> arr = new Array<int?>(10);

            for(int i = 0; i < arr.Capacity; i++)
            {
                arr.Add(i);
            }

            foreach(int item in arr)
            {
                Assert.IsNotNull(item);
            }
            Assert.IsTrue(arr.Count == 10);

            arr.Clear();

            Assert.IsTrue(arr.Count == 0);
        }

        [TestMethod]
        public void Array_Contains()
        {
            string expectedItem = "Expected";
            Collection<string> c = new Collection<string> { "word0", "word1", "word2", "word3" };
            Array<string> arr = new Array<string>(5);
            arr.Add(expectedItem);

            Assert.IsTrue(arr.Contains(expectedItem));
        }

        [TestMethod]
        public void Array_Remove()
        {
            string expectedItem = "Expected";
            Collection<string> c = new Collection<string> { "word0", "word1", "word2", "word3" };
            Array<string> arr = new Array<string>(5, c);
            arr.Add(expectedItem);

            Assert.IsTrue(arr.Remove(expectedItem));
        }

        [TestMethod]
        public void Array_CopyTo()
        {
            Collection<string> c = new Collection<string> { "word0", "word1", "word2", "word3" };
            Array<string> arr = new Array<string>(4, c);

            string[] sarr = new string[arr.Capacity];
            arr.CopyTo(sarr, 0);

            for(int i = 0; i < sarr.Length; i++)
            {
                Assert.IsNotNull(sarr[i]);
                Assert.AreEqual(sarr[i], arr[i]);
            }
        }
    }
}
