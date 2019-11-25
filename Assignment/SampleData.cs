using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        public enum CsvColumn { Id, FirstName, LastName, EmailAddress, StreetAddress, City, State, Zip }
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
                ( from row in CsvRows select row.Split(',')[(int) CsvColumn.State] )
                .Distinct() // remove duplicates
                .OrderBy((string state) => state) // compare by state string
                .ToList(); // force query to execute

            return states;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(',', GetUniqueSortedListOfStatesGivenCsvRows());

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                List<Person> people = (
                    from row in CsvRows
                    select row.Split(',')
                    into row
                    orderby
                        row[(int) CsvColumn.State],
                        row[(int) CsvColumn.City],
                        row[(int) CsvColumn.Zip]
                    select new Person()
                    {
                        FirstName = row[(int) CsvColumn.FirstName],
                        LastName = row[(int) CsvColumn.LastName],
                        EmailAddress = row[(int) CsvColumn.EmailAddress],
                        Address = new Address()
                        {
                            State = row[(int) CsvColumn.State],
                            City = row[(int) CsvColumn.City],
                            Zip = row[(int) CsvColumn.Zip],
                            StreetAddress = row[(int) CsvColumn.StreetAddress]
                        }
                    }
                    ).ToList();

                return people;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
