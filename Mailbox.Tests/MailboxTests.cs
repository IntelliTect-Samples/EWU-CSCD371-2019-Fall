using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [TestMethod]
        public void Constructor_AllParameters_NoErrors()
        {
            _ = new Mailbox(Size.Small, (0, 0), new Person());
        }

        [TestMethod]

        public void ToString_ValidMailbox_ReturnsCorrectRepresentation()
        {
            Mailbox mailbox = new Mailbox(Size.Small, (0, 0), new Person("Homer", "Simpson"));
            Assert.AreEqual("Size: Small, Location: 0 0, Owner: Homer Simpson",mailbox.ToString());
        }

        [TestMethod]
        public void ToString_DefaultSize_ReturnsEmptyString()
        {
            Mailbox mailbox = new Mailbox(Size.Default, (0, 0), new Person("Homer", "Simpson"));
            Assert.AreEqual("", mailbox.ToString());
        }

        [TestMethod]
        public void ToString_PremiumSizeValidMailbox_ReturnsCorrectOutput()
        {
            Mailbox mailbox = new Mailbox(Size.SmallPremium, (0, 0), new Person("Homer", "Simpson"));
            Assert.AreEqual("Size: Small Premium, Location: 0 0, Owner: Homer Simpson", mailbox.ToString());
        }
    }
}