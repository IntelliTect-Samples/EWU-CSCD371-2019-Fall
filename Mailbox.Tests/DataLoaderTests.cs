using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
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
        public void Load_LoadsProperly()
        {
            var mailboxes = new List<Mailbox>();
            mailboxes.Add(new Mailbox(Sizes.Small, (1, 1), new Person("First1", "Last1")));
            mailboxes.Add(new Mailbox(Sizes.Medium, (2, 2), new Person("First2", "Last2")));
            mailboxes.Add(new Mailbox(Sizes.LargePremium, (3, 3), new Person("First3", "Last3")));

            using var ms = new MemoryStream();
            using var sut = new DataLoader(ms);
            using var sw = new StreamWriter(ms);

            ms.Position = 0;

            sw.Write(JsonConvert.SerializeObject(mailboxes));
            sw.Flush();

            var mailboxes2 = sut.Load();

            Assert.AreEqual(mailboxes.Count, mailboxes2!.Count);
            Assert.AreEqual(mailboxes[0].ToString(), mailboxes2![0].ToString());
            Assert.AreEqual(mailboxes[1].ToString(), mailboxes2![1].ToString());
            Assert.AreEqual(mailboxes[2].ToString(), mailboxes2![2].ToString());
        }

        [TestMethod]
        public void Save_SavesProperly()
        {
            var mailboxes = new List<Mailbox>();
            mailboxes.Add(new Mailbox(Sizes.Small, (1, 1), new Person("First1", "Last1")));
            mailboxes.Add(new Mailbox(Sizes.Medium, (2, 2), new Person("First2", "Last2")));
            mailboxes.Add(new Mailbox(Sizes.LargePremium, (3, 3), new Person("First3", "Last3")));

            using var ms = new MemoryStream();
            using var sut = new DataLoader(ms);
            using var sr = new StreamReader(ms);

            ms.Position = 0;

            sut.Save(mailboxes);
            ms.Position = 0;
            var mailboxes2 = JsonConvert.DeserializeObject<List<Mailbox>>(sr.ReadToEnd());

            Assert.AreEqual(mailboxes.Count, mailboxes2!.Count);
            Assert.AreEqual(mailboxes[0].ToString(), mailboxes2![0].ToString());
            Assert.AreEqual(mailboxes[1].ToString(), mailboxes2![1].ToString());
            Assert.AreEqual(mailboxes[2].ToString(), mailboxes2![2].ToString());
        }
    }
}
