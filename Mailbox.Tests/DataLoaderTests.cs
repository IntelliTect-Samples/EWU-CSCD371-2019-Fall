using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailRoom;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MailRoom.Tests
{
    [TestClass]
    public class DataLoaderTests
    {
        [TestMethod]
        public void SaveAndLoad_SaveMailboxesAndLoadMailboxes_ReturnsMailboxesMatchingOriginal()
        {
            using MemoryStream fakeStream = new MemoryStream();
            using DataLoader sut = new DataLoader(fakeStream);
            List<Mailbox> expected = new List<Mailbox>
            {
                new Mailbox(new Person("F1", "L1"), (1, 1), Sizes.Small),
                new Mailbox(new Person("F2", "L2"), (2, 1), Sizes.Small)
            };
            MailboxCollection mailboxes = new MailboxCollection(expected, 2, 1);

            sut.Save(mailboxes);
            List<Mailbox>? result = sut.Load();

            Assert.IsNotNull(result);
            for (int i = 0; i < result?.Count; i++)
            {
                string resultBox = result[i].ToString();
                string expectedBox = expected[i].ToString();
                Assert.AreEqual<string>(expectedBox, resultBox);
            }
        }
    }
}
