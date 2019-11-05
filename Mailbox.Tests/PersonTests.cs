using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Person_Equals_AreEqual()
        {
            // Arrange
            Person testPerson1 = new Person("first", "last");
            Person testPerson2 = new Person("first", "last");

            // Act


            // Assert
            Assert.IsTrue(testPerson1.Equals(testPerson2));
        }

        [TestMethod]
        public void Person_ToString_ReturnsCorrectlyFormattedString()
        {
            // Arrange
            Person testPerson1 = new Person("First", "Last");

            // Act


            // Assert
            Assert.AreEqual(testPerson1.ToString(), "First Last");
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow(null, "last")]
        [DataRow("first", null)]
        public void Person_Constructor_ThrowsException(string firstName, string lastName)
        {
            // Arrange
            Person sut = new Person(firstName, lastName);

            // Act


            // Assert
        }
    }
}
