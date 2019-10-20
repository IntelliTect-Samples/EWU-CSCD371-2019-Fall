using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Inheritance.Tests
{
    [TestClass]
    public class FoodTests
    {
        [TestMethod]
        public void FoodPrintInfo()
        {
            var item = new Food
            {
                Upc = "Test Upc",
                Brand = "Test Brand"
            };

            string testPrintedInfo = item.PrintInfo();

            Assert.AreEqual("<Test Upc> - <Test Brand>", testPrintedInfo);
        }
    }
}
