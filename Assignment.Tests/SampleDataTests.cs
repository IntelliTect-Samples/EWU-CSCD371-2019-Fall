using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {

        public TestContext? TestContext { get; set; }

        [TestMethod]
        [DataRow(@".\People.csv")]
        public void SampleData_CsvRows_ReturnsCollection(string fileName)
        {
            //Organize
            SampleData sampleData = new SampleData();
            IEnumerable<string> testList = new List<String>();

            //Act
            IEnumerable<string> result = sampleData.CsvRows;

            using (var fileReader = new StreamReader(fileName))
            {
                for(string? s = fileReader.ReadLine(); !fileReader.EndOfStream; s = fileReader.ReadLine())
                {
                    ((List<string>)testList).Add(s!);
                }
            }

            testList = testList.Skip<string>(1);

            //Assert
            CollectionAssert.AreEqual(testList.ToList<string>(), result.ToList<string>());
        }

        [TestMethod]
        public void SampleData_CsvRows_SkipsFirstLine()
        {
            //Organize
            SampleData sampleData = new SampleData();

            //Act
            IEnumerable<string> result = sampleData.CsvRows;

            //Assert
            Assert.AreNotEqual("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip", result.First<string>());
        }

        [TestMethod]
        public void SampleData_GetUniqueSortedListOfStatesGivenCsvRows_ReturnsSortedList()
        {
            //Organize
            SampleData sampleData = new SampleData();
            IEnumerable<IPerson> expected = sampleData.People;

            //Act
            IEnumerable<string> result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();


            IEnumerable<string> expectedStatesList = expected.Select(item => item.Address.State).Distinct<string>().OrderBy(s => s);

            expectedStatesList.All<string>(s =>
            {
                TestContext?.WriteLine(s);
                return true;
            });

            //Assert
            CollectionAssert.AreEqual(expectedStatesList.ToList(), result.ToList());
        }

        [TestMethod]
        public void SampleData_CreatePerson_ReturnsPerson()
        {
            //Organize
            SampleData sampleData = new SampleData();

            //Act
            IEnumerable<string> personCsv = sampleData.CsvRows;
            string personData = personCsv.First<string>();
            Person p = sampleData.CreatePerson(personData);

            //Assert
            Assert.IsTrue(p is Person);
        }

        [TestMethod]
        public void SampleData_CreatePerson_FillsPersonFields()
        {
            //Organize
            SampleData sampleData = new SampleData();

            //Act
            IEnumerable<string> personCsv = sampleData.CsvRows;
            string personData = personCsv.First<string>();

            Person p = sampleData.CreatePerson(personData);
            Person expected = new Person
            {
                FirstName = personData.Split(",")[1]
            };

            TestContext?.WriteLine(expected.FirstName);

            //Assert
            Assert.ReferenceEquals(expected, p);
        }

        [TestMethod]
        public void SampleData_People_ReturnsIEnumerable_OfPeople()
        {
            //Organize
            SampleData sampleData = new SampleData();
            IEnumerable<string> testPeople = sampleData.CsvRows;

            //Act
            IEnumerable<IPerson> expectedPersonCollection = testPeople.Select(item =>
            {
                return sampleData.CreatePerson(item);
            });

            //Assert
            Assert.ReferenceEquals(expectedPersonCollection, sampleData.People);
        }

        [TestMethod]
        public void SampleData_GetAggregateSortedListOfStatesUsingCsvRows_ReturnsArrayOfStates()
        {
            //Organize
            SampleData sample = new SampleData();
            IEnumerable<string> stateCollection = sample.GetUniqueSortedListOfStatesGivenCsvRows();

            //Act
            string[] expectedStringArray = stateCollection.ToArray<string>();
            string expectedString = String.Join(", ", expectedStringArray);

            string stateString = sample.GetAggregateSortedListOfStatesUsingCsvRows();

            //Assert
            Assert.AreEqual(expectedString, stateString);
        }

        [TestMethod]
        public void SampleData_FilterByEmailAddress_ReturnsFilteredList()
        {
            //Organize
            SampleData sampleData = new SampleData();
            IEnumerable<IPerson> expected = sampleData.People;

            //Act
            expected = expected.Where(item => item.EmailAddress.Equals("smahonyg@stanford.edu"));
            IEnumerable<(string FirstName, string LastName)> expectedTuple = expected.Select(item => (item.FirstName, item.LastName));

            IEnumerable<(string FirstName, string LastName)> filteredList = sampleData.FilterByEmailAddress(item => item.Equals("smahonyg@stanford.edu"));

            //Assert
            CollectionAssert.AreEqual(expectedTuple.ToList(), filteredList.ToList());
        }

        [TestMethod]
        public void SampleData_GetAggregateListOfStatesGivenPeopleCollection_ReturnsStateString()
        {
            //Organize
            SampleData sampleData = new SampleData();

            //Act
            string expected =  sampleData.People.Select(item => item.Address.State).Distinct().Aggregate((result, next) => result + ", " + next);
            string statesList = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);

            TestContext?.WriteLine(expected);

            //Assert
            Assert.AreEqual(expected, statesList);
        }
    }
}
