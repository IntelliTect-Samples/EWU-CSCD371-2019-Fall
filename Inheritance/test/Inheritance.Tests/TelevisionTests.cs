using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class TelevisionTests
    {
        [TestMethod]
        public void Television_EnsureCorrectPrint()
        {
            var tv = new Television {Size = "65", Manufacturer = "Sony" };
            Assert.AreEqual("Sony - 65", tv.PrintInfo());
        }
    }
}