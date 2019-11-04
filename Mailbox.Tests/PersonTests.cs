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
        public void EqualsCheck_SameName()
        {
            var person1 = new Person("Test", "Person");
            var person2 = new Person("Test", "Person");

            Assert.IsTrue(person1.Equals(person2));
        }

        [TestMethod]
        public void EqualsOperatorCheck_SameName()
        {
            var person1 = new Person("Test", "Person");
            var person2 = new Person("Test", "Person");

            Assert.IsTrue(person1 == person2);
        }

        [TestMethod]
        public void GetHashCode_AreEqual()
        {
            var person1 = new Person("Test", "Person");
            var person2 = new Person("Test", "Person");

            Assert.AreEqual(person1.GetHashCode(), person2.GetHashCode());
        }
    }
}
