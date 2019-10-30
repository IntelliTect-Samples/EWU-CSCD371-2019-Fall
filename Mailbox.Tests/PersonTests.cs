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
        [DataRow("Doug", "Student")]
        [DataRow("Jimmy", "Person")]
        [DataRow("Anastasia", "Smith")]
        [DataRow("John", "Doe")]
        public void Person_Constructor_SetsFirstAndLastName(string firstName, string lastName)
        {
            Person p = new Person(firstName, lastName);

            Assert.AreEqual(firstName, p.FirstName);
            Assert.AreEqual(lastName, p.LastName);
        }

        [TestMethod]
        [DataRow(null, "Student")]
        [DataRow("Doug", null)]
        [DataRow(null, null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Person_Constructor_NullNames_ThrowArgumentNullException(string? firstName, string? lastName)
        {
            _ = new Person(firstName, lastName);
        }

        [TestMethod]
        [DataRow("Doug", "Student")]
        [DataRow("Jimmy", "Person")]
        [DataRow("Anastasia", "Smith")]
        [DataRow("John", "Doe")]
        public void Person_GetHashCode_ReturnsOverridenHashCode(string firstName, string lastName)
        {
            Person p = new Person(firstName, lastName);

            int hashCode = p.GetHashCode();

            Assert.AreEqual((firstName, lastName).GetHashCode(), hashCode);
        }
    }
}
