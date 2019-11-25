using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Tests
{
    [TestClass()]
    public class SampleDataTests
    {
        [TestMethod()]
        public void CsvRowsNotEmpty()
        {
            //Arrange
            SampleData sampleData = new SampleData("People.csv");
            IEnumerable<string> result = sampleData.CsvRows;
            List<string> list = new List<string>();

            //Act
            foreach (string item in result)
            {
                Console.WriteLine(item);
                list.Add(item);
            }

            //Assert
            Assert.IsTrue(list.Count != 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CsvRowsEmptyFileNameThrowsException()
        {
            //Arrange
            SampleData sampleData = new SampleData("");
            IEnumerable<string> result = sampleData.CsvRows;
            List<string> list = new List<string>();

            //Act
            foreach (string item in result)
            {
                list.Add(item);
            }

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CsvRowsNullFileNameThrowsException()
        {
            //Arrange
            SampleData sampleData = new SampleData(null);
            IEnumerable<string> result = sampleData.CsvRows;
            List<string> list = new List<string>();

            //Act
            foreach (string item in result)
            {
                list.Add(item);
            }

            //Assert
        }

        [TestMethod]
        public void UniqueSortedListOfStates()
        {
            SampleData sampleData = new SampleData("People.csv");
            List<string> list = new List<string>();

            //Act
            IEnumerable<string> result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            foreach (string item in result)
            {
                list.Add(item);
            }

            //Assert
            for (int ix = 0; ix < list.Count - 1; ix++)
            {
                Assert.IsTrue(list[ix].CompareTo(list[ix + 1]) == -1);
            }
        }

        [TestMethod]
        public void GetAggregateSortedListOfStates()
        {
            //Arrange
            SampleData sampleData = new SampleData("People.csv");

            //Act
            string result = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            //Assert
            string[] list = result.Split(',');
            for (int ix = 0; ix < list.Length - 1; ix++)
            {
                Assert.IsTrue(list[ix].CompareTo(list[ix + 1]) != 1);
            }
        }

        [TestMethod]
        public void PeopleNotNull()
        {
            //Arrange
            SampleData sampleData = new SampleData("People.csv");
            
            //Act
            
            //Assert
            foreach (Person person in sampleData.People)
            {
                Assert.IsNotNull(person);
                Assert.IsNotNull(person.Address.City);
                Assert.IsNotNull(person.Address.State);
                Assert.IsNotNull(person.Address.StreetAddress);
                Assert.IsNotNull(person.Email);
                Assert.IsNotNull(person.FirstName);
                Assert.IsNotNull(person.LastName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterByEmailNullInputThrowsException()
        {
            //Arrange
            SampleData sampleData = new SampleData("People.csv");

            //Act
            sampleData.FilterByEmailAddress(null);

            //Assert
        }

        [TestMethod]
        public void FilterByEmailValidInput()
        {
            //Arrange
            SampleData sampleData = new SampleData("People.csv");

            //Act
            IEnumerable<(string FirstName, string LastName)> result = sampleData.FilterByEmailAddress(email => email.EndsWith(".edu"));

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeople()
        {
            //Arrange
            SampleData sampleData = new SampleData("People.csv");

            //Act
            string result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);

            //Assert
            foreach (Person person in sampleData.People)
            {
                Assert.IsTrue(result.Contains(person.Address.State));
            }
        }
    }
}