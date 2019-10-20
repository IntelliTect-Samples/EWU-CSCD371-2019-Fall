using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Inheritance.Tests
{
    [TestClass]
    public class TelevisionTests
    {
        [TestMethod]
        public void TelevisionPrintInfo()
        {
            var item = new Television
            {
                Manufacturer = "Test Manufacturer",
                Size = "Test Size"
            };

            string testPrintedInfo = item.PrintInfo();

            Assert.AreEqual("<Test Manufacturer> - <Test Size>", testPrintedInfo);
        }
    }
}
