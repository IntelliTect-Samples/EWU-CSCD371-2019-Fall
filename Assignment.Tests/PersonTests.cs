using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Tests
{
    [TestClass]
    public class PersonTests
    {
        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("", "last", "email")]
        [DataRow("first", "", "email")]
        [DataRow("first", "last", "")]
        [DataRow(null, "last", "email")]
        [DataRow("first", null, "email")]
        [DataRow("first", "last", null)]
        public void Person_ConstructorNullOrWhitespace_ThrowsException(string first, string last, string email)
        {
            _ = new Person(first, last, new Address("street", "city", "state", "zip"), email);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Person_ConstructorNullAddress_ThrowsException()
        {
            _ = new Person("first", "last", null!, "email");
        }

        [TestMethod]
        public void Person_Constructor_SetsValues()
        {
            string first = "first";
            string last = "last";
            string street = "street";
            string city = "city";
            string state = "state";
            string zip = "zip";
            string email = "email";

            Person person = new Person(first, last, new Address(street, city, state, zip), email);

            Assert.AreEqual(first, person.FirstName);
            Assert.AreEqual(last, person.LastName);
            Assert.AreEqual(street, person.Address.StreetAddress);
            Assert.AreEqual(city, person.Address.City);
            Assert.AreEqual(state, person.Address.State);
            Assert.AreEqual(zip, person.Address.Zip);
            Assert.AreEqual(email, person.EmailAddress);

        }
    }
}
