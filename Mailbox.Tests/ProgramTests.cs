using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailRoom;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailRoom.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void GetOwnersDisplay_ConcatenatesUniqueOwners_ReturnsString()
        {
            List<Mailbox> boxes = new List<Mailbox>
            {
                new Mailbox(new Person("F1", "L1"), (0, 0), Sizes.Small),
                new Mailbox(new Person("F1", "L1"), (1, 0), Sizes.Small),
                new Mailbox(new Person("F2", "L2"), (2, 0), Sizes.Small)
            };
            string expected = boxes[0].Owner.ToString() + Environment.NewLine + boxes[2].Owner.ToString();
            MailboxCollection mailboxes = new MailboxCollection(boxes, 3, 1);

            string result = Program.GetOwnersDisplay(mailboxes);

            Assert.AreEqual<string>(expected, result);
        }

        [DataTestMethod]
        public void GetOwnersDisplay_GivenNullCollection_ReturnsEmptyString()
        {
#pragma warning disable CS8625 // testing in case null collection does get passed somehow
            string? result = Program.GetOwnersDisplay(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            Assert.AreEqual<string>("", result);
        }

        [DataTestMethod]
        public void GetMailboxDetails_GetsStringRepresentationOfMailbox_ReturnsConcatenatedMailbox()
        {
            Mailbox box = new Mailbox(new Person("F1", "L1"), (0, 0), Sizes.Small);
            MailboxCollection mailboxes = new MailboxCollection(new List<Mailbox> { box }, 1, 1);
            string expected = box.ToString();

            string result = Program.GetMailboxDetails(mailboxes, 0, 0) ?? "";

            Assert.AreEqual<string>(expected, result);
        }

        [DataTestMethod]
        public void GetMailboxDetails_FailsToFindMailbox_ReturnsNull()
        {
            MailboxCollection mailboxes = new MailboxCollection(new List<Mailbox>(), 1, 1);

            string? result = Program.GetMailboxDetails(mailboxes, 0, 0);

            Assert.IsNull(result);
        }

        [DataTestMethod]
        public void GetMailboxDetails_GivenNullCollection_ReturnsNull()
        {
#pragma warning disable CS8625 // testing in case null collection does get passed somehow
            string? result = Program.GetMailboxDetails(null, 1, 1);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            Assert.IsNull(result);
        }

        [TestMethod]
        public void AddNewMailbox_CreatesNewBoxForFirstEmptySpotInEmptyList_ReturnsMailbox()
        {
            MailboxCollection boxes = new MailboxCollection(new List<Mailbox>(), 1, 1);
            Mailbox expected = new Mailbox(new Person("F1", "L1"), (0, 0), Sizes.Small);

            Mailbox? test = Program.AddNewMailbox(boxes, expected.Owner.FirstName, expected.Owner.LastName, expected.MailboxSize);

            Assert.AreEqual<string>(expected.ToString(), test?.ToString() ?? "");
        }

        [TestMethod]
        public void AddNewMailbox_CreatesNewBoxForFirstEmptySpotForPartiallyFilledList_ReturnsMailbox()
        {
            MailboxCollection boxes = new MailboxCollection(new List<Mailbox>(), 2, 1);
            boxes.Add(new Mailbox(new Person("F1", "L1"), (0, 0), Sizes.Small));
            Mailbox expected = new Mailbox(new Person("F2", "L2"), (1, 0), Sizes.Small);

            Mailbox? test = Program.AddNewMailbox(boxes, expected.Owner.FirstName, expected.Owner.LastName, expected.MailboxSize);

            Assert.AreEqual<string>(expected.ToString(), test?.ToString() ?? "");
        }

        [TestMethod]
        public void AddNewMailbox_ListIsFull_ReturnsNull()
        {
            MailboxCollection boxes = new MailboxCollection(new List<Mailbox>(), 2, 1);
            boxes.Add(new Mailbox(new Person("F1", "L1"), (0, 0), Sizes.Small));
            boxes.Add(new Mailbox(new Person("F2", "L2"), (1, 0), Sizes.Small));

            Mailbox? test = Program.AddNewMailbox(boxes, "F3", "L3", Sizes.Small);

            Assert.IsNull(test);
        }

        [TestMethod]
        public void AddNewMailbox_OnlyEmptySpotAdjacentToSameOwner_ReturnsNull()
        {
            MailboxCollection boxes = new MailboxCollection(new List<Mailbox>(), 3, 1);
            boxes.Add(new Mailbox(new Person("F1", "L1"), (0, 0), Sizes.Small));
            boxes.Add(new Mailbox(new Person("F1", "L1"), (2, 0), Sizes.Small));

            Mailbox? test = Program.AddNewMailbox(boxes, "F1", "L1", Sizes.Small);

            Assert.IsNull(test);
        }
    }
}
