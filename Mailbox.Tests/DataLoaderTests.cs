using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class DataLoaderTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorPassedNull()
        {
            DataLoader dataLoader = new DataLoader(null);
            dataLoader.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SavePassedNull()
        {
            MemoryStream stream = new MemoryStream();
            DataLoader dataLoader = new DataLoader(stream);

            dataLoader.Save(null);
            dataLoader.Dispose();
        }

        [TestMethod]
        public void LoadSaveSucessful()
        {
            MemoryStream stream = new MemoryStream();
            DataLoader dataLoader = new DataLoader(stream);
            List<Mailbox> mailboxes = getTestData();

            dataLoader.Save(mailboxes);
            List<Mailbox> loadedMailboxes = dataLoader.Load();

            for(int i = 0; i < loadedMailboxes.Count; i++)
            {
                Assert.AreEqual(mailboxes[i].Owner, loadedMailboxes[i].Owner);
                Assert.AreEqual(mailboxes[i].Location, loadedMailboxes[i].Location);
                Assert.AreEqual(mailboxes[i]._Size, loadedMailboxes[i]._Size);
            }
            dataLoader.Dispose();
        }

        public List<Mailbox> getTestData()
        {
            List<Mailbox> mailboxes = new List<Mailbox>();

            //Locations for the mailboxes
            ValueTuple<int, int> loc = (0, 0);
            ValueTuple<int, int> loc2 = (0, 1);

            //The mailboxes being tested
            Mailbox mail1 = new Mailbox(Size.Small, loc, (new Person("Jesse", "James")));
            Mailbox mail2 = new Mailbox(Size.Medium, loc2, (new Person("Merry", "North")));

            mailboxes.Add(mail1);
            mailboxes.Add(mail2);

            return mailboxes;
        }
    }
}
