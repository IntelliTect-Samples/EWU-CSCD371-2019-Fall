using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows
            => (from line in File.ReadAllLines("People.csv")
               select line).Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            IEnumerable<string> query = (from row in CsvRows
                                        let state = row.Split(',')[6]
                                        select state).Distinct().OrderBy(item => item);

            return query;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            string[] stateArr = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();

            return string.Join(',', stateArr);
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                List<Person> people = new List<Person>();
                IEnumerable<string> rows = CsvRows;

                foreach (string s in rows)
                {
                    Person pers = new Person();
                    Address addr = new Address();
                    string[] items = s.Split(',');

                    pers.FirstName = items[1];
                    pers.LastName = items[2];
                    pers.EmailAddress = items[3];

                    addr.StreetAddress = items[4];
                    addr.City = items[5];
                    addr.State = items[6];
                    addr.Zip = items[7];

                    pers.Address = addr;

                    people.Add(pers);
                }

                return people;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            return from person in People
                   where filter(person.EmailAddress)
                   select (person.FirstName, person.LastName);
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
