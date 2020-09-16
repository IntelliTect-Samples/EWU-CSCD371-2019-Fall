using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Tests
{
    [TestClass]
    public class AddressTests
    {
        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("", "City", "State", "Zip")]
        [DataRow("Address", "", "State", "Zip")]
        [DataRow("Address", "City", "", "Zip")]
        [DataRow("Address", "City", "State", "")]
        [DataRow(null, "City", "State", "zip")]
        [DataRow("Address", null, "State", "zip")]
        [DataRow("Address", "City", null, "zip")]
        [DataRow("Address", "City", "State", null)]
        public void Address_ConstructorNullOrEmptyParameters_ThrowsException(string address, string city, string state, string zip)
        {
            _ = new Address(address, city, state, zip);
        }

        [TestMethod]
        public void Address_Constructor_AssignsValues()
        {
            string streetAddress = "Address";
            string city = "City";
            string state = "State";
            string zip = "Zip";

            Address address = new Address(streetAddress, city, state, zip);

            Assert.AreEqual(streetAddress, address.StreetAddress);
            Assert.AreEqual(city, address.City);
            Assert.AreEqual(state, address.State);
            Assert.AreEqual(zip, address.Zip);
        }
    }
}
