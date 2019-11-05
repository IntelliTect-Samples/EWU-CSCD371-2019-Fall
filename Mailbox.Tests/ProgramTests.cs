using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Mailbox.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOwnersDisplay_PassNull()
        {
            Program.GetOwnersDisplay(null);
        }

        [TestMethod]
        public void GetOwnersDisplay_Success()
        {
            string results = Program.GetOwnersDisplay(getTestMailboxes());
            string expected = $"Bob Jones{Environment.NewLine}Steven Bills{Environment.NewLine}John Doe{Environment.NewLine}";

            Assert.AreEqual(expected, results);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetMailboxDetails_PassNull()
        {
            Program.GetMailboxDetails(null, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetMailboxDetails_PassBadNumbers()
        {
            Program.GetMailboxDetails(getTestMailboxes(), 0, -2);
        }

        [TestMethod]
        public void GetMailboxDetails_Success()
        {
            string results = Program.GetMailboxDetails(getTestMailboxes(), 1, 1);
            string expected = getTestMailboxes()[0].ToString() + Environment.NewLine;

            Assert.AreEqual(expected, results);

            results = Program.GetMailboxDetails(getTestMailboxes(), 1, 2);
            expected = getTestMailboxes()[1].ToString() + Environment.NewLine;

            Assert.AreEqual(expected, results);

            results = Program.GetMailboxDetails(getTestMailboxes(), 1, 3);
            expected = getTestMailboxes()[2].ToString() + Environment.NewLine;

            Assert.AreEqual(expected, results);
        }

        [DataTestMethod]
        [DataRow(null, "", "", Sizes.Small)]
        [DataRow(null, null, "", Sizes.Small)]
        [DataRow(null, "", null, Sizes.Small)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewMailbox_PassNull(Mailboxes mailboxes, string first, string last, Sizes size)
        {
            if (mailboxes is null && (first is null || last is null))
                mailboxes = getTestMailboxes();

            Program.AddNewMailbox(mailboxes, first, last, size);
        }

        private Mailboxes getTestMailboxes()
        {
            List<Mailbox> mailboxes = new List<Mailbox>()
            {
                new Mailbox() { Owner = new Person() { FirstName = "Bob", LastName = "Jones"}, Location = (1, 1), Size = Sizes.Small },
                new Mailbox() { Owner = new Person() { FirstName = "Steven", LastName = "Bills"}, Location = (1, 2), Size = Sizes.Medium },
                new Mailbox() { Owner = new Person() { FirstName = "John", LastName = "Doe"}, Location = (1, 3), Size = Sizes.LargePremium }
            };

            return new Mailboxes(mailboxes, 4, 4);
        }
    }
}
