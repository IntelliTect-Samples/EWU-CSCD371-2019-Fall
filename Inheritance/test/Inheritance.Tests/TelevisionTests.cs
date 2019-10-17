using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class TelevisionTests
    {
        [TestMethod]
        public void TelevisionPrintInfo_CorrectlyFormatted()
        {
            string manufacturer = "SomeManufacturer Inc.",
                   size = "32\"";
            var tele = new Television() {
                Manufacturer = manufacturer,
                Size = size
            };
            Assert.AreEqual(
                $"{manufacturer} - {size}",
                tele.PrintInfo()
            );
        }
    }
}
