using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Ctor_ValidArguments_PropogatesValues()
        {
            string fName = "Inigo", lName = "Montoya", email = "inigo.montoya@father.com";
            var address = new Address("123 Fake St", "Candyland", "Confusion", "123456");
            var person = new Person(fName, lName, email, address);

            Assert.AreEqual<string>(fName, person.FirstName);
            Assert.AreEqual<string>(fName, person.FirstName);
            Assert.AreEqual<string>(email, person.EmailAddress);
            Assert.AreEqual<IAddress>(address, person.Address);
        }

        [TestMethod]
        public void Ctor_NullFirstName_ThrowsException()
        {
            string? fName = null;
            string lName = "Montoya", email = "inigo.montoya@father.com";
            var address = new Address("123 Fake St", "Candyland", "Confusion", "123456");
            Assert.ThrowsException<ArgumentNullException>(() => new Person(fName!, lName, email, address));
        }

        [TestMethod]
        public void Ctor_NullLastName_ThrowsException()
        {
            string? lName = null;
            string fName = "Inigo", email = "inigo.montoya@father.com";
            var address = new Address("123 Fake St", "Candyland", "Confusion", "123456");
            Assert.ThrowsException<ArgumentNullException>(() => new Person(fName, lName!, email, address));
        }

        [TestMethod]
        public void Ctor_NullEmail_ThrowsException()
        {
            string? email = null;
            string fName = "Inigo", lName = "Montoya";
            var address = new Address("123 Fake St", "Candyland", "Confusion", "123456");
            Assert.ThrowsException<ArgumentNullException>(() => new Person(fName, lName, email!, address));
        }

        [TestMethod]
        public void Ctor_NullAddress_ThrowsException()
        {
            string fName = "Inigo", lName = "Montoya", email = "inigo.montoya@father.com";
            Address? address = null;
            Assert.ThrowsException<ArgumentNullException>(() => new Person(fName, lName, email, address!));
        }
    }
}
