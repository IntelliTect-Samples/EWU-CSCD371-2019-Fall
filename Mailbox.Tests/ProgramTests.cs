using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOwnersDisplay_NullMailboxes_ThrowsException()
        {
            Program.GetOwnersDisplay(null!);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetMailboxDetails_NullMailboxes_ThrowsException()
        {
            Program.GetMailboxDetails(null!, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewMailbox_NullMailboxes_ThrowsException()
        {
            Program.AddNewMailbox(null!, "Test", "Tester", Sizes.Small);
        }

        [TestMethod]
        public void GetOwnersDisplay_ReturnsDistinctNames()
        {
            var mailboxes = new Mailboxes(new List<Mailbox>(), 10, 10);
            mailboxes.Add(new Mailbox(Sizes.Small, (1, 1), new Person("First1", "Last1")));
            mailboxes.Add(new Mailbox(Sizes.Medium, (2, 2), new Person("First2", "Last2")));
            mailboxes.Add(new Mailbox(Sizes.LargePremium, (3, 3), new Person("First3", "Last3")));
            mailboxes.Add(new Mailbox(Sizes.Small, (4, 4), new Person("First1", "Last1")));

            string display = Program.GetOwnersDisplay(mailboxes);
            var sb = new StringBuilder();
            sb.AppendLine("First1 Last1");
            sb.AppendLine("First2 Last2");
            sb.AppendLine("First3 Last3");
            string expectedResult = sb.ToString();

            Assert.AreEqual(expectedResult, display);
        }

        [TestMethod]
        public void GetMailboxDetails_MailboxNotFound_ReturnsNull()
        {
            var mailboxes = new Mailboxes(new List<Mailbox>(), 10, 10);
            mailboxes.Add(new Mailbox(Sizes.Small, (1, 1), new Person("First1", "Last1")));

            string? mailboxDetails = Program.GetMailboxDetails(mailboxes, 2, 1);

            Assert.IsNull(mailboxDetails);
        }

        [TestMethod]
        public void GetMailboxDetails_MailboxFound()
        {
            var mailboxes = new Mailboxes(new List<Mailbox>(), 10, 10);
            mailboxes.Add(new Mailbox(Sizes.Small, (1, 1), new Person("First1", "Last1")));

            string expectedResult = mailboxes[0].ToString();
            string? mailboxDetails = Program.GetMailboxDetails(mailboxes, 1, 1);

            Assert.IsNotNull(mailboxes);
            Assert.AreEqual(expectedResult, mailboxDetails);
        }

        [TestMethod]
        public void AddNewMailbox_NoSpotAvailable_ReturnsNull()
        {
            var mailboxes = new Mailboxes(new List<Mailbox>(), 1, 3);
            mailboxes.Add(new Mailbox(Sizes.Small, (0, 0), new Person("First1", "Last1")));
            mailboxes.Add(new Mailbox(Sizes.Medium, (0, 1), new Person("First2", "Last2")));
            mailboxes.Add(new Mailbox(Sizes.LargePremium, (0, 2), new Person("First3", "Last3")));

            var mailbox = Program.AddNewMailbox(mailboxes,"Test", "Tester", Sizes.Small);

            Assert.IsNull(mailbox);
        }

        [TestMethod]
        public void AddNewMailbox_OneSpotAvailable_HasSameName_ReturnsNull()
        {
            var mailboxes = new Mailboxes(new List<Mailbox>(), 1, 3);
            mailboxes.Add(new Mailbox(Sizes.Small, (0, 0), new Person("First1", "Last1")));
            mailboxes.Add(new Mailbox(Sizes.Medium, (0, 1), new Person("First2", "Last2")));

            var mailbox = Program.AddNewMailbox(mailboxes, "First2", "Last2", Sizes.Small);

            Assert.IsNull(mailbox);
        }

        [TestMethod]
        public void AddNewMailbox_OneSpotAvailable_SuccessfullyAddsMailbox()
        {
            var mailboxes = new Mailboxes(new List<Mailbox>(), 1, 3);
            mailboxes.Add(new Mailbox(Sizes.Small, (0, 0), new Person("First1", "Last1")));
            mailboxes.Add(new Mailbox(Sizes.Medium, (0, 1), new Person("First2", "Last2")));

            var mailbox = Program.AddNewMailbox(mailboxes, "Test", "Person", Sizes.Small);
            var testMailbox = new Mailbox(Sizes.Small, (0, 2), new Person("Test", "Person"));

            Assert.AreEqual(testMailbox.ToString(), mailbox!.ToString());
        }
    }
}
