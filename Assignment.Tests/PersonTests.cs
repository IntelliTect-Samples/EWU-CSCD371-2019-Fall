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

        private static IEnumerable<object[]> GetObjectEqualsData()
        {
            yield return new object[] { FakePerson, null!, false };
            yield return new object[] { FakePerson, FakePerson, true };
            yield return new object[] { FakePerson, FakeSamePerson, true };
            yield return new object[] { FakePerson, FakeDifferentPerson, false };
            yield return new object[] { FakePerson, FakeSamePersonDifferentAddress, false };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetObjectEqualsData), DynamicDataSourceType.Method)]
        public void ObjectEquals_GivenTestCase_MatchesExpected(Person left, object right, bool expected)
            => Assert.AreEqual<bool>(expected, left?.Equals(right) ?? !expected);
        // I know left cannot be null, but adding null handling because assignment doesn't
        // allow disabling/pragma of nullable warnings, and they have to be handled,
        // and compiler/analyzers are still giving nullable warnings on left!.Equals(right)

        private static IEnumerable<object[]> GetPersonEqualsData()
        {
            yield return new object[] { FakePerson, null!, false };
            yield return new object[] { FakePerson, FakePerson, true };
            yield return new object[] { FakePerson, FakeSamePerson, true };
            yield return new object[] { FakePerson, FakeDifferentPerson, false };
            yield return new object[] { FakePerson, FakeSamePersonDifferentAddress, false };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetPersonEqualsData), DynamicDataSourceType.Method)]
        public void PersonEquals_GivenTestCase_MatchesExpected(Person left, Person right, bool expected)
            => Assert.AreEqual<bool>(expected, left?.Equals(right) ?? !expected);

        private static IEnumerable<object[]> GetOperatorEqualsData()
        {
            yield return new object[] { null!, null!, true };
            yield return new object[] { null!, FakePerson, false };
            yield return new object[] { FakePerson, null!, false };
            yield return new object[] { FakePerson, FakePerson, true };
            yield return new object[] { FakePerson, FakeSamePerson, true };
            yield return new object[] { FakePerson, FakeDifferentPerson, false };
            yield return new object[] { FakePerson, FakeSamePersonDifferentAddress, false };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOperatorEqualsData), DynamicDataSourceType.Method)]
        public void OperatorEquals_GivenTestCase_MatchesExpected(Person left, Person right, bool expected)
            => Assert.AreEqual<bool>(expected, left == right);

        [DataTestMethod]
        [DynamicData(nameof(GetOperatorEqualsData), DynamicDataSourceType.Method)]
        public void OperatorNotEquals_GivenEqualsTestCase_MatchesOppositeOfExpected(Person left, Person right, bool expected)
            => Assert.AreEqual<bool>(!expected, left != right);
    }
}