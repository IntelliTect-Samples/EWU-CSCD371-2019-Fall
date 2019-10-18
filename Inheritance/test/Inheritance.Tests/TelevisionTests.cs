using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Inheritance.Tests
{
    [TestClass]
    public class TelevisionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Television_PrintInfo_NullSize()
        {
#nullable disable
            Television f = new Television("Big", null);
#nullable enable
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Television_PrintInfo_NullManufacturer()
        {
#nullable disable
            Television f = new Television(null, "Samsung");
#nullable enable
        }

        [TestMethod]
        public void Television_PrintInfo_CorrectMessage()
        {
            Television f = new Television("Big", "Samsung");

            Assert.AreEqual(f.PrintInfo(), "<Samsung> - <Big>");
        }
    }
}
