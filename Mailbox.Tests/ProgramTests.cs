using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mailbox;

namespace Mailbox.Tests
{

    [TestClass]
    public class ProgramTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOwnersDisplay_GivenNull_ThrowsException()
        {
            Program.GetOwnersDisplay(null);
        }

        [TestMethod]
        public void GetOwnersDisplay_GivenValidMailboxes_ReturnsCorrectOwners()
        {
            var mailboxes = GenerateMailboxes();
            var returned  = Program.GetOwnersDisplay(mailboxes);
            var expected  = new StringBuilder();
            mailboxes.ForEach(mailbox => expected.Append(mailbox.Owner.ToString()).Append(Environment.NewLine));

            Assert.AreEqual(expected.ToString(), returned);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetMailboxDetails_GivenNull_ThrowsException()
        {
            Program.GetMailboxDetails(null, 0, 0);
        }

        [DataTestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(1, 1, 1)]
        [DataRow(1, 0, 2)]
        public void GetMailboxDetails_ReturnsCorrectMailboxString(int x, int y, int index)
        {
            var mailboxes = GenerateMailboxes();
            var returned  = Program.GetMailboxDetails(mailboxes, x, y);

            Assert.AreEqual(mailboxes[index].ToString(), returned);
        }

        [DataTestMethod]
        [DataRow(-1, 2)]
        [DataRow(2, -1)]
        [DataRow(5, 3)]
        [DataRow(2, 7)]
        public void GetMailboxDetails_ReturnsNullIfNoMailboxExists(int x, int y)
        {
            var mailboxes = GenerateMailboxes();
            var returned  = Program.GetMailboxDetails(mailboxes, x, y);

            Assert.IsNull(returned);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewMailbox_GivenNullMailboxes_ThrowsException()
        {
            Program.AddNewMailbox(null, "first", "last", Size.Default);
        }

        [DataTestMethod]
        [DataRow(null, "a")]
        [DataRow("a", null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewMailbox_GivenNullParams_ThrowsException(string firstName, string lastName)
        {
            Program.AddNewMailbox(GenerateMailboxes(), firstName, lastName, Size.Default);
        }

        [TestMethod]
        public void AddNewMailbox_SameAdjacentPerson_ReturnsNull()
        {
            // Captain Price already has a mailbox located at (0, 0), and the only open spot is (0, 1)
            Assert.IsNull(Program.AddNewMailbox(GenerateMailboxes(), "John", "Price", Size.Default));
        }

        [TestMethod]
        public void AddNewMailbox_NewPerson_ReturnsNewMailbox()
        {
            Assert.IsNotNull(Program.AddNewMailbox(GenerateMailboxes(),"John", "MacTavish", Size.SmallPremium));
        }
        
        private Mailboxes GenerateMailboxes()
        {
            return new Mailboxes(new List<Mailbox>
                                 {
                                     new Mailbox(new Person("John", "Price"), Size.LargePremium, (0, 0)),
                                     new Mailbox(new Person("Simon", "Riley"), Size.Default, (1, 1)),
                                     new Mailbox(new Person("Kyle", "Garrick"), Size.Small, (1, 0))
                                 },
                                 2,
                                 2);
        }

    }

}
