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
        {
            get
            {
                List<string> result = new List<string>();
                using (var fileReader = new StreamReader(@$".\People.csv"))
                {
                    for (string? s = fileReader.ReadLine(); !fileReader.EndOfStream; s = fileReader.ReadLine())
                    {
                        result.Add(s!);
                    }
                }
                return result.Skip<string>(1);
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            SampleData sampleData = new SampleData();
            IEnumerable<IPerson> personCollection = sampleData.People;

            IEnumerable<string> statesList = personCollection.Select(item => item.Address.State).Distinct<string>().OrderBy(s => s);

            return statesList;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            SampleData sample = new SampleData();
            IEnumerable<string> stateCollection = sample.GetUniqueSortedListOfStatesGivenCsvRows();
            string[] stateStringArray = stateCollection.ToArray<string>();
            return String.Join(", ", stateStringArray);
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                SampleData sampleData = new SampleData();
                IEnumerable<string> peopleData = sampleData.CsvRows;

                IEnumerable<IPerson> personCollection = peopleData.Select(item =>
                {
                    return sampleData.CreatePerson(item);
                });

                return personCollection;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            return from Person in People where filter(Person.EmailAddress) select (Person.FirstName, Person.LastName);
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            return people.Select(item => item.Address.State).Distinct().Aggregate((result, next) => result + ", " + next);
        }

        public Person CreatePerson(string inputString)
        {
            string[] personData = inputString.Split(",");
            return new Person
            {
                FirstName = personData[1],
                LastName = personData[2],
                EmailAddress = personData[3],
                Address = new Address
                {
                    StreetAddress = personData[4],
                    City = personData[5],
                    State = personData[6],
                    Zip = personData[7]
                }
            };
        }
    }
}
