using Inheritance;
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
[ExpectedException(typeof(ArgumentNullException))]
public void Television_PrintInfo_SizeNull()
{
    //Arrange
    Television television = new Television("LG", null);

    //Act
    television.PrintInfo();
}
[TestMethod]
[ExpectedException(typeof(ArgumentNullException))]
public void Television_PrintInfo_ManufacturerNull()
{
    //Arrange
    Television television = new Television(null, "60");

    //Act
    television.PrintInfo();
}

[TestMethod]
public void Television_PrintInfoCorrectly()
{
    //Arrange
    Television television = new Television("LG", "60");

    //Act
    television.PrintInfo();

    //Assert
    Assert.AreEqual(television.PrintInfo(), "<LG> - <60>");
}

[TestMethod]
[ExpectedException(typeof(ArgumentNullException))]
public void Food_PrintInfo_Brandnull()
{
    //Arrange
    Food food = new Food("123456789", null);

    //Act
    food.PrintInfo();
}
[TestMethod]
[ExpectedException(typeof(ArgumentNullException))]
public void Food_PrintInfo_UpcNull()
{
    //Arrange
    Food food = new Food(null, "Kellogs");

    //Act
    food.PrintInfo();
}

[TestMethod]
public void Food_PrintInfoCorrectly()
{
    //Arrange
    Food food = new Food("123456789", "Kellogs");

    //Act
    food.PrintInfo();

    //Assert
    Assert.AreEqual(food.PrintInfo(), "<123456789> - <Kellogs>");
}
     }

     public class TestItem : Item
{
    public string Name { get; set; }

    public override string PrintInfo() => Name;
}
 }