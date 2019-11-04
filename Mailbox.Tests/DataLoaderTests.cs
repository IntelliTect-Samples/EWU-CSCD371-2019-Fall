using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Mailbox.Tests {
    [TestClass]
    public class DataLoaderTests {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_DoesntAcceptNullStream() {
            //Arrange

            //Act
            DataLoader dl = new DataLoader(null);

            //Assert
        }

        [TestMethod]
        public void LoadandSave_Work() {
            //Arrange
            Mailboxes massive = new Mailboxes(new Mailbox[10, 10]);
            Person person = new Person("Joel", "Kalich");
            while (!massive.FindValidLocation(person).Equals((-1, -1))) {
                (int, int) temp = massive.FindValidLocation(person);
                massive.MailboxesArray[temp.Item1, temp.Item2] = new Mailbox(new Sizes(), temp, person);
            }
            DataLoader dl = new DataLoader(File.Open("Mailboxes.json", FileMode.OpenOrCreate, FileAccess.ReadWrite));

            //Act
            dl.Save(massive.MailboxesArray);
            Mailbox[,] result = dl.Load();

            //Assert
            Assert.AreEqual(massive.MailboxesArray.ToString(), result.ToString());
        }
    }
}
