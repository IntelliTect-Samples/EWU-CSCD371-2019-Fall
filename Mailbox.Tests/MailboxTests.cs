using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Mailbox_CreateMailbox_ThrowsArgument()
        {
            Mailbox mailbox = new Mailbox(Size.Small, (1, 1), null);
            mailbox.ToString();
        }

        [TestMethod]
        [DataRow(Size.Undeclared)]
        [DataRow(Size.Premium)]
        public void Mailbox_ToString_WithoutSize(Size size)
        {
            Mailbox mailbox = new Mailbox(size, (1, 1), new Person("Hubbard", "Taty"));
            Assert.AreEqual("Taty Hubbard's Mailbox is located at 1 and 1", mailbox.ToString());
        }

        [TestMethod]
        [DataRow(Size.SmallPremium)]
        [DataRow(Size.MediumPremium)]
        [DataRow(Size.LargePremium)]
        [DataRow(Size.Small)]
        [DataRow(Size.Medium)]
        [DataRow(Size.Large)]

        public void Mailbox_ToString(Size size)
        {
            Mailbox mailbox = new Mailbox(size, (1, 1), new Person("Hubbard", "Taty"));
            Assert.AreEqual($"Taty Hubbard's {size} Mailbox is located at 1 and 1", mailbox.ToString());
        }
    }
}
