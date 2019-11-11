using Assignment6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment6Tests
{
    [TestClass]
    public class ArrayTests
    {
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
    }
}
