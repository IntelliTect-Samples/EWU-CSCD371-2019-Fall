using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        public string? FileName { get; set; }

        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                if (FileName is null || FileName.Length <= 0) FileName = @"People.csv";
                IEnumerable<string> rows;
                rows = from line in File.ReadAllLines(FileName).Skip(1)
                       select line;
                return rows;
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            IEnumerable<string> rows = CsvRows;
            IEnumerable<string> sortedStates;
            sortedStates = from line in rows
                           let s = line.Split(',')
                           orderby s[6]
                           select s[6];
            sortedStates = sortedStates.Select(x => x).Distinct();

            return sortedStates;

        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IEnumerable<string> rows = CsvRows;
            IEnumerable<string> sortedStates = GetUniqueSortedListOfStatesGivenCsvRows();
            List<string> s = sortedStates.ToList();
            string aggregateSortedList = "";
            aggregateSortedList = String.Join(',', s);

            return aggregateSortedList;
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                IEnumerable<string> rows = CsvRows;
                rows = from line in rows
                       let s = line.Split(',')
                       orderby s[6], s[5], s[7]
                       select line;
                List <IPerson> people = new List<IPerson>();
                foreach(string line in rows)
                {
                    string[] s = line.Split(',');
                    Person p = new Person
                    {
                        FirstName = s[1],
                        LastName = s[2],
                        EmailAddress = s[3],
                        Address = new Address
                        {
                            StreetAddress = s[4],
                            City = s[5],
                            State = s[6],
                            Zip = s[7]
                        }
                    };                   
                    people.Add(p);
                }
                return people;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            IEnumerable<string> rows = CsvRows;
            IEnumerable<(string FirstName, string LastName)> names = from line in rows
                                                                     let s = line.Split(',')
                                                                     where filter(s[3]) == true
                                                                     select (s[1], s[2]);
            return names;
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            IEnumerable<string> sortedStates = from p in people
                                               let s = p.Address.State
                                               select s;
            sortedStates = sortedStates.OrderBy(s => s);
            sortedStates = sortedStates.Select(x => x).Distinct();
            string aggregate = String.Join(',', sortedStates.ToList());
            return aggregate;
        }
    }
}
