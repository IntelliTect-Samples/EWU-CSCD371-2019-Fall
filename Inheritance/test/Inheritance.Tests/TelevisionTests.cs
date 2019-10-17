using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inheritance;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Inheritance.Tests
{
    [TestClass]
    public class TelevisionTests
    {
        [TestMethod]
        public void Televsion_PrintsCorrectly()
        {
            // Arrange
            var tv = new Television { Manufacturer = "Test", Size = "Big" };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    // Act
                    Printer.Print(tv, writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("<Test> - <Big>", lineWritten);
                    }
                }
            }
        }
    }
}