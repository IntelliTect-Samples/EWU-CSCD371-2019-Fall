using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{

    [TestClass]
    public class ArrayTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Given0_ThrowsException()
        {
            var unused = new ArrayCollection<int>(0);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(10)]
        public void ArrayOperator_OperatesCorrectly(int value)
        {
            var array = new ArrayCollection<int>(1);
            array[0] = value;

            Assert.AreEqual(value, array[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveItem_GivenNull_ThrowsException()
        {
            var array = new ArrayCollection<string>(2) {"a", "b"};
            array.Remove(null);
        }
        
        [TestMethod]
        public void RemoveItem_RemovesCorrectItemFromArray()
        {
            var array = new ArrayCollection<string>(2) {"a", "b"};
            array.Remove("a");

            Assert.AreEqual(1, array.Count);
            Assert.AreEqual("b", array[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_GivenNull_ThrowsException()
        {
            var array = new ArrayCollection<string>(1);
            array.Add(null);
        }
        
        [TestMethod]
        public void Add_AddsToFirstEmptySpace()
        {
            var expected = new ArrayCollection<string>(5)
            {
                "c",
                "a",
                "b",
                "d",
                "e"
            };
            var array = new ArrayCollection<string>(5);
            array[1] = "a";
            array[3] = "b";
            
            array.Add("c");
            array.Add("d");
            array.Add("e");
            
            Assert.AreEqual(5, array.Count);
            Assert.AreEqual(expected.ToString(), array.ToString());
        }

        [TestMethod]
        public void CopyTo_CorrectlyCopiesArray()
        {
            var a = new ArrayCollection<string>(3) {"a", "b", "c"};
            var b = new string[3];
            a.CopyTo(b, 0);
            
            Assert.AreEqual(a.ToString(), b.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CopyTo_GivenNullArray_ThrowsException()
        {
            var a = new ArrayCollection<string>(3) {"a", "b", "c"};
            // ReSharper disable once AssignNullToNotNullAttribute
            a.CopyTo(null, 0);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(3)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyTo_GivenInvalidIndex_ThrowsException(int index)
        {
            var a = new ArrayCollection<string>(3) {"a", "b", "c"};
            var b = new string[3];
            a.CopyTo(b, index);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CopyTo_GivenDifferentArraySize_ThrowsException()
        {
            var a = new ArrayCollection<string>(3) {"a", "b", "c"};
            var b = new string[2];
            a.CopyTo(b, 0);
        }

        [TestMethod]
        public void Contains_ReturnsCorrectValue()
        {
            var a = new ArrayCollection<string>(3) {"a", "b", "c"};
            
            Assert.IsTrue(a.Contains("a"));
            Assert.IsFalse(a.Contains("d"));
        }

        [TestMethod]
        public void Clear_CorrectlyClearsArray()
        {
            var a = new ArrayCollection<string>(3) {"a", "b", "c"};
            a.Clear();
            
            Assert.AreEqual(3, a.Capacity);
            Assert.AreEqual(0, a.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ReadOnlyException))]
        public void WhileReadOnly_Operator_ThrowsException()
        {
            var a = new ArrayCollection<string>(3, true) {"a", "b", "c"};

            a[0] = "d";
        }
        
        [TestMethod]
        [ExpectedException(typeof(ReadOnlyException))]
        public void WhileReadOnly_Add_ThrowsException()
        {
            var a = new ArrayCollection<string>(3, true) {"a", "b"};

            a.Add("c");
        }

    }

}
