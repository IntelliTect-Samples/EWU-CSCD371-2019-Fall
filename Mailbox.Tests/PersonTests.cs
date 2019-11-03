using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests
    {
        [DataTestMethod]
        [DataRow(null, "last", DisplayName = "Null First Name")]
        [DataRow("first", null, DisplayName = "Null Last Name")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullNames_ThrowsException(string first, string last)
        {
            _ = new Person(first, last);
        }

        [TestMethod]
        public void ToString_GetsStringRepresentation_ConcatenatesNameInReverseOrderCommaSeparated()
        {
            Person testPerson = new Person("First", "Last");

            string result = testPerson.ToString();

            Assert.AreEqual<string>("Last, First", result);
        }

        [TestMethod]
        public void EqualsPerson_SamePerson_ReturnsTrue()
        {
            Person test1 = new Person("First", "Last");
            Person test2 = new Person("First", "Last");

            bool result = test1.Equals(test2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualsPerson_DifferentPerson_ReturnsFalse()
        {
            Person test1 = new Person("First", "Last");
            Person test2 = new Person("1st", "Last");

            bool result = test1.Equals(test2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EqualsObject_SamePerson_ReturnsTrue()
        {
            Person test1 = new Person("First", "Last");
            Person test2 = new Person("First", "Last");

            bool result = test1.Equals((Object) test2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualsObject_DifferentPerson_ReturnsFalse()
        {
            Person test1 = new Person("First", "Last");
            Person test2 = new Person("1st", "Last");

            bool result = test1.Equals((Object) test2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EqualsObject_NullPerson_ReturnsFalse()
        {
            Person test = new Person("First", "Last");

            bool result = test.Equals(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EqualsOperator_SamePerson_ReturnsTrue()
        {
            Person test1 = new Person("First", "Last");
            Person test2 = new Person("First", "Last");

            bool result = test1 == test2;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualsOperator_DifferentPerson_ReturnsFalse()
        {
            Person test1 = new Person("First", "Last");
            Person test2 = new Person("1st", "Last");

            bool result = test1 == test2;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EqualsOperator_NullRightPerson_ReturnsFalse()
        {
            Person test = new Person("First", "Last");

            bool result = test == null;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EqualsOperator_NullLeftPerson_ReturnsFalse()
        {
            Person test = new Person("First", "Last");

            bool result = null == test;

            Assert.IsFalse(result);
        }

        // only testing one case, as it's just a logical inversion of == operator
        // if one works the other should too
        [TestMethod]
        public void NotEqualsOperator_SamePerson_ReturnsFalse()
        {
            Person test1 = new Person("First", "Last");
            Person test2 = new Person("First", "Last");

            bool result = test1 != test2;

            Assert.IsFalse(result);
        }
    }
}
