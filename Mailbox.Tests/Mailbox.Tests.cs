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
        public void Mailbox_ToString()
        {
            Size size = Size.PremiumLarge;
            ValueTuple<int, int> loc = new ValueTuple<int, int>(1, 1);
            Person person = new Person("Jimmy", "John");
            Mailbox mb = new Mailbox(size, loc, person);
            Assert.AreEqual(mb.ToString(), "Owner: John, Jimmy, Location: 1, 1, Size: PremiumLarge");
        }

        [DataTestMethod]
        [DataRow(Size.Small)]
        [DataRow(Size.Medium)]
        [DataRow(Size.Large)]
        [DataRow(Size.PremiumSmall)]
        [DataRow(Size.PremiumMedium)]
        [DataRow(Size.PremiumLarge)]
        public void Mailbox_Sizes_WorkingSizes(Size size)
        {
            Person theDude = new Person("The", "Dude");
            ValueTuple <int, int> location = new ValueTuple<int, int>(1, 1);
            Mailbox mailbox = new Mailbox(size, location, theDude);
            Assert.AreEqual(mailbox.ToString(), "Owner: Dude, The, Location: 1, 1, Size: " + size.ToString());
        }

        [DataTestMethod]
        [DataRow(Size.Unset)]
        [DataRow(Size.Premium)]
        public void Mailbox_Sizes_EmptyStringWithBadSizes(Size size)
        {
            Person theDude = new Person("The", "Dude");
            ValueTuple<int, int> location = new ValueTuple<int, int>(1, 1);
            Mailbox mailbox = new Mailbox(size, location, theDude);
            Assert.AreEqual(mailbox.ToString(), "Owner: Dude, The, Location: 1, 1");
            
        }

    }
}
