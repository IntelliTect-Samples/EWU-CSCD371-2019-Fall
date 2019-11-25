using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

#pragma warning disable CA1065

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private string _FileName { get; }

        public SampleData(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));
            _FileName = fileName;
        }

        public IEnumerable<string> CsvRows
        {
            get
            {
                foreach (var line in File.ReadAllLines(_FileName).Skip(1).ToArray())
                    yield return line;
            }
        }

        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() =>
            CsvRows
                .Select(row => ParsePerson(row))
                .Select(p => p.Address.State)
                .Distinct()
                .OrderBy(s => s);

        public string GetAggregateSortedListOfStatesUsingCsvRows() =>
            CsvRows
                .Select(row => ParsePerson(row))
                .Select(p => p.Address.State)
                .Distinct()
                .OrderBy(s => s)
                .Aggregate((a, b) => $"{a}, {b}");

        public IEnumerable<IPerson> People
        {
            get => CsvRows
                    .Select(x => ParsePerson(x))
                    .OrderBy(p => p.Address.State)
                    .ThenBy(p => p.Address.City)
                    .ThenBy(p => p.Address.Zip);
        }

        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) =>
            from person in People
                where filter(person.Email)
                select (person.FirstName, person.LastName);

        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) =>
            people
                .Select(p => p.Address.State)
                .Distinct()
                .Aggregate((a, b) => $"{a}, {b}");

        public static Person ParsePerson(string? csvRow)
        {
            if (string.IsNullOrEmpty(csvRow))
                throw new ArgumentNullException(nameof(csvRow), $"{nameof(csvRow)} may not be null or empty.");

            string[] data = csvRow.Split(',');

            if (data.Length < 8)
                throw new ArgumentException($"{nameof(csvRow)} must have length >= 8.", nameof(csvRow));

            // Take last 4 elements of csv
            string[] addressData = data.Reverse().Take(4).Reverse().ToArray();

            return new Person()
            {
                FirstName=data[1],
                LastName=data[2],
                Email=data[3],
                Address=ParseAddress(addressData)
            };
        }

        public static Address ParseAddress(string[]? data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data), $"{nameof(data)} may not be null.");
            if (data.Length < 4)
                throw new ArgumentException($"{nameof(data)} must have length >= 4.", nameof(data));

            return new Address()
            {
                StreetAddress = data[0],
                City = data[1],
                State = data[2],
                Zip = data[3]
            };
        }
    }
}
