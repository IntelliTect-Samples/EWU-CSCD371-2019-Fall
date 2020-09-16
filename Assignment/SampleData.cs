using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private static string FileName { get; set; } = "People.csv";
        public enum Column
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

        public SampleData(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            FileName = fileName;
        }

        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines(Path.GetFullPath(FileName)).Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            return CsvRows.Select(line => line.Split(',')[(int)Column.State]).Distinct().OrderBy(state => state);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(",", GetUniqueSortedListOfStatesGivenCsvRows());

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                IEnumerable<string> sortedRows = CsvRows.OrderBy(row => row.Split(',')[(int)Column.State]).ThenBy(row => row.Split(',')[(int)Column.City]).ThenByDescending(row => row.Split(',')[(int)Column.Zip]);
                IEnumerable<IPerson> people = sortedRows.Select(person =>
                {
                    string[] split = person.Split(",");
                    return new Person(split[(int)Column.FirstName], split[(int)Column.LastName],
                        new Address(split[(int)Column.StreetAddress], split[(int)Column.City], split[(int)Column.State], split[(int)Column.Zip]),
                        split[(int)Column.Email]);
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

            return people
                .Select(person => person.Address.State)
                .Distinct()
                .OrderBy(state => state.ToString())
                .Aggregate((state1, state2) => state1 + "," + state2)
                .ToString();
        }
    }
}
