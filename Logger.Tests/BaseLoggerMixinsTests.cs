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
