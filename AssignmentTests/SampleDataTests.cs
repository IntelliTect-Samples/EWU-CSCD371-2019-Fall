using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AssignmentTests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void SampleData_CsvRows_ReturnsListFirstLineSkipped()
        {
            // Arrange
            SampleData data = new SampleData();
            int lineCount = File.ReadAllLines("People.csv").Count();

            // Act


            // Assert
            Assert.AreEqual(data.CsvRows.Count(), lineCount - 1);
        }

        [TestMethod]
        public void SampleData_GetUniqueSortedListOfStatesGivenCsvRows_ReturnsSortedUniqueStates()
        {
            // Arrange
            SampleData data = new SampleData();
            IEnumerable<string> actualStates = data.GetUniqueSortedListOfStatesGivenCsvRows();
            List<string> lines = data.CsvRows.ToList();
            List<string> distinctStates = new List<string>();

            // Act
            foreach (string line in lines)
            {
                string state = line.Split(",")[(int)PersonInfo.State];
                if (!(distinctStates.Contains(state)))
                {
                    distinctStates.Add(state);
                }
            }

            // Assert
            Assert.AreEqual(actualStates.Count(), distinctStates.Count());
            // Checks if sorted using Linq
            Assert.IsTrue(actualStates.SequenceEqual(actualStates.OrderBy(x => x)));

        }

        [TestMethod]
        public void SampleData_GetUniqueSortedListOfStatesGivenCsvRows_ReturnsSortedUniqueStatesOfSpokaneAddresses()
        {
            // Arrange
            string path = Path.GetFullPath("TestPeople.csv");
            SampleData data = new SampleData(path);
            IEnumerable<string> actualStates = data.GetUniqueSortedListOfStatesGivenCsvRows();
            List<string> lines = data.CsvRows.ToList();
            List<string> spokaneAddresses = new List<string>();

            // Act
            foreach (string line in lines)
            {
                string state = line.Split(",")[(int)PersonInfo.State];
                if (!(spokaneAddresses.Contains(state)))
                {
                    spokaneAddresses.Add(state);
                }
            }

            // Assert
            Assert.AreEqual(actualStates.Count(), spokaneAddresses.Count());
        }

        [TestMethod]
        public void SampleData_GetAggregateSortedListOfStatesUsingCsvRows_ReturnsSortedStringOfStates()
        {
            // Arrange
            SampleData data = new SampleData();
            IEnumerable<string> orderedStates = data.GetUniqueSortedListOfStatesGivenCsvRows();
            string expected = string.Join(", ", orderedStates);

            // Act
            string actual = data.GetAggregateSortedListOfStatesUsingCsvRows();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
