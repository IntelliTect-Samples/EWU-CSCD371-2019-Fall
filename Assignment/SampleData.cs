using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{

    /*1. Implement the `ISampleData.CsvRows` property, loading the data from the `People.csv` file and returning each line as a single string.

- Change the "Copy to" property on People.csv to "Copy if newer" so that the file is deployed along with your test project.
- Using LINQ, skip the first row in the `People.csv`.
- Be sure to appropriately handle resource (`IDisposable`) items correctly if applicable (and it may not be depending on how you implement it).

    */
    public class SampleData : ISampleData
    {

        private readonly string? _FileName;

        public SampleData(string? fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            } else
            {
                _FileName = fileName;
            }
        }

        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                return from line in File.ReadAllLines(_FileName) where !string.IsNullOrEmpty(line) where !(line.Contains("State")) select line;
            }
        }

        /*
         * Implement `IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()` to return a **sorted**, **unique** list of states.

- Use `ISampleData.CsvRows` for your data source.
- Don't forget the list should be unique.
- Sort the list by State, City, Zip.
- Include a test that leverages a hard coded list of Spokane based addresses.
- Include a test that uses LINQ to verify the data is sorted correctly (do not use a hard coded list).

         * 
         */

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            IEnumerable<string> result = CsvRows.Select(line => line.Split(',')[6]).Distinct().OrderBy(line => line);

            return result;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            string result = string.Join(",", CsvRows.Select(line => CreatePerson(line))
                .Select(person => person.Address.State).OrderBy(line => line).ToArray());

            return result;
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                return from row in CsvRows select CreatePerson(row);
            }
        }

        private Person CreatePerson(string? csvRow)
        {
            if (string.IsNullOrEmpty(csvRow)) throw new ArgumentNullException(nameof(csvRow));

            string[] line = csvRow.Split(',');

            string firstName = line[1];
            string lastName = line[2];
            string email = line[3];
            Address address = new Address(line[4], line[5], line[6], line[7]);

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(address.ToString()))
            {
                throw new ArgumentNullException(nameof(csvRow), "Some part of the row was empty");
            }

            return new Person(firstName, lastName, address, email);
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            if (filter is null) throw new ArgumentNullException(nameof(filter));


            return from person in People
                   where filter(person.EmailAddress)
                   select (person.FirstName, person.LastName);
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            if (people is null) throw new ArgumentNullException(nameof(people));

            string result = string.Join(",", people.Select(person => person.Address.State)
                .Distinct());

            return result;
        }
    }
}
