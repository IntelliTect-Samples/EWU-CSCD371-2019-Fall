using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void SampleDataConstructor_ValidFile()
        {
            SampleData sd = new SampleData("People.csv");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SampleDataConstructor_NullFile()
        {
            SampleData sd = new SampleData(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void SampleDataConstructor_NonExistingFile()
        {
            SampleData sd = new SampleData("fake.file");
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_Hardcoded_AllDisticnt()
        {
            string randomFile = Path.GetTempFileName();

            List<string> hardcodedList = new List<string>
            {
                "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip",
                "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Spokane,WA,70577",
                "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Spokane,WA,71961",
                "3,Chadd,Stennine,cstennine2@wired.com,94148 Kings Terrace,Spokane,WA,59721"
            };

            File.AppendAllLines(randomFile, hardcodedList);

            SampleData sd = new SampleData(randomFile);
            IEnumerable<string> states = sd.GetUniqueSortedListOfStatesGivenCsvRows();

            File.Delete(randomFile);

            Assert.AreEqual<int>(1, states.Count());
            Assert.IsTrue(states.Contains("WA"));
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_UserLINQ_AllDisticnt()
        {
            SampleData sd = new SampleData("People.csv");
            IEnumerable<string> states = sd.GetUniqueSortedListOfStatesGivenCsvRows();

            Assert.IsTrue(states.Zip(states.Skip(1), (first, second) => first.CompareTo(second) < 0).All(state => state));
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_AllDistinct()
        {
            SampleData sd = new SampleData("People.csv");
            string[] states = sd.GetAggregateSortedListOfStatesUsingCsvRows().Split(",");

            Assert.IsTrue(states.Zip(states.Skip(1), (first, second) => first.CompareTo(second) < 0).All(state => state));
        }

        [TestMethod]
        public void People_BadList_ReturnEmptyList()
        {
            string randomFile = Path.GetTempFileName();

            List<string> hardcodedList = new List<string>
            {
                "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip",
                "1,Priscilla,Jenyns,pjenyns0@state.gov",
                "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Spokane,WA",
                "3,Chadd"
            };

            File.AppendAllLines(randomFile, hardcodedList);

            SampleData sd = new SampleData(randomFile);
            IEnumerable<IPerson> people = sd.People;

            File.Delete(randomFile);

            Assert.IsFalse(people.Any());
        }

        [TestMethod]
        public void People_IncompleteList_ReturnPartialList()
        {
            string randomFile = Path.GetTempFileName();

            List<string> hardcodedList = new List<string>
            {
                "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip",
                "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Spokane,WA,70577",
                "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Spokane,WA",
                "3,Chadd"
            };

            File.AppendAllLines(randomFile, hardcodedList);

            SampleData sd = new SampleData(randomFile);
            IEnumerable<IPerson> people = sd.People;

            File.Delete(randomFile);

            Assert.IsTrue(people.Any());
            Assert.AreEqual<int>(1, people.Count());
        }

        [TestMethod]
        public void People_FullList_ReturnList()
        {
            SampleData sd = new SampleData("People.csv");
            IEnumerable<IPerson> people = sd.People;

            Assert.IsTrue(people.Any());
            Assert.AreEqual<int>(50, people.Count());
        }

        [TestMethod]
        public void FilterByEmailAddress_ReturnsAccurateList()
        {
            SampleData sd = new SampleData("People.csv");
            string[] testEmails =
            {
                "pjenyns0@state.gov",
                "cstennine2@wired.com",
                "cbucklej@tiny.cc"
            };

            IEnumerable<(string FirstName, string LastName)> results = sd.FilterByEmailAddress(email => testEmails.Contains(email));

            Assert.AreEqual<int>(3, results.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterByEmailAddress_NullPredicate()
        {
            SampleData sd = new SampleData("People.csv");
            IEnumerable<(string FirstName, string LastName)> results = sd.FilterByEmailAddress(null!);
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_DistinctList()
        {
            SampleData sd = new SampleData("People.csv");
            IEnumerable<IPerson> people = sd.People;

            string expected = sd.GetAggregateSortedListOfStatesUsingCsvRows();
            string actual = sd.GetAggregateListOfStatesGivenPeopleCollection(people);

            Assert.AreEqual<string>(expected, actual);

            List<string> peopleOfActual = new List<string>(actual.Split(","));
            IEnumerable<string> distinctList = peopleOfActual.Distinct();
            Assert.IsTrue(distinctList.Count() == expected.Split(",").Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAggregateListOfStatesGivenPeopleCollection_NullPeople()
        {
            SampleData sd = new SampleData("People.csv");
            string actual = sd.GetAggregateListOfStatesGivenPeopleCollection(null!);
        }
    }
}
