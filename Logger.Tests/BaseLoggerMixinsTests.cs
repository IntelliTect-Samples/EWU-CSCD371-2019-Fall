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
            BaseLoggerMixins.Error(null, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Warning_WithNullLogger_ThrowsException()
        {
            BaseLoggerMixins.Warning(null, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Information_WithNullLogger_ThrowsException()
        {
            BaseLoggerMixins.Information(null, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Debug_WithNullLogger_ThrowsException()
        {
            BaseLoggerMixins.Debug(null, "");
        }

        [TestMethod]
        public void Error_WithData_LogsMessage()
        {
            var logger = new TestLogger();
            logger.Error("Message {0}", 42);
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Warning_WithData_LogsMessage()
        {
            var logger = new TestLogger();
            logger.Warning("Message {0}", 42);
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Debug_WithData_LogsMessage()
        {
            var logger = new TestLogger();
            logger.Debug("Message {0}", 42);
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Information_WithData_LogsMessage()
        {
            var logger = new TestLogger();
            logger.Information("Message {0}", 42);
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [DataTestMethod]
        [DataRow("Message {0}", 42)]
        [DataRow("Message {0}", "42")]
        [DataRow("Message {0}", (float)42)]
        [DataRow("Message {0}", (double)42)]
        public void LogHelperMethods_WithDifferentDataTypes_Success(string message, object fmt)
        {
            var logger = new TestLogger();
            logger.Error(message, fmt);
            logger.Warning(message, fmt);
            logger.Information(message, fmt);
            logger.Debug(message, fmt);
            Assert.AreEqual(4, logger.LoggedMessages.Count);
            logger.LoggedMessages.ForEach(delegate((LogLevel LogLevel, string Message) log) {
                Assert.AreEqual("Message 42", log.Message);
            });
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
