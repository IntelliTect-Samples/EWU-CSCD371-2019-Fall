using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

#pragma warning disable CA1065

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private string? _FileName;

        public SampleData(string? fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName), $"{nameof(fileName)} cannot be null or empty.");

            _FileName = fileName;
        }

        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                if (_FileName is null)
                    throw new InvalidOperationException($"{nameof(_FileName)} cannot be null when accessing {nameof(CsvRows)}");
                using (var sr = new StreamReader(@_FileName))
                {
                    string line = "";
                    sr.BaseStream.Position = 0;
                    sr.ReadLine(); // skip column headers
                    while (!((line = sr.ReadLine()) is null))
                    {
                        yield return line;
                    }
                }
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
        {
            return CsvRows
                .Select(row => ParsePerson(row))
                .Select(p => p.Address.State)
                .Distinct()
                .OrderBy(s => s);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            return CsvRows
                .Select(row => ParsePerson(row))
                .Select(p => p.Address.State)
                .Distinct()
                .OrderBy(s => s)
                .Aggregate((a, b) => $"{a}, {b}");
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                return from line in CsvRows
                    select ParsePerson(line);
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            return from person in People
                where filter(person.Email)
                select (person.FirstName, person.LastName);
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            return (from person in people
                    select person.Address.State)
                .Distinct()
                .Aggregate((a, b) => $"{a}, {b}");
        }

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
