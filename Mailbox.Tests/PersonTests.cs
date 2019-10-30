using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void ToString_ValidName_ReturnsCorrectStringRepresentation()
        {
            string firstName = "Joe";
            string lastName = "Grills";
            Person joeGrills = new Person(firstName, lastName);
            Assert.AreEqual($"{firstName} {lastName}", joeGrills.ToString());
        }
    }
}
