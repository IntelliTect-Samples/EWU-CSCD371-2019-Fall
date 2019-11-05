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
        public void DataLoader_Load_LoadsSuccessfully()
        {
            // Arrange
            MemoryStream source = new MemoryStream();
            DataLoader sut = new DataLoader(source);
            List<Mailbox> list = new List<Mailbox>();
            list.Add(new Mailbox(Size.Large, (1, 1), new Person("first", "Last")));
            list.Add(new Mailbox(Size.Large, (1, 6), new Person("first", "Last")));
            list.Add(new Mailbox(Size.Large, (3, 1), new Person("first", "Last")));

            // Act
            sut.Save(list);
            List<Mailbox> testList = sut.Load();

            // Assert
            Assert.AreEqual(testList.Count, list.Count);
            sut.Dispose();
        }

        [TestMethod]
        public void DataLoader_Load_JsonException()
        {
            // Arrange
            MemoryStream source = new MemoryStream();
            DataLoader sut = new DataLoader(source);
            List<Mailbox> list = new List<Mailbox>();
            list.Add(new Mailbox(Size.Large, (1, 1), new Person("first", "Last")));
            list.Add(new Mailbox(Size.Large, (1, 6), new Person("first", "Last")));
            list.Add(new Mailbox(Size.Large, (3, 1), new Person("first", "Last")));

            // Act
            using (StreamWriter sw = new StreamWriter(source, leaveOpen: true))
            {
                foreach(Mailbox mailbox in list)
                {
                    sw.WriteLine(mailbox.ToString());
                }
            }

            // Assert
            Assert.IsNull(sut.Load());
            sut.Dispose();
        }
    }
}
