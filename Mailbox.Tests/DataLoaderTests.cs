using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Mailbox.Tests
{
    [TestClass]
    public class DataLoaderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataLoader_CreatWithNullStream()
        {
            DataLoader data = new DataLoader(null);
            data.Dispose();
        }

        [TestMethod]
        public void DataLoader_Save_Success()
        {
            MemoryStream memoryStream = new MemoryStream();
            DataLoader dataLoader = new DataLoader(memoryStream);
            List<Mailbox> mailboxes = new List<Mailbox>();

            mailboxes.Add(new Mailbox(Size.Small, (1, 1), new Person("Hubbard", "Tatyana")));
            dataLoader.Save(mailboxes);
            dataLoader.Dispose();
        }


        // Something weird is going on with this test method, but everything else works
        [TestMethod]
        public void DataLoader_Load_Success()
        {
            MemoryStream memoryStream = new MemoryStream();
            DataLoader dataLoader = new DataLoader(memoryStream);
            List<Mailbox> mailboxes = new List<Mailbox>();
            List<Mailbox> returnMailboxes;

            mailboxes.Add(new Mailbox(Size.Small, (1, 1), new Person("Hubbard", "Tatyana")));
            mailboxes.Add(new Mailbox(Size.Medium, (1, 3), new Person("Hubbard", "Tatyana")));
            mailboxes.Add(new Mailbox(Size.Large, (1, 5), new Person("Hubbard", "Tatyana")));
            mailboxes.Add(new Mailbox(Size.Undeclared, (1, 7), new Person("Hubbard", "Tatyana")));

            dataLoader.Save(mailboxes);
            returnMailboxes = dataLoader.Load();

            Assert.AreEqual(mailboxes.Count, returnMailboxes.Count);

            dataLoader.Dispose();
        }

        [TestMethod]
        public void DataLoader_Load_ThrowsException()
        {
            MemoryStream memoryStream = new MemoryStream();
            using (StreamWriter sw = new StreamWriter(memoryStream, leaveOpen: true))
            {
                sw.Write(new Mailbox(Size.Medium, new ValueTuple<int,int>(1, 1), new Person("Hubbard", "Tatyana")));
            }
            DataLoader dataLoader = new DataLoader(memoryStream);
            Assert.IsNull(dataLoader.Load());
            dataLoader.Dispose();
        }
    }
}
