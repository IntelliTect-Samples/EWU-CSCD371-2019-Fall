using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox.Tests
{
    [TestClass]
    public class DataLoaderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_PassNull_ThrowException()
        {
            DataLoader dl = new DataLoader(null);
            dl.Dispose();
        }

        [TestMethod]
        public void Constructor_Success()
        {
            MemoryStream stream = new MemoryStream();
            DataLoader dl = new DataLoader(stream);

            stream.Close();
            dl.Dispose();
        }

        [TestMethod]
        public void Save_PassNull()
        {
            MemoryStream stream = new MemoryStream();
            DataLoader dl = new DataLoader(stream);

            dl.Save(null);

            Assert.AreEqual(0, dl.Load().Count);

            stream.Close();
            dl.Dispose();
        }

        [TestMethod]
        public void Save_PassEmptyMailboxes()
        {
            MemoryStream stream = new MemoryStream();
            DataLoader dl = new DataLoader(stream);

            dl.Save(new List<Mailbox>());

            Assert.AreEqual(0, dl.Load().Count);

            stream.Close();
            dl.Dispose();
        }

        [TestMethod]
        public void Save_And_Load_Success()
        {
            MemoryStream stream = new MemoryStream();
            List<Mailbox> mailboxes = getTestMail();

            DataLoader dl = new DataLoader(stream);

            dl.Save(mailboxes);

            List<Mailbox> loaded = dl.Load();

            Assert.AreEqual(mailboxes.Count, loaded.Count);

            for(int i = 0; i < mailboxes.Count; i++)
            {
                Assert.AreEqual(mailboxes[i].Owner, loaded[i].Owner);
                Assert.AreEqual(mailboxes[i].Size, loaded[i].Size);
                Assert.AreEqual(mailboxes[i].Location, loaded[i].Location);
            }

            stream.Close();
            dl.Dispose();
        }

        private List<Mailbox> getTestMail()
        {
            List<Mailbox> mailboxes = new List<Mailbox>()
            {
                new Mailbox() { Owner = new Person() { FirstName = "Bob", LastName = "Jones"}, Location = (1, 1), Size = Sizes.Small },
                new Mailbox() { Owner = new Person() { FirstName = "Steven", LastName = "Bills"}, Location = (1, 2), Size = Sizes.Medium },
                new Mailbox() { Owner = new Person() { FirstName = "John", LastName = "Doe"}, Location = (1, 3), Size = Sizes.LargePremium }
            };

            return mailboxes;
        }
    }
}
