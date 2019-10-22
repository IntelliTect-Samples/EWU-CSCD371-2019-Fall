using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    class TelevisionTests
    {

        [TestMethod]
        public void Check_Television_PrintInfo()
        {
            Television tv = new Television();

            tv.Size = "70";
            tv.Manufacturer = "Panasonic";

            Assert.AreEqual("<Panasonic> - <70>", tv.PrintInfo());
        }
        
    }
}
