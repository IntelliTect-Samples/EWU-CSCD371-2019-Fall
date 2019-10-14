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
            // Arrange

            // Act
            BaseLoggerMixins.Error(null, "");

            // Assert
        }

        [TestMethod]
        public void Error_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Error("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Success_AllExtensionMethods()
        {
            //Arrange
            var errorLogger = new TestLogger();
            var warningLogger = new TestLogger();
            var informationLogger = new TestLogger();
            var debugLogger = new TestLogger();

            //Act
            errorLogger.Error("Message {0}", 1);
            warningLogger.Warning("Message {0}", 2);
            informationLogger.Information("Message {0}", 3);
            debugLogger.Debug("Message {0}", 4);

            //Assert
            Assert.AreEqual(LogLevel.Error, errorLogger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 1", errorLogger.LoggedMessages[0].Message);

            Assert.AreEqual(LogLevel.Warning, warningLogger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 2", warningLogger.LoggedMessages[0].Message);

            Assert.AreEqual(LogLevel.Information, informationLogger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 3", informationLogger.LoggedMessages[0].Message);

            Assert.AreEqual(LogLevel.Debug, debugLogger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 4", debugLogger.LoggedMessages[0].Message);
        }

    }

    public class TestLogger : BaseLogger
    {
        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }

        public override string ClassName{get;set;}
    }
}
