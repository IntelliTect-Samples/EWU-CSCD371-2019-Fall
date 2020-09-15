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
            => CsvRows.Select(line => line.Split(',')[(int)Columns.State]).Distinct().OrderBy(state => state);

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => String.Join(",", GetUniqueSortedListOfStatesGivenCsvRows());

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                IEnumerable<string> sortedRows = CsvRows.OrderBy(row => row.Split(',', (int)Columns.State)).ThenBy(row => row.Split(',', (int)Columns.City)).ThenBy(row => row.Split(',', (int)Columns.Zip));
                IEnumerable<IPerson> people = sortedRows.Select(person =>
                {
                    string[] split = person.Split(",");
                    return new Person()
                    {
                        FirstName = split[(int)Columns.FirstName],
                        LastName = split[(int)Columns.LastName],
                        Address = new Address()
                        {
                            StreetAddress = split[(int)Columns.StreetAddress],
                            State = split[(int)Columns.State],
                            City = split[(int)Columns.City],
                            Zip = split[(int)Columns.Zip]
                        },
                        EmailAddress = split[(int)Columns.Email]
                    };
                });
                return people;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
            => People.Where(person => filter(person.EmailAddress)).Select(person => (person.FirstName, person.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            IEnumerable<string> states = people.Select(person => person.Address.State);
            return states.Distinct().OrderBy(state => state).Aggregate((state1, state2 )=> $"{state1},{state2}");
        }
    }
}
