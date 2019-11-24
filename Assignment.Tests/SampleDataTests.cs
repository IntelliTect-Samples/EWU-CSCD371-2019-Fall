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
        [TestMethod]
        public void CsvRows_HasProperCount()
        {
            var sut = new SampleData();

            IEnumerable<string> query = sut.CsvRows;

            Assert.AreEqual<int>(File.ReadAllLines("People.csv").Length - 1, query.Count());
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsSortedList()
        {
            var sut = new SampleData();

            IEnumerable<string> query = sut.GetUniqueSortedListOfStatesGivenCsvRows();

            Assert.IsTrue(query.Zip(query.Skip(1), (first, second) => first.CompareTo(second) < 0).All(state => state));
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsCommaSeperatedStatesAsString()
        {
            var sut = new SampleData();
            var expectedResult = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";

            var result = sut.GetAggregateSortedListOfStatesUsingCsvRows();

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void People_ReturnsIEnumerableOfPersons()
        {
            var sut = new SampleData();
            Address testAddress = new Address
            {
                StreetAddress = "4718 Thackeray Pass",
                City = "Mobile",
                State = "AL",
                Zip = "37308"
            };

            Person testPerson = new Person
            {
                FirstName = "Arthur",
                LastName = "Myles",
                EmailAddress = "amyles1c@miibeian.gov.cn",
                Address = testAddress
            };

            IEnumerable<IPerson> people = sut.People;

            Assert.AreEqual(testPerson.FirstName, people.First().FirstName);
        }

        [TestMethod]
        public void FilterByEmailAddress_ReturnsFirstAndLastNameOfPersonWithEmail()
        {
            var sut = new SampleData();
            var testEmail = "kbutteryn@woothemes.com";

            var result = sut.FilterByEmailAddress(email => email == testEmail);

            Assert.IsTrue(result.Contains(("Karel", "Buttery")));
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_ReturnsCommaSeperatedStatesAsString()
        {
            var sut = new SampleData();
            IEnumerable<IPerson> people = sut.People;
            var expected = sut.GetAggregateSortedListOfStatesUsingCsvRows();

            var result = sut.GetAggregateListOfStatesGivenPeopleCollection(people);

            Assert.AreEqual(expected, result);
        }
    }
}
