using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Inheritance.Tests
{
    [TestClass]
    class FoodTests
    {
        [TestMethod]
        public void Food_PrintInfo()
        {
            Food food = new Food();

            food.Upc = "64684";
            food.Brand = "Black Angus";

            string toCompare = "<64684> - <Black Angus>";

            Assert.AreEqual(toCompare, food.PrintInfo());
        }

    }
}
