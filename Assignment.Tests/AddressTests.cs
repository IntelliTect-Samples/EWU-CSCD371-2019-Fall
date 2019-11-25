using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void Address_Constructor_Qapla()
        {
            //string fname, string lname, string streetAddress, string city, string state, string zip, string email
            IAddress address = new Address("12345 6th ave.", "Cheney", "WA", "99004");
            Assert.AreEqual(address.StreetAddress, "12345 6th ave.");
            Assert.AreEqual(address.City, "Cheney");
            Assert.AreEqual(address.State, "WA");
            Assert.AreEqual(address.Zip, "99004");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Address_Constructor_Fail()
        {
            IAddress address = new Address(null!, null!, null!, null!);
        }

    }
}
