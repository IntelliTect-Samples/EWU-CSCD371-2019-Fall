using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxesTests
    {
        [TestMethod]
        public void Constructor_ValidArgs_CorrectValues()
        {
            int h = 5, w = 7;
            var mbs = new Mailboxes(new List<Mailbox>(), w, h);

            Assert.AreEqual(mbs.Height, h);
            Assert.AreEqual(mbs.Width, w);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_NegativeHeight_ThrowsException()
        {
            new Mailboxes(new List<Mailbox>(), 5, -5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_NegativeWidth_ThrowsException()
        {
            new Mailboxes(new List<Mailbox>(), -5, 5);
        }

        [TestMethod]
        public void GetAdjacentPeople_2x2_FalseAndName()
        {
            var owner = new Person("Inigo", "Montoya");
            var size = Sizes.Small;
            var mbs = new Mailboxes(new[] { new Mailbox((0, 0), owner, size), new Mailbox((1, 1), owner, size) }, 2, 2);

            Assert.IsFalse(mbs.GetAdjacentPeople(0, 1, out var people));
            Assert.AreEqual(people.Count, 1);
            Assert.IsTrue(people.Contains(owner));
        }

        [TestMethod]
        public void GetAdjacentPeople_2x3_TrueAndNames()
        {
            var owner1 = new Person("Inigo", "Montoya");
            var owner2 = new Person("Miracle", "Max");
            var size = Sizes.Small;
            var mbs = new Mailboxes(new[] { new Mailbox((0, 0), owner1, size), new Mailbox((1, 1), owner2, size),
                                            new Mailbox((0, 1), owner2, size)}, 2, 3);

            Assert.IsTrue(mbs.GetAdjacentPeople(0, 1, out var people));
            Assert.AreEqual(people.Count, 2);
            Assert.IsTrue(people.Contains(owner1));
            Assert.IsTrue(people.Contains(owner2));
        }
    }
}
