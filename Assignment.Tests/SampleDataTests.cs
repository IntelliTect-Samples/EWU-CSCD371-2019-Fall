using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests
{

    [TestClass]
    public class SampleDataTests
    {

        private static readonly SampleData _SampleData = new SampleData();
        private static readonly SampleData _TestData   = new SampleData {Path = "TestPeople.csv"};

        [TestMethod]
        public void GetUniqueSortedListOfStates_Hardcoded_ReturnsCorrectlySortedList()
        {
            // Not sure what this hardcoded test of Spokane addresses is supposed to do...?
        }

        [TestMethod]
        public void GetUniqueSortedListOfStates_Linq_ReturnsCorrectlySortedList()
        {
            var states     = _SampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            var enumerable = states as string[] ?? states.ToArray();

            Assert.IsTrue(
                enumerable.Zip(enumerable.Skip(1), (a, b) => string.Compare(a, b, StringComparison.Ordinal) < 0)
                          .All(state => state));
        }

        [TestMethod]
        public void GetAggregateListOfStatesFromCsv_ReturnsCorrectListOfDistinctStates()
        {
            var states = _TestData.GetAggregateSortedListOfStatesUsingCsvRows().Split(",");
            Assert.IsTrue(states.Length == 3);
            Assert.IsTrue(states[0] == "MI");
            Assert.IsTrue(states[1] == "WA");
            Assert.IsTrue(states[2] == "WI");
        }

        [TestMethod]
        public void People_ReturnsCorrectlySortedListOfPeople()
        {
            var people = _TestData.People;

            var expected = new[] {"G", "I", "A", "K", "E", "C"};
            var given    = people.Select(person => person.FirstName).ToArray();

            Assert.IsTrue(expected[0] == given[0]);
            Assert.IsTrue(expected[2] == given[2]);
            Assert.IsTrue(expected[3] == given[3]);
            Assert.IsTrue(expected[5] == given[5]);
        }

        [TestMethod]
        public void People_FilterByEmail_ReturnsCorrectlyFilteredList()
        {
            var people = _TestData.FilterByEmailAddress(email => email.EndsWith(".com"));

            var given = people.Select(person => person.FirstName).ToArray();
            Assert.IsTrue(given.Length == 2);
            Assert.IsTrue(given[0] == "A");
            Assert.IsTrue(given[1] == "C");
        }

        [TestMethod]
        public void GetAggregateListOfStatesFromPeople_ReturnsCorrectDistinctListOfStates()
        {
            var people = _TestData.People.Where(person => person.EmailAddress.EndsWith(".com"));
            var states = _TestData.GetAggregateListOfStatesGivenPeopleCollection(people).Split(",");
            Assert.IsTrue(states.Length == 2);
            Assert.IsTrue(states[0] == "WA");
            Assert.IsTrue(states[1] == "WI");
        }

    }

}
