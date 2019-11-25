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
            Assert.AreEqual<int>(sampleData.CsvRows.Count(), sampleData.CsvRows.Count());
        }

        [TestMethod]
        public void CsvRows_MockCsv_ReturnsCorrectContents()
        {
            //Arrange
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeople.csv");
            string[] expectedData = File.ReadAllLines(Environment.CurrentDirectory + "//MockPeople.csv").Skip(1).ToArray();
            string[] actualData = sampleData.CsvRows.ToArray();
            //Act
            bool contentsMatch = Enumerable.SequenceEqual<string>(expectedData, actualData);
            //Assert
            Assert.IsTrue(contentsMatch);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_MockCsv_ReturnsCorrectContents()
        {
            //Arrange
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeople.csv");
            string[] expectedData = { "CA", "FL", "MT" };
            //Act
            string[] actualData = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
            bool contentsMatch = Enumerable.SequenceEqual<string>(expectedData, actualData);
            //Assert
            Assert.IsTrue(contentsMatch);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_SpokaneAddresses_ReturnsCorrectContents()
        {
            //Arrange
            string[] SpokanePeople = {
                "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202",
                "2,Eugene,Krabs,moneymoneymoney@gmail.com,765 Calico Drive,Spokane,WA,99201",
                "3,Squidward,Tentacles,clarinetking@gmail.com,2500 Mudlick Road,Spokane,WA,99201"
            };
            SampleData sampleData = new SampleData(SpokanePeople);
            string[] expectedData = { "WA" };
            //Act
            string[] actualData = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
            bool contentsMatch = Enumerable.SequenceEqual<string>(expectedData, actualData);
            //Assert
            Assert.IsTrue(contentsMatch);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_NoHardCodedList_ReturnsCorrectContents()
        {
            //Arrange
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeople.csv");
            //Act
            string[] actualData = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
            bool isSorted = Enumerable.SequenceEqual(actualData, actualData.OrderBy(state => state));
            //Assert
            Assert.IsTrue(isSorted);
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_MockCsv_ReturnsCorrectContents()
        {
            //Arrange
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeople.csv");
            string expectedData = "CA,FL,MT";
            //Act
            string actualData = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            //Assert
            Assert.AreEqual<string>(expectedData, actualData);
        }

        [TestMethod]
        public void People_MockCsv_ReturnsCorrectNumberOfPeople()
        {
            //Arrange
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeople.csv");
            //Act
            int numberOfPeople = sampleData.People.Count();
            //Assert
            Assert.AreEqual<int>(sampleData.CsvRows.Count(), numberOfPeople);
        }

        [TestMethod]
        public void People_MockCsv_ReturnsCorrectPeople()
        {
            //Arrange
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeople.csv");
            Person[] expectedPeople = sampleData.CsvRows.Select(csvRow => new Person(csvRow)).ToArray();
            IPerson[] actualPeople = sampleData.People.ToArray();
            //Act
            bool hasAllPeople = true;
            foreach (Person person in expectedPeople)
            {
                if (hasAllPeople)
                    hasAllPeople = actualPeople.Contains(person);
            }
            //Assert
            Assert.IsTrue(hasAllPeople);
        }

        [TestMethod]
        public void People_MockCsv_PeopleAreSorted()
        {
            //Arrange
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeople.csv");
            string expectedNames = "Chadd,Joe,Henri,Karin,Priscilla";
            IPerson[] people = sampleData.People.ToArray();
            string actualNames = people.Select(person => person.FirstName).Aggregate((personOne, personTwo) => personOne + "," + personTwo);
            //Act
            bool isOrdered = expectedNames.Equals(actualNames);
            //Assert
            Assert.IsTrue(isOrdered);
        }
    }
}