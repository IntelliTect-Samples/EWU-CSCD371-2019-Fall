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
            => CsvRows.Select(line => line.Split(',')[6])
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
                        FirstName = line[1],
                        LastName = line[2],
                        EmailAddress = line[3],
                        Address = new Address
                        {
                            StreetAddress = line[4],
                            City = line[5],
                            State = line[6],
                            Zip = line[7]
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
    }
}
