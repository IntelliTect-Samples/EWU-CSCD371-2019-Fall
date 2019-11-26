using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{

    public class SampleData : ISampleData
    {
        public string Path { get; set; } 
        
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines(Path ?? "People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() =>
            CsvRows.Select(s => s.Split(",")[6]).Distinct().OrderBy(state => state);

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows() =>
            GetUniqueSortedListOfStatesGivenCsvRows().Aggregate((a, b) => $"{a},{b}");

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                return CsvRows.Select(s =>
                               {
                                   var      cols    = s.Split(",");
                                   string[] address = cols.Skip(4).Take(4).ToArray();

                                   return new Person
                                   {
                                       FirstName = cols[1],
                                       LastName  = cols[2],
                                       Address = new Address
                                       {
                                           StreetAddress = address[0],
                                           City          = address[1],
                                           State         = address[2],
                                           Zip           = address[3]
                                       },
                                       EmailAddress = cols[3]
                                   };
                               })
                              .OrderBy(person => person.Address.State)
                              .ThenBy(person => person.Address.City)
                              .ThenBy(person => person.Address.Zip);
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            return People.Where(person => filter(person.EmailAddress))
                         .Select(person => (person.FirstName, person.LastName));
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            return people.Select(person => person.Address.State)
                         .Distinct()
                         .OrderBy(state => state)
                         .Aggregate((a, b) => $"{a},{b}");
        }

    }

}
