using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment {
    public class SampleData : ISampleData {
        public string PeoplePath { get; } = "People.csv";

        // 1.
        public IEnumerable<string> CsvRows =>
            File.ReadAllLines(PeoplePath).Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() =>
            CsvRows.Select(item =>
                item.Split(',')[6]
            ).Distinct().OrderBy(item =>
                item
            );

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows() => string.Join(",", GetUniqueSortedListOfStatesGivenCsvRows());

        // 4.
        public IEnumerable<IPerson> People =>
            CsvRows.Select(line =>
            {
                string[] columns = line.Split(',');
                return new Person()
                {
                    FirstName = columns[0],
                    LastName = columns[1],
                    EmailAddress = columns[2],
                    Address = new Address
                    {
                        StreetAddress = columns[3],
                        City = columns[4],
                        State = columns[5],
                        Zip = columns[6]
                    }
                };
            }).OrderBy(item => item.LastName);

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter) =>
            People.Select(line =>
                (line.FirstName, line.LastName)
            ).Where(item =>
                filter.Equals(People.Select(line => line.EmailAddress))
            );


        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people) {
            LinkedList<string> states = new LinkedList<string>();
            return string.Join(',', People.Select(line =>
            {
                states.AddLast(line.Address.State);
                return line.Address.State;
            }).Where(item => !states.Contains(item)));
        }
    }
}
