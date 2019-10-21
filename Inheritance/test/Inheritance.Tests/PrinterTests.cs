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
        [ExpectedException(typeof(NullReferenceException))]
        public void NullItem_ThrowsException()
        {
            //Arrange
            TestItem item = null;

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    //Act
                    Printer.Print(item, writer);
                    writer.Flush();

                    //Assert
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullPrintStream_ThrowsException()
        {
            //Arrange
            TestItem item = new TestItem { Name = "Test Item" };

            //Act
            Printer.Print(item, null);

            //Assert
        }

        [TestMethod]
        public void TelevisionGetsPrinted()
        {
            //Arrange
            Television television = new Television
            {
                Manufacturer = "Vizio",
                Size = "24"
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    //Act
                    Printer.Print(television, writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("Vizio - 24", lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        public void FoodGetsPrinted()
        {
            //Arrange
            Food food = new Food
            {
                Upc = "12344321",
                Brand = "Campbells"
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    //Act
                    Printer.Print(food, writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("12344321 - Campbells", lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTelevisionManufacturer_ThrowsException()
        {
            //Arrange
            Television television = new Television
            {
                Size = "48"
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    //Act
                    Printer.Print(television, writer);
                }
            }

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyTelevisionManufacturer_ThrowsException()
        {
            //Arrange
            Television television = new Television
            {
                Manufacturer = "",
                Size = "48"
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    //Act
                    Printer.Print(television, writer);
                }
            }

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTelevisionSize_ThrowsException()
        {
            //Arrange
            Television television = new Television
            {
                Manufacturer = "Vizio"
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    //Act
                    Printer.Print(television, writer);
                }
            }

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyTelevisionSize_ThrowsException()
        {
            //Arrange
            Television television = new Television
            {
                Manufacturer = "Vizio",
                Size = ""
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    //Act
                    Printer.Print(television, writer);
                }
            }

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullFoodBrand_ThrowsException()
        {
            //Arrange
            Food food = new Food
            {
                Upc = "42318"
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    //Act
                    Printer.Print(food, writer);
                }
            }

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyFoodBrand_ThrowsException()
        {
            //Arrange
            Food food = new Food
            {
                Brand = "",
                Upc = "42318"
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    //Act
                    Printer.Print(food, writer);
                }
            }

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullFoodUpc_ThrowsException()
        {
            //Arrange
            Food food = new Food
            {
                Brand = "Oreos"
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    //Act
                    Printer.Print(food, writer);
                }
            }

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyFoodUpc_ThrowsException()
        {
            //Arrange
            Food food = new Food
            {
                Brand = "Oreos",
                Upc = ""
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    //Act
                    Printer.Print(food, writer);
                }
            }

            //Assert
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
