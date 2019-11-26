﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System;
using System.Text.RegularExpressions;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows_MockCsv_ReturnsCorrectNumberOfLines()
        {
            //Arrange
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "\\MockPeopleShortList.csv");
            //Act
            //Assert
            Assert.AreEqual<int>(sampleData.CsvRows.Count(), sampleData.CsvRows.Count());
        }

        [TestMethod]
        public void CsvRows_MockCsv_ReturnsCorrectContents()
        {
            //Arrange
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeopleShortList.csv");
            string[] expectedData = File.ReadAllLines(Environment.CurrentDirectory + "//MockPeopleShortList.csv").Skip(1).ToArray();
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
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeopleShortList.csv");
            string[] expectedData = { "CA", "FL", "MT" };
            //Act
            string[] actualData = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
            bool contentsMatch = Enumerable.SequenceEqual<string>(expectedData, actualData);
            //Assert
            Assert.IsTrue(contentsMatch);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_SpokaneAddresses_ReturnsRightState()
        {
            //Arrange
            string[] SpokanePeople = {
                "1,Indigo,Montoya,youkilledmyfather@gmail.com,1391 Brute Squad Road,Spokane,WA,99202",
                "2,Eugene,Stoner,ratatat@gmail.com,765 Full Auto Drive,Spokane,WA,99201",
                "3,Edward,Scissorhands,snipysnipsnip@gmail.com,2500 Haircut Road,Spokane,WA,99201"
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
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeopleShortList.csv");
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
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeopleShortList.csv");
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
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeopleShortList.csv");
            //Act
            int numberOfPeople = sampleData.People.Count();
            //Assert
            Assert.AreEqual<int>(sampleData.CsvRows.Count(), numberOfPeople);
        }

        [TestMethod]
        public void People_MockCsv_ReturnsCorrectPeople()
        {
            //Arrange
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeopleShortList.csv");
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
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeopleShortList.csv");
            string expectedNames = "Chadd,Joe,Henri,Karin,Priscilla";
            IPerson[] people = sampleData.People.ToArray();
            string actualNames = people.Select(person => person.FirstName)
                .Aggregate((personOne, personTwo) => personOne + "," + personTwo);
            //Act
            bool isOrdered = expectedNames.Equals(actualNames);
            //Assert
            Assert.IsTrue(isOrdered);
        }

        [TestMethod]
        public void FilterByEmailAddress_FilterByWebsite_ReturnsCorrectPeople()
        {
            //Arrange
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeopleShortList.csv");
            (string firstName, string lastName)[] expectedNames = { ("Chadd", "Stennine"), ("Joe", "Smith") };
            (string firstName, string lastName)[] actualNames = sampleData.FilterByEmailAddress(email => email.Contains("wired.com")).ToArray();
            //Act
            bool namesAreCorrect = Enumerable.SequenceEqual(expectedNames, actualNames);
            //Assert
            Assert.IsTrue(namesAreCorrect);
        }

        [TestMethod]
        public void FilterByEmailAddress_FilterByEntireAddress_ReturnsCorrectPerson()
        {
            //Arrange
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeopleShortList.csv");
            (string firstName, string lastName)[] expectedName = { ("Joe", "Smith") };
            (string firstName, string lastName)[] actualName = sampleData.FilterByEmailAddress(email => email.Equals("jsmith@wired.com")).ToArray();
            //Act
            bool namesIsCorrect = Enumerable.SequenceEqual(expectedName, actualName);
            //Assert
            Assert.IsTrue(namesIsCorrect);
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_MockCsv_ReturnsCorrectStates()
        {
            //Arrange
            SampleData sampleData = new SampleData(Environment.CurrentDirectory + "//MockPeopleShortList.csv");
            string expectedStates = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().Aggregate((stateOne, stateTwo) => stateOne + "," + stateTwo);
            //Act
            string actualStates = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);
            bool statesAreCorrect = expectedStates.Equals(actualStates);
            //Assert
            Assert.IsTrue(statesAreCorrect);
        }
    }
}
