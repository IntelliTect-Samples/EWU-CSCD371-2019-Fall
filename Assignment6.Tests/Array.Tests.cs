using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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

            Assert.AreEqual<int>(capacity, array.Capacity);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(-46)]
        [DataRow(-4567)]
        [DataRow(-386)]
        public void Constructor_InvalidCapacity_ThrowsException(int capacity)
        {
            Assert.ThrowsException<ArgumentException>(() => new Array<int>(capacity));
        }

        [TestMethod]
        public void Add_RoomAvailable_CorrectlyAppends()
        {
            var range = Enumerable.Range(0, 100);
            var array = new Array<string>(100);

            foreach (int i in range) array.Add(i.ToString());

            foreach (var (expected, actual) in range.Select(i => (i.ToString(), array[i])))
                Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void Add_RoomAvailable_FillsGaps()
        {
            var array = new Array<int>(100);
            int val = 12345678;
            foreach (int i in Enumerable.Range(0, 25)) array[i] = i;
            foreach (int i in Enumerable.Range(50, 50)) array[i] = i;

            array.Add(val);

            Assert.AreEqual<int>(val, array[25]);
        }

        [TestMethod]
        public void Add_NoRoom_ThrowsException()
        {
            var array = new Array<int>(0);

            Assert.ThrowsException<InvalidOperationException>(() => array.Add(5));
        }

        [TestMethod]
        public void Clear_ValidArray_ClearsValues()
        {
            var array = new Array<int>(100) { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            array.Clear();

            Assert.AreEqual<int>(0, array.Count);
            foreach (int i in Enumerable.Range(0, array.Capacity))
                Assert.ThrowsException<InvalidOperationException>(() => array[i]);
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

            Assert.AreEqual<int>(count, array.Count);
        }

        [TestMethod]
        public void IsReadOnly_ReturnsFalse()
        {
            Assert.IsFalse(new Array<int>(0).IsReadOnly);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(-5)]
        [DataRow(100)]
        [DataRow(10000)]
        public void GetIndex_IndexOutOfRange_ThrowsException(int index)
        {
            var array = new Array<int>(100);

            Assert.ThrowsException<IndexOutOfRangeException>(() => array[index]);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(99)]
        [DataRow(50)]
        [DataRow(98)]
        [DataRow(2)]
        public void GetIndex_ElementDoesntExist_ThrowsException(int index)
        {
            var array = new Array<int>(100);

            Assert.ThrowsException<InvalidOperationException>(() => array[index]);
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
        [DataRow(-1)]
        [DataRow(-5)]
        [DataRow(100)]
        [DataRow(10000)]
        public void SetIndex_IndexOutOfRange_ThrowsException(int index)
        {
            var array = new Array<int>(100);

            Assert.ThrowsException<IndexOutOfRangeException>(() => array[index] = 0);
        }

        [DataTestMethod]
        [DataRow(0, 34)]
        [DataRow(15, 300)]
        [DataRow(68, 3965)]
        [DataRow(99, 63839478)]
        public void GetIndexSetIndex_ValidIndex_ValueMatches(int index, int value)
        {
            var array = new Array<int>(100) { [index] = value };

            Assert.AreEqual<int>(value, array[index]);
        }

        [DataTestMethod]
        [DataRow(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0)]
        [DataRow(new int[0], 65467)]
        [DataRow(new[] { 1, 2, 3, 4, 5 }, 4654739)]
        public void CopyTo_ValidArray_CopiesElements(int[] inputs, int start)
        {
            int[] outputs = new int[start + inputs.Length];
            var array = new Array<int>(inputs.Length);
            foreach (int element in inputs) array.Add(element);

            array.CopyTo(outputs, start);

            Assert.IsTrue(Enumerable.SequenceEqual(inputs, outputs[start..]));
        }

        [DataTestMethod]
        [DataRow(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 1)]
        [DataRow(new[] { 5, 6, 8, 3, 2134, 657, 2345, 674, 2345 }, 17, 5)]
        [DataRow(new[] { 1, 2, 3, 4, 5 }, 765438, 3)]
        public void CopyTo_ArrayTooShort_ThrowsException(int[] inputs, int start, int off)
        {
            int[] outputs = new int[start + inputs.Length - off];
            var array = new Array<int>(inputs.Length);
            foreach (int element in inputs) array.Add(element);

            Assert.ThrowsException<ArgumentException>(() => array.CopyTo(outputs, start));
        }

        [TestMethod]
        public void CopyTo_NullArray_ThrowsException()
        {
            var array = new Array<int>(5);

            Assert.ThrowsException<ArgumentNullException>(() => array.CopyTo(null!, 0));
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(-5)]
        [DataRow(-314159265)]
        [DataRow(-94567)]
        public void CopyTo_NegativeIndex_ThrowsException(int index)
        {
            var array = new Array<int>(100);

            Assert.ThrowsException<IndexOutOfRangeException>(() => array.CopyTo(new int[200], index));
        }

        [DataTestMethod]
        [DataRow(64830, 45)]
        [DataRow(1234, 0)]
        [DataRow(987654, 99)]
        [DataRow(314159, 1)]
        [DataRow(null, 15)]
        public void Remove_ContainsItem_RemovesItem(int? value, int index)
        {
            var array = new Array<int?>(100);
            foreach (int i in Enumerable.Range(0, 40).Concat(Enumerable.Range(60, 40)))
                array[i] = i;
            array[50] = null;
            array[index] = value;

            Assert.IsTrue(array.Remove(value));
            Assert.ThrowsException<InvalidOperationException>(() => array[index]);
        }

        [DataTestMethod]
        [DataRow(64830)]
        [DataRow(1234)]
        [DataRow(987654)]
        [DataRow(314159)]
        public void Remove_DoesNotContainItem_DoesntModifyArray(int value)
        {
            var range = Enumerable.Range(0, 100);
            var array = new Array<int>(100);
            foreach (int i in range) array.Add(i);

            Assert.IsFalse(array.Remove(value));
            foreach (int i in range) Assert.AreEqual<int>(i, array[i]);
        }

        [TestMethod]
        public void GetEnumerator_ValidElements_IteratesCorrectly()
        {
            var ranges = Enumerable.Range(0, 30)
                .Concat(Enumerable.Range(40, 30))
                .Concat(Enumerable.Range(80, 20));
            var array = new Array<int>(100);
            foreach (int i in ranges) array[i] = i;
            var list = new List<int>();

            foreach (object? i in (System.Collections.IEnumerable)array)
                list.Add((int)i!);

            var zipped = ranges.Zip(list);
            Assert.AreEqual<int>(ranges.Count(), zipped.Count());
            foreach ((int expected, int actual) in zipped)
                Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void ToList_ValidArray_CorrectElements()
        {
            var array = new Array<int?>(100);
            foreach (int i in Enumerable.Range(0, 30)
                      .Concat(Enumerable.Range(40, 30))
                      .Concat(Enumerable.Range(80, 20)))
                array[i] = i;
            array[35] = null;

            Assert.IsTrue(Enumerable.SequenceEqual(array, (List<int?>)array));
        }
    }
}
