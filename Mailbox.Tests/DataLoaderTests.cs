using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace Mailbox.Tests
{
    [TestClass]
    public class DataLoaderTests
    {
        [TestMethod]
        public void DataLoader_LoadMailbox_Success()
        {
            string fileName = Path.GetRandomFileName();
            Stream fileStream = File.Open(fileName, FileMode.Create);
            List<Mailbox> mailboxes = new List<Mailbox>()
            {
                new Mailbox(Size.Small, (1, 1), new Person("Asher", "Mancinelli")),
                new Mailbox(Size.Small, (2, 1), new Person("John", "Doe")),
                new Mailbox(Size.Small, (1, 2), new Person("Jake", "FakeName")),
            };

            using (var sw = new StreamWriter(fileStream))
            {
                foreach (var box in mailboxes)
                {
                    sw.WriteLine(JsonConvert.SerializeObject(box));
                }
            }
            
            fileStream = File.Open(fileName, FileMode.Open);
            var sut = new DataLoader(fileStream);

            try
            {
                List<Mailbox>? loadedMailboxes = sut.Load();
                var boxPairs = mailboxes.Zip(loadedMailboxes, (a, b) => (a, b));

                Assert.IsNotNull(loadedMailboxes);
                foreach (var (box, loadedBox) in boxPairs)
                {
                    Assert.AreEqual(box, loadedBox);
                }
            }
            finally
            {
                File.Delete(fileName);
                fileStream.Dispose();
            }
        }

        [TestMethod]
        public void DataLoader_SaveMailbox_Success()
        {
            string fileName = Path.GetRandomFileName();
            Stream fileStream = File.Open(fileName, FileMode.Create);
            List<Mailbox> mailboxes = new List<Mailbox>()
            {
                new Mailbox(Size.Small, (1, 1), new Person("Asher", "Mancinelli")),
                new Mailbox(Size.Small, (2, 1), new Person("John", "Doe")),
                new Mailbox(Size.Small, (1, 2), new Person("Jake", "FakeName")),
            };
        
            try
            {
                var sut = new DataLoader(fileStream);

                sut.Save(mailboxes);
                string[] lines = File.ReadLines(fileName).ToArray();
                var testPairs = mailboxes.Zip(lines, (a, b) => (a, b));

                foreach (var (box, line) in testPairs)
                {
                    Assert.AreEqual(JsonConvert.SerializeObject(box), line);
                }
            }
            finally
            {
                File.Delete(fileName);
                fileStream.Dispose();
            }
        }
    }
}
