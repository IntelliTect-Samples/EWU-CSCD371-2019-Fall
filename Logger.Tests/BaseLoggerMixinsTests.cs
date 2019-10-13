using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {

        [DataTestMethod]
        [DataRow("Message {0}", 12)]
        [DataRow("Message {0}", "12")]
        public void Debug_WithData_LogsMessage(string message, object messageContent)
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Debug(message, messageContent);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 12", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Debug_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Debug(null, "");

            // Assert
        }

        [DataTestMethod]
        [DataRow("Message {0}", 22)]
        [DataRow("Message {0}", "22")]
        public void Error_WithData_LogsMessage(string message, object messageContent)
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Error(message, messageContent);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 22", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Error(null, "");

            // Assert
        }


        [DataTestMethod]
        [DataRow("Message {0}", 32)]
        [DataRow("Message {0}", "32")]
        public void Information_WithData_LogsMessage(string message, object messageContent)
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Information(message, messageContent);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 32", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Information_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Information(null, "32");

            // Assert
        }

        [DataTestMethod]
        [DataRow("Message {0}", 42)]
        [DataRow("Message {0}", "42")]
        public void Warning_WithData_LogsMessage(string message, object messageContent)
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Warning("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Warning_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Warning(null, "42");

            // Assert
        }
    }

    public class TestLogger : BaseLogger
    {
        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }
    }
}
