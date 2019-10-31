using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests
    {
        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow(null, "Simpson")]
        [DataRow("Homer", null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullParameters_ThrowsExcecption(string? firstName, string? lastName)
        {
            Person _ = new Person(firstName, lastName);
        }

        [TestMethod]
        public void ToString_ValidName_ReturnsCorrectStringRepresentation()
        {
            string firstName = "Joe";
            string lastName = "Grills";
            Person joeGrills = new Person(firstName, lastName);
            Assert.AreEqual($"{firstName} {lastName}", joeGrills.ToString());
        }

        [TestMethod]
        public void Equals_SameFirstAndLastName_ReturnsTrue()
        {
            string firstName = "Joe";
            string lastName = "Grills";
            Person joeGrills = new Person(firstName, lastName);
            Person joeGrills2 = new Person(firstName, lastName);
            Assert.IsTrue(joeGrills.Equals(joeGrills2));
        }

        [TestMethod]
        public void Equals_DifferentFirstAndLastName_ReturnsFalse()
        {
            string firstName = "Joe";
            string lastName = "Grills";
            string firstName2 = "Homer";
            string lastName2 = "Simpson";
            Person joeGrills = new Person(firstName, lastName);
            Person homerSimpson = new Person(firstName2, lastName2);
            Assert.IsFalse(joeGrills.Equals(homerSimpson));
        }

        [TestMethod]
        public void Equals_SameFirstNameDifferentLastName_ReturnsFalse()
        {
            string firstName = "Joe";
            string lastName = "Grills";
            string lastName2 = "Simpson";
            Person joeGrills = new Person(firstName, lastName);
            Person joeSimpson = new Person(firstName, lastName2);
            Assert.IsFalse(joeGrills.Equals(joeSimpson));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Equals_NullParameter_ThrowsException()
        {
            string firstName = "Homer";
            string lastName = "Simpson";
            Person homerSimpson = new Person(firstName, lastName);
            object? nullObject = null;
#pragma warning disable CS8604 // I am intentionally passing null here.
            _ = homerSimpson.Equals(nullObject);
#pragma warning restore CS8604
        }

        [TestMethod]
        public void GetHashcode_TwoDifferentPeople_ReturnsDifferentHashCodes()
        {
            Person homerSimpson = new Person("Homer", "Simpson");
            Person nedFlanders = new Person("Ned", "Flanders");
            Assert.AreNotEqual(homerSimpson.GetHashCode(), nedFlanders.GetHashCode());
        }

        [TestMethod]
        public void GetHashcode_SamePerson_ReturnsSameHashCodes()
        {
            Person homerSimpson = new Person("Homer", "Simpson");
            Person homerSimpson2 = new Person("Homer", "Simpson");
            Assert.AreEqual(homerSimpson.GetHashCode(), homerSimpson2.GetHashCode());
        }

        [TestMethod]
        public void OperatorEqualsEquals_SamePeople_ReturnsTrue()
        {
            Person homerSimpson = new Person("Homer", "Simpson");
            Person homerSimpson2 = new Person("Homer", "Simpson");
            Assert.IsTrue(homerSimpson == homerSimpson2);
        }

        [TestMethod]
        public void OperatorEqualsEquals_DifferentPeople_ReturnsFalse()
        {
            Person homerSimpson = new Person("Homer", "Simpson");
            Person nedFlanders = new Person("Ned", "Flanders");
            Assert.IsFalse(homerSimpson == nedFlanders);
        }

        [TestMethod]
        public void OperatorNotEquals_SamePeople_ReturnsFalse()
        {
            Person homerSimpson = new Person("Homer", "Simpson");
            Person homerSimpson2 = new Person("Homer", "Simpson");
            Assert.IsFalse(homerSimpson != homerSimpson2);
        }

        [TestMethod]
        public void OperatorNotEquals_DifferentPeople_ReturnsTrue()
        {
            Person homerSimpson = new Person("Homer", "Simpson");
            Person nedFlanders = new Person("Ned", "Flanders");
            Assert.IsTrue(homerSimpson != nedFlanders);
        }
    }
}