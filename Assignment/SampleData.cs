using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private string _FilePath;

        enum Column
        {
            Id, FirstName, LastName, Email, StreetAddress, City, State, Zip
        }

        public SampleData(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));
            _FilePath = filePath;
        }

        public IEnumerable<string> CsvRows => File.ReadLines(_FilePath).Skip(1);


        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
                                 => CsvRows.Select(item =>
                                    item.Split(',')[(int)Column.State])
                                    .Distinct()
                                    .OrderBy(state => state);


        public string GetAggregateSortedListOfStatesUsingCsvRows()
                        => String.Join(",", GetUniqueSortedListOfStatesGivenCsvRows());


        public IEnumerable<IPerson> People =>
            CsvRows.Select(row => row.Split(","))
            .Select(line =>
                new Person(
                    line[(int)Column.FirstName],
                    line[(int)Column.LastName],
                    new Address(
                        line[(int)Column.StreetAddress],
                        line[(int)Column.City],
                        line[(int)Column.State],
                        line[(int)Column.Zip]),
                    line[(int)Column.Email]))
            .OrderBy(state => state.Address.State)
            .ThenBy(city => city.Address.City)
            .ThenBy(zip => zip.Address.Zip);


        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => People
                                         .Where(person => filter(person.EmailAddress))
                                         .Select(person => (person.FirstName, person.LastName));


        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => people
                                            .Select(state => state.Address.State)
                                            .OrderBy(state => state)
                                            .Distinct()
                                            .Aggregate((a, b) => a + ',' + b);
    }
}

