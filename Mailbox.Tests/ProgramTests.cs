using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestPlatform.TestHost;
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddMailbox_nullMailboxes()
        {
            Program.AddNewMailbox(null, "Jim", "Lakes", Size.Small);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddMailbox_nullFirstName()
        {
            Mailboxes mailboxes = new Mailboxes(getTestData(), 50, 10);
            Program.AddNewMailbox(mailboxes, null, "Lakes", Size.Small);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddMailbox_nullLastName()
        {
            Mailboxes mailboxes = new Mailboxes(getTestData(), 50, 10);
            Program.AddNewMailbox(null, "Jim", null, Size.Small);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void getMailBoxDetails_NullMailboxes()
        {
            string str = Program.GetMailboxDetails(null, 0, 1);
        }
        [TestMethod]
        public void getMailBoxDetails_sucess()
        {
            Mailboxes mailboxes = new Mailboxes(getTestData(), 50, 10);

            string str = Program.GetMailboxDetails(mailboxes, 0, 0);
            ValueTuple<int, int> loc = (0, 0);
            Mailbox mailbox = new Mailbox(Size.Small, loc, (new Person("Jesse", "James")));

            Assert.AreEqual(mailbox.ToString(), str);
        }



        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void getOwnerList_NullMailbox()
        {
            Program.GetOwnersDisplay(null);
        }
        [TestMethod]
        public void getOwnerList_sucess()
        {
            Mailboxes mailboxes = new Mailboxes(getTestData(), 50, 10);
            string retrieve = Program.GetOwnersDisplay(mailboxes);
            string str = "Jesse James\nMerry North\nAllen Smith\nTerry Graves\nLuke Alex\n";

            Assert.AreEqual(str, retrieve);
        }



        [TestMethod]
        public void Mailbox_ToString()
        {
            ValueTuple<int, int> loc = (0, 0);
            Mailbox mailbox = new Mailbox(Size.Small, loc, (new Person("Jesse", "James")));

            string retrieve = mailbox.ToString();
            string str = "Owner: James Jesse, Location: 0,0, Size: " + Size.Small;

            Assert.AreEqual(str, retrieve);
        }

        [TestMethod]
        public void Person_EqualTrue()
        {
            Person personOne = new Person("Jesse", "James");
            Person personTwo = new Person("Jesse", "James");

            Assert.IsTrue(personOne == personTwo);
        }
        [TestMethod]
        public void Person_EqualFalse()
        {
            Person personOne = new Person("Jesse", "James");
            Person personTwo = new Person("Jim", "Lakes");

            Assert.IsTrue(personOne != personTwo);
        }



        public List<Mailbox> getTestData()
        {
            List<Mailbox> mailboxes = new List<Mailbox>();

            //Locations for the mailboxes
            ValueTuple<int, int> loc = (0, 0);
            ValueTuple<int, int> loc2 = (0, 1);
            ValueTuple<int, int> loc3 = (0, 2);
            ValueTuple<int, int> loc4 = (0, 3);
            ValueTuple<int, int> loc5 = (0, 4);

            //The mailboxes being tested
            Mailbox mail1 = new Mailbox(Size.Small, loc, (new Person("Jesse", "James")));
            Mailbox mail2 = new Mailbox(Size.Medium, loc2, (new Person("Merry", "North")));
            Mailbox mail3 = new Mailbox(Size.Large, loc3, (new Person("Allen", "Smith")));
            Mailbox mail4 = new Mailbox(Size.PremiumSmall, loc4, (new Person("Terry", "Graves")));
            Mailbox mail5 = new Mailbox(Size.Unspecified, loc5, (new Person("Luke", "Alex")));

            mailboxes.Add(mail1);
            mailboxes.Add(mail2);
            mailboxes.Add(mail3);
            mailboxes.Add(mail4);
            mailboxes.Add(mail5);

            return mailboxes;
        }
    }
}
