using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Inheritance.Tests
{
    [TestClass]
    public class PrinterTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Television_PrintInfo_NullManufacturer()
        {
            Item tv = new Television() { Manufacturer = null, Size = 65 };
            tv.PrintInfo();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Television_PrintInfo_SizeNotSet()
        {
            Item tv = new Television() { Manufacturer = "Sony" };
            tv.PrintInfo();
        }

        [TestMethod]
        public void Television_PrintInfo_PrintCorrectInfo()
        {
            Item tv = new Television() { Manufacturer = "Sony", Size = 65 };
            tv.PrintInfo();
            Assert.AreEqual(tv.PrintInfo(), "Sony - 65");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Food_PrintInfo_NullUpc()
        {
            Item food = new Food() { Upc = null, Brand = "Wheeties"};
            food.PrintInfo();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Food_PrintInfo_NullBrand()
        {
            Item food = new Food() { Upc = "173467321476c32789777643t732v731178887324767" };
            food.PrintInfo();
        }

        [TestMethod]
        public void Food_PrintInfo_PrintCorrectInfo()
        {
            Item food = new Food() { Upc = "173467321476c32789777643t732v731178887324767", Brand = "Wheeties" };
            food.PrintInfo();
            Assert.AreEqual(food.PrintInfo(), "173467321476c32789777643t732v731178887324767 - Wheeties");
        }

        [TestMethod]
        public void ItemGetsPrinted()
        {
            // Arrange
            var item = new TestItem { Name = "Test Item" };
             
            using (var stream = new MemoryStream()) {
                using (var writer = new StreamWriter(stream))
                {
                    // Act
                    Printer.Print(item, writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("Test Item", lineWritten);
                    }
                }
            }
        }
    }

    public class TestItem : Item {
        public string Name { get; set; }

        public override string PrintInfo()
        {
            return Name;
        }
    }
}
