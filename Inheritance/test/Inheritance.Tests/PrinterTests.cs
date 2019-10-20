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

        [TestMethod]
        public void FoodItemGetsPrinted()
        {
            // Arrange
            var foodItem = new Food { Brand = "Crystal Geyser", Upc = "5935277172" };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    // Act
                    Printer.Print(foodItem, writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual(($"{ foodItem.Upc } - { foodItem.Brand }" ), lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        public void TelevisionItemGetsPrinted()
        {
            // Arrange
            var tvItem = new Television { Manufacturer = "Sony", Size = "60 Inch" };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    // Act
                    Printer.Print(tvItem, writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual(($"{ tvItem.Manufacturer } - { tvItem.Size }"), lineWritten);
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
