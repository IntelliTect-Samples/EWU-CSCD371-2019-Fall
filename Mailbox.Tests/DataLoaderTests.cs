using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Mailbox.Tests
{
    [TestClass]
    public class DataLoaderTests
    {
        private List<MailBox> testBoxes = new List<MailBox>()
         {
             new MailBox(Sizes.Small, (1, 1), new Person("first", "last")),
             new MailBox(Sizes.Medium, (23, 5), new Person("my", "name")),
             new MailBox(Sizes.LargePremium, (2, 7), new Person("Inigo", "Montoya"))
         };

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullArgument_ThrowsException()
        {
            DataLoader dataLoader = new DataLoader(null);
        }

        [TestMethod]
        public void Load_UnSerializedData_ReturnsNull()
        {
            MemoryStream memory = new MemoryStream();
            using (StreamWriter sw = new StreamWriter(memory, leaveOpen: true))
            {
                foreach (MailBox mailbox in testBoxes)
                    sw.WriteLine(mailbox);
            }
            memory.Position = 0;

            DataLoader dataLoader = new DataLoader(memory);

            Assert.IsNull(dataLoader.Load());

            dataLoader.Dispose();
        }

        [TestMethod]
        public void Load_SerializedData_ReturnsData()
        {
            MemoryStream memory = new MemoryStream
            {
                Position = 0
            };

            using var writer = new StreamWriter(memory, leaveOpen: true);
            writer.WriteLine(JsonConvert.SerializeObject(testBoxes));
            writer.Flush();


            DataLoader dataLoader = new DataLoader(memory);

            var boxes = dataLoader.Load();

                Assert.IsNotNull(boxes);
                Assert.AreEqual(testBoxes.Count, boxes.Count);
            
        
        }
    }
}

