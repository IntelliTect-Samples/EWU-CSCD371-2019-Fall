using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines("People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
            => CsvRows.Select(line => line.Split(',')[(int)Column.State])
                .Distinct()
                .OrderBy(states => states);

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => String.Join(',', GetUniqueSortedListOfStatesGivenCsvRows());

        // 4.
        public IEnumerable<IPerson> People
            => CsvRows.Select(line => line.Split(','))
                    .Select(line => new Person
                    {
                        FirstName = line[(int)Column.FirstName],
                        LastName = line[(int)Column.LastName],
                        EmailAddress = line[(int)Column.Email],
                        Address = new Address
                        {
                            StreetAddress = line[(int)Column.StreetAddress],
                            City = line[(int)Column.City],
                            State = line[(int)Column.State],
                            Zip = line[(int)Column.Zip]
                        }
                    })
                    .OrderBy(person => person.Address!.State)
                    .ThenBy(person => person.Address!.City)
                    .ThenBy(person => person.Address!.Zip);

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => People.Where(person => filter(person.EmailAddress))
                                            .Select(person => (person.FirstName, person.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => 
            people.Select(person => person.Address.State)
            .Distinct()
            .Aggregate((first, second) => $"{first},{second}");

        public enum Column
        {
            Id, FirstName, LastName, Email, StreetAddress, City, State, Zip
        }
    }
}
