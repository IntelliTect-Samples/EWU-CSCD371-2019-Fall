using System;
using Assignment6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6Tests
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        [DataRow(5)]
        [DataRow(100)]
        [DataRow(46)]
        [DataRow(1)]
        public void Constructor_AcceptsCapacity(int capacity)
        {
            var array = new Array<int>(capacity);
            Assert.AreEqual(capacity, array.Capacity);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(-23)]
        [DataRow(-4324)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_InvalidCapacity_ThrowsException(int capacity)
        {
            _ = new Array<int>(capacity);
        }

        [TestMethod]
        public void Add_CapacityNotReached_AddsValues()
        {
            Array<int> array = new Array<int>(4)
            {
                { 0 },{ 1 },{ 2 },{ 3 }
            };

            int j = 0;
            foreach (int? item in array)
            {
                Assert.AreEqual(j, item);
                j++;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Add_CapacityReached_ThrowsException()
        {
            Array<string> array = new Array<string>(4)
            {
                { "0" },{ "1" },{ "2" },{ "3" }
            };
            array.Add("newItem");
        }

        [TestMethod]
        public void Clear_DeletesAllElements()
        {
            Array<string> array = new Array<string>(4)
            {
                { "0" },{ "1" },{ "2" },{ "3" }
            };

            array.Clear();
            Assert.IsTrue(array.Count == 0);

            foreach (string? item in array)
            {
                Assert.IsNull(item);
            }
        }

        [TestMethod]
        [DataRow("0")]
        [DataRow("1")]
        [DataRow("2")]
        [DataRow("3")]
        public void Contains_ContainsValue_ReturnsTrue(string testString)
        {
            Array<string> array = new Array<string>(4)
            {
                { "0" },{ "1" },{ "2" },{ "3" }
            };

            Assert.IsTrue(array.Contains(testString));
        }

        [TestMethod]
        [DataRow("4")]
        [DataRow("5")]
        [DataRow("6")]
        [DataRow("7")]
        public void Contains_DoesntContainValue_ReturnsFalse(string testString)
        {
            Array<string> array = new Array<string>(4)
            {
                { "0" },{ "1" },{ "2" },{ "3" }
            };

            Assert.IsFalse(array.Contains(testString));
        }

        [TestMethod]
        [DataRow("0")]
        [DataRow("1")]
        [DataRow("2")]
        [DataRow("3")]
        public void Remove_ValueExists_RemovesValue(string testString)
        {
            Array<string> array = new Array<string>(4)
            {
                { "0" },{ "1" },{ "2" },{ "3" }
            };

            Assert.IsTrue(array.Remove(testString));
            Assert.IsFalse(array.Contains(testString));
        }

        [TestMethod]
        [DataRow("4")]
        [DataRow("5")]
        [DataRow("6")]
        [DataRow("7")]
        public void Remove_ValueDoesntExist_ReturnsFalse(string testString)
        {
            Array<string> array = new Array<string>(4)
            {
                { "0" },{ "1" },{ "2" },{ "3" }
            };

            Assert.IsFalse(array.Remove(testString));
        }

        [TestMethod]
        [DataRow(new string[] { "1", "2" })]
        [DataRow(new string[] { "random", "words", "for", "test" })]
        [DataRow(new string[] { "3", "nb ghg hgj", "JNJKNB", "1.89", "7878", "gcxdzxc", "hvv" })]
        public void CopyTo_SuccessfullyCopiesList(string[] array)
        {
            if (array is null)
                return;

            Array<string> ClassArray = new Array<string>(array.Length);

            foreach (var item in array)
            {
                ClassArray.Add(item);
            }

            string[] copyToArray = new string[array.Length];

            ClassArray.CopyTo(copyToArray, 0);

            for (int i = 0; i < ClassArray.Capacity; i++)
            {
                Assert.AreEqual(copyToArray[i], ClassArray[i]);
            }

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CopyTo_ArgumentNull_ThrowsException()
        {
            Array<string> array = new Array<string>(4)
            {
                { "0" },{ "1" },{ "2" },{ "3" }
            };

            array.CopyTo(null!, 0);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(7)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyTo_InvalidIndex_ThrowsException(int index)
        {
            string[] stringArray = { "2", "4", "5" };
            Array<string> array = new Array<string>(4)
            {
                { "0" },{ "1" },{ "2" },{ "3" }
            };

            array.CopyTo(stringArray, index);
        }

        [TestMethod]
        public void IsReadOnly_ReturnsFalse()
        {
            Array<string> array = new Array<string>(4);
            Assert.IsFalse(array.IsReadOnly);
        }

        [TestMethod]
        [DataRow(new string[] { "1", "2" })]
        [DataRow(new string[] { "random", "words", "for", "test" })]
        [DataRow(new string[] { "3", "nb ghg hgj", "JNJKNB", "1.89", "7878", "gcxdzxc", "hvv" })]
        public void Count_ReturnNumberOfItems(string[] array)
        {
            Array<string> ClassArray = new Array<string>(10);

            if (array is null)
                return;
            foreach (var item in array)
            {
                ClassArray.Add(item);
            }
            Assert.AreEqual(array.Length, ClassArray.Count);
        }

        [TestMethod]
        [DataRow(-4)]
        [DataRow(6)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_GetInvalidKey_ThrowsException(int index)
        {
            Array<string> array = new Array<string>(4)
            {
                { "0" },{ "1" },{ "2" },{ "3" }
            };

            _ = array[index];
        }

        [TestMethod]
        [DataRow(-4)]
        [DataRow(6)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_SetInvalidKey_ThrowsException(int index)
        {
            Array<string> array = new Array<string>(4)
            {
                { "0" },{ "1" },{ "2" },{ "3" }
            };

            array[index] = "random";
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Indexer_GetValidKey_ReturnsValue(int index)
        {
            Array<int> array = new Array<int>(4)
            {
                { 0 },{ 1 },{ 2 },{ 3 }
            };

            Assert.AreEqual(array[index], index);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Indexer_SetValidKey_SetsValue(int index)
        {
            Array<int> array = new Array<int>(4)
            {
                { 0 },{ 1 },{ 2 },{ 3 }
            };
            array[index] = index + 5;
            Assert.AreEqual(array[index], (index + 5));
        }

        public static void GetEnumerator_ForEachLoop_SuccessfullyIterates()
        {
            Array<int> array = new Array<int>(4)
            {
                { 0 },{ 1 },{ 2 },{ 3 }
            };

            int i = 0;
            foreach (var item in array)
            {
                Assert.AreEqual(item, i);
                i++;
            }
        }
    }
}
