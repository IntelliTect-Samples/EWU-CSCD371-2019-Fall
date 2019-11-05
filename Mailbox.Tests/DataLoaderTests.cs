using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{

    [TestClass]
    public class DataLoaderTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_GivenNull_ThrowsException()
        {
            var unused = new DataLoader(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Save_GivenNull_ThrowsException()
        {
            using var memStream  = new MemoryStream();
            using var dataLoader = new DataLoader(memStream);

            try
            {
                dataLoader.Save(null);
            } finally
            {
                dataLoader.Dispose();
                memStream.Dispose();
            }
        }

        [TestMethod]
        public void SaveLoad_WritesReads_Correctly()
        {
            List<Mailbox> mailboxes = new List<Mailbox>
            {
                new Mailbox(new Person("John", "Price"), Size.LargePremium, (0, 0)),
                new Mailbox(new Person("Simon", "Riley"), Size.Default, (0, 1)),
                new Mailbox(new Person("Kyle", "Garrick"), Size.Small, (0, 2))
            };

            using var memStream  = new MemoryStream();
            var       dataLoader = new DataLoader(memStream);
            dataLoader.Save(mailboxes);

            StringBuilder expected = new StringBuilder();
            mailboxes.ForEach(mailbox => expected.Append(mailbox).Append(Environment.NewLine));

            StringBuilder loaded = new StringBuilder();
            dataLoader.Load().ForEach(mailbox => loaded.Append(mailbox).Append(Environment.NewLine));

            Console.WriteLine(loaded.ToString());

            Assert.AreEqual(expected.ToString(), loaded.ToString());
        }

        [TestMethod]
        public void Load_NothingSaved_ReturnsNull()
        {
            using var memStream  = new MemoryStream();
            var       dataLoader = new DataLoader(memStream);

            Assert.IsNull(dataLoader.Load());
        }

    }

}
