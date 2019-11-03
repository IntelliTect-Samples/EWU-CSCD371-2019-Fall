using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        [DataRow(null, "lastname")]
        [DataRow("firstname", null)]
        [DataRow(null, null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullParameters_ThowsException(string firstName, string lastName)
        {
            Person _ = new Person(firstName, lastName);
        }


        [TestMethod]
        [DataRow("firstname", "lastname")]
        [DataRow("first name", "Last-name")]
        [DataRow("NotNull", "ALso not_null")]
        public void Constructor_CorrectParameters_ReturnsPerson(string firstName, string lastName)
        {
            Person person = new Person(firstName, lastName);
            Assert.IsNotNull(person);
            Assert.AreEqual(person._FirstName, firstName);
            Assert.AreEqual(person._LastName, lastName);
        }

        [TestMethod]
        [DataRow("firstname", "lastname")]
        [DataRow("first name", "Last-name")]
        [DataRow("NotNull", "ALso not_null")]
        public void EqualsOverride_ReturnsTrue(string firstName, string lastName)
        {
            Person person1 = new Person(firstName, lastName);
            Person person2 = new Person(firstName, lastName);
            Assert.IsTrue(person1==person2);
        }

        [TestMethod]
        [DataRow("firstname", "lastname")]
        public void ToString_ReturnsValidString(string firstName, string lastName)
        {
            Person person1 = new Person(firstName, lastName);
            Assert.AreEqual(person1.ToString, "firstname lastname");
        }
    }
}