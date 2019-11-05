﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        [DataRow("firstname", "lastname")]
        [DataRow("first name", "Last-name")]
        [DataRow("NotNull", "ALso not_null")]
        public void Constructor_CorrectParameters_ReturnsPerson(string firstName, string lastName)
        {
            Person person = new Person(firstName, lastName);
            Assert.IsNotNull(person);
            Assert.AreEqual(person.FirstName, firstName);
            Assert.AreEqual(person.LastName, lastName);
        }

        [TestMethod]
        [DataRow("firstname", "lastname")]
        [DataRow("first name", "Last-name")]
        [DataRow("NotNull", "ALso not_null")]
        public void EqualsOverride_ReturnsTrue_NotEqualsOverride_ReturnsFalse(string firstName, string lastName)
        {
            Person person1 = new Person(firstName, lastName);
            Person person2 = new Person(firstName, lastName);
            Assert.IsTrue(person1 == person2);
            Assert.IsFalse(person1 != person2);
        }

        [TestMethod]
        [DataRow("test", "lastname")]
        [DataRow("first name", "name")]
        [DataRow("NotNull", "ALso not_null")]
        public void NotEqualsOverride_ReturnsTrue_EqualsOverride_ReturnsFalse(string firstName, string lastName)
        {
            Person person1 = new Person(firstName, lastName);
            Person person2 = new Person("test", "name");
            Assert.IsTrue(person1 != person2);
            Assert.IsFalse(person1 == person2);
        }

        [TestMethod]
        [DataRow("firstname", "lastname")]
        public void ToString_ReturnsValidString(string firstName, string lastName)
        {
            Person person1 = new Person(firstName, lastName);
            Assert.AreEqual(person1.ToString(), "firstname lastname");
        }
        
    }
}
