using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines("Person.csv")
            .Skip(1); //Using LINQ, skip the first row in the People.csv



        /// <summary>
        /// Implement IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() to return a sorted, unique list of states.
        /// A. Use ISampleData.CsvRows for your data source.
        /// B. Don't forget the list should be unique.
        /// C. Sort the list alphabetically
        /// D. Include a test that leverages a hard coded list of Spokane based addresses.
        /// E. Include a test that uses LINQ to verify the data is sorted correctly (do not use a hard coded list).
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            return CsvRows.Select(line => line.Split(',')[6]).OrderBy(x => x).Distinct();            
        }

        /// <summary>
        /// Implement ISampleData.GetAggregateSortedListOfStatesUsingCsvRows() to return a string that contains a unique, comma separated list of states.
        /// A. Use ISampleData.GetUniqueSortedListOfStatesGivenCsvRows for your data source.
        /// B. Consider "selecting" only the states and calling ToArray() to retrieve an array of all the state names.
        /// C. Given the array, consider using string.Join to combine the list into a single string.
        /// </summary>
        /// <returns></returns>
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            return string.Join(',', GetUniqueSortedListOfStatesGivenCsvRows());
        }

        // 4.
        public IEnumerable<IPerson> People 
        {
            get 
            {
                List<IPerson> people = new List<IPerson>();

                Address address = null;

                foreach(string line in CsvRows)
                {
                    Person person = new Person
                    {
                        Address = address = new Address()
                    };

                    //Id,FirstName,LastName,Email,StreetAddress,City,State,Zip
                    //1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577
                    var parts = line.Split(new char[] { ',' });

                    if (parts.Length < 8)
                        continue;

                    person.FirstName = parts[1];
                    person.LastName = parts[2];
                    person.EmailAddress = parts[3];

                    address.StreetAddress = parts[4];
                    address.City = parts[5];
                    address.State = parts[6];
                    address.Zip = parts[7];
                                                        
                    people.Add(person);
                }

                /// Sort the list by State, City, Zip. (Sort the addresses first then select).
                /// Be sure that Person.Address is also populated.
                /// Adding null validation to all the Person and Address properties is optional.
                /// Consider using ISampleData.CsvRows in your test to verify your results.

                return people.OrderBy(x => x.Address.State)
                    .ThenBy(x => x.Address.City)
                    .ThenBy(x => x.Address.Zip); 
            }
        }


        /// <summary>
        /// Implement ISampleDate.FilterByEmailAddress(Predicate<string> filter) to 
        /// return a list of names where the email address matches the filter.
        /// Use ISampleData.People for your data source.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            return People.Where(x => filter(x.EmailAddress)).Select(x => (x.FirstName, x.LastName));
        }

        /// <summary>
        /// Implement ISampleData.GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people) to 
        /// return a string that contains a unique, comma separated list of states.
        /// Use the people parameter from ISampleData.GetUniqueListOfStates for your data source.
        /// At a minimum, use System.Linq.Enumerable.Aggregate LINQ method to create your result.
        /// Don't forget the list should be unique.
        ///  It is recommended that at a minimum you use ISampleData.GetUniqueSortedListOfStatesGivenCsvRows to 
        ///  validate your result.
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            return string.Join(',', people.Select(x => x.Address.State).OrderBy(x => x).Distinct());
        }
    }
}
