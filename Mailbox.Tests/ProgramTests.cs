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
        public void AddNewMailbox_GivenValidData_ReturnsCorrectMailbox()
        {
            //Arrange
            Mailboxes mailboxes = new Mailboxes(new List<Mailbox>(), 4, 4);
            Mailbox? mailbox;

            //Act
            mailbox = Program.AddNewMailbox(mailboxes, "Josh", "Lini", Size.Small);

            //Assert
            Assert.AreEqual(mailbox?.ToString(), new Mailbox(Size.Small, (0, 0), new Person("Josh", "Lini")).ToString());
        }

        [TestMethod]
        public void AddNewMailbox_GivenTooManyBoxes_ReturnsNull()
        {
            //Arrange
            Mailboxes? mailboxes = new Mailboxes(new List<Mailbox>(), 1, 1);
            Mailbox? mailbox;

            //Act
            mailboxes.Add(new Mailbox(Size.Small, (0, 0), new Person("Josh", "Lini")));
            mailboxes.Add(new Mailbox(Size.Small, (0, 1), new Person("Josh", "Lini")));
            mailboxes.Add(new Mailbox(Size.Small, (1, 0), new Person("Josh", "Lini")));
            mailboxes.Add(new Mailbox(Size.Small, (1, 1), new Person("Josh", "Lini")));
            mailbox = Program.AddNewMailbox(mailboxes, "Josh", "Lini", Size.Small);

            //Assert
            Assert.IsNull(mailbox);
        }

        [TestMethod]
        public void GetMailboxDetails_GivenValidLocation_ReturnsToString()
        {
            //Arrange
            Mailboxes mailboxes = new Mailboxes(new List<Mailbox>(), 4, 4);
            mailboxes.Add(new Mailbox(Size.Small, (0, 0), new Person("Josh", "Lini")));
            string? output;

            //Act
            output = Program.GetMailboxDetails(mailboxes, 0, 0);

            //Assert
            Assert.AreEqual(output, "Mailbox: Location: (0,0) - Owner: Lini, Josh - Size: Small");
        }

        [TestMethod]
        public void GetMailboxDetails_GivenNonValidLocation_ReturnsNull()
        {
            //Arrange
            Mailboxes mailboxes = new Mailboxes(new List<Mailbox>(), 4, 4);
            mailboxes.Add(new Mailbox(Size.Small, (0, 0), new Person("Josh", "Lini")));
            string? output;

            //Act
            output = Program.GetMailboxDetails(mailboxes, 25, 0);

            //Assert
            Assert.IsNull(output);
        }

        [TestMethod]
        public void GetMailboxDetails_GivenEmptyLocation_ReturnsNull()
        {
            //Arrange
            Mailboxes mailboxes = new Mailboxes(new List<Mailbox>(), 4, 4);
            mailboxes.Add(new Mailbox(Size.Small, (0, 0), new Person("Josh", "Lini")));
            string? output;

            //Act
            output = Program.GetMailboxDetails(mailboxes, 1, 0);

            //Assert
            Assert.IsNull(output);
        }
    }
}
