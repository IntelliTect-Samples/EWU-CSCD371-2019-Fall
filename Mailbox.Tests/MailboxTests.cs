using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [TestMethod]
        public void ToString_CheckOutputWithEmptySize()
        {
            var owner = new Person("Test", "Person");
            var sut = new Mailbox(Sizes.None, (0,0), owner);

            string correct = $"Size:  Location: (0, 0) Owner: Test Person";
            Assert.AreEqual(correct, sut.ToString());
        }

        [TestMethod]
        public void ToString_CheckOutputWithNonDefaultSize()
        {
            var owner = new Person("Test", "Person");
            var sut = new Mailbox(Sizes.Small, (0, 0), owner);

            string correct = $"Size: Small Location: (0, 0) Owner: Test Person";
            Assert.AreEqual(correct, sut.ToString());
        }
    }
}
