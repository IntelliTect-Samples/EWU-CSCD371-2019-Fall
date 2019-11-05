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
    }
}
