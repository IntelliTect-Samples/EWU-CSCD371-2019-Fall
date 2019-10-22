using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Inheritance.Tests
{
    [TestClass]
    public class PersonPrinterTests
    {
        [TestMethod]
        public void PersonGetsPrinted()
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

        [TestMethod]
        public void Test_ItemUpc()
        {
            Food burger = new Food();
            burger.Upc = "111";
            Assert.AreEqual("111",burger.Upc);
        }
        [TestMethod]
        public void Test_ItemBrand()
        {
            Food burger = new Food();
            burger.Brand = "McDonalds";
            Assert.AreEqual("McDonalds", burger.Brand);
        }
        [TestMethod]
        public void Test_TVManufacturer()
        {
            Television tv = new Television();
            tv.manufacturer = "Sony";
            Assert.AreEqual("Sony", tv.manufacturer);
        }
        [TestMethod]
        public void Test_TVSize()
        {
            Television tv= new Television();
            tv.size = "120in";
            Assert.AreEqual("120in", tv.size);
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
