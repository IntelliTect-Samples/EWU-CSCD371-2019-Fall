using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [TestMethod]
        public void ToString_ValidString()
        {
            string expectedMailbox = "Test Name's Large box is located at row 1 and column 1.";

            var mailbox = new Mailbox((1, 1), new Person("Test", "Name"), Size.Large);

            Assert.AreEqual(mailbox.ToString(), expectedMailbox);
        }

        [TestMethod]
        public void ToString_EmptyString()
        {
            var mailbox = new Mailbox((1, 1), new Person("Test", "Name"), Size.Default);

            Assert.IsTrue(string.IsNullOrEmpty(mailbox.ToString()));
        }
    }
}
