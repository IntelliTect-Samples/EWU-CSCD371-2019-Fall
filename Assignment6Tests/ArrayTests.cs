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
            var _ = new Array<string>(cap);
        }
    }
}
