using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        internal enum columns
        {
            Id, FirstName, LastName, Email, StreetAddress, City, State, Zip
        }

        // 1.
        public IEnumerable<string> CsvRows =>
            File.ReadAllLines("People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() =>
            CsvRows.Select(line => line.Split(',')[6])
                   .Distinct()
                   .OrderBy(state => state);

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows() =>
            string.Join(',', GetUniqueSortedListOfStatesGivenCsvRows());

        // 4.
        public IEnumerable<IPerson> People =>
            CsvRows.Select(line => line.Split(','))
                   .Select(fields => new Person(
                                fields[(int)columns.FirstName],
                                fields[(int)columns.LastName],
                                fields[(int)columns.Email],
                                new Address(
                                    fields[(int)columns.StreetAddress],
                                    fields[(int)columns.City],
                                    fields[(int)columns.State],
                                    fields[(int)columns.Zip]
                                )
                            )
                           );

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter
        ) =>
            People.Where(person => filter(person.EmailAddress))
                  .Select(person => (person.FirstName, person.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people
        ) =>
            throw new NotImplementedException();
    }
}
