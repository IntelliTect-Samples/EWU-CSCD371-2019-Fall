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
        [ExpectedException(typeof(ArgumentNullException))]
        public void SampleData_UsingNullFilePath_ThrowsException()
        {
            var sut = new SampleData(null!);
        }

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
        public void GetUniqueSortedListOfStatesGivenCsvRows_UsingHardCodedAddresses_ReturnsWA()
        {
            string filepath = Path.GetFullPath("TestFile.txt");
            var sut = new SampleData(filepath);

            try
            {
                var addresses = new List<string>()
                {
                    "1,First1,Last1,email1,street address1,Spokane,WA,99201",
                    "2,First2,Last2,email2,street address2,Spokane,WA,99201",
                    "3,First3,Last3,email3,street address3,Spokane,WA,99201"
                };

                File.AppendAllLines(filepath, addresses);

                IEnumerable<string> query = sut.GetUniqueSortedListOfStatesGivenCsvRows();
                
                Assert.AreEqual<int>(1, query.Count());
                Assert.IsTrue(query.Contains("WA"));
            }
            finally
            {
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
            }
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

            Assert.AreEqual<int>(50, people.Count());
            Assert.AreEqual((testPerson.FirstName, testPerson.LastName), (people.First().FirstName, people.First().LastName));
            Assert.AreEqual((testPerson.Address.State, testPerson.Address.StreetAddress), (people.First().Address.State, people.First().Address.StreetAddress));
        }

        [TestMethod]
        public void FilterByEmailAddress_ReturnsFirstAndLastNameOfPersonWithEmail()
        {
            var sut = new SampleData();
            var testEmail = "kbutteryn@woothemes.com";

            IEnumerable<(string FirstName, string LastName)> result = sut.FilterByEmailAddress(email => email == testEmail);

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
