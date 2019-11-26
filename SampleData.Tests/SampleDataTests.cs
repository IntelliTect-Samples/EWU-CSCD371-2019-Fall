using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        enum Column
        {
            Id, FirstName, LastName, Email, StreetAddress, City, State, Zip
        }

        private string? _FileName;
        private string[]? _TestString;

        [TestInitialize]
        public void TestInitialize()
        {
            _FileName = Path.GetTempFileName();
            _ = new FileInfo(_FileName)
            {
                Attributes = FileAttributes.Temporary
            };

            _TestString = new string[]
            {
                "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip",
                "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Spokane,WA,99201",
                "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Spokane,WA,99217",
                "3,Chadd,Stennine,cstennine2@wired.com,94148 Kings Terrace,Spokane,WA,99201",
                "4,Fremont,Pallaske,fpallaske3@umich.edu,16958 Forster Crossing,Spokane,WA,99208",
                "5,Melisa,Kerslake,mkerslake4@dion.ne.jp,283 Pawling Parkway,Spokane,WA,99201",
                "6,Reade,Stalman,rstalmank@purevolume.com,20622 Fulton Street,Spokane,WA,99205",
                "7,Jedd,Boissier,jboissiero@cbsnews.com,1 Arrowood Crossing,Spokane,WA,99218"
            };

            using StreamWriter sw = new StreamWriter(_FileName);
            foreach (string line in _TestString)
            {
                sw.WriteLine(line);
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(_FileName))
                File.Delete(_FileName);
        }


        // -------- 1 : CSVROWS TEST --------//
        [TestMethod]
        public void CsvRows_ReadsAllButFirstLine_ReturnsLines()
        {
            SampleData sampleData = new SampleData(_FileName!);

            IEnumerable<string> list = sampleData.CsvRows;

            var elementsInFile = list.Zip(_TestString.Skip(1), (first, second) => (first, second));

            foreach (var (expected, actual) in elementsInFile)
            {
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CsvRows_NullFile_ThrowsException()
        {
            SampleData sampleData = new SampleData(null!);            
        }

        // -------- 2 : GetUniqueSortedListOfStatesGivenCsvRows TEST --------//

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_SpokaneAddresses_IsSorted()
        {
            string[] expectedStates = { "WA" };

            SampleData sample = new SampleData(_FileName!);

            IEnumerable<string> stateList = sample.GetUniqueSortedListOfStatesGivenCsvRows();

            Assert.IsTrue(stateList.SequenceEqual(expectedStates));

        }
        
        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_SpokaneAddresses_IsSortedUsingLinq()
        {
            SampleData sample = new SampleData(_FileName!);

            IEnumerable<string> stateList = sample.GetUniqueSortedListOfStatesGivenCsvRows();

            IEnumerable<string> expectedStates = sample.CsvRows.Select(row => row.Split(",")[(int)Column.State]).OrderBy(state => state).Distinct();

            Assert.IsTrue(stateList.SequenceEqual(expectedStates));

        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_PeopleCsvFile_IsSorted()
        {
            string[] expectedStates = { "AL", "AZ", "CA", "DC", "FL", "GA", "IN",
                "KS", "LA", "MD", "MN", "MO", "MT", "NC", "NE", "NH", "NV", "NY",
                "OR", "PA", "SC", "TN", "TX", "UT", "VA", "WA", "WV"};

            SampleData sample = new SampleData("People.csv");

            IEnumerable<string> stateList = sample.GetUniqueSortedListOfStatesGivenCsvRows();

            Assert.IsTrue(stateList.SequenceEqual(expectedStates));
        }

        // -------- 3 : GetAggregateSortedListOfStatesUsingCsvRows TEST --------//

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_TestFile_IsSorted()
        {
            string expectedString = "CA,GA,MT,VA,WA";

            SampleData sample = new SampleData("TestFile.csv");

            string stateList = sample.GetAggregateSortedListOfStatesUsingCsvRows();

            Assert.AreEqual(expectedString, stateList);
        }

        // -------- 4 : People TEST --------//

        [TestMethod]
        public void People_TestFile_IsSortedByAddress()
        {
            SampleData sample = new SampleData("People.csv");

            IEnumerable<Person> peopleList = (IEnumerable<Person>)sample.People;

            peopleList.ToArray();

            for (int i = 0, j = 1; j < peopleList.ToArray().Length - 1; i++, j++)
            {
                Assert.IsTrue(peopleList.ToArray()[i].CompareTo(peopleList.ToArray()[j]) <= 0);
            }
        }

        [TestMethod]
        public void People_AddressIsPopulated_ReturnsNoneNull()
        {
            SampleData sample = new SampleData("People.csv");

            IEnumerable<IPerson> peopleList = sample.People;

            peopleList.ToArray();

            for (int i = 0; i < peopleList.ToArray().Length; i++)
            {
                Assert.IsNotNull(peopleList.ToArray()[i].Address);
            }
        }

        [TestMethod]
        public void People_PersonObjectsPopulated_ContainExpectedValues()
        {
            SampleData sample = new SampleData("SmallerPersonFile.csv");

            IEnumerable<IPerson> peopleList = sample.People;

            IPerson[] expectedPeople = {
                new Person("Chadd", "Stennine", new Address("94148 Kings Terrace", "Long Beach", "CA", "59721"), "cstennine2@wired.com"),
                new Person("Fremont", "Pallaske", new Address("16958 Forster Crossing", "Atlanta", "GA", "10687"), "fpallaske3@umich.edu"),
                new Person("Priscilla", "Jenyns", new Address("7884 Corry Way", "Helena", "MT", "70577"), "pjenyns0@state.gov"),
                new Person("Karin", "Joder", new Address("03594 Florence Park", "Tampa", "WA", "71961"), "kjoder1@quantcast.com")

            };

            int i = 0;
            foreach (Person person in peopleList)
            {
                Assert.IsTrue(person.Equal(expectedPeople[i]));
                i++;
            }
        }

        // -------- 5 : FilterByEmailAddress TEST --------//

        [TestMethod]
        public void FilterByEmailAddress_ReturnsNameTuple()
        {
            SampleData sample = new SampleData("TestFile.csv");

            ValueTuple<string, string>[] expectedNames = 
            {
                ("Priscilla", "Jenyns"),
                ("Karin", "Joder"),
                ("Editha", "Loseke")
            };

            IEnumerable<(string FirstName, string LastName)> actualNames = sample.FilterByEmailAddress(email => email.EndsWith(".gov", StringComparison.CurrentCulture));

            int i = 0;
            foreach ((string, string) email in actualNames)
            {
                Assert.AreEqual(email, expectedNames[i]);
                i++;
            }
        }

        // -------- 6 : GetAggregateListOfStatesGivenPeopleCollection TEST --------//

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_UsingGetUniqueSortedListOfStatesUsingCsvRows_ReturnsSortedList()
        {
            SampleData sample = new SampleData("People.csv");

            string[] expectedStates = sample.GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
            string expectedAggregateStates = string.Join(",", expectedStates);

            string actualStates = sample.GetAggregateListOfStatesGivenPeopleCollection(sample.People);

            Assert.AreEqual(actualStates, expectedAggregateStates);
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_UsingPeopleArray_ReturnsSortedList()
        {
            SampleData sample = new SampleData("People.csv");

            string expectedAggregateStates = "CA,GA,MT,WA";
                
            IPerson[] expectedPeople = {
                new Person("Chadd", "Stennine", new Address("94148 Kings Terrace", "Long Beach", "CA", "59721"), "cstennine2@wired.com"),
                new Person("Fremont", "Pallaske", new Address("16958 Forster Crossing", "Atlanta", "GA", "10687"), "fpallaske3@umich.edu"),
                new Person("Priscilla", "Jenyns", new Address("7884 Corry Way", "Helena", "MT", "70577"), "pjenyns0@state.gov"),
                new Person("Karin", "Joder", new Address("03594 Florence Park", "Tampa", "WA", "71961"), "kjoder1@quantcast.com")

            };

            string actualStates = sample.GetAggregateListOfStatesGivenPeopleCollection(expectedPeople);

            Assert.AreEqual(actualStates, expectedAggregateStates);
        }
    }
}
