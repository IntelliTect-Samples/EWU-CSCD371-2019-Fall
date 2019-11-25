using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Tests
{
    [TestClass]
    public class PersonTests
    {
        private static Address FakeAddress { get; } = new Address()
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

        private static Person FakePerson { get; } = new Person()
        {
            FirstName = "firstname",
            LastName = "lastname",
            EmailAddress = "emailaddress",
            Address = FakeAddress
        };

        private static Person FakeSamePerson { get; } = new Person()
        {
            FirstName = "firstname",
            LastName = "lastname",
            EmailAddress = "emailaddress",
            Address = FakeAddress
        };

        private static Person FakeDifferentPerson { get; } = new Person()
        {
            FirstName = "differentfirstname",
            LastName = "differentlastname",
            EmailAddress = "differentemailaddress",
            Address = FakeDifferentAddress
        };

        private static Person FakeSamePersonDifferentAddress { get; } = new Person()
        {
            FirstName = "firstname",
            LastName = "lastname",
            EmailAddress = "emailaddress",
            Address = FakeDifferentAddress
        };

        // will refactor to data driven testing later

        [TestMethod]
        public void ObjectEquals_NullData_ReturnsFalse()
        {
            bool areEqual = FakePerson.Equals((object) null!);

            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void ObjectEquals_SameData_ReturnsTrue()
        {
            bool areEqual = FakePerson.Equals((object) FakeSamePerson);

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void ObjectEquals_DifferentData_ReturnsFalse()
        {
            bool areEqual = FakePerson.Equals((object) FakeDifferentPerson);

            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void ObjectEquals_SamePersonDifferentAddress_ReturnsFalse()
        {
            bool areEqual = FakePerson.Equals((object) FakeSamePersonDifferentAddress);

            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void PersonEquals_NullData_ReturnsFalse()
        {
            bool areEqual = FakePerson.Equals((Person) null!);

            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void PersonEquals_SameData_ReturnsTrue()
        {
            bool areEqual = FakePerson.Equals(FakeSamePerson);

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void PersonEquals_DifferentData_ReturnsFalse()
        {
            bool areEqual = FakePerson.Equals(FakeDifferentPerson);

            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void PersonEquals_SamePersonDifferentAddress_ReturnsFalse()
        {
            bool areEqual = FakePerson.Equals(FakeSamePersonDifferentAddress);

            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void OperatorEquals_RightNullData_ReturnsFalse()
        {
            bool areEqual = FakePerson == null!;

            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void OperatorEquals_LeftNullData_ReturnsFalse()
        {
            bool areEqual = null! == FakePerson;

            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void OperatorEquals_SameData_ReturnsTrue()
        {
            bool areEqual = FakePerson == FakeSamePerson;

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void OperatorEquals_SamePersonDifferentAddress_ReturnsFalse()
        {
            bool areEqual = FakePerson == FakeSamePersonDifferentAddress;

            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void OperatorNotEquals_RightNullData_ReturnsTrue()
        {
            bool areNotEqual = FakePerson != null!;

            Assert.IsTrue(areNotEqual);
        }

        [TestMethod]
        public void OperatorNotEquals_LeftNullData_ReturnsTrue()
        {
            bool areNotEqual = null! != FakePerson;

            Assert.IsTrue(areNotEqual);
        }

        [TestMethod]
        public void OperatorNotEquals_SameData_ReturnsFalse()
        {
            bool areNotEqual = FakePerson != FakeSamePerson;

            Assert.IsFalse(areNotEqual);
        }
    }
}