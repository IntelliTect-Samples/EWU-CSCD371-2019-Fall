using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment6;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayCollectionTests
    {
        private ArrayCollection<int> GetNewSUT() => new ArrayCollection<int>(3) { 1, 2, 3 };

        [TestMethod]
        public void Constructor_EnsuresCapacity_ReturnsDesiredCapacity()
        {
            int capacity = 3;
            ArrayCollection<int> sut = new ArrayCollection<int>(capacity);

            Assert.AreEqual<int>(capacity, sut.Capacity);
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(0, DisplayName = "Zero capacity")]
        [DataRow(-5, DisplayName = "Negative capacity")]
        public void Constructor_InvalidCapacity_Throws(int capacity)
        {
            _ = new ArrayCollection<int>(capacity);

            // should throw exception above, so this shouldn't be executed
            Assert.Fail();
        }

        [TestMethod]
        public void Add_InsertsItem_ItemAddedToArray()
        {
            ArrayCollection<int> sut = new ArrayCollection<int>(3);
            int count = sut.Count;
            int item = 1;

            sut.Add(item);
            count++;

            Assert.AreEqual<int>(count, sut.Count);
            Assert.AreEqual<int>(item, sut[0]);
        }

        [TestMethod]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0028:Simplify collection initialization", Justification = "Testing add specifically")]
        public void Add_InsertFillsLastSlot_CapacityDoesntIncrease()
        {
            int capacity = 1;
            ArrayCollection<int> sut = new ArrayCollection<int>(capacity);

            sut.Add(1);

            Assert.AreEqual<int>(capacity, sut.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_InsertItemWhenArrayIsFull_Throws()
        {
            ArrayCollection<int> sut = GetNewSUT();
            int item = 4;

            sut.Add(item);

            // should throw exception above, so this shouldn't be executed
            Assert.Fail();
        }

        [TestMethod]
        public void Remove_DeletesSpecifiedItem_RemovesItemAndFillsEmptySpot()
        {
            ArrayCollection<int> sut = GetNewSUT();
            int itemToRemove = 2;

            sut.Remove(itemToRemove);

            Assert.IsFalse(sut.Contains(itemToRemove));
            Assert.AreEqual<int>(2, sut.Count);
            Assert.AreEqual<int>(1, sut[0]);
            Assert.AreEqual<int>(3, sut[1]);
        }

        [TestMethod]
        public void Remove_DeleteFromEmptyArray_ReturnsFalse()
        {
            ArrayCollection<int> sut = new ArrayCollection<int>(3);
            int itemToRemove = 2;

            Assert.IsFalse(sut.Remove(itemToRemove));
        }

        [TestMethod]
        public void Remove_DeleteFromArrayButItemDoesntExist_ReturnsFalse()
        {
            ArrayCollection<int> sut = GetNewSUT();
            int itemToRemove = 4;

            Assert.IsFalse(sut.Remove(itemToRemove));
        }

        [TestMethod]
        public void Clear_ClearsArray_RemovesEverythingAndZeroesCount()
        {
            ArrayCollection<int> sut = GetNewSUT();

            sut.Clear();

            Assert.AreEqual<int>(0, sut.Count);
            Assert.IsFalse(sut.Contains(1));
            Assert.IsFalse(sut.Contains(2));
            Assert.IsFalse(sut.Contains(3));
        }

        [TestMethod]
        public void Contains_ChecksForExistingItem_Returnstrue()
        {
            ArrayCollection<int> sut = GetNewSUT();
            int item = 1;

            Assert.IsTrue(sut.Contains(item));
        }

        [TestMethod]
        public void Contains_ChecksForNonExistentItem_ReturnsFalse()
        {
            ArrayCollection<int> sut = GetNewSUT();
            int item = 4;

            Assert.IsFalse(sut.Contains(item));
        }

        [TestMethod]
        public void Indexing_GetsExistingItem_ReturnsItemAtIndex()
        {
            int item = 1;
            ArrayCollection<int> sut = new ArrayCollection<int>(1) { item };

            Assert.AreEqual<int>(item, sut[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexing_GetsNonExistentItem_Throws()
        {
            ArrayCollection<int> sut = new ArrayCollection<int>(3) { 1 };

            _ = sut[2];

            // should throw exception above, so this shouldn't be executed
            Assert.Fail();
        }

        [DataTestMethod]
        [DataRow(-1, DisplayName = "Index too low")]
        [DataRow(4, DisplayName = "Index too high")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexing_GetIndexOutOfRange_Throws(int badIndex)
        {
            ArrayCollection<int> sut = GetNewSUT();

            _ = sut[badIndex];

            // should throw exception above, so this shouldn't be executed
            Assert.Fail();
        }

        [TestMethod]
        public void Indexing_SetsItem_IndexContainsItem()
        {
            ArrayCollection<int> sut = new ArrayCollection<int>(1);
            int item = 1;

            sut[0] = item;

            Assert.AreEqual<int>(item, sut[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexing_SetsAtIndexLargerThanCount_Throws()
        {
            ArrayCollection<int> sut = new ArrayCollection<int>(3) { 1 };

            sut[2] = 3;

            // should throw exception above, so this shouldn't be executed
            Assert.Fail();
        }

        [DataTestMethod]
        [DataRow(-1, DisplayName = "Index too low")]
        [DataRow(4, DisplayName = "Index too high")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexing_SetIndexOutOfRange_Throws(int badIndex)
        {
            ArrayCollection<int> sut = GetNewSUT();

            sut[badIndex] = 0;

            // should throw exception above, so this shouldn't be executed
            Assert.Fail();
        }

        [TestMethod]
        public void CopyTo_ValueCopiesArray_ReturnsCloneOfArray()
        {
            ArrayCollection<int> sut = GetNewSUT();
            int[] clone = new int[sut.Count];

            sut.CopyTo(clone, 0);

            Assert.AreEqual<int>(sut.Count, clone.Length);
            for (int i = 0; i < sut.Count; i++)
            {
                Assert.AreEqual<int>(sut[i], clone[i]);
            }
        }

        [TestMethod]
        public void GenericGetEnumerator_AdvancesElement_EnumeratorItemMatchesIndexedItem()
        {
            ArrayCollection<int> sut = GetNewSUT();
            var enumerator = sut.GetEnumerator();

            enumerator.MoveNext();

            Assert.AreEqual<int>(sut[1], enumerator.Current);
        }

        [TestMethod]
        public void NonGenericGetEnumerator_AdvancesElement_EnumeratorItemMatchesIndexedItem()
        {
            ArrayCollection<int> sut = GetNewSUT();
            System.Collections.IEnumerator enumerator = ((System.Collections.IEnumerable) sut).GetEnumerator();

            enumerator.MoveNext();

            Assert.IsNotNull(enumerator.Current); //returning object, make sure it exists
            Assert.AreEqual<int>(sut[1], (int)enumerator.Current!); // we checked it, cast and forgive null
        }
    }
}
