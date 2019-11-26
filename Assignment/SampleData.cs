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
                    FirstName = columns[1],
                    LastName = columns[2],
                    EmailAddress = columns[3],
                    Address = new Address
                    {
                        StreetAddress = columns[4],
                        City = columns[5],
                        State = columns[6],
                        Zip = columns[7]
                    }
                };
            }).OrderBy(item => item.LastName);

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(string filter) {
            LinkedList<(string, string)> list = new LinkedList<(string, string)>();
            foreach (Person person in People) {
                if (person.EmailAddress.Equals(filter)) {
                    list.AddLast((person.FirstName, person.LastName));
                }
            }
            return list;
        }


        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people) {
            List<string> list = new List<string>();
            foreach (Person person in people) {
                if (!list.Contains(person.Address.State)) {
                    list.Add(person.Address.State);
                }
            }
            list.Sort();
            return string.Join(',', list);
        }
    }
}
