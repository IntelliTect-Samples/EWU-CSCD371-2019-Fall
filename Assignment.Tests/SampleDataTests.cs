using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows_MockCsv_ReturnsCorrectNumberOfLines()
        {
            //Arrange
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "\\MockPeople.csv");
            //Act
            //Assert
            Assert.AreEqual<int>(3, sampleData.CsvRows.Count());
        }

        [TestMethod]
        public void CsvRows_MockCsv_ReturnsCorrectContents()
        {
            //Arrange
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeople.csv");
            string[] expectedData = File.ReadAllLines(Environment.CurrentDirectory + "//MockPeople.csv").Skip(1).ToArray();
            string[] actualData = sampleData.CsvRows.ToArray();
            //Act
            bool ContentsMatch = Enumerable.SequenceEqual<string>(expectedData, actualData);
            //Assert
            Assert.IsTrue(ContentsMatch);
        }
    }
}