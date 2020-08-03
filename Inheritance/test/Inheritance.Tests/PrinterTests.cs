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
        public void TelevisionGetsPrinted()
        {
            // Arrange
            var television = new Television
            {
                Manufacturer = "Samsung",
                Size = "42\""
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    // Act
                    Printer.Print(television, writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("Samsung - 42\"", lineWritten);
                    }
                }
            }
        }




        [TestMethod]
        public void FoodGetsPrinted()
        {
            // Arrange
            var food = new Food
            {
                Upc = "123456789",
                Brand = "Kirkland"
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    // Act
                    Printer.Print(food, writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("123456789 - Kirkland", lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        public void ItemGetsPrinted()
        {
            // Arrange
            var item = new TestItem { Name = "Test Item" };

            using (var stream = new MemoryStream())
            {
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

    public class TestItem : Item
    {
        public string Name { get; set; }

        public override string PrintInfo()
        {
            return Name;
        }
    }
}
