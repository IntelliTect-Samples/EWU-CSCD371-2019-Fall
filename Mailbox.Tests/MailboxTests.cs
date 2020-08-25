using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [TestMethod]
        public void Mailbox_ConstructorCreates()
        {
            Sizes size = Sizes.Medium;
            (int, int)location = (1,2);
            Person person = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };

            Mailbox mailbox = new Mailbox(size, location, person);

            Assert.AreEqual(size, mailbox.BoxSize);
            Assert.AreEqual(location, mailbox.Location);
            Assert.AreEqual(person, mailbox.Owner);
        }

        [TestMethod]
        public void Mailbox_ToString()
        {
            Sizes size = Sizes.Medium;
            (int, int) location = (1, 2);
            Person person = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };

            Mailbox mailbox = new Mailbox(size, location, person);

            string value = mailbox.ToString();

            Assert.AreEqual("Scott Rowland - (1, 2) - Medium", value);
        }

        [TestMethod]
        public void Mailbox_SizeString_NonPremium()
        {
            Sizes size = Sizes.Small;
            (int, int) location = (1, 2);
            Person person = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };

            Mailbox mailbox = new Mailbox(size, location, person);

            string smallValue = mailbox.SizeString();

            mailbox.BoxSize = Sizes.Medium;
            string mediumValue = mailbox.SizeString();
            mailbox.BoxSize = Sizes.Large;
            string largeValue = mailbox.SizeString();

            Assert.AreEqual("Small", smallValue);
            Assert.AreEqual("Medium", mediumValue);
            Assert.AreEqual("Large", largeValue);
        }

        [TestMethod]
        public void Mailbox_SizeString_Premium()
        {
            Sizes size = Sizes.SmallPremium;
            (int, int) location = (1, 2);
            Person person = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };

            Mailbox mailbox = new Mailbox(size, location, person);

            string smallValue = mailbox.SizeString();

            mailbox.BoxSize = Sizes.MediumPremium;
            string mediumValue = mailbox.SizeString();
            mailbox.BoxSize = Sizes.LargePremium;
            string largeValue = mailbox.SizeString();

            Assert.AreEqual("Small - Premium", smallValue);
            Assert.AreEqual("Medium - Premium", mediumValue);
            Assert.AreEqual("Large - Premium", largeValue);
        }
    }
}
