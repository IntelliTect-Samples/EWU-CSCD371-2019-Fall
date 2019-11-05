using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InvalidSize_ThowsException()
        {
            _ = new MailBox((Sizes)3, (1, 2), new Person());
        }
        

        [TestMethod]
        public void Constructor_CorrectParameters_AreEqual()
        {
            var person = new Person();
            MailBox mailbox = new MailBox(Sizes.Large, (1, 2), person);

            Assert.AreEqual(Sizes.Large, mailbox.MailboxSize);
            Assert.AreEqual((1,2), mailbox.Location);
            Assert.AreEqual(person, mailbox.Owner);
        }

        [TestMethod]
        public void ToString_RegularSizes_CorrectlyDisplayed()
        {
            var person = new Person("fake", "name");
            MailBox mailbox = new MailBox(Sizes.Large, (1, 2), person);

            Assert.AreEqual(mailbox.ToString(), "Mailbox Owner: fake name, Location: x = 1, y = 2, Box size: Large");
        }

        [TestMethod]
        public void ToString_DefaultSize_CorrectlyDisplayed()
        {
            var person = new Person("fake", "name");
            MailBox mailbox = new MailBox(Sizes.Undeclared, (1, 2), person);

            Assert.AreEqual(mailbox.ToString(), "Mailbox Owner: fake name, Location: x = 1, y = 2, Box size: ");
        }

        [TestMethod]
        public void ToString_PremiumSize_CorrectlyDisplayed()
        {
            var person = new Person("fake", "name");
            MailBox mailbox = new MailBox(Sizes.LargePremium, (1, 2), person);

            Assert.AreEqual(mailbox.ToString(), "Mailbox Owner: fake name, Location: x = 1, y = 2, Box size: Premium Large");
        }
    }
}
