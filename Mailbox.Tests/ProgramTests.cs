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
        public void Program_GetOwnersDisplay_ReturnAllOwners()
        {
            var person1 = new Person() { FirstName = "person1", LastName = "person1" };
            var person2 = new Person() { FirstName = "person2", LastName = "person2" };
            var person3 = new Person() { FirstName = "person3", LastName = "person3" };
            var person4 = new Person() { FirstName = "person4", LastName = "person4" };

            Mailbox mailbox1 = new Mailbox(Sizes.Small, (1, 0), person1);
            Mailbox mailbox2 = new Mailbox(Sizes.Small, (0, 1), person2);
            Mailbox mailbox3 = new Mailbox(Sizes.Small, (2, 1), person3);
            Mailbox mailbox4 = new Mailbox(Sizes.Small, (1, 2), person4);

            var mailboxList = new List<Mailbox>()
            {
                mailbox1,
                mailbox2,
                mailbox3,
                mailbox4
            };
            var mailboxes = new Mailboxes(mailboxList, 10, 10);

            string owners = Program.GetOwnersDisplay(mailboxes);
            foreach (Mailbox box in mailboxList)
            {
                Assert.IsTrue(owners.Contains(box.Owner.ToString()));
            }
        }


        [TestMethod]
        public void Program_GetOwnersDisplay_ReturnDistinctOwners()
        {
            var person1 = new Person() { FirstName = "person1", LastName = "person1" };
            var person2 = new Person() { FirstName = "person2", LastName = "person2" };
            var person3 = new Person() { FirstName = "person3", LastName = "person3" };

            Mailbox mailbox1 = new Mailbox(Sizes.Small, (1, 0), person1);
            Mailbox mailbox2 = new Mailbox(Sizes.Small, (0, 1), person2);
            Mailbox mailbox3 = new Mailbox(Sizes.Small, (2, 1), person3);
            Mailbox mailbox4 = new Mailbox(Sizes.Small, (1, 2), person3);

            var mailboxList = new List<Mailbox>()
            {
                mailbox1,
                mailbox2,
                mailbox3,
                mailbox4
            };
            var mailboxes = new Mailboxes(mailboxList, 10, 10);

            string owners = Program.GetOwnersDisplay(mailboxes);
            string[] lines = owners.Split($"{Environment.NewLine}");

            //4th line is empty string
            Assert.AreEqual(4, lines.Length);
        }


        [TestMethod]
        public void Program_GetMailboxDetails_ReturnsBoxInfo()
        {
            var person1 = new Person() { FirstName = "person1", LastName = "person1" };

            Mailbox mailbox1 = new Mailbox(Sizes.Small, (1, 0), person1);

            var mailboxList = new List<Mailbox>()
            {
                mailbox1
            };
            var mailboxes = new Mailboxes(mailboxList, 10, 10);

            string? value = Program.GetMailboxDetails(mailboxes, 1, 0);

            Assert.IsNotNull(value);
            Assert.AreEqual(mailbox1.ToString(), value);
        }

        [TestMethod]
        public void Program_GetMailboxDetails_ReturnsNull()
        {
            var person1 = new Person() { FirstName = "person1", LastName = "person1" };

            Mailbox mailbox1 = new Mailbox(Sizes.Small, (1, 0), person1);

            var mailboxList = new List<Mailbox>()
            {
                mailbox1
            };
            var mailboxes = new Mailboxes(mailboxList, 10, 10);

            string? value = Program.GetMailboxDetails(mailboxes, 8, 0);

            Assert.IsNull(value);
        }


        [TestMethod]
        public void Program_AddNewMailbox_NotNextAdjacent()
        {
            var person1 = new Person() { FirstName = "person1", LastName = "person1" };

            Mailbox mailbox1 = new Mailbox(Sizes.Small, (0, 0), person1);

            var mailboxList = new List<Mailbox>()
            {
                mailbox1
            };
            var mailboxes = new Mailboxes(mailboxList, 1, 2);

            Mailbox? box = Program.AddNewMailbox(mailboxes, "person1", "person1", Sizes.Small);

            Assert.IsNull(box);
        }

        [TestMethod]
        public void Program_AddNewMailbox_NoAvailableBoxes()
        {
            var person1 = new Person() { FirstName = "person1", LastName = "person1" };

            Mailbox mailbox1 = new Mailbox(Sizes.Small, (0, 0), person1);

            var mailboxList = new List<Mailbox>()
            {
                mailbox1
            };
            var mailboxes = new Mailboxes(mailboxList, 1, 1);

            Mailbox? box = Program.AddNewMailbox(mailboxes, "person2", "person2", Sizes.Small);

            Assert.IsNull(box);
        }

        [TestMethod]
        public void Program_AddNewMailbox_CreatesMailbox()
        {
            var person1 = new Person() { FirstName = "person1", LastName = "person1" };

            Mailbox mailbox1 = new Mailbox(Sizes.Small, (0, 0), person1);

            var mailboxList = new List<Mailbox>()
            {
                mailbox1
            };
            var mailboxes = new Mailboxes(mailboxList, 1, 2);

            Mailbox? box = Program.AddNewMailbox(mailboxes, "person2", "person2", Sizes.Small);

            Assert.IsNotNull(box);
            Assert.AreEqual(box?.Owner.FirstName, "person2");
            Assert.AreEqual(box?.Owner.LastName, "person2");
        }
    }
}
