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
            var item = new TestItem {Name = "Test Item"};
            Assert.AreEqual("Test Item", TestPrint(item));
        }

        [TestMethod]
        [DataRow("Sony", 65)]
        [DataRow("", 70)]
        public void Television_EnsureCorrectPrint(string manufacturer, int size)
        {
            var tv = new Television {Manufacturer = manufacturer, Size = size};
            Assert.AreEqual($"{(manufacturer.Length != 0 ? manufacturer : "Unknown Manufacturer")} - {size}",
                            TestPrint(tv));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Television_GivenNull_ThrowsException()
        {
            var tv = new Television();
            tv.PrintInfo();
        }

        [TestMethod]
        [DataRow("Brett's Best", "31415926535")]
        [DataRow("", "")]
        public void Food_EnsureCorrectPrint(string brand, string upc)
        {
            var food = new Food {Brand = brand, Upc = upc};
            Assert.AreEqual(
                $"{(upc.Length != 0 ? upc : "Invalid UPC")} - {(brand.Length != 0 ? brand : "Unknown Brand")}",
                TestPrint(food));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Food_GivenNull_ThrowsException()
        {
            var food = new Food();
            food.PrintInfo();
        }

        private static string TestPrint(Item item)
        {
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            Printer.Print(item, writer);
            writer.Flush();

            stream.Position = 0;
            stream.Seek(0, SeekOrigin.Begin);

            using var reader = new StreamReader(stream);
            return reader.ReadLine();
        }

    }

    public class TestItem : Item
    {

        public string Name { get; set; }

        public override string PrintInfo() => Name ?? "Empty Name";

    }

}
