﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        public string FilePath { get; set; }

        public SampleData(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath))
                throw new FileNotFoundException();

            FilePath = filePath;
        }

        public IEnumerable<string> CsvRows
        {
            get
            {
                string[] lines = File.ReadAllLines(FilePath);
                lines = lines.Skip(1).ToArray();

                foreach (String line in lines)
                {
                    yield return line;
                }
            }
        }

        public IEnumerable<IPerson> People
        {
            get
            {
                var people =
                    from line in CsvRows
                    select ParsePerson(line);

                return people;
            }

        }

        public static Person ParsePerson(string row)
        {
            if (string.IsNullOrEmpty(row))
                throw new ArgumentNullException(nameof(row));

            string[] values = row.Split(',');
            string[] address = values.Skip(4).Take(4).ToArray();

            return new Person(values[1], values[2], values[3], ParseAddress(address));
        }

        public static Address ParseAddress(string[] address)
        {
            if (address is null)
                throw new ArgumentNullException(nameof(address));
            if (address.Length < 4)
                throw new ArgumentException("", nameof(address));

            return new Address(address[0], address[1], address[2], address[3]);
        }

        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            throw new NotImplementedException();
        }

        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            var states =
                people
                .Select(p => p.Address.State)
                .Aggregate((abbreviation1, abbreviation2) => $"{abbreviation1}, {abbreviation2}");

            return states;
        }

        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            var states =
                CsvRows
                .Select(row => ParsePerson(row))
                .Select(p => p.Address.State)
                .OrderBy(s => s)
                .Aggregate((abbreviation1, abbreviation2) => $"{abbreviation1}, {abbreviation2}");

            return states;

        }

        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            var states =
                CsvRows
                .Select(row => ParsePerson(row))
                .Select(p => p.Address.State);

            return states.OrderBy(s => s).Distinct();
        }
    }
}
