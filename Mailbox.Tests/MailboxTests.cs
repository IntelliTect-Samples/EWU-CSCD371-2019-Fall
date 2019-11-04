using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [TestMethod]
        [DataRow(null, 2, 3, "first", "last")]
        [DataRow(0, 2, 3, "first", "last")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullParameters_ThowsException(Size size, int x, int y, string firstName, string lastName)
        {
            Person TestPerson = new Person(firstName, lastName);
            Mailbox mailbox = new Mailbox(size, (x,y), TestPerson);
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
    }
}
