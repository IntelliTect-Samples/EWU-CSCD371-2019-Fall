using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public enum PersonInfo
    {
        Id, FirstName, LastName, Email, StreetAddress, City, State, Zip
    }
    public class SampleData : ISampleData
    {
        private string _fileName;

        public SampleData(string fileName)
        {
            _fileName = fileName;
        }

        public SampleData()
        {
            _fileName = "People.csv";
        }

        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines(_fileName)
            .Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            var orderedLine = CsvRows.OrderBy(line => line.Split(",")[(int)PersonInfo.State]);
            return orderedLine.Select(state => state.Split(",")[(int)PersonInfo.State]).Distinct();
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IEnumerable<string> states = CsvRows.Select(state => state.Split(",")[(int)PersonInfo.State]).Distinct();
            string[] statesArray = states.ToArray();
            Array.Sort(statesArray);

            string result = string.Join(", ", statesArray);

            return result;
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
