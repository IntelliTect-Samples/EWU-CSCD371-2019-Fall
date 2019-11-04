using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    class PersonTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonGivenNull_ThrowsArgNullEx()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type. This is a Unit Test
            var _ = new Person(null, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [TestMethod]
        public void EqualsGivenWrongObject_ReturnsFalse()
        {
            //Arrange
            Person pers = new Person("First", "Last");
            bool equal;

            //Act
            equal = pers.Equals("Test");

            //Assert
            Assert.IsFalse(equal);
        }
    }
}
