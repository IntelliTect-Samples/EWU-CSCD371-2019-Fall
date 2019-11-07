using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(1357)]
        [DataRow(8734)]
        [DataRow(78)]
        [DataRow(385)]
        public void Constructor_ValidCapacity_CorrectCapacity(int capacity)
        {
            var array = new Array<int>(capacity);

            Assert.AreEqual(capacity, array.Capacity);
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(-1)]
        [DataRow(-46)]
        [DataRow(-4567)]
        [DataRow(-386)]
        public void Constructor_InvalidCapacity_ThrowsException(int capacity)
        {
            new Array<int>(capacity);
        }

        [TestMethod]
        public void Add_RoomAvailable_CorrectlyAppends()
        {
            var range = Enumerable.Range(0, 100);
            var array = new Array<string>(100);

            foreach (int i in range) array.Add(i.ToString());

            foreach (var (expected, actual) in range.Select(i => (i.ToString(), array[i])))
                Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_RoomAvailable_FillsGaps()
        {
            var array = new Array<int>(100);
            int val = 12345678;
            foreach (int i in Enumerable.Range(0, 25)) array[i] = i;
            foreach (int i in Enumerable.Range(50, 50)) array[i] = i;

            array.Add(val);

            Assert.AreEqual(val, array[25]);
        }

        [TestMethod]
        public void Clear_ValidArray_ClearsValues()
        {
            var array = new Array<int>(100) { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            array.Clear();

            Assert.AreEqual(0, array.Count);
            foreach (int i in Enumerable.Range(0, array.Capacity))
            {
                try
                {
                    _ = array[i];
                    Assert.Fail();
                }
                catch (InvalidOperationException)
                {
                    // Exception indicates successful Clear()
                }
            }
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(5)]
        [DataRow(400)]
        [DataRow(15)]
        [DataRow(1)]
        [DataRow(7)]
        public void Count_ValidArray_CorrectValue(int count)
        {
            var array = new Array<int>(3 * count + 4);
            foreach (int i in Enumerable.Range(0, count)) array.Add(i);

            Assert.AreEqual(count, array.Count);
        }

        [TestMethod]
        public void IsReadOnly_ReturnsFalse()
        {
            Assert.IsFalse(new Array<int>(0).IsReadOnly);
        }

        [DataTestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        [DataRow(-1)]
        [DataRow(-5)]
        [DataRow(100)]
        [DataRow(10000)]
        public void GetIndex_IndexOutOfRange_ThrowsException(int index)
        {
            var array = new Array<int>(100);

            _ = array[index];
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetIndex_ElementDoesntExist_ThrowsException()
        {
            _ = new Array<int>(100)[50];
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(50)]
        [DataRow(99)]
        public void Contains_ElementInArray_True(int index)
        {
            int val = 123456789;
            var array = new Array<int>(100) { [index] = val };

            Assert.IsTrue(array.Contains(val));
        }

        [TestMethod]
        public void Contains_ElementNotInArray_False()
        {
            int val = 123456789;
            var array = new Array<int>(100);

            Assert.IsFalse(array.Contains(val));
        }

        [DataTestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        [DataRow(-1)]
        [DataRow(-5)]
        [DataRow(100)]
        [DataRow(10000)]
        public void SetIndex_IndexOutOfRange_ThrowsException(int index)
        {
            new Array<int>(100) { [index] = 0 };
        }

        [DataTestMethod]
        [DataRow(0, 34)]
        [DataRow(15, 300)]
        [DataRow(68, 3965)]
        [DataRow(99, 63839478)]
        public void GetIndexSetIndex_ValidIndex_ValueMatches(int index, int value)
        {
            var array = new Array<int>(100) { [index] = value };

            Assert.AreEqual(value, array[index]);
        }
    }
}
