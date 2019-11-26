using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        [ExpectedException(typeof(FileNotFoundException))]
        public void SampleDataConstructor_InvalidFileName_ThrowsException()
        {
            _ = new SampleData("InvalidFile.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SampleDataConstructor_NullFileName_ThrowsException()
        {
            _ = new SampleData(null!);
        }

        [TestMethod]
        public void CsvRows_UsingValidFile_ReturnsListFirstLineSkipped()
        {
            // Arrange
            SampleData data = new SampleData();
            int lineCount = File.ReadAllLines("People.csv").Skip(1).Count();

            // Act


            // Assert
            Assert.AreEqual(data.CsvRows.Count(), lineCount);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_GivenValidCsvRows_ReturnsSortedUniqueStates()
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
            Assert.AreEqual(actualStates.Count(), distinctStates.Count);
            // Checks if sorted using Linq
            Assert.IsTrue(actualStates.SequenceEqual(actualStates.OrderBy(x => x)));

        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_GivenValidListOfStates_ReturnsSortedUniqueStatesOfSpokaneAddresses()
        {
            // Arrange
            string path = Path.GetFullPath("TestPeopleSpokane.csv");
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
            Assert.AreEqual(actualStates.Count(), spokaneAddresses.Count);
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_GivenValidListOfOrderedStates_ReturnsSortedStringOfStates()
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

        [TestMethod]
        public void People_GivenValidCsvRows_ReturnsCorrectlySortedListOfPeople()
        {
            // Arrange
            string path = Path.GetFullPath("TestPeople.csv");
            SampleData data = new SampleData(path);
            IEnumerable<IPerson> sut = data.People;
            string[] expectedFirstNames = { "Luke", "John", "Ben", "Jackie", "John", "Jerett" };
            List<string> sutFirstNames = new List<string>();

            // Act
            foreach(IPerson p in sut)
            {
                sutFirstNames.Add(p.FirstName);
            }


            // Assert
            Assert.IsTrue(expectedFirstNames.SequenceEqual(sutFirstNames.ToArray()));
        }

        [TestMethod]
        public void FilterByEmailAddress_UsingTestPeople_ReturnsCorrectNames()
        {
            // Arrange
            string path = Path.GetFullPath("TestPeople.csv");
            SampleData data = new SampleData(path);
            IEnumerable<(string FirstName, string LastName)> sutNames = data.FilterByEmailAddress(email => email.Contains("gmail.com"));
            List <(string, string)> expectedNames = new List<(string, string)>();

            // Act
            expectedNames.Add(("John", "Ryan"));
            expectedNames.Add(("John", "Link"));
            expectedNames.Add(("Ben", "Smith"));
            expectedNames.Add(("Jerett", "Latimer"));
            expectedNames.Add(("Luke", "Mason"));

            // Assert
            CollectionAssert.Contains(sutNames.ToList(), expectedNames[0]);
            CollectionAssert.Contains(sutNames.ToList(), expectedNames[1]);
            CollectionAssert.Contains(sutNames.ToList(), expectedNames[2]);

        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_UsingTestPeople_ReturnsCorrectListOfStates()
        {
            // Arrange
            string path = Path.GetFullPath("TestPeople.csv");
            SampleData data = new SampleData(path);
            string states = data.GetAggregateListOfStatesGivenPeopleCollection(data.People);
            string expected = data.GetAggregateSortedListOfStatesUsingCsvRows();

            // Act


            // Assert
            Assert.AreEqual(states, expected);
        }
    }
}
