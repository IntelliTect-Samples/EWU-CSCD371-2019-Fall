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

        private string? _FileName;

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
                using StreamReader streamReader = new StreamReader(_FileName);
                streamReader.ReadLine();
                yield return streamReader.ReadLine();
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

            //var sorted = CsvRows.Select(line => new
            //{
            //    State = line.Split(',')[6],
            //    City = line.Split(',')[5],
            //    Zip = line.Split(',')[7],
            //    Line = line
            //}).Distinct().OrderBy(x => x.State).ThenBy(x => x.City).ThenBy(x => x.Zip);

            //IEnumerable<string> result = (IEnumerable<string>)sorted;
            //return result;

            IEnumerable<string> result = (IEnumerable<string>)CsvRows.Select(line => CreatePerson(line))
                .OrderBy(person => person.Address.State)
                .ThenBy(person => person.Address.City)
                .ThenBy(person => person.Address.Zip)
                .Distinct();

            return result;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            string result = string.Join(" ", CsvRows.Select(line => CreatePerson(line))
                .Select(person => person.Address.State).ToArray());

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
            Address address = new Address()
            {
                StreetAddress = line[4],
                City = line[5],
                State = line[6],
                Zip = line[7]
            };

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(address.ToString()))
            {
                throw new ArgumentNullException(nameof(csvRow), "Some part of the row was empty");
            }

            return new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Email = email
            };
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            return from person in People
                   where filter(person.Email)
                   select (person.FirstName, person.LastName);
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
