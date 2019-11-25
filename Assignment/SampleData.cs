using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines("People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => throw new NotImplementedException();

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => throw new NotImplementedException();

        // 4.
        public IEnumerable<IPerson> People => CsvRows.Select(person => person.Split(","))
            .Select(person => new Person 
            {
                FirstName = person[1],
                LastName = person[2],
                StreetAddress = person[4],
                City = person[5],
                State = person[6],
                Zip = person[7],
                Address = new Address
                {
                    StreetAddress = person[4],
                    City = person[5],
                    State = person[6],
                    Zip = person[7]
                }
            })
            .OrderBy(person => person.Address.State)
            .ThenBy(person => person.Address.City)
            .ThenBy(person => person.Address.Zip);

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();

        enum Column
        {
            StreetAddress,
            City,
            State,
            Zip
        }
        /** IN CLASS RANDOM CRAP
        public string SelectStateWithChildAddresses()
        {
            List<Address> addresses = new List<Address>();

            File.ReadAllLines("Person.csv").Select(item =>
            {
                string[] columns = item.Split(",");
                addresses.Add(new Address()
                {
                    StreetAddress = columns[(int)Column.StreetAddress],
                    State = columns[(int)Column.State],
                    City = columns[(int)Column.City],
                    Zip = columns[(int)Column.Zip],
                });
                return 1;
            });

            IEnumerable<IGrouping<string, Address>> thing = addresses.GroupBy(a=>a.State);

            return "";
        } */
    }
}
