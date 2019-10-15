using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            BaseLoggerMixins.Error(null,"");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Debug_WithNullLogger_ThrowsException()
        {
            BaseLoggerMixins.Debug(null, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Information_WithNullLogger_ThrowsException()
        {
            BaseLoggerMixins.Information(null, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Warning_WithNullLogger_ThrowsException()
        {
            BaseLoggerMixins.Warning(null, "");
        }

        [TestMethod]
        public void Error_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Error("Message- Hello");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message- Hello", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Warning_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Warning("Message- Hello");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message- Hello", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Information_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Information("Message- Hello");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message- Hello", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Debig_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Debug("Message- Hello");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message- Hello", logger.LoggedMessages[0].Message);
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
