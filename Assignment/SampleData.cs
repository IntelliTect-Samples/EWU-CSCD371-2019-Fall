using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {

        private string _FilePath;

        enum Columns
        {
            Id, FirstName, LastName, Email, StreetAddress, City, State, Zip
        }

        public SampleData(string filePath)
        {
            _FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }
        public IEnumerable<string> CsvRows => File.ReadAllLines(_FilePath).Skip(1);

        public IPerson CreatePerson(string line)
        {
            if (string.IsNullOrEmpty(line)) throw new ArgumentNullException(nameof(line));
            string[] items = line.Split(',');
            IPerson person = new Person(items[1], items[2], items[4], items[5], items[6], items[7], items[3]);
            return person;
        }

        public IEnumerable<IPerson> People
        {
            get
            {
                var people = from line in CsvRows select CreatePerson(line);
                return people;
            }
        }

        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() =>
            CsvRows.Select(line => line.Split(',')[(int)Columns.State]).Distinct().OrderBy(states => states);

        public string GetAggregateSortedListOfStatesUsingCsvRows() =>
            String.Join(',', GetUniqueSortedListOfStatesGivenCsvRows());

        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter) =>
            People.Where(person => filter(person.Email))
            .Select(person => (person.FirstName, person.LastName));

        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people) =>
            GetUniqueSortedListOfStatesGivenCsvRows().Aggregate<string>((i, j) => $"{i},{j}");

    }
}
