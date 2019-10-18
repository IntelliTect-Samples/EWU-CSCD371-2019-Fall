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

    [TestClass]
    public class FoodPrinterTests
    {
        [TestMethod]
        public void FoodGetsPrinted()
        {
            // Arrange
            Food item = new Food { Upc = "152542362578", Brand = "Nabisco" };

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
                        Assert.AreEqual("152542362578 - Nabisco", lineWritten);
                    }
                }
            }
        }
    }

    [TestClass]
    public class TelevisionPrinterTests
    {
        [TestMethod]
        public void TelevisionGetsPrinted()
        {
            // Arrange
            Television item = new Television { Manufacturer = "Sony", Size = 42 };

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
                        Assert.AreEqual("Sony - 42", lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        public void TelevisionNullManufacturerGetsPrinted()
        {
            // Arrange
            Television item = new Television { Manufacturer = null, Size = 42 };

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
                        Assert.AreEqual(" - 42", lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        public void TelevisionEmptySizeGetsPrinted()
        {
            // Arrange
            Television item = new Television { Manufacturer = "Sony" };

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
                        Assert.AreEqual("Sony", lineWritten);
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
