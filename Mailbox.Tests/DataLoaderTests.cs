using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{
    [TestClass]
    public class DataLoaderTests
    {
        [TestMethod]
        public void DataLoader_SaveMailbox_Success()
        {
            string fileName = Path.GetRandomFileName();
            Stream fileStream = File.Open(fileName, FileMode.Create);
            var mailboxes = new List<Mailbox>()
            {
                new Mailbox(Size.Small, (1, 1), new Person("Asher", "Mancinelli")),
            }
        
            try
            {
                var sut = new DataLoader(fileStream);

                sut.Save(mailboxes);
                string[] lines = File.ReadLines(fileName).ToArray();
                var testPairs = mailboxes.Zip(lines, (a, b) => (a, b));

                foreach (var (box, line) in testPairs)
                {
                    Assert.AreEqual(JsonConvert.SerializeObject(box), line);
                }
            }
            finally
            {
                File.Delete(fileName);
                fileStream.Dispose();
            }
        }
    }
}
