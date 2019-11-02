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
        public void SaveGoodData()
        {
            //Arrange
            List<Mailbox> toSave = new List<Mailbox>();
            List<Mailbox> saved = new List<Mailbox>();
            MemoryStream source = new MemoryStream();
            DataLoader dataLoader = new DataLoader(source);

            toSave.Add(new Mailbox(new Person("FirstName", "LastName"), Sizes.Small, (0, 0)));

            //Act
            dataLoader.Save(toSave);

            //Assert

        }
    }
}