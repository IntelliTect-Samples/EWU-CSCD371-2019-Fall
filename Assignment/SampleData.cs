using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private string FileName { get; set; }

        public SampleData(string? fileName)
        {
            if (fileName is null)
                throw new ArgumentNullException(nameof(fileName));

            else if (!File.Exists(fileName))
                throw new FileNotFoundException(nameof(fileName));

            FileName = fileName;
        }

        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines(FileName).Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            List<string> query = CsvRows.Select(item => item.Split(',')[6]).Distinct().OrderBy(stateName => stateName).ToList();
            return query;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            return string.Join(",", GetUniqueSortedListOfStatesGivenCsvRows());
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                List<Person> people =
                    (
                        from item in CsvRows
                        select item.Split(",")

                        into line
                        where line.Length == 8
                        orderby
                        line[6],
                        line[5],
                        line[7]

                        select new Person()
                        {
                            FirstName = line[1],
                            LastName = line[2],
                            EmailAddress = line[3],
                            Address = new Address
                            {
                                StreetAddress = line[4],
                                City = line[5],
                                State = line[6],
                                Zip = line[7]
                            }
                        }
                    ).ToList();

                return people;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            return from person in People
                   where filter(person.EmailAddress)
                   select (person.FirstName, person.LastName);
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            if (people is null)
                throw new ArgumentNullException(nameof(people));

            List<string> states = people.Select(person => person.Address.State).Distinct().ToList();
            return states.Aggregate((state, next) => $"{state},{next}");
        }
    }
}
