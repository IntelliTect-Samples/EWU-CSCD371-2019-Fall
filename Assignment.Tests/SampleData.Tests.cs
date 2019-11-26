using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        private enum Columns
        {
            Id, FirstName, LastName, Email, StreetAddress, City, State, Zip
        }
        
        private static bool IsOrdered<T>(IEnumerable<T> sequence)
            where T : IComparable<T> =>
            sequence.Zip(sequence.Skip(1))
                    .All(pair => pair.First.CompareTo(pair.Second) <= 0);

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_IsSorted()
        {
            List<string> data = new SampleData().GetUniqueSortedListOfStatesGivenCsvRows().ToList();

            Assert.IsTrue(IsOrdered(data));
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_HasAllStates()
        {
            var sampleData = new SampleData();
            List<string> data = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();

            Assert.IsTrue(sampleData.CsvRows.All(row =>
                data.Contains(row.Split(',')[(int)Columns.State])));
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_StatesAreUnique()
        {
            List<string> data = new SampleData().GetUniqueSortedListOfStatesGivenCsvRows().ToList();

            Assert.AreEqual<int>(data.Count, data.Distinct().Count());
        }

        [DataTestMethod]
        [DataRow("a")]
        [DataRow("b")]
        [DataRow("h")]
        [DataRow("x")]
        [DataRow("m")]
        [DataRow("e")]
        public void FilterByEmailAddress_Filters(string substring)
        {
            var sampleData = new SampleData();
            IEnumerable<IPerson> people = sampleData.People;
            IEnumerable<(string FirstName, string LastName)> filtered = sampleData.FilterByEmailAddress(email => email.Contains(substring));

            Assert.IsTrue(filtered.All(p => people.Any(p => p.EmailAddress.Contains(substring))));
        }


    }
}
