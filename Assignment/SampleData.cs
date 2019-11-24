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
        // returning a copy of the cached csv data, ensuring immutable list
        public IEnumerable<string> CsvRows { get => new List<string>(CsvData); }

        // uses cached csv data from people.csv by default
        private static readonly IEnumerable<string> _CsvDefault = File.ReadAllLines(_CSV_FILENAME).Skip(1).ToList();
        private IEnumerable<string> _CsvData = _CsvDefault;
        public IEnumerable<string> CsvData { get => _CsvData; set => _CsvData = value ?? _CsvData; } // make sure it's never null
        public void UseDefaultCsvData() => CsvData = _CsvDefault;

        public SampleData() => UseDefaultCsvData();

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            // just some notes to future me here, don't mind them
            List<string> states = (
                from line in CsvRows
                select line.Split(',')[(int)CsvColumn.State]) // transform the line into split strings
                .Distinct() // remove duplicates
                .OrderBy((string state) => state) // compare by state string
                .ToList(); // force query to execute
            return states;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => throw new NotImplementedException();

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
