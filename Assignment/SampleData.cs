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
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
