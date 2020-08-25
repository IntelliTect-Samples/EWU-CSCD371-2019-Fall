using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
   public class PersonTests
    {
        [TestMethod]
        public void Equals_NullObjectReturnsFalse()
        {
            Person person = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };

            Assert.IsFalse(person.Equals(null));
        }

        [TestMethod]
        public void Equals_ReturnsFalse()
        {
            Person person1 = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };
            Person person2 = new Person()
            {
                FirstName = "Person",
                LastName = "Name"
            };

            Assert.IsFalse(person1.Equals(person2));
        }

        [TestMethod]
        public void Equals_ReturnsTrue()
        {
            Person person1 = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };
            Person person2 = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };

            Assert.IsTrue(person1.Equals(person2));
        }


        [TestMethod]
        public void EqualsOperatorOverload_ReturnsFalse()
        {
            Person person1 = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };
            Person person2 = new Person()
            {
                FirstName = "Person",
                LastName = "Name"
            };

            Assert.IsFalse(person1 == person2);
        }

        [TestMethod]
        public void EqualsOperatorOverload_ReturnsTrue()
        {
            Person person1 = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };
            Person person2 = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };

            Assert.IsTrue(person1 == person2);
        }


        [TestMethod]
        public void NotEqualsOperatorOverload_ReturnsTrue()
        {
            Person person1 = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };
            Person person2 = new Person()
            {
                FirstName = "Person",
                LastName = "Name"
            };

            Assert.IsTrue(person1 != person2);
        }

        [TestMethod]
        public void NotEqualsOperatorOverload_ReturnsFalse()
        {
            Person person1 = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };
            Person person2 = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };

            Assert.IsFalse(person1 != person2);
        }

        [TestMethod]
        public void Person_ToString_IsFullName()
        {
            Person person1 = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };
            Assert.AreEqual("Scott Rowland", person1.ToString());
        }

        [TestMethod]
        public void Person_GetHashCode_ReturnsHash()
        {
            Person person1 = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };

            Assert.AreEqual(HashCode.Combine("Scott", "Rowland"), person1.GetHashCode());
        }
    }
}
