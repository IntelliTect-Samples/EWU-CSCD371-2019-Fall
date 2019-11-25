using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows { get; set; }

        public SampleData(string csvFilePath)
        {
            CsvRows = File.ReadAllLines(csvFilePath).Skip(1);
            People = GenerateSortedCollectionOfPeople();
        }

        public SampleData(IEnumerable<string> hardCodedCollection)
        {
            this.CsvRows = hardCodedCollection;
            People = GenerateSortedCollectionOfPeople();
        }

        public enum Information
        {
            Id, FirstName, LastName, Email, StreetAddress, City, State, Zip
        }

        public IEnumerable<IPerson> GenerateSortedCollectionOfPeople()
        {
            return CsvRows.Select(csvRow => new Person(csvRow)).OrderBy(person => person.Address.State).ThenBy(person => person.Address.City).ThenBy(person => person.Address.Zip);
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            IEnumerable<string> data = CsvRows.Select(row => row.Split(',')[(int)Information.State]);
            return data.Distinct().OrderBy(state => state);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            return GetUniqueSortedListOfStatesGivenCsvRows().Aggregate((StateOne, StateTwo) => StateOne + "," + StateTwo);
        }

        // 4.
        public IEnumerable<IPerson> People { get; }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            return People.Where(person => filter(person.EmailAddress)).Select(person => (person.FirstName, person.LastName));
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}