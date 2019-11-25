using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines("People.csv").Skip(1).ToList();

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => CsvRows.Select(ParsePersonText).Select(person => person.Address.State).Distinct().OrderBy(s => s);

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => CsvRows.Select(ParsePersonText).Select(person => person.Address.State).Distinct().OrderBy(s => s).Aggregate((a, b) => $"{a}, {b}");

        // 4.
        public IEnumerable<IPerson> People => 
            CsvRows.Select(ParsePersonText);

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter) => 
            from person in People
            where filter(person.EmailAddress)
            select (person.FirstName, person.LastName);

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people) => 
            people.Select(person => person.Address.State).Distinct().Aggregate((a, b) => $"{a}, {b}");

        private Person ParsePersonText(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException($"{nameof(value)} is empty/null");

            string[] data = value.Split(',');

            if (data.Length != 8)
                throw new ArgumentException($"{nameof(value)} must have 8 values");

            return new Person()
            {
                FirstName = data[1],
                LastName = data[2],
                EmailAddress = data[3],
                Address = new Address()
                {
                    StreetAddress = data[4],
                    City = data[5],
                    State = data[6],
                    Zip = data[7],
                }
            };

            
        }
    }
}
