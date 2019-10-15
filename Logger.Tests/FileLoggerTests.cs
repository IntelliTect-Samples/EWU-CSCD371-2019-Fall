using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
	[TestClass]
	public class FileLoggerTests
	{
		public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();


		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Error_WithNullPath_ThrowsException()
		{
            //Arrange

            //Act
			FileLogger logger = new FileLogger(null);

            //Assert
		}

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithEmptyPath_ThrowsException()
        {
            //Arrange

            //Act
            FileLogger logger = new FileLogger("");

            //Assert
        }

		[TestMethod]
		public void PathDoesNotExist()
		{
            //Arrange

            //Act
            FileLogger logger = new FileLogger("ThisDoesNotExist.txt");

            //Assert
			Assert.IsTrue(File.Exists("ThisDoesNotExist.txt"));
		}
	}
}
