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

        private static IEnumerable<object[]> GetObjectEqualsData()
        {
            yield return new object[] { new ValueTuple<Address, object, bool>(FakeAddress, null!, false) };
            yield return new object[] { new ValueTuple<Address, object, bool>(FakeAddress, FakeAddress, true) };
            yield return new object[] { new ValueTuple<Address, object, bool>(FakeAddress, FakeSameAddress, true) };
            yield return new object[] { new ValueTuple<Address, object, bool>(FakeAddress, FakeDifferentAddress, false) };
            yield return new object[] { new ValueTuple<Address, object, bool>(FakeDifferentAddress, FakeAddress, false) };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetObjectEqualsData), DynamicDataSourceType.Method)]
        public void ObjectEquals_GivenTestCase_MatchesExpected((Address Left, object Right, bool Expected) testData)
            => Assert.AreEqual<bool>(testData.Expected, testData.Left.Equals(testData.Right));

        private static IEnumerable<object[]> GetAddressEqualsData()
        {
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, null!, false) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeAddress, true) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeSameAddress, true) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeDifferentAddress, false) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeDifferentAddress, FakeAddress, false) };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetAddressEqualsData), DynamicDataSourceType.Method)]
        public void AddressEquals_GivenTestCase_MatchesExpected((Address Left, Address Right, bool Expected) testData)
            => Assert.AreEqual<bool>(testData.Expected, testData.Left.Equals(testData.Right));

        private static IEnumerable<object[]> GetOperatorEqualsData()
        {
            yield return new object[] { new ValueTuple<Address, Address, bool>(null!, null!, true) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(null!, FakeAddress, false) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, null!, false) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeAddress, true) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeSameAddress, true) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeAddress, FakeDifferentAddress, false) };
            yield return new object[] { new ValueTuple<Address, Address, bool>(FakeDifferentAddress, FakeAddress, false) };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOperatorEqualsData), DynamicDataSourceType.Method)]
        public void OperatorEquals_GivenTestCase_MatchesExpected((Address Left, Address Right, bool Expected) testData)
            => Assert.AreEqual<bool>(testData.Expected, testData.Left == testData.Right);

        [DataTestMethod]
        [DynamicData(nameof(GetOperatorEqualsData), DynamicDataSourceType.Method)]
        public void OperatorNotEquals_GivenEqualsTestCase_MatchesOppositeOfExpected((Address Left, Address Right, bool Expected) testData)
            => Assert.AreEqual<bool>(!testData.Expected, testData.Left != testData.Right);

        private static IEnumerable<object[]> GetCompareToData()
        {
            yield return new object[] { new ValueTuple<Address, Address, int>(FakeAddress, null!, 1) };
            yield return new object[] { new ValueTuple<Address, Address, int>(FakeAddress, FakeAddress, 0) };
            yield return new object[] { new ValueTuple<Address, Address, int>(FakeAddress, FakeSameAddress, 0) };
            yield return new object[] { new ValueTuple<Address, Address, int>(FakeAddress, FakeDifferentAddress, 1) }; // diff is smaller
            yield return new object[] { new ValueTuple<Address, Address, int>(FakeDifferentAddress, FakeAddress, -1) };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetCompareToData), DynamicDataSourceType.Method)]
        public void CompareTo_GivenTestCase_MatchesExpected((Address Left, Address Right, int Expected) testData)
            => Assert.AreEqual<int>(testData.Expected, testData.Left.CompareTo(testData.Right));

        private static IEnumerable<object[]> GetGreaterEqualData()
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

        private static IEnumerable<object[]> GetLessEqualData()
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

        private static IEnumerable<object[]> GetGreaterData()
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

        private static IEnumerable<object[]> GetLesserData()
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