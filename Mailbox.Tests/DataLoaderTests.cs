using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            using (FileStream fileStream = new FileStream("testfile.txt", FileMode.Create))
            {
                DataLoader dataLoader = new DataLoader(fileStream);

                List<Mailbox> mailboxList = dataLoader.Load();

                Assert.AreNotEqual(0, mailboxList.Count);

                dataLoader.Dispose();
            }
        }
    }
}