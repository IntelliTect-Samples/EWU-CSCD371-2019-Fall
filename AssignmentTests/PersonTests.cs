using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentTests
{
    [TestClass]
    public class PersonTests
    {

        [TestMethod]
        public void PersonConstructor_CreatesPerson_Success()
        {
            // Arrange
            Address address = new Address("123 Main St", "Cheahlis", "WA", "98532");
            Person sut = new Person("Jerett", "Latimer", address, "jlatimer2@yahoo.com");

            // Act

            // Assert
            Assert.IsNotNull(sut);
        }

        [DataTestMethod]
        [DataRow(null, "Latimer", "jlatimer2@yahoo.com")]
        [DataRow("Jerett", null, "jlatimer2@yahoo.com")]
        [DataRow("Jerett", "Latimer", null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonConstructor_NullParameters_ThrowsException(string firstName, string lastName, string email)
        {
            Address address = new Address("123 Main St", "Cheahlis", "WA", "98532");
            Person sut = new Person(firstName, lastName, address, email);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonConstructor_NullAddressParameter_ThrowsException()
        {
            Person sut = new Person("Jerett", "Latimer", null!, "jlatimer2@yahoo.com");
        }
    }
}
