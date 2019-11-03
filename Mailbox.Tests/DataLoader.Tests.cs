using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

#pragma warning disable CS8625
#pragma warning disable CS8602
#pragma warning disable CS8600

namespace Mailbox.Tests
{
    [TestClass]
    public class DataLoaderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataLoader_Constructor_NullStream()
        {
            DataLoader loader = new DataLoader(null);
        }

        [TestMethod]
        public void DataLoader_Save_Success()
        {
            List<Mailbox> boxList = new List<Mailbox>();
            MemoryStream source = new MemoryStream();
            DataLoader loader = new DataLoader(source);

            boxList.Add(new Mailbox(Size.Small, new ValueTuple<int, int>(1, 1), new Person("Some", "One")));

            loader.Save(boxList);
            loader.Dispose();
        }

        [TestMethod]
        public void DataLoader_Load_ReturnMailboxes()
        {
            List<Mailbox> boxList = new List<Mailbox>();
            MemoryStream source = new MemoryStream();
            DataLoader loader = new DataLoader(source);

            boxList.Add(new Mailbox(Size.Medium, new ValueTuple<int, int>(1, 1), new Person("Some", "One")));
            boxList.Add(new Mailbox(Size.Medium, new ValueTuple<int, int>(1, 3), new Person("Some", "One")));
            boxList.Add(new Mailbox(Size.Medium, new ValueTuple<int, int>(1, 5), new Person("Some", "One")));

            loader.Save(boxList);
            boxList = loader.Load();
            Assert.AreEqual(boxList.Count, 3);
            loader.Dispose();
        }

        [TestMethod]
        public void DataLoader_Load_JsonReaderException()
        {
            MemoryStream source = new MemoryStream();
            using (StreamWriter sw = new StreamWriter(source, leaveOpen: true))
            {
                sw.Write(new Mailbox(Size.Small, (1, 1), new Person("The", "Dude")));
            }
            DataLoader dataLoader = new DataLoader(source);
            Assert.IsNull(dataLoader.Load());
            dataLoader.Dispose();
        }

    }
}
