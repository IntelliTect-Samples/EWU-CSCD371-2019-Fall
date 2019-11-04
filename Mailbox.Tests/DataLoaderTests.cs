using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mailbox;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Mailbox.Tests
{
    [TestClass()]
    public class DataLoaderTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataLoaderNullStreamThrowsException()
        {
            //Arrange

            //Act
            DataLoader dataLoader = new DataLoader(null);

            //Assert
        }

        [TestMethod()]
        public void SaveAndLoadGoodData()
        {
            //Arrange
            List<Mailbox> toSave = new List<Mailbox>();
            List<Mailbox> saved = new List<Mailbox>();
            MemoryStream source = new MemoryStream();
            DataLoader dataLoader = new DataLoader(source);
            List<Mailbox> loaded = new List<Mailbox>();

            toSave.Add(new Mailbox(new Person("FirstName", "LastName"), Sizes.Small, (0, 0)));

            //Act
            dataLoader.Save(toSave);
            loaded = dataLoader.Load();

            //Assert
            Assert.AreEqual(toSave[0].Owner.toString(), loaded[0].Owner.toString());
            Assert.AreEqual(toSave[0].Location.ToString(), loaded[0].Location.ToString());
            Assert.AreEqual(toSave[0].BoxSize.ToString(), loaded[0].BoxSize.ToString());
        }
    }
}