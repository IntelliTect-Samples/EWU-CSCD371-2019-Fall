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
        public void DataLoader_Constructor_Sets_Stream()
        {
            using (FileStream fileStream = new FileStream("testfile.txt", FileMode.Create))
            {
                DataLoader dataLoader = new DataLoader(fileStream);

                Assert.IsNotNull(dataLoader.Stream);

                dataLoader.Dispose();
            }
        }

        [TestMethod]
        public void DataLoader_Load_LoadsList()
        {
            using (FileStream fileStream = new FileStream("testfile.txt", FileMode.OpenOrCreate))
            {
                DataLoader dataLoader = new DataLoader(fileStream);

                List<Mailbox> mailboxList = dataLoader.Load();

                Assert.AreNotEqual(0, mailboxList.Count);

                dataLoader.Dispose();
            }
        }

        [TestMethod]
        public void DataLoader_Save_SavesListToStream()
        {
            using(FileStream fileStream = new FileStream("testfile.txt", FileMode.OpenOrCreate))
            {
                DataLoader dataLoader = new DataLoader(fileStream);

                List<Mailbox> mailboxList = new List<Mailbox>();

                mailboxList.Add(new Mailbox() { Owner = new Person("Doug", "Student") , Location = (2, 4), Size = Size.Medium} );

                dataLoader.Save(mailboxList);

                using var reader = new StreamReader(fileStream, leaveOpen: true);
                string serialData = reader.ReadToEnd();

                List<Mailbox>? testList = JsonConvert.DeserializeObject<List<Mailbox>> (serialData);

                Assert.AreEqual(mailboxList.Count, testList.Count);

                dataLoader.Dispose();
            }
        }
    }
}