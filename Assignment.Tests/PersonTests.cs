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
            yield return new object[] { new ValueTuple<Person, object, bool>(FakePerson, null!, false) };
            yield return new object[] { new ValueTuple<Person, object, bool>(FakePerson, FakePerson, true) };
            yield return new object[] { new ValueTuple<Person, object, bool>(FakePerson, FakeSamePerson, true) };
            yield return new object[] { new ValueTuple<Person, object, bool>(FakePerson, FakeDifferentPerson, false) };
            yield return new object[] { new ValueTuple<Person, object, bool>(FakePerson, FakeSamePersonDifferentAddress, false) };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetObjectEqualsData), DynamicDataSourceType.Method)]
        public void ObjectEquals_GivenTestCase_MatchesExpected((Person Left, object Right, bool Expected) testData)
            => Assert.AreEqual<bool>(testData.Expected, testData.Left.Equals(testData.Right));

        private static IEnumerable<object[]> GetPersonEqualsData()
        {
            yield return new object[] { new ValueTuple<Person, Person, bool>(FakePerson, null!, false) };
            yield return new object[] { new ValueTuple<Person, Person, bool>(FakePerson, FakePerson, true) };
            yield return new object[] { new ValueTuple<Person, Person, bool>(FakePerson, FakeSamePerson, true) };
            yield return new object[] { new ValueTuple<Person, Person, bool>(FakePerson, FakeDifferentPerson, false) };
            yield return new object[] { new ValueTuple<Person, Person, bool>(FakePerson, FakeSamePersonDifferentAddress, false) };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetPersonEqualsData), DynamicDataSourceType.Method)]
        public void PersonEquals_GivenTestCase_MatchesExpected((Person Left, Person Right, bool Expected) testData)
            => Assert.AreEqual<bool>(testData.Expected, testData.Left.Equals(testData.Right));

        private static IEnumerable<object[]> GetOperatorEqualsData()
        {
            yield return new object[] { new ValueTuple<Person, Person, bool>(null!, null!, true) };
            yield return new object[] { new ValueTuple<Person, Person, bool>(null!, FakePerson, false) };
            yield return new object[] { new ValueTuple<Person, Person, bool>(FakePerson, null!, false) };
            yield return new object[] { new ValueTuple<Person, Person, bool>(FakePerson, FakePerson, true) };
            yield return new object[] { new ValueTuple<Person, Person, bool>(FakePerson, FakeSamePerson, true) };
            yield return new object[] { new ValueTuple<Person, Person, bool>(FakePerson, FakeDifferentPerson, false) };
            yield return new object[] { new ValueTuple<Person, Person, bool>(FakePerson, FakeSamePersonDifferentAddress, false) };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOperatorEqualsData), DynamicDataSourceType.Method)]
        public void OperatorEquals_GivenTestCase_MatchesExpected((Person Left, Person Right, bool Expected) testData)
            => Assert.AreEqual<bool>(testData.Expected, testData.Left == testData.Right);

        [DataTestMethod]
        [DynamicData(nameof(GetOperatorEqualsData), DynamicDataSourceType.Method)]
        public void OperatorNotEquals_GivenEqualsTestCase_MatchesOppositeOfExpected((Person Left, Person Right, bool Expected) testData)
            => Assert.AreEqual<bool>(!testData.Expected, testData.Left != testData.Right);
    }
}