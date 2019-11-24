using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        // caching SUT so we don't need to constantly re-read csv by re-instantiating it
        private ISampleData SUT { get; } = new SampleData();

        [TestMethod]
        public void CsvRows_GetsAllCSVData_ReturnsEachRowAsStringInCollection()
        {
            List<string> csvData = File.ReadAllLines("People.csv").ToList();
            string discard = csvData.First();
            List<string> clippedData = csvData.Skip(1).ToList();

            List<string> sutData = (List<string>) SUT.CsvRows;

            Assert.IsTrue(sutData.Count > 0, message: "Failed to read in more than 1 line.");
            Assert.AreNotEqual<string>(discard, sutData[0], message: "Failed to discard header row.");
            Assert.IsTrue(Enumerable.SequenceEqual(clippedData, sutData), message: "Not sequence equal.");
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRowsTest_ReturnsListOfUniqueStates_FiltersOutDuplicates()
        {
            IEnumerable<string> sutData = SUT.GetUniqueSortedListOfStatesGivenCsvRows();
            IEnumerable<string> unique = sutData.Distinct();

            Assert.IsTrue(Enumerable.SequenceEqual(unique, sutData), message: "Contains duplicates.");
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRowsTest_ReturnsSortedListOfStates_ListInAscendingOrder()
        {
            List<string> sutData = (List<string>) SUT.GetUniqueSortedListOfStatesGivenCsvRows();
            IEnumerable<string> sorted = new List<string>(sutData) // copy data
                .OrderBy(state => state).ToList();

            Assert.IsTrue(Enumerable.SequenceEqual(sorted, sutData), message: "Not Sorted.");
            Assert.IsTrue(string.CompareOrdinal(sutData[0], sutData[sutData.Count - 1]) < 0, message: "Not sorted ascending");
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRowsTest_HardcodedList_ReturnsSortedUniqueStates()
        {
            // use custom, hardcoded csv data
            ((SampleData) SUT).CsvData = new List<string>()
            {
                "8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022",
                "15,Phillida,Chastagnier,pchastagniere@reference.com,1 Rutledge Point,Spokane,WA,99021",
                "19,Fayette,Dougherty,fdoughertyi@stanford.edu,6487 Pepper Wood Court,Spokane,WA,99021"
            };

            IEnumerable<string> sutData = SUT.GetUniqueSortedListOfStatesGivenCsvRows();

            ((SampleData)SUT).UseDefaultCsvData(); // reset cached SUT, so it doesn't affect future tests

            Assert.IsTrue(Enumerable.SequenceEqual(new List<string>() { "WA" }, sutData));
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRowsTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void FilterByEmailAddressTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollectionTest()
        {
            Assert.Fail();
        }
    }
}
