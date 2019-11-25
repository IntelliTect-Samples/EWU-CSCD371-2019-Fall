using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {

        private readonly string? _FileName;

        public SampleData(string? fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            } else
            {
                _FileName = fileName;
            }
        }

        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                return from line in File.ReadAllLines(_FileName) where !string.IsNullOrEmpty(line) where !(line.Contains("State")) select line;
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            IEnumerable<string> result = CsvRows.Select(line => line.Split(',')[6]).Distinct().OrderBy(line => line);

            return result;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            string result = string.Join(",", CsvRows.Select(line => CreatePerson(line))
                .Select(person => person.Address.State).OrderBy(line => line).ToArray());

            return result;
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                return from row in CsvRows select CreatePerson(row);
            }
        }

        private Person CreatePerson(string? csvRow)
        {
            if (string.IsNullOrEmpty(csvRow)) throw new ArgumentNullException(nameof(csvRow));

            string[] line = csvRow.Split(',');

            string firstName = line[1];
            string lastName = line[2];
            string email = line[3];
            Address address = new Address(line[4], line[5], line[6], line[7]);

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(address.ToString()))
            {
                throw new ArgumentNullException(nameof(csvRow), "Some part of the row was empty");
            }

            return new Person(firstName, lastName, address, email);
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            if (filter is null) throw new ArgumentNullException(nameof(filter));


            return from person in People
                   where filter(person.Email)
                   select (person.FirstName, person.LastName);
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            if (people is null) throw new ArgumentNullException(nameof(people));

            string result = string.Join(",", people.Select(person => person.Address.State)
                .Distinct());

            return result;
        }
    }
}
