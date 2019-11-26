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

        public static IEnumerable<object[]> GetGreaterEqualData()
        {
            // have to use a tuple because differing param types, but still have to wrap in array to satisfy dynamicdata method requirements
            yield return new object[] { new ValueTuple<Address, Address, bool>(null!, null!, true) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, null!, true) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(null!, FakeAddress, false) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeAddress, true) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeSameAddress, true) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeDifferentAddress, true) }; //diff is smaller
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeDifferentAddress, FakeAddress, false) };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetGreaterEqualData), DynamicDataSourceType.Method)] // can't pass in addresses the simple way
        public void OperaterGreaterEqual_GivenTestCase_MatchesExpected((Address Left, Address Right, bool Expected) testData)
            => Assert.AreEqual<bool>(testData.Expected, testData.Left >= testData.Right);

        public static IEnumerable<object[]> GetLessEqualData()
        {
            yield return new object[] { new ValueTuple<Address, Address, bool>(null!, null!, true) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, null!, false) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(null!, FakeAddress, true) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeAddress, true) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeSameAddress, true) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeDifferentAddress, false) }; //diff is smaller
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeDifferentAddress, FakeAddress, true) };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetLessEqualData), DynamicDataSourceType.Method)]
        public void OperaterLessEqual_GivenTestCase_MatchesExpected((Address Left, Address Right, bool Expected) testData)
            => Assert.AreEqual<bool>(testData.Expected, testData.Left <= testData.Right);

        public static IEnumerable<object[]> GetGreaterData()
        {
            // why do I have to wrap the return in an array?  won't run if I only return the tuple
            yield return new object[] { new ValueTuple<Address, Address, bool>(null!, null!, false) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, null!, true) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(null!, FakeAddress, false) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeAddress, false) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeSameAddress, false) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeDifferentAddress, true) }; //diff is smaller
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeDifferentAddress, FakeAddress, false) };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetGreaterData), DynamicDataSourceType.Method)] // can't pass in addresses the simple way
        public void OperaterGreater_GivenTestCase_MatchesExpected((Address Left, Address Right, bool Expected) testData)
            => Assert.AreEqual<bool>(testData.Expected, testData.Left > testData.Right);

        public static IEnumerable<object[]> GetLesserData()
        {
            yield return new object[] { new ValueTuple<Address, Address, bool>(null!, null!, false) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, null!, false) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(null!, FakeAddress, true) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeAddress, false) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeSameAddress, false) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeDifferentAddress, false) }; //diff is smaller
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeDifferentAddress, FakeAddress, true) };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetLesserData), DynamicDataSourceType.Method)]
        public void OperaterLesser_GivenTestCase_MatchesExpected((Address Left, Address Right, bool Expected) testData)
            => Assert.AreEqual<bool>(testData.Expected, testData.Left < testData.Right);
    }
}