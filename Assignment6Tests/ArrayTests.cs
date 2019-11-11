using Assignment6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment6Tests
{
    [TestClass]
    public class ArrayTests
    {
        /* Array<T> Testing */

        [TestMethod]
        public void ArrayReturnsCorrectCapacity()
        {
            //Arrange
            int cap = 24;
            int returnedCap;
            var array = new Array<string>(cap);

            //Act
            returnedCap = array.Capacity;

            //Assert
            Assert.AreEqual(cap, returnedCap);
        }

        [TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArrayExceptsWithInvalidCapacity()
        {
            //Arrange
            int cap = -1;

            //Act
            Array<string> _ = new Array<string>(cap);
        }

        [DataTestMethod]
        [DataRow(0, "hi0")]
        [DataRow(1, "hi1")]
        [DataRow(2, "hi2")]
        [DataRow(3, "hi3")]
        [DataRow(4, "hi4")]
        public void ArrayIndexingFunctional(int index, string expected)
        {
            //Arrange
            Array<string> array = new Array<string>(5)
            {
                //Act
                [index] = "hi" + index
            };

            //Assert
            Assert.AreEqual(array[index], expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArrayThrowsExceptionWhenIndexOutOfBounds()
        {
            //Arrange
            Array<string> _ = new Array<string>(2)
            {
                //Act
                [6] = "test"
            };
        }

        [TestMethod]
        public void ForeachFunctionalGivenFullArray()
        {
            //Arrange
            Array<string> array = new Array<string>(5) { "A", "B", "C", "D", "E" }; //Warning tells me to use explicit, code analyzer tells me to use implicit (var)
            string concat = "";

            //Act
            foreach (string str in array)
            {
                concat += str;
            }

            //Assert
            Assert.AreEqual("ABCDE", concat);
        }

        [TestMethod]
        public void ForeachFunctionalGivenPartiallyFullArray()
        {
            //Arrange
            Array<string> array = new Array<string>(5) { "A" };
            string concat = "";

            //Act
            foreach (string str in array)
            {
                concat += str;
            }

            //Assert
            Assert.AreEqual("A", concat);
        }

        [TestMethod]
        public void ForeachFunctionalWithEmptyArray()
        {
            //Arrange
            Array<string> array = new Array<string>(5);
            bool skipped = true;

            //Act
            foreach (string str in array)
            {
                skipped = false;
            }

            //Assert
            Assert.IsTrue(skipped);
        }

        [TestMethod]
        public void ArrayClearWorks()
        {
            //Arrange
            Array<string> array = new Array<string>(5) { "A", "B", "C", "D", "E" };
            bool clear = true;

            //Act
            array.Clear();
            foreach (string str in array)
            {
                clear = false;
            }

            //Assert
            Assert.IsTrue(clear);
            Assert.AreEqual(0, array.Count);
        }

        [TestMethod]
        public void ArrayContainsWorks()
        {
            //Arrange
            Array<string> array = new Array<string>(5) { "A", "B", "C", "D", "E" };
            bool contains;
            bool invalid;

            //Act
            contains = array.Contains("C");
            invalid = array.Contains("Z");

            //Assert
            Assert.IsTrue(contains);
            Assert.IsFalse(invalid);
        }

        [TestMethod]
        public void ArrayAddWorks()
        {
            //Arrange
#pragma warning disable IDE0028 // Simplify collection initialization. Makes test more obvious
            Array<string> array = new Array<string>(5);
#pragma warning restore IDE0028 // Simplify collection initialization
            int count = array.Count;
            int countAfter;

            //Act
            array.Add("Z");
            array.Add("25");
            countAfter = array.Count;

            //Assert
            Assert.IsTrue(array.Contains("Z"));
            Assert.IsTrue(array.Contains("25"));
            Assert.AreEqual(countAfter, count + 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArrayAddThrowsExceptionWhenNull()
        {
            //Arrange
            Array<string> array = new Array<string>(5);

            //Act
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type. Needed to test what happens when null
            array.Add(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }


        [TestMethod]
        public void ArrayRemoveWorks()
        {
            //Arrange
            Array<string> array = new Array<string>(5) { "A", "B", "C" };
            bool removed;
            int count = array.Count;
            int countAfter;

            //Act
            removed = array.Remove("B");
            countAfter = array.Count;

            //Assert
            Assert.IsTrue(removed);
            Assert.IsFalse(array.Contains("B"));
            Assert.AreEqual(countAfter, count - 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArrayRemoveThrowsExceptionWhenNull()
        {
            //Arrange
            Array<string> array = new Array<string>(5);

            //Act
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type. Needed to test what happens when null
            _ = array.Remove(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }


        [TestMethod]
        public void ArrayCopyToWorks()
        {
            //Arrange
            Array<string> array = new Array<string>(5) { "A", "B", "C", "D", "E" };
            string[] strArr = new string[5];
            string collResult = "";
            string arrayResult = "";

            //Act
            array.CopyTo(strArr, 0);

            foreach (string str in array)
            {
                collResult += str;
            }

            foreach (string str in strArr)
            {
                arrayResult += str;
            }

            //Assert
            Assert.AreEqual(collResult, arrayResult);
        }

        [TestMethod]
        public void GetEnumeratorReturnsEnumerator()
        {
            //Arrange
            Array<string> array = new Array<string>(5) { "A", "B", "C", "D", "E" };

            //Act
            var enumerator = array.GetEnumerator();

            //Assert
            Assert.IsTrue(enumerator is System.Collections.Generic.IEnumerator<string>);
        }

        /* ArrayEnumerator<T> Testing */

        [TestMethod]
        public void ArrayEnumeratorValidBeforeMoveNext()
        {
            //Arrange
            Array<string> array = new Array<string>(5) { "A", "B", "C", "D", "E" };
            using ArrayEnumerator<string> enumerator = new ArrayEnumerator<string>(array);

            //Act
            string current = enumerator.Current;

            //Assert
            Assert.AreEqual(current, default);
        }

        [TestMethod]
        public void ArrayEnumeratorMoveNextRetrievesFirstItem()
        {
            //Arrange
            Array<string> array = new Array<string>(5) { "A", "B", "C", "D", "E" };
            using ArrayEnumerator<string> enumerator = new ArrayEnumerator<string>(array);

            //Act
            enumerator.MoveNext();

            //Assert
            Assert.AreEqual(enumerator.Current, "A");
        }

        [TestMethod]
        public void ArrayEnumeratorResetWorks()
        {
            //Arrange
            Array<string> array = new Array<string>(5) { "A", "B", "C", "D", "E" };
            using ArrayEnumerator<string> enumerator = new ArrayEnumerator<string>(array);
            string first;
            string second;

            //Act
            enumerator.MoveNext();
            first = enumerator.Current;

            enumerator.Reset();

            enumerator.MoveNext();
            second = enumerator.Current;

            //Assert
            Assert.AreEqual(first, second);
        }
    }
}
