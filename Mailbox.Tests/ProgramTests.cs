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
            Assert.AreEqual(mailbox, new Mailbox(Size.Small, (0, 0), new Person("Josh", "Lini")));
        }
    }
}
