using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{

    [TestClass]
    public class PersonTests
    {

        [DataTestMethod]
        [DataRow("A", null)]
        [DataRow(null, "B")]
        [DataRow(null, null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_GivenNullStrings_ThrowsException(string? firstName, string? lastName)
        {
            var unused = new Person(firstName, lastName);
        }

        [DataTestMethod]
        [DataRow("John", "Price")]
        [DataRow("John", "MacTavish")]
        [DataRow("Kyle", "Garrick")]
        [DataRow("Simon", "Riley")]
        public void Constructor_GivenValidStrings_SetsCorrectly(string firstName, string lastName)
        {
            var person = new Person(firstName, lastName);
            
            Assert.AreEqual(firstName, person.FirstName);
            Assert.AreEqual(lastName, person.LastName);
        }

        [TestMethod]
        public void Equals_ReturnsCorrectly()
        {
            var a = new Person("A", "B");
            var b = new Person("A", "B");
            var c = new Person("B", "A");
            
            Assert.IsTrue(a.Equals(b));
            Assert.IsFalse(a.Equals(c));
        }
        
        [TestMethod]
        public void EqualsOperator_ReturnsCorrectly()
        {
            var a = new Person("A", "B");
            var b = new Person("A", "B");
            var c = new Person("B", "A");
            
            Assert.IsTrue(a == b);
            Assert.IsFalse(a == c);
        }
        
        [TestMethod]
        public void DoesNotEqualsOperator_ReturnsCorrectly()
        {
            var a = new Person("A", "B");
            var b = new Person("A", "B");
            var c = new Person("B", "A");
            
            Assert.IsTrue(a != c);
            Assert.IsFalse(a != b);
        }
        
    }

}
