using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void Ctor_ValidArguments_PropogatesValues()
        {
            string street = "123 Fake St", city = "Candyland", state = "Confusion", zip = "123456";
            var address = new Address(street, city, state, zip);

            Assert.AreEqual<string>(street, address.StreetAddress);
            Assert.AreEqual<string>(city, address.City);
            Assert.AreEqual<string>(state, address.State);
            Assert.AreEqual<string>(zip, address.Zip);
        }

        [TestMethod]
        public void Ctor_NullStreetAddress_ThrowsException()
        {
            string? street = null;
            string city = "Candyland", state = "Confusion", zip = "123456";
            Assert.ThrowsException<ArgumentNullException>(() => new Address(street!, city, state, zip));
        }

        [TestMethod]
        public void Ctor_NullCity_ThrowsException()
        {
            string? city = null;
            string street = "123 Fake St", state = "Confusion", zip = "123456";
            Assert.ThrowsException<ArgumentNullException>(() => new Address(street, city!, state, zip));
        }

        [TestMethod]
        public void Ctor_NullState_ThrowsException()
        {
            string? state = null;
            string street = "123 Fake St", city = "Candyland", zip = "123456";
            Assert.ThrowsException<ArgumentNullException>(() => new Address(street, city, state!, zip));
        }

        [TestMethod]
        public void Ctor_NullZip_ThrowsException()
        {
            string? zip = null;
            string street = "123 Fake St", city = "Candyland", state = "Confusion";
            Assert.ThrowsException<ArgumentNullException>(() => new Address(street, city, state, zip!));
        }

        [TestMethod]
        public void Equals_Null_False()
        {
            var address = new Address("123 Fake St", "Candyland", "Confusion", "123456");
            object? n = null;

            bool equal = address.Equals(n);

            Assert.IsFalse(equal);
        }

        [TestMethod]
        public void Equals_Equal_True()
        {
            var address1 = new Address("123 Fake St", "Candyland", "Confusion", "123456");
            var address2 = new Address("123 Fake St", "Candyland", "Confusion", "123456");

            bool equal = address1.Equals(address2);

            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void Equals_NotEqual_False()
        {
            var address1 = new Address("123 Fake St", "Candyland", "Confusion", "123456");
            var address2 = new Address("456 Real Ave", "Mordor", "Nebraska", "987654");

            bool equal = address1.Equals(address2);

            Assert.IsFalse(equal);
        }
    }
}
