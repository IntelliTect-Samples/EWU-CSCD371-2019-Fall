using System;
using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Constructor_ValidParameters_ParameterEqualsValue()
        {
            string firstName = "Inigo", lastName = "Montoya", email = "Inigo@montoya.com";
            Address testAddress = new Address("123 fake street", "Spokane", "WA", "99208");

            Person person = new Person(firstName, lastName, testAddress, email);

            Assert.AreEqual(person.FirstName, firstName);
            Assert.AreEqual(person.LastName, lastName);
            Assert.AreEqual(person.EmailAddress, email);
            Assert.AreEqual(person.Address, testAddress);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullFirstname_ThrowsException()
        {
            string? firstName = null, lastName = "Montoya", email = "Inigo@montoya.com";
            Address testAddress = new Address("123 fake street", "Spokane", "WA", "99208");
            _ = new Person(firstName!, lastName, testAddress, email);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullLastname_ThrowsException()
        {
            string? firstName = "Inigo", lastName = null, email = "Inigo@montoya.com";
            Address testAddress = new Address("123 fake street", "Spokane", "WA", "99208");
            _ = new Person(firstName, lastName!, testAddress, email);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullEmail_ThrowsException()
        {
            string? firstName = "Inigo", lastName = "Montoya", email = null;
            Address testAddress = new Address("123 fake street", "Spokane", "WA", "99208");
            _ = new Person(firstName, lastName, testAddress, email!);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullAddress_ThrowsException()
        {
            string firstName = "Inigo", lastName = "Montoya", email = "Inigo@montoya.com";
            Address? testAddress = null;
            _ = new Person(firstName, lastName, testAddress!, email);
        }

        [TestMethod]
        public void Equal_EqualAddresses_ReturnTrue()
        {
            Person person1 = new Person("Inigo", "Montoya", new Address("123 fake street", "Spokane", "WA", "99006"), "Inigo@Motoya.com");
            Person person2 = new Person("Inigo", "Montoya", new Address("123 fake street", "Spokane", "WA", "99006"), "Inigo@Motoya.com");

            Assert.IsTrue(person1.Equal(person2));
        }

        [TestMethod]
        public void Equal_UnEqualAddresses_ReturnFalse()
        {
            Person person1 = new Person("Inigo", "Montoya", new Address("123 fake street", "Spokane", "WA", "99006"), "Inigo@Motoya.com");
            Person person2 = new Person("Inigo", "Moya", new Address("123 fake street", "Spokane", "WA", "99006"), "Inigo@Motoya.com");

            Assert.IsFalse(person1.Equal(person2));
        }

        [TestMethod]
        public void Equal_NullAddress_ReturnFalse()
        {
            Person person1 = new Person("Inigo", "Montoya", new Address("123 fake street", "Spokane", "WA", "99006"), "Inigo@Motoya.com");

            Assert.IsFalse(person1.Equal(null!));
        }
    }
}
