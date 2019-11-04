using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class DataLoaderTests
    {
        [TestMethod]
        public void Load_OneMailbox_ReturnsCorrectValue()
        {
            //Arrange
            Mailbox mailbox = new Mailbox(Size.Small, (0, 0), new Person("Homer", "Simpson"));
            MemoryStream memoryStream = new MemoryStream();
            using (StreamWriter streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(), 1024, true))
            {
                streamWriter.Write(mailbox.GetJson());
            }

            //Act
            using DataLoader dataLoader = new DataLoader(memoryStream);
            List<Mailbox> mailboxes = dataLoader.Load() ?? new List<Mailbox>();
            memoryStream.Dispose();

            //Assert
            Assert.AreEqual(mailbox.ToString(), mailboxes[0].ToString());
        }

        [TestMethod]
        public void Load_MultipleMailboxes_ReturnsCorrectValue()
        {
            //Arrange
            Mailbox homersMailbox = new Mailbox(Size.Small, (0, 0), new Person("Homer", "Simpson"));
            Mailbox nedsMailbox = new Mailbox(Size.Medium, (1, 1), new Person("Ned", "Flanders"));
            MemoryStream memoryStream = new MemoryStream();
            using (StreamWriter streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(), 1024, true))
            {
                streamWriter.WriteLine(homersMailbox.GetJson());
                streamWriter.WriteLine(nedsMailbox.GetJson());
            }
            //Act
            using DataLoader dataLoader = new DataLoader(memoryStream);
            List<Mailbox> mailboxes = dataLoader.Load() ?? new List<Mailbox>();
            memoryStream.Dispose();
            //Assert
            Assert.AreEqual(homersMailbox.ToString(), mailboxes[0].ToString());
            Assert.AreEqual(nedsMailbox.ToString(), mailboxes[1].ToString());
        }

        [TestMethod]
        public void Load_PremiumMailbox_ReturnsCorrectValue()
        {
            //Arrange
            Mailbox premiumMailbox = new Mailbox(Size.LargePremium, (2, 3), new Person("Homer", "Simpson"));
            MemoryStream memoryStream = new MemoryStream();
            using (StreamWriter streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(), 1024, true))
            {
                streamWriter.WriteLine(premiumMailbox.GetJson());
            }
            //Act
            using DataLoader dataloader = new DataLoader(memoryStream);
            List<Mailbox> mailboxes = dataloader.Load() ?? new List<Mailbox>();
            memoryStream.Dispose();
            //Assert
            Assert.AreEqual(premiumMailbox.ToString(), mailboxes[0].ToString());
        }

        [TestMethod]
        public void Save_OneMailbox_CorrectlyStoresJsonInformation()
        {
            //Arrange
            MemoryStream memoryStream = new MemoryStream();
            using DataLoader dataLoader = new DataLoader(memoryStream);
            Mailbox homersMailbox = new Mailbox(Size.Small, (0, 0), new Person("Homer", "Simpson"));
            List<Mailbox> mailboxes = new List<Mailbox>();
            mailboxes.Add(homersMailbox);
            //Act
            dataLoader.Save(mailboxes);
            string readResult = "";
            using (StreamReader streamReader = new StreamReader(memoryStream, new UTF8Encoding(), false, 1024, true))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                readResult = streamReader.ReadLine() ?? "";
            }
            memoryStream.Dispose();
            //Assert
            Assert.AreEqual(homersMailbox.GetJson(), readResult);
        }

        [TestMethod]
        public void Save_TwoMailboxes_CorrectlyStoresJsonInformation()
        {
            //Arrange
            MemoryStream memoryStream = new MemoryStream();
            using DataLoader dataLoader = new DataLoader(memoryStream);
            Mailbox homersMailbox = new Mailbox(Size.Small, (0, 0), new Person("Homer", "Simpson"));
            Mailbox nedsMailbox = new Mailbox(Size.MediumPremium, (1, 2), new Person("Ned", "Flanders"));
            List<Mailbox> mailboxes = new List<Mailbox>();
            mailboxes.Add(homersMailbox);
            mailboxes.Add(nedsMailbox);
            //Act
            dataLoader.Save(mailboxes);
            string homerReadResult = "";
            string nedReadResult = "";
            using (StreamReader streamReader = new StreamReader(memoryStream, new UTF8Encoding(), false, 1024, true))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                homerReadResult = streamReader.ReadLine() ?? "";
                nedReadResult = streamReader.ReadLine() ?? "";
            }
            memoryStream.Dispose();
            //Assert
            Assert.AreEqual(homersMailbox.GetJson(), homerReadResult);
            Assert.AreEqual(nedsMailbox.GetJson(), nedReadResult);
        }
    }
}