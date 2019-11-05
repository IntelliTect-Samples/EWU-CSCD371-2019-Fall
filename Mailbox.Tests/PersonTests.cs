using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        [DataRow(null, null)]
        [DataRow("Test", null)]
        [DataRow(null, "Name")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullName(string firstName, string lastName)
        {
            Person person = new Person(firstName, lastName);
        }


        [TestMethod]
        [DataRow("Test", "test")]
        [DataRow("First", "Last")]
        public void Equals_AreEqual(string firstName, string lastName)
        {
            Person first = new Person(firstName, lastName);
            Person second = new Person(firstName, lastName);
            bool success = first.Equals(second);
            Assert.IsTrue(success);
        }

        [TestMethod]
        [DataRow("Test", "test")]
        [DataRow("First", "Last")]
        public void Equals_AreNotEqual(string firstName, string lastName)
        {
            Person first = new Person(firstName, lastName);
            Person second = new Person(lastName, firstName);

            bool success = first.Equals(second);

            Assert.IsFalse(success);
        }

        [TestMethod]
        [DataRow("Test", "test")]
        [DataRow("First", "Last")]
        public void EqualsOperator_AreEqual(string firstName, string lastName)
        {
            Person first = new Person(firstName, lastName);
            Person second = new Person(firstName, lastName);

            Assert.IsTrue(first == second);
        }

        [TestMethod]
        [DataRow("Test", "test")]
        [DataRow("First", "Last")]
        public void EqualsOperator_AreNotEqual(string firstName, string lastName)
        {
            Person first = new Person(firstName, lastName);
            Person second = new Person(lastName, firstName);

            Assert.IsFalse(first == second);
        }

        [TestMethod]
        [DataRow("Test", "test")]
        [DataRow("First", "Last")]
        public void DoesNotEqualsOperator_AreEqual(string firstName, string lastName)
        {
            Person first = new Person(firstName, lastName);
            Person second = new Person(firstName, lastName);

            Assert.IsFalse(first != second);
        }

        [TestMethod]
        [DataRow("Test", "test")]
        [DataRow("First", "Last")]
        public void DoesNotEqualsOperator_AreNotEqual(string firstName, string lastName)
        {
            Person first = new Person(firstName, lastName);
            Person second = new Person(lastName, firstName);

            Assert.IsTrue(first != second);
        }
    }
}
