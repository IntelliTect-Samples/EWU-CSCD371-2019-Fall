using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{

    [TestClass]
    public class PersonTests
    {

        [DataTestMethod]
        [DataRow("A", null)]
        [DataRow(null, "B")]
        [DataRow(null, null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_GivenNullStrings_ThrowsException(string? firstName, string? lastName)
        {
            var person = new Person(firstName, lastName);
        }

        [DataTestMethod]
        [DataRow("John", "Price")]
        [DataRow("John", "MacTavish")]
        [DataRow("Kyle", "Garrick")]
        [DataRow("Simon", "Riley")]
        public void Constructor_GivenValidStrings_SetsCorrectly(string firstName, string lastName)
        {
            var person = new Person(firstName, lastName);
            
            Assert.AreEqual(firstName, person.FirstName);
            Assert.AreEqual(lastName, person.LastName);
        }

    }

}
