using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {

        private string _FilePath;

        enum Columns
        {
            Id, FirstName, LastName, Email, StreetAddress, City, State, Zip
        }

        public SampleData(string filePath)
        {
            _FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }
        public IEnumerable<string> CsvRows 
        {
            get
            {
                foreach (string line in File.ReadAllLines(_FilePath).Skip(1).ToArray())
                {
                    yield return line;
                }
            }
        }

        public static IPerson CreatePerson(string line)
        {
            //0     1       2           3                  4         5     6   7
            //1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577
            if(string.IsNullOrEmpty(line)) throw new ArgumentNullException(nameof(line));
            string[] items = line.Split(',');
            IPerson person = new Person(items[1], items[2], items[4], items[5], items[6], items[7], items[3]);
            return person;
        }
        public IEnumerable<IPerson> People
        {
            get
            {
                var people = from line in CsvRows select CreatePerson(line);
                return people;
            }
        }

        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            var states = CsvRows.Select(line => CreatePerson(line)).Select(item => item.State).Distinct();
            return states;
        }

        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            throw new NotImplementedException();
        }   
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            throw new NotImplementedException();
        }
    }
}
