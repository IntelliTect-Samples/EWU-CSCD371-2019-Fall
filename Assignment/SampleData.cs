using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        public string FileName { get; set; }

        public SampleData(string fileName)
        {
            FileName = fileName;
        }

        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                foreach (var ara in File.ReadAllLines(FileName).Skip(1))
                {
                    yield return ara;
                }
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
            => CsvRows.Select(myList =>
                myList.Split(",")[6]
            ).Distinct().OrderBy(myState=>myState);


        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            string[] stateAra = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
            return string.Join(",", stateAra);
        }

        // 4.
        public IEnumerable<IPerson> People
            => CsvRows.Where(myList
                => myList.Split(",").Length == 8
            ).OrderBy(
                state => state.Split(",")[6]
            ).ThenBy(
                city => city.Split(",")[5]
            ).ThenBy(
                zip => zip.Split(",")[7]
            ).Select(myString => newPerson(myString));

        public static Person newPerson(string attr)
        {
            if (attr == null)
                throw new ArgumentNullException(nameof(attr));

            string[] attrArray = attr.Split(",");
            Address address = newAddress(attrArray[4], attrArray[5], attrArray[6], attrArray[7]);

            return new Person
            {
                FirstName = attrArray[1],
                LastName = attrArray[2],
                Address = address,
                Email = attrArray[3]
            };
        }
        public static Address newAddress(string streetAddress, string city, string state, string zip)
        {
            return new Address
            {
                StreetAddress = streetAddress,
                City = city,
                State = state,
                Zip = zip
            };
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
            => from person in People
               where filter(person.Email)
               select (person.FirstName, person.LastName);

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            if (people == null)
                throw new ArgumentNullException("People is null");

            string[] stateAra = people.Select(person => person.Address.State).Distinct().ToArray();
            return stateAra.Aggregate((state, nextState) => $"{state},{nextState}");
        }
    }
}
