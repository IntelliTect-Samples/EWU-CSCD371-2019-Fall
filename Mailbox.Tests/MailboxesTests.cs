using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxesTests
    {
        [TestMethod]
        public void Mailboxes_Constructor_ExceptionOnBadDimensions()
        {
            // 2x2 wall of mailboxes
            var boxes = new List<Mailbox>()
            {
                new Mailbox(Size.Small, (0, 0), new Person("Mark", "Ruff")),
                new Mailbox(Size.Medium, (0, 1), new Person("Kevin", "Durant")),
                new Mailbox(Size.Small | Size.Premium, (1, 0), new Person("Spam", "Bar")),
                new Mailbox(Size.Large | Size.Premium, (1, 1), new Person("Dennis", "Ritchie")),
            };

            // Exception on bad values
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Mailboxes(boxes, 2, 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Mailboxes(boxes, 0, 2));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Mailboxes(boxes, -1, 3));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Mailboxes(boxes, 3, -1));

            // Exception on insufficient sized mailboxes
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Mailboxes(boxes, 2, 1));
        }
    }
}
