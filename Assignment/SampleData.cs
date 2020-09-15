using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private static string FileName { get; } = "People.csv";
        private enum Columns
        {
            Id,
            FirstName,
            LastName,
            Email,
            StreetAddress,
            City,
            State,
            Zip
        };

        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines(Path.GetFullPath(FileName)).Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            return CsvRows.Select(line => line.Split(',')[(int)Columns.State]).Distinct().OrderBy(state => state);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(",", GetUniqueSortedListOfStatesGivenCsvRows());

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                IEnumerable<string> sortedRows = CsvRows.OrderBy(row => row.Split(',', (int)Columns.State)).ThenBy(row => row.Split(',', (int)Columns.City)).ThenBy(row => row.Split(',', (int)Columns.Zip));
                IEnumerable<IPerson> people = sortedRows.Select(person =>
                {
                    string[] split = person.Split(",");
                    return new Person(split[(int)Columns.FirstName], split[(int)Columns.LastName],
                        new Address(split[(int)Columns.StreetAddress], split[(int)Columns.City], split[(int)Columns.State], split[(int)Columns.Zip]),
                        split[(int)Columns.Email]);
                });
                return people;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            if (filter is null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            return People.Where(person => filter(person.EmailAddress)).Select(person => (person.FirstName, person.LastName));
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            if (people is null)
            {
                throw new ArgumentNullException(nameof(people));
            }

            IEnumerable<string> states = people.Select(person => person.Address.State);
            return states.Distinct().OrderBy(state => state).Aggregate((state1, state2) => $"{state1},{state2}");
        }
    }
}
