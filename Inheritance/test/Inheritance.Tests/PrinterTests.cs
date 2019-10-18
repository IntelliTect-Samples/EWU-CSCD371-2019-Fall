using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

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

        [TestMethod]
        public void TelevisionGetsPrinted()
        {
            //Arrange
            Television myTV = new Television() { Manufacturer = "Sony", Size = "40\"" };

            //Act
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    Printer.Print(myTV, writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("Sony - 40\"", lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        public void FoodGetsPrinted()
        {
            //Arrange
            Food myFood = new Food() { Upc = "012345678905", Brand = "Dale" };

            //Act
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    Printer.Print(myFood, writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("012345678905 - Dale", lineWritten);
                    }
                }
            }
        }

        public class TestItem : Item
        {
            public string Name { get; set; }

            public override string PrintInfo()
            {
                return "Test Item";
            }
        }
    }
}