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

        public enum Column
        {
            Id, FirstName, LastName, Email, StreetAddress, City, State, Zip
        }

        public IEnumerable<IPerson> GenerateSortedCollectionOfPeople()
        {
            IEnumerable<IPerson> people = CsvRows.Select(csvRow => new Person(csvRow))
                .OrderBy(person => person.Address.State)
                .ThenBy(person => person.Address.City)
                .ThenBy(person => person.Address.Zip);
            return people;
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            IEnumerable<string> states = CsvRows.Select(row => row.Split(',')[(int)Column.State])
                .Distinct()
                .OrderBy(state => state);
            return states;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            string states = GetUniqueSortedListOfStatesGivenCsvRows()
                .Aggregate((StateOne, StateTwo) => StateOne + "," + StateTwo);
            return states;
        }

        // 4.
        public IEnumerable<IPerson> People { get; }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            return People.Where(person => filter(person.EmailAddress))
                .Select(person => (person.FirstName, person.LastName));
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            string states = people.Select(person => person.Address.State)
                .Distinct()
                .OrderBy(state => state)
                .Aggregate((stateOne, stateTwo) => stateOne + "," + stateTwo);
            return states;
        }
    }
}