using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Tests
{
    [TestClass()]
    public class AddressTests
    {
        [TestMethod()]
        public void CreateAddressGoodData()
        {
            //Arrange
            string streetAddress = "1212 N. New Street";
            string city = "Spokane";
            string state = "WA";
            string zip = "99223";

            //Act
            Address address = new Address(streetAddress, city, state, zip);

            //Assert
            Assert.IsNotNull(address);
            Assert.AreEqual(address.StreetAddress, streetAddress);
            Assert.AreEqual(address.City, city);
            Assert.AreEqual(address.State, state);
            Assert.AreEqual(address.Zip, zip);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAddressNullStreetThrowsException()
        {
            //Arrange
            string ?streetAddress = null;
            string city = "Spokane";
            string state = "WA";
            string zip = "99223";

            //Act
            Address address = new Address(streetAddress, city, state, zip);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAddressNullCityThrowsException()
        {
            //Arrange
            string streetAddress = "1212 N. New Street";
            string ?city = null;
            string state = "WA";
            string zip = "99223";

            //Act
            Address address = new Address(streetAddress, city, state, zip);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAddressNullStateException()
        {
            //Arrange
            string streetAddress = "1212 N. New Street";
            string city = "Spokane";
            string ?state = null;
            string zip = "99223";

            //Act
            Address address = new Address(streetAddress, city, state, zip);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAddressNullZipThrowsException()
        {
            //Arrange
            string streetAddress = "1212 N. New Street";
            string city = "Spokane";
            string state = "WA";
            string ?zip = null;

            //Act
            Address address = new Address(streetAddress, city, state, zip);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAddressEmptyStreetThrowsException()
        {
            //Arrange
            string streetAddress = "";
            string city = "Spokane";
            string state = "WA";
            string zip = "99223";

            //Act
            Address address = new Address(streetAddress, city, state, zip);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAddressEmptyCityThrowsException()
        {
            //Arrange
            string streetAddress = "1212 N. New Street";
            string city = "";
            string state = "WA";
            string zip = "99223";

            //Act
            Address address = new Address(streetAddress, city, state, zip);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAddressEmptyStateThrowsException()
        {
            //Arrange
            string streetAddress = "1212 N. New Street";
            string city = "Spokane";
            string state = "";
            string zip = "99223";

            //Act
            Address address = new Address(streetAddress, city, state, zip);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAddressEmptyZipThrowsException()
        {
            //Arrange
            string streetAddress = "1212 N. New Street";
            string city = "Spokane";
            string state = "WA";
            string zip = "";

            //Act
            Address address = new Address(streetAddress, city, state, zip);

            //Assert
        }
    }
}