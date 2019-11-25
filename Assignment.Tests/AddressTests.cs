using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Tests
{
    [TestClass]
    public class AddressTests
    {
        private static Address FakeAddress { get; } = new Address()
        {
            City = "city",
            State = "state",
            StreetAddress = "streetaddress",
            Zip = "zip"
        };
        private static Address FakeSameAddress { get; } = new Address()
        {
            City = "city",
            State = "state",
            StreetAddress = "streetaddress",
            Zip = "zip"
        };
        private static Address FakeDifferentAddress { get; } = new Address()
        {
            City = "differentcity",
            State = "differentstate",
            StreetAddress = "differentstreetaddress",
            Zip = "differentzip"
        };

        // will refactor to data driven testing later

        [TestMethod]
        public void ObjectEquals_SameData_ReturnsTrue()
        {
            bool areEqual = FakeAddress.Equals((object) FakeSameAddress);

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void ObjectEquals_DifferentData_ReturnsFalse()
        {
            bool areEqual = FakeAddress.Equals((object) FakeDifferentAddress);

            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void AddressEquals_SameData_ReturnsTrue()
        {
            bool areEqual = FakeAddress.Equals(FakeSameAddress);

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void AddressEquals_DifferentData_ReturnsFalse()
        {
            bool areEqual = FakeAddress.Equals(FakeDifferentAddress);

            Assert.IsFalse(areEqual);
        }

        // dont need to test negation, it's passing through to address equals
        [TestMethod]
        public void OperatorEquals_SameData_ReturnsTrue()
        {
            bool areEqual = FakeAddress == FakeSameAddress;

            Assert.IsTrue(areEqual);
        }

        // dont need to test negation, it's passing through to address equals
        [TestMethod]
        public void OperatorNotEquals_SameData_ReturnsTrue()
        {
            bool areNotEqual = FakeAddress != FakeSameAddress;

            Assert.IsFalse(areNotEqual);
        }

        [TestMethod]
        public void CompareTo_NullData_ReturnsGreaterThanZero()
        {
            int expected = 1;
            int comparison = FakeAddress.CompareTo(null!);

            Assert.AreEqual<int>(expected, comparison);
        }

        [TestMethod]
        public void CompareTo_SameData_ReturnsZero()
        {
            int expected = 0;
            int comparison = FakeAddress.CompareTo(FakeSameAddress);

            Assert.AreEqual<int>(expected, comparison);
        }

        [TestMethod]
        public void CompareTo_DifferentData_ReturnsGreaterThanZero()
        {
            // fakediff state starts with d, fake starts with s, so fakediff is smaller
            int expected = 1;
            int comparison = FakeAddress.CompareTo(FakeDifferentAddress);

            Assert.AreEqual<int>(expected, comparison);
        }
    }
}