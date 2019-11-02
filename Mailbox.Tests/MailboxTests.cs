using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mailbox;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass()]
    public class MailboxTests
    {
        [TestMethod()]
        public void CreateOwnerGoodValues()
        {
            //Arrange
            string first = "Test";
            string last = "Box";

            //Act
            Person person = new Person(first, last);

            //Assert
            Assert.AreEqual(person.toString(), "Test Box");
        }

        [TestMethod]
        public void CreateMailboxGoodValuesAllSizes()
        {
            //Arrange
            Person person = new Person("Test", "Box");

            //Act
            Mailbox smallMailbox = new Mailbox(person, Sizes.Small, (0, 0));
            Mailbox mediumMailbox = new Mailbox(person, Sizes.Medium, (0, 0));
            Mailbox largeMailbox = new Mailbox(person, Sizes.Large, (0, 0));
            Mailbox empty = new Mailbox(person, Sizes.Default, (0, 0));

            //Assert
            Assert.AreEqual(smallMailbox.toString(), "Owner: Test Box, Small");
            Assert.AreEqual(mediumMailbox.toString(), "Owner: Test Box, Medium");
            Assert.AreEqual(largeMailbox.toString(), "Owner: Test Box, Large");
            Assert.AreEqual(empty.toString(), "");
        }
        [TestMethod]
        public void CreateMailboxGoodValuesAllSizesPremium()
        {
            //Arrange
            Person person = new Person("Test", "Box");

            //Act
            Mailbox smallPremiumMailbox = new Mailbox(person, Sizes.Small | Sizes.Premium, (0, 0));
            Mailbox mediumPremiumMailbox = new Mailbox(person, Sizes.Medium | Sizes.Premium, (0, 0));
            Mailbox largePremiumMailbox = new Mailbox(person, Sizes.Large | Sizes.Premium, (0, 0));

            //Assert
            Assert.AreEqual(smallPremiumMailbox.toString(), "Owner: Test Box, Small, Premium");
            Assert.AreEqual(mediumPremiumMailbox.toString(), "Owner: Test Box, Medium, Premium");
            Assert.AreEqual(largePremiumMailbox.toString(), "Owner: Test Box, Large, Premium");
        }
    }
}