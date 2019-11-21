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
                    yield return sr.ReadLine();
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => throw new NotImplementedException();

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => throw new NotImplementedException();

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();

        public static Person ParsePerson(string? csvRow)
        {
            if (string.IsNullOrEmpty(csvRow))
                throw new ArgumentNullException(nameof(csvRow), $"{nameof(csvRow)} may not be null or empty.");

            string[] data = csvRow.Split(',');

            if (data.Length < 8)
                throw new ArgumentException($"{nameof(csvRow)} must have length >= 8.", nameof(csvRow));

            // Take last 4 elements of csv
            string[] addressData = data.Reverse().Take(4).Reverse().ToArray();

            Address addr = ParseAddress(addressData);

            return new Person()
            {
                FirstName=data[1],
                LastName=data[2],
                Address=addr
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
