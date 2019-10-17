using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Inheritance.Tests {
    [TestClass]
    public class PrinterTests {
        [TestMethod]
        public void PersonGetsPrinted() {
            // Arrange
            var item = new TestItem { Name = "Test Item" };

            using (var stream = new MemoryStream()) {
                using (var writer = new StreamWriter(stream)) {
                    // Act
                    Printer.Print(item, writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream)) {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("Test Item", lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        public void FoodGetsPrinted() {
            //Arrange
            var item = new Food { Brand = "Reeses", Upc = "034000007363" };

            using (var stream = new MemoryStream()) {
                using (var writer = new StreamWriter(stream)) {
                    // Act
                    Printer.Print(item, writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream)) {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("034000007363 - Reeses", lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        public void TelevisionGetsPrinted() {
            //Arrange
            var item = new Television { Manufacturer = "Samsung", Size = 80 };

            using (var stream = new MemoryStream()) {
                using (var writer = new StreamWriter(stream)) {
                    // Act
                    Printer.Print(item, writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream)) {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("Samsung - 80", lineWritten);
                    }
                }
            }
        }
    }

    public class TestItem : Item {
        public string Name { get; set; }

        public override string PrintInfo() {
            return this.Name;
        }
    }
}
