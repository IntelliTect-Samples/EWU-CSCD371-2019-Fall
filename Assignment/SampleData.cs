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
            return new Person()
            {
                FirstName = line[(int)PersonInfo.FirstName],
                LastName = line[(int)PersonInfo.LastName],
                EmailAddress = line[(int)PersonInfo.Email],
                Address = CreateAddress(line)

            };
        }

        private IAddress CreateAddress(string[] line)
        {
            return new Address
            {
                StreetAddress = line[(int)PersonInfo.StreetAddress],
                City = line[(int)PersonInfo.City],
                State = line[(int)PersonInfo.State],
                Zip = line[(int)PersonInfo.Zip]
            };
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
