using System;
using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void Constructor_ValidParameters_ParameterEqualsValue()
        {
            string street = "123 fake street", state = "WA", city = "spokane", zip = "99208";
            Address testAddress = new Address(street, city, state, zip);

            Assert.AreEqual(testAddress.City, city);
            Assert.AreEqual(testAddress.State, state);
            Assert.AreEqual(testAddress.StreetAddress, street);
            Assert.AreEqual(testAddress.Zip, zip);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullStreet_ThrowsException()
        {
            string? street = null;
            string state = "WA", city = "spokane", zip = "99208";
            _ = new Address(street!, city, state, zip);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullState_ThrowsException()
        {
            string? state = null;
            string street = "123 fake street", city = "spokane", zip = "99208";
            _ = new Address(street, city, state!, zip);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullCity_ThrowsException()
        {
            string? city = null;
            string state = "WA", street = "123 fake street", zip = "99208";
            _ = new Address(street, city!, state, zip);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullZip_ThrowsException()
        {
            string? zip = null;
            string state = "WA", city = "spokane", street = "123 fake street";
            _ = new Address(street, city, state, zip!);
        }

        [TestMethod]
        public void Equal_EqualAddresses_ReturnTrue()
        {
            Address address1 = new Address("123 fake street", "spokane", "WA", "99208");
            Address address2 = new Address("123 fake street", "spokane", "WA", "99208");

            Assert.IsTrue(address1.Equal(address2));
        }

        [TestMethod]
        public void Equal_UnEqualAddresses_ReturnFalse()
        {
            Address address1 = new Address("123 fake street", "spokane", "WA", "99208");
            Address address2 = new Address("123 real street", "spokane", "WA", "99208");

            Assert.IsFalse(address1.Equal(address2));
        }

        [TestMethod]
        public void Equal_NullAddress_ReturnFalse()
        {
            Address address1 = new Address("123 fake street", "spokane", "WA", "99208");
            Assert.IsFalse(address1.Equal(null!));
        }
    }
}