using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Assignment;
using System;
using System.Linq;

namespace AssignmentTests
{
    [TestClass]
    public class ISampleDataTests
    {
        [TestMethod]
        public void GetCSVRows()
        {
            SampleData sd = new SampleData();
            IEnumerable<string> rows = sd.CsvRows;
            int count = 0;
            int expectedCount = 50;
            foreach(string s in rows)
            {
                count++;
            }
            Assert.AreEqual(expectedCount, count);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStates_UsingSpokaneHardCoded()
        {
            SampleData sd = new SampleData();
            sd.FileName = @"SpokaneHardCoded.csv";
            IEnumerable<string> rows = sd.CsvRows;
            IEnumerable<string> states = sd.GetUniqueSortedListOfStatesGivenCsvRows();


            IEnumerable<string> expectedRows = from s in rows
                                               let line = s.Split(',')
                                               let state = line[6]
                                               orderby state
                                               select state;
            expectedRows = expectedRows.Select(x => x).Distinct();

            CollectionAssert.AreEqual(expectedRows.ToList(), states.ToList());

        }

        [TestMethod]
        public void GetUniqueSortedListOfStates_UsingLinq()
        {
            SampleData sd = new SampleData();
            IEnumerable<string> rows = sd.CsvRows;
            IEnumerable<string> states = sd.GetUniqueSortedListOfStatesGivenCsvRows();

            
            IEnumerable<string> expectedRows = from s in rows
                                               let line = s.Split(',')
                                               let state = line[6]
                                               orderby state
                                               select state;
            expectedRows = expectedRows.Select(x => x).Distinct();

            CollectionAssert.AreEqual(expectedRows.ToList(), states.ToList());

        }

        [TestMethod]
        public void GetAggregateSortedList()
        {
            SampleData sd = new SampleData();
            string list = sd.GetAggregateSortedListOfStatesUsingCsvRows();
            string expectedList = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";

            Assert.AreEqual(expectedList, list);
        }

        [TestMethod]
        public void GetPeopleListSortedByStateCityZip()
        {
            SampleData sd = new SampleData();
            IEnumerable<IPerson> people = sd.People;
            IEnumerable<string> rows = sd.CsvRows;

            int expectedCount = rows.Count();

            Assert.AreEqual(expectedCount, people.Count());

            rows = from line in rows
                   let s = line.Split(',')
                   orderby s[6], s[5], s[7]
                   select line;

            int index = 0;
            foreach(string line in rows)
            {
                IPerson pElement = people.ElementAt(index);
                string[] s = line.Split(',');
                Assert.AreEqual(pElement.FirstName, s[1]);
                Assert.AreEqual(pElement.LastName, s[2]);
                Assert.AreEqual(pElement.EmailAddress, s[3]);
                Assert.AreEqual(pElement.Address.StreetAddress, s[4]);
                Assert.AreEqual(pElement.Address.City, s[5]);
                Assert.AreEqual(pElement.Address.State, s[6]);
                Assert.AreEqual(pElement.Address.Zip, s[7]);
                index++;
            }



        }

        [TestMethod]
        public void GetFilteredEmailNames_ValidEmailEntered()
        {
            SampleData sd = new SampleData();
            string validEmail = "eloseked@posterous.com";
            Predicate<string> pred = delegate (string s) { return s.Equals(validEmail); };
            IEnumerable <(string FirstName, string LastName)> names = sd.FilterByEmailAddress(pred);

            int expectedCount = 1;
            int count = names.Count();

            (string FirstName, string LastName) expectedName = ("Editha", "Loseke");

            Assert.AreEqual(expectedCount, count);
            Assert.AreEqual(expectedName, names.First());
        }

        [TestMethod]
        public void GetAggregateSortedListFromPeople()
        {
            SampleData sd = new SampleData();
            string list = sd.GetAggregateListOfStatesGivenPeopleCollection(sd.People);
            IEnumerable<string> expectedList = sd.GetUniqueSortedListOfStatesGivenCsvRows();
            IEnumerable<string> splitList = list.Split(',');

            Assert.AreEqual(expectedList.Count(), splitList.Count());
            CollectionAssert.AreEqual(expectedList.ToList(), splitList.ToList());
        }

    }
}
