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
        private string _FileName;

        public SampleData(string fileName)
        {
            _FileName = fileName;
        }

        public SampleData()
        {
            _FileName = "People.csv";
        }

        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines(_FileName)
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
            IEnumerable<string> states = CsvRows
                .Select(state => state.Split(",")[(int)PersonInfo.State])
                .Distinct()
                .OrderBy(x => x);

            string result = string.Join(", ", states);

            return result;
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get => CsvRows
                .Select(p => CreatePerson(p))
                .OrderBy(p => p.Address.State)
                .ThenBy(p => p.Address.City)
                .ThenBy(p => p.Address.Zip);
        }

        private IPerson CreatePerson(string x)
        {
            string[] line = x.Split(",");
            return new Person(line[(int)PersonInfo.FirstName],
                line[(int)PersonInfo.LastName],
                CreateAddress(line),
                line[(int)PersonInfo.Email]);
        }

        private IAddress CreateAddress(string[] line)
        {
            return new Address(line[(int)PersonInfo.StreetAddress], 
                line[(int)PersonInfo.City],
                line[(int)PersonInfo.State],
                line[(int)PersonInfo.Zip]);
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            return People.Where(p => filter(p.EmailAddress)).Select(name => (name.FirstName, name.LastName));
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            return people
                .Select(p => p.Address.State)
                .Distinct()
                .OrderBy(x => x)
                .Aggregate((current, next) => current + ", " + next)
                .ToString();
        }
    }
}
