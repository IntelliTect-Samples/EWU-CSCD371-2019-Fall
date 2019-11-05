using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [TestMethod]
        public void Constructor_AllParameters_NoErrors()
        {
            _ = new Mailbox(Sizes.Small, (0, 0), new Person());
        }

        [DataTestMethod]
        [DataRow(Sizes.Small | Sizes.Medium)]
        [DataRow(Sizes.Small | Sizes.Large)]
        [DataRow(Sizes.Medium | Sizes.Small)]
        [DataRow(Sizes.Medium | Sizes.Large)]
        [DataRow(Sizes.Large | Sizes.Small)]
        [DataRow(Sizes.Large | Sizes.Medium)]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_BadSizeParameter_ThrowsArgumentException(Sizes invalidSize)
        {
            _ = new Mailbox(invalidSize, (0, 0), new Person("Homer", "Simpson"));
        }

        [TestMethod]
        public void ToString_ValidMailbox_ReturnsCorrectRepresentation()
        {
            Mailbox mailbox = new Mailbox(Sizes.Small, (0, 0), new Person("Homer", "Simpson"));
            Assert.AreEqual("Size: Small, Location: 0 0, Owner: Homer Simpson", mailbox.ToString());
        }

        [TestMethod]
        public void ToString_DefaultSize_ReturnsEmptyString()
        {
            Mailbox mailbox = new Mailbox(Sizes.Default, (0, 0), new Person("Homer", "Simpson"));
            Assert.AreEqual("", mailbox.ToString());
        }

        [TestMethod]
        public void ToString_PremiumSizeValidMailbox_ReturnsCorrectOutput()
        {
            Mailbox mailbox = new Mailbox(Sizes.SmallPremium, (0, 0), new Person("Homer", "Simpson"));
            Assert.AreEqual("Size: Small Premium, Location: 0 0, Owner: Homer Simpson", mailbox.ToString());
        }
    }
}