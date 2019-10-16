using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Inheritance.Tests
{
    [TestClass]
    public class FoodTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Food_PrintInfo_NullUpc()
        {
            Food f = new Food { Brand = "Kellogs" };

            f.PrintInfo();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Food_PrintInfo_NullBrand()
        {
            Food f = new Food { Upc = "123456789" };

            f.PrintInfo();
        }

        [TestMethod]
        public void Food_PrintInfo_CorrectMessage()
        {
            Food f = new Food { Upc = "123456789", Brand = "Kellogs" };

            Assert.AreEqual(f.PrintInfo(), "<123456789> - <Kellogs>");
        }
    }
}
