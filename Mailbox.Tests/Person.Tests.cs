using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Constructor_ValidArgs_CorrectValues()
        {
            var fname = "Inigo";
            var lname = "Montoya";

            var person = new Person(fname, lname);

            Assert.AreEqual(fname, person.FirstName);
            Assert.AreEqual(lname, person.LastName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullFirstName_ThrowsException()
        {
#nullable disable
            new Person(null, "montoya");
#nullable enable
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullLastName_ThrowsException()
        {
#nullable disable
            new Person("Inigo", null);
#nullable enable
        }

        [TestMethod]
        public void Equals_Equal_True()
        {
            var person1 = new Person("Inigo", "Montoya");
            var person2 = new Person("Inigo", "Montoya");
            Assert.IsTrue(person1 == person2);
        }

        [TestMethod]
        public void Equals_NotEqual_False()
        {
            var person1 = new Person("Inigo", "Montoya");
            var person2 = new Person("Miracle", "Max");
            Assert.IsFalse(person1 == person2);
        }
    }
}
