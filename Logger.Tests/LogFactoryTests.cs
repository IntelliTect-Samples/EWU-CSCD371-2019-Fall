using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void LogFactory_CreateLogger_ClassNamePropogates()
        {
            string className = nameof(LogFactoryTests);
            string logFile = $"{nameof(LogFactoryTests)}.log";
            string testMessage = "abcdefghijklmnopqrstuvwxyz";
            LogFactory factory = new LogFactory();
            factory.ConfigureFileLogger(logFile);

            try
            {
                BaseLogger? logger = factory.CreateLogger(className);

                Assert.IsNotNull(logger);
#pragma warning disable CS8602
                logger.Log(LogLevel.Error, testMessage);
#pragma warning restore CS8602

                string[] logResults = File.ReadAllLines(logFile);

                Assert.AreEqual(1, logResults.Length);
                Assert.IsTrue(logResults[0].Contains(className));
            }
            finally
            {
                File.Delete(logFile);
            }

        }

        [TestMethod]
        public void LogFactory_CreateLogger_NullFileLogger()
        {
            string className = nameof(LogFactoryTests);
            string? logFile = null;
            LogFactory factory = new LogFactory();
#nullable disable
            factory.ConfigureFileLogger(logFile);
#nullable enable

            BaseLogger? logger = factory.CreateLogger(className);

            Assert.IsNull(logger);
        }
    }
}
