using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private enum Columns
        {
            Id, FirstName, LastName, Email, StreetAddress, City, State, Zip
        }

        public IEnumerable<string> CsvRows =>
            File.ReadAllLines("People.csv").Skip(1);

        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() =>
            CsvRows.Select(line => line.Split(',')[(int)Columns.State])
                   .Distinct()
                   .OrderBy(state => state);

        public string GetAggregateSortedListOfStatesUsingCsvRows() =>
            string.Join(',', GetUniqueSortedListOfStatesGivenCsvRows());

        public IEnumerable<IPerson> People =>
            CsvRows.Select(line => line.Split(','))
                   .Select(fields => new Person(
                                fields[(int)Columns.FirstName],
                                fields[(int)Columns.LastName],
                                fields[(int)Columns.Email],
                                new Address(
                                    fields[(int)Columns.StreetAddress],
                                    fields[(int)Columns.City],
                                    fields[(int)Columns.State],
                                    fields[(int)Columns.Zip]
                                )
                            ));

        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter
        ) =>
            People.Where(person => filter(person.EmailAddress))
                  .Select(person => (person.FirstName, person.LastName));

        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people
        ) =>
            people?.Select(p => p.Address.State)
                  .Distinct()
                  .Aggregate((list, state) => $"{list}, {state}")
            ?? throw new ArgumentNullException(nameof(people));
    }
}
