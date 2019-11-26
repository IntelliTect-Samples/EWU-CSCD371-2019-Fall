using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        // caching SUT so we don't need to constantly re-read csv by re-instantiating it
        private static SampleData Sut { get; } = new SampleData();

        private bool HasDuplicates(IEnumerable<string> items)
        {
            IEnumerable<string> duplicates =
                items.Where(item1 => items.Count(item2 => item1 == item2) > 1);

            return duplicates.Any();
        }

        private bool IsAscendingOrder(List<string> items)
        {
            bool hasDescendingElements = 
                items
                .Where((string state, int i) => i < items.Count - 1) // ignore last element which would cause index OoB
                .Select((string state, int i) => (state, items[i + 1])) // pair up elements sequentially
                .Select(((string First, string Second) pair) => // compare elements of pair to check ascending order
                        string.CompareOrdinal(pair.First, pair.Second) < 0
                ).Any(isAscending => !isAscending); // find any result that indicates descending order

            return !hasDescendingElements;
        }

        [TestMethod]
        public void UseDefaultCsvData_DiscardsCustomData_RevertsToDefaultData()
        {
            List<string> data = new List<string>()
                { "8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022" };
            Sut.CsvRows = data;

            Sut.UseDefaultCsvData();

            Assert.IsFalse(Enumerable.SequenceEqual(data, Sut.CsvRows));
        }

        [TestMethod]
        public void CsvRows_AcceptsCustomData_CsvRowsMatchesCustomData()
        {
            List<string> data = new List<string>()
                { "8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022" };

            Sut.CsvRows = data;
            IEnumerable<string> cache = Sut.CsvRows; // need to reset sut before asserting
            Sut.UseDefaultCsvData(); // reset cached SUT, so it doesn't affect future tests

            Assert.IsTrue(Enumerable.SequenceEqual(data, cache));
        }

        [TestMethod]
        public void CsvRows_GetsAllCSVData_ReturnsEachRowAsStringInCollection()
        {
            List<string> csvData = File.ReadAllLines("People.csv").ToList();
            string discard = csvData.First();
            List<string> clippedData = csvData.Skip(1).ToList();

            List<string> sutData = (List<string>) Sut.CsvRows;

            Assert.IsTrue(sutData.Count > 0, message: "Failed to read in more than 1 line.");
            Assert.AreNotEqual<string>(discard, sutData[0], message: "Failed to discard header row.");
            Assert.IsTrue(Enumerable.SequenceEqual(clippedData, sutData), message: "Not sequence equal.");
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsListOfUniqueStates_FiltersOutDuplicates()
        {
            List<string> data = new List<string>()
            {
                "8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022",
                "8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022"
            };
            Sut.CsvRows = data;

            IEnumerable<string> sutData = Sut.GetUniqueSortedListOfStatesGivenCsvRows();
            Sut.UseDefaultCsvData();

            bool hasDuplicates = HasDuplicates(sutData);

            Assert.IsFalse(hasDuplicates, message: "Duplicates found.");
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsSortedListOfStates_ListInAscendingOrder()
        {
            List<string> sutData = (List<string>) Sut.GetUniqueSortedListOfStatesGivenCsvRows();

            // linq verification without hardcoded list
            bool isAscending = IsAscendingOrder(sutData);

            Assert.IsTrue(isAscending, message: "Has elements that are in descending order");
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_HardcodedList_ReturnsSortedUniqueStates()
        {
            // use custom, hardcoded spokane based csv data
            Sut.CsvRows = new List<string>()
            {
                "8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022",
                "15,Phillida,Chastagnier,pchastagniere@reference.com,1 Rutledge Point,Spokane,WA,99021",
                "19,Fayette,Dougherty,fdoughertyi@stanford.edu,6487 Pepper Wood Court,Spokane,WA,99021"
            };
            IEnumerable<string> expected = new List<string>() { "WA" };

            IEnumerable<string> sutData = Sut.GetUniqueSortedListOfStatesGivenCsvRows();
            Sut.UseDefaultCsvData();

            Assert.IsTrue(Enumerable.SequenceEqual(expected, sutData), message: "List mismatch.");
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ItemsInStringAreUnique_DoesNotFindDuplicates()
        {
            string sutData = Sut.GetAggregateSortedListOfStatesUsingCsvRows();

            bool hasDuplicates = HasDuplicates(sutData.Split(','));

            Assert.IsFalse(hasDuplicates, message: "Duplicates found.");
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ItemsInStringAreSortedAscending_DoesNotFindItemsOutOfOrder()
        {
            string sutData = Sut.GetAggregateSortedListOfStatesUsingCsvRows();

            bool isAscending = IsAscendingOrder(sutData.Split(',').ToList());

            Assert.IsTrue(isAscending, message: "Has elements that are in descending order.");
        }

        [TestMethod]
        public void PeopleProperty_GivenMalformedData_FiltersOutMalformedEntries()
        {
            Sut.CsvRows = new List<string>()
            {
                "8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim PointSpokane,WA,99022",
                "15,Phillida,Chastagnier,1 Rutledge Point,Spokane,WA,99021",
            };
            IEnumerable<IPerson> people = Sut.People;
            Sut.UseDefaultCsvData();

            bool hasMalformedEntries = people.Any();

            Assert.IsFalse(hasMalformedEntries, message: "Contains malformed entries.");
        }

        [TestMethod]
        public void PeopleProperty_GivenWellFormedPartialData_ReturnsPartialInstantiation()
        {
            Sut.CsvRows = new List<string>() { "8,Joly,Scneider,,,Spokane,WA,99022" };
            Person sutperson = ((List<Person>) Sut.People)[0];
            Sut.UseDefaultCsvData();
            Person dataPerson = new Person()
            {
                FirstName = "Joly",
                LastName = "Scneider",
                Address = new Address()
                {
                    State = "WA",
                    City = "Spokane",
                    Zip = "99022"
                }
            };

            bool match = sutperson == dataPerson;

            Assert.IsTrue(match, message: "Doesn't match.");
        }

        [TestMethod]
        public void PeopleProperty_ConvertsCsvDataToPersonObjects_AllPersonObjectsHaveAddressObject()
        {
            IEnumerable<IPerson> people = Sut.People;

            bool missingAddressObjects = 
                people
                .Select(person => person.Address)
                .Any(address => address is null);

            Assert.IsFalse(missingAddressObjects, message: "Address object is missing.");
        }

        [TestMethod]
        public void PeopleProperty_ConvertsCsvDataToPersonObjects_AddressObjectIsPopulated()
        {
            List<string> data = new List<string>() { "8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022" };
            string[] dataSplit = data[0].Split(',');

            Sut.CsvRows = data;
            IAddress address = Sut.People.First().Address;
            Sut.UseDefaultCsvData();

            // I could have done a manual item-by-item comparison here, but I wanted give reflection a try
            IEnumerable<bool> Mismatches =
                // pair up address properties with raw data using csv enum, then check that they match
                from property in address.GetType().GetProperties()
                let value = (string) property.GetValue(address)!
                let index = (int) Enum.Parse(typeof(SampleData.CsvColumn), property.Name)
                select value == dataSplit[index]
                // now find any instances of mismatched data
                into match
                where !match
                select match;

            Assert.IsFalse(Mismatches.Any(), message: "Address object doesn't match raw data.");
        }

        [TestMethod]
        public void PeopleProperty_ConvertsCsvDataToPersonObjects_AllPeopleInCsvArePresentAsPersonObjects()
        {
            List<Person> people = (List<Person>) Sut.People;
            List<string[]> data = 
                Sut.CsvRows
                .Select(row => row.Split(','))
                .ToList();

            IEnumerable<string> dataNames =
                from row in data
                orderby
                    row[(int) SampleData.CsvColumn.State],
                    row[(int) SampleData.CsvColumn.City],
                    row[(int) SampleData.CsvColumn.Zip]
                let first = row[(int) SampleData.CsvColumn.FirstName]
                let last = row[(int) SampleData.CsvColumn.LastName]
                select $"{first} {last}";

            IEnumerable<string> sutNames =
                people.Select(person => $"{person.FirstName} {person.LastName}");

            Assert.IsTrue(Enumerable.SequenceEqual(dataNames, sutNames), message: "Lists of names do not match.");
        }

        [TestMethod]
        public void PeopleProperty_ConvertsCsvDataToSortedPersonObjects_PersonObjectsAreSortedByAddress()
        {
            IEnumerable<IPerson> people = Sut.People;

            List<Address> addresses = 
                people
                .Select(person => (Address) person.Address)
                .ToList();

            bool outOfOrder = addresses
                .Where((Address address, int i) => i < addresses.Count - 1)
                .Select((Address address, int i) => (address, addresses[i + 1]))
                .Select(((Address First, Address Second) pair) => pair.First.CompareTo(pair.Second) <= 0)
                .Any(ascending => !ascending);

            Assert.IsFalse(outOfOrder, message: "Addresses not in ascending State-City-Zip order.");
        }

        [TestMethod]
        public void FilterByEmailAddress_FilterByEmailsContainingNumber_ReturnsExactlyAllNamesMatchingEmailCriteria()
        {
            IEnumerable<ValueTuple<string,string>> expected =
                from row in Sut.CsvRows
                select row.Split(',')
                into row
                let email = row[(int) SampleData.CsvColumn.EmailAddress]
                where Regex.IsMatch(email, "\\d+")
                orderby
                    row[(int) SampleData.CsvColumn.State],
                    row[(int) SampleData.CsvColumn.City],
                    row[(int) SampleData.CsvColumn.Zip]
                let first = row[(int) SampleData.CsvColumn.FirstName]
                let last = row[(int) SampleData.CsvColumn.LastName]
                select (first, last);

            IEnumerable<ValueTuple<string,string>> filtered = Sut.FilterByEmailAddress(email => Regex.IsMatch(email, "\\d+"));

            Assert.IsTrue(Enumerable.SequenceEqual(expected, filtered), message: "Filtered doesn't match expected.");
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollectionTest()
        {
            string expected = Sut.GetAggregateSortedListOfStatesUsingCsvRows();

            var states = Sut.GetAggregateListOfStatesGivenPeopleCollection(Sut.People);

            Assert.AreEqual<string>(expected, states, message: "Does not match expected.");
        }
    }
}
