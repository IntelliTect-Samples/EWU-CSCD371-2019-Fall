using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentTests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void AddressConstructor_CreatesAddress_Success()
        {
            // Arrange
            Address sut = new Address("123 Main St", "Chehalis", "WA", "98532");

            // Act

            // Assert
            Assert.IsNotNull(sut);
        }

        [DataTestMethod]
        [DataRow(null, "Chehalis", "WA", "98532")]
        [DataRow("123 Main St", null, "WA", "98532")]
        [DataRow("123 Main St", "Chehalis", null, "98532")]
        [DataRow("123 Main St", "Chehalis", "WA", null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddressConstructor_NullParameters_ThrowsException(string streetAddress, string city,
            string state, string zip)
        {
            Address sut = new Address(streetAddress, city, state, zip);
        }
    }
}
