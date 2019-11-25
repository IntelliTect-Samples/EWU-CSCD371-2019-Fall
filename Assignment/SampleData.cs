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
        {
            get
            {
                IEnumerable<string> rows;
                rows = from line in File.ReadAllLines(@"People.csv").Skip(1)
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
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
