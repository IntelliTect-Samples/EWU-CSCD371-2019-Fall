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
        public void Person_Equals_AreEqual()
        {
            // Arrange
            Person testPerson1 = new Person("first", "last");
            Person testPerson2 = new Person("first", "last");

            // Act


            // Assert
            Assert.IsTrue(testPerson1.Equals(testPerson2));
        }
    }
}
