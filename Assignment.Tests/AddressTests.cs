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
            yield return new object[] { FakeAddress, null!, false };
            yield return new object[] { FakeAddress, FakeAddress, true };
            yield return new object[] { FakeAddress, FakeSameAddress, true };
            yield return new object[] { FakeAddress, FakeDifferentAddress, false };
            yield return new object[] { FakeDifferentAddress, FakeAddress, false };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetObjectEqualsData), DynamicDataSourceType.Method)]
        public void ObjectEquals_GivenTestCase_MatchesExpected(Address left, object right, bool expected)
            => Assert.AreEqual<bool>(expected, left?.Equals(right) ?? !expected);
            // I know left cannot be null, but adding null handling because assignment doesn't
            // allow disabling/pragma of nullable warnings, and they have to be handled,
            // and compiler/analyzers are still giving nullable warnings on left!.Equals(right)

        private static IEnumerable<object[]> GetAddressEqualsData()
        {
            yield return new object[] { FakeAddress, null!, false };
            yield return new object[] { FakeAddress, FakeAddress, true };
            yield return new object[] { FakeAddress, FakeSameAddress, true };
            yield return new object[] { FakeAddress, FakeDifferentAddress, false };
            yield return new object[] { FakeDifferentAddress, FakeAddress, false };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetAddressEqualsData), DynamicDataSourceType.Method)]
        public void AddressEquals_GivenTestCase_MatchesExpected(Address left, Address right, bool expected)
            => Assert.AreEqual<bool>(expected, left?.Equals(right) ?? !expected);

        private static IEnumerable<object[]> GetOperatorEqualsData()
        {
            yield return new object[] { null!, null!, true };
            yield return new object[] { null!, FakeAddress, false };
            yield return new object[] { FakeAddress, null!, false };
            yield return new object[] { FakeAddress, FakeAddress, true };
            yield return new object[] { FakeAddress, FakeSameAddress, true };
            yield return new object[] { FakeAddress, FakeDifferentAddress, false };
            yield return new object[] { FakeDifferentAddress, FakeAddress, false };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOperatorEqualsData), DynamicDataSourceType.Method)]
        public void OperatorEquals_GivenTestCase_MatchesExpected(Address left, Address right, bool expected)
            => Assert.AreEqual<bool>(expected, left == right);

        [DataTestMethod]
        [DynamicData(nameof(GetOperatorEqualsData), DynamicDataSourceType.Method)]
        public void OperatorNotEquals_GivenEqualsTestCase_MatchesOppositeOfExpected(Address left, Address right, bool expected)
            => Assert.AreEqual<bool>(!expected, left != right);

        private static IEnumerable<object[]> GetCompareToData()
        {
            yield return new object[] { FakeAddress, null!, 1 };
            yield return new object[] { FakeAddress, FakeAddress, 0 };
            yield return new object[] { FakeAddress, FakeSameAddress, 0 };
            yield return new object[] { FakeAddress, FakeDifferentAddress, 1 }; // diff is smaller
            yield return new object[] { FakeDifferentAddress, FakeAddress, -1 };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetCompareToData), DynamicDataSourceType.Method)]
        public void CompareTo_GivenTestCase_MatchesExpected(Address left, Address right, int expected)
            => Assert.AreEqual<int>(expected, left?.CompareTo(right) ?? 1-expected);

        private static IEnumerable<object[]> GetGreaterEqualData()
        {
            // have to use a tuple because differing param types, but still have to wrap in array to satisfy dynamicdata method requirements
            yield return new object[] { null!, null!, true };
            yield return new object[] { FakeAddress, null!, true };
            yield return new object[] { null!, FakeAddress, false };
            yield return new object[] { FakeAddress, FakeAddress, true };
            yield return new object[] { FakeAddress, FakeSameAddress, true };
            yield return new object[] { FakeAddress, FakeDifferentAddress, true }; //diff is smaller
            yield return new object[] { FakeDifferentAddress, FakeAddress, false };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetGreaterEqualData), DynamicDataSourceType.Method)] // can't pass in addresses the simple way
        public void OperaterGreaterEqual_GivenTestCase_MatchesExpected(Address left, Address right, bool expected)
            => Assert.AreEqual<bool>(expected, left >= right);

        private static IEnumerable<object[]> GetLessEqualData()
        {
            yield return new object[] { null!, null!, true };
            yield return new object[] { FakeAddress, null!, false };
            yield return new object[] { null!, FakeAddress, true };
            yield return new object[] { FakeAddress, FakeAddress, true };
            yield return new object[] { FakeAddress, FakeSameAddress, true };
            yield return new object[] { FakeAddress, FakeDifferentAddress, false }; //diff is smaller
            yield return new object[] { FakeDifferentAddress, FakeAddress, true };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetLessEqualData), DynamicDataSourceType.Method)]
        public void OperaterLessEqual_GivenTestCase_MatchesExpected(Address left, Address right, bool expected)
            => Assert.AreEqual<bool>(expected, left <= right);

        private static IEnumerable<object[]> GetGreaterData()
        {
            // why do I have to wrap the return in an array?  won't run if I only return the tuple
            yield return new object[] { null!, null!, false };
            yield return new object[] { FakeAddress, null!, true };
            yield return new object[] { null!, FakeAddress, false };
            yield return new object[] { FakeAddress, FakeAddress, false };
            yield return new object[] { FakeAddress, FakeSameAddress, false };
            yield return new object[] { FakeAddress, FakeDifferentAddress, true }; //diff is smaller
            yield return new object[] { FakeDifferentAddress, FakeAddress, false };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetGreaterData), DynamicDataSourceType.Method)] // can't pass in addresses the simple way
        public void OperaterGreater_GivenTestCase_MatchesExpected(Address left, Address right, bool expected)
            => Assert.AreEqual<bool>(expected, left > right);

        private static IEnumerable<object[]> GetLesserData()
        {
            yield return new object[] { null!, null!, false };
            yield return new object[] { FakeAddress, null!, false };
            yield return new object[] { null!, FakeAddress, true };
            yield return new object[] { FakeAddress, FakeAddress, false };
            yield return new object[] { FakeAddress, FakeSameAddress, false };
            yield return new object[] { FakeAddress, FakeDifferentAddress, false }; //diff is smaller
            yield return new object[] { FakeDifferentAddress, FakeAddress, true };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetLesserData), DynamicDataSourceType.Method)]
        public void OperaterLesser_GivenTestCase_MatchesExpected(Address left, Address right, bool expected)
            => Assert.AreEqual<bool>(expected, left < right);
    }
}