using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        public enum CsvColumn { Id, FirstName, LastName, Email, StreetAddress, City, State, Zip }
        private const string _CSV_FILENAME = "People.csv";

        // 1.
        private static readonly IEnumerable<string> _CsvDefault = File.ReadAllLines(_CSV_FILENAME).Skip(1).ToList();
        private IEnumerable<string> _CsvRows = _CsvDefault;
        public IEnumerable<string> CsvRows
        {
            get => new List<string>(_CsvRows); // ensuring immutable list
            set => _CsvRows = value is IEnumerable<string> ? new List<string>(value) : _CsvRows; // avoiding nulls
        }

        public void UseDefaultCsvData() => _CsvRows = _CsvDefault;

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            List<string> states =
                // transform the line into tuple of states extracted from split strings
                ( from line in CsvRows select line.Split(',')[(int) CsvColumn.State] )
                .Distinct() // remove duplicates
                .OrderBy((string state) => state) // compare by state string
                .ToList(); // force query to execute

            return states;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(',', GetUniqueSortedListOfStatesGivenCsvRows());

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
