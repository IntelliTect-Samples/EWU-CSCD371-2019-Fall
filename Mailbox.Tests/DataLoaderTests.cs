using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System;

namespace Mailbox.Tests
{
    [TestClass]
    public class DataLoaderTests
    {
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

                foreach (var pair in testPairs)
                {
                    Assert.AreEqual(JsonConvert.SerializeObject(pair[0]), pair[1]);
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
