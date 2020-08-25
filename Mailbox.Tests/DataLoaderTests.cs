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
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataLoader_ConstructorNeedsNonNullStream()
        {
            Stream? stream = null;
            //Act
#pragma warning disable CS8604 // Possible null reference argument.
            using DataLoader _ = new DataLoader(stream);
#pragma warning restore CS8604 // Possible null reference argument.
        }


        [TestMethod]
        public void DataLoader_Load()
        {
            //Arrange
            //string path = Path.GetRandomFileName();
            using MemoryStream stream = new MemoryStream();

            Person person = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };
            Mailbox box = new Mailbox(Sizes.Large, (0, 0), person);
            var boxes = new List<Mailbox>
            {
                box
            };

            using StreamWriter streamWriter = new StreamWriter(stream, leaveOpen:true);
            streamWriter.Write(JsonConvert.SerializeObject(boxes));
            streamWriter.Flush();

            //Act
            using var dataLoader = new DataLoader(stream);
            List<Mailbox> mailboxes = dataLoader.Load();

            Mailbox mailbox = mailboxes[0];
            //Assert
            Assert.AreEqual(mailboxes.Count, 1);
            Assert.AreEqual(Sizes.Large, mailbox.BoxSize);
            Assert.AreEqual((0, 0), mailbox.Location);
            Assert.AreEqual(person, mailbox.Owner);
            
        }


        [TestMethod]
        public void DataLoader_Save()
        {
            Person person = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };
            Mailbox box = new Mailbox(Sizes.Large, (0, 0), person);
            var boxes = new List<Mailbox>
            {
                box
            };

            using var stream = new MemoryStream();
            using var dataLoader = new DataLoader(stream);

            //Act
            dataLoader.Save(boxes);

            using var streamReader = new StreamReader(stream, leaveOpen: true);
            stream.Position = 0;
            var line = streamReader.ReadToEnd();


            List<Mailbox> mailboxes = JsonConvert.DeserializeObject<List<Mailbox>>(line);

            Assert.AreEqual(1, mailboxes.Count);
            Assert.AreEqual(Sizes.Large, mailboxes[0].BoxSize);
            Assert.AreEqual((0, 0), mailboxes[0].Location);
            Assert.AreEqual(person, mailboxes[0].Owner);




        }

        [TestMethod]
        public void DataLoader_Dispose()
        {
            var stream = new TestStream();
            DataLoader dataLoader = new DataLoader(stream);
            dataLoader.Dispose();

            Assert.IsTrue(stream.isDisposed);
        }

        private class TestStream : MemoryStream
        {
            public bool isDisposed;

            protected override void Dispose(bool disposing)
            {
                isDisposed = true;
                base.Dispose(disposing);
            }
        }
    }
}
