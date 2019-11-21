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

            var sorted = CsvRows.Select(line => new
            {
                State = line.Split(',')[6],
                City = line.Split(',')[5],
                Zip = line.Split(',')[7],
                Line = line
            }).Distinct().OrderBy(x => x.State).ThenBy(x => x.City).ThenBy(x => x.Zip);

            IEnumerable<string> result = (IEnumerable<string>)sorted;
            return result;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => throw new NotImplementedException();

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
