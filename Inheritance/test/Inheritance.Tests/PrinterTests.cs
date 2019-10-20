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
        public void Food_PrintInfo()
        {
            //Arrange
            var foodItem = new Food { Brand = "McDonalds", Upc = "1004" };
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    //Act
                    Printer.Print(foodItem, writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    //Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual(foodItem.PrintInfo(), lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        public void Television_PrintInfo()
        {
            //Arrange
            var tvItem = new Television { Manufacturer="Vizio", Size="15" };
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    //Act
                    Printer.Print(tvItem, writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    //Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual(tvItem.PrintInfo(), lineWritten);
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
