using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullActor_ThrowsException()
        {
            // Arrange

            // Act
            ActorExtension.Speak(null, null);
            
            // Assert
        }

        [TestMethod]
        public void Penny_Speak()
        {
            // Arrange
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    // Act
                    Actor penny = new Penny();
                    penny.Speak(writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("Hello, my name is Penny", lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        public void Sheldon_Speak()
        {
            // Arrange
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    // Act
                    Actor sheldon = new Sheldon();
                    sheldon.Speak(writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("Hello, my name is Sheldon", lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        public void Raj_Speak_No_Women()
        {
            // Arrange
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    // Act
                    Actor raj = new Raj(false);
                    raj.Speak(writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("Hello, my name is Raj", lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        public void Raj_Speak_Women_Present()
        {
            // Arrange
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    // Act
                    Actor raj = new Raj(true);
                    raj.Speak(writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("mumble", lineWritten);
                    }
                }
            }
        }
    }
}
