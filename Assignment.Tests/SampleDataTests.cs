using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {

        // caching SUT so we don't need to constantly re-read csv by re-instantiating it
        private static ISampleData Sut { get; } = new SampleData();

        private bool HasDuplicates(IEnumerable<string> items)
        {
            return items
                .Where(item1 => items.Count(item2 => item1 == item2) > 1)
                .ToList()
                .Any();
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
            // linq verification without hardcoded list
            IEnumerable<string> sutData = Sut.GetUniqueSortedListOfStatesGivenCsvRows();

            bool hasDuplicates = HasDuplicates(sutData);

            Assert.IsFalse(hasDuplicates, message: "Duplicates found.");
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsSortedListOfStates_ListInAscendingOrder()
        {
            List<string> sutData = (List<string>)Sut.GetUniqueSortedListOfStatesGivenCsvRows();

            bool hasDescending = sutData
                .Where((string state, int i) => i < sutData.Count - 1) // ignore last element which would cause index OoB
                .Select((string state, int i) => (state, sutData[i + 1])) // pair up elements sequentially
                .Select(((string First, string Second) pair) => // compare elements of pair to check ascending order
                        string.CompareOrdinal(pair.First, pair.Second) < 0
                ).Any(isAscending => isAscending == false); // find any result that indicates descending order

            Assert.IsFalse(hasDescending, message: "Has elements that are in descending order");
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_HardcodedList_ReturnsSortedUniqueStates()
        {
            // use custom, hardcoded csv data
            ((SampleData) Sut).CsvRows = new List<string>()
            {
                "8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022",
                "15,Phillida,Chastagnier,pchastagniere@reference.com,1 Rutledge Point,Spokane,WA,99021",
                "19,Fayette,Dougherty,fdoughertyi@stanford.edu,6487 Pepper Wood Court,Spokane,WA,99021"
            };
            IEnumerable<string> expected = new List<string>() { "WA" };

            IEnumerable<string> sutData = Sut.GetUniqueSortedListOfStatesGivenCsvRows();
            ((SampleData)Sut).UseDefaultCsvData(); // reset cached SUT, so it doesn't affect future tests

            Assert.IsTrue(Enumerable.SequenceEqual(expected, sutData));
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsFormattedString_StringContainsUniqueCommaSeparatedStates()
        {
            string sutData = Sut.GetAggregateSortedListOfStatesUsingCsvRows();

            bool hasDuplicates = HasDuplicates(sutData.Split(','));

            Assert.IsFalse(hasDuplicates, message: "Duplicates found.");
        }

        [TestMethod]
        public void FilterByEmailAddressTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollectionTest()
        {
            Assert.Inconclusive();
        }
    }
}
