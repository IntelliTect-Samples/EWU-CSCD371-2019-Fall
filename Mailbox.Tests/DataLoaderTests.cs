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
        public void SaveToStream_LoadFromStream_CompareLists()
        {
            DataLoader dl = new DataLoader(File.Open("Mailboxes.json", FileMode.OpenOrCreate, FileAccess.ReadWrite));

            List<Mailbox> mailboxes = new List<Mailbox>()
            {
                new Mailbox(Size.Small, 0, 0, new Person("Drew", "Bosco")),
                new Mailbox(Size.Premium | Size.Small, 0, 0, new Person("Audrey", "Halfhill"))
            };

            dl.Save(mailboxes);
            List<Mailbox> retrieveBoxes = dl.Load();

            Assert.IsNotNull(retrieveBoxes);
        }
    }
}
