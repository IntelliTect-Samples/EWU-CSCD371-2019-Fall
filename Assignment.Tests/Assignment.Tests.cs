using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assignment.Tests
{
    [TestClass]
    public class AssignmentTests
    {
        [TestMethod]
        public void SampleData_CsvRows_GetsData()
        {
            var sampleApp = new SampleData("People.csv");
            IEnumerable<string> set = sampleApp.CsvRows;
            Assert.AreEqual<int>(50, set.Count());
        }

        [TestMethod]
        public void SampleData_CsvRows_GetsDataHardCoded()
        {
            string line = "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577";
            var sampleApp = new SampleData("People.csv");
            IEnumerable<string> set = sampleApp.CsvRows;
            Assert.AreEqual<string>(line, set.First());
        }

        [TestMethod]
        public void SampleData_CreatePerson_Qapla()
        {
            var sampleApp = new SampleData("People.csv");
            IPerson person = sampleApp.CreatePerson("1,Jimmy,John,jimmyjohn@yahoo.com,12345 6th ave.,Cheney,WA,99004");
            Assert.AreEqual(person.FirstName, "Jimmy");
            Assert.AreEqual(person.LastName, "John");
            Assert.AreEqual(person.StreetAddress, "12345 6th ave.");
            Assert.AreEqual(person.City, "Cheney");
            Assert.AreEqual(person.State, "WA");
            Assert.AreEqual(person.Zip, "99004");
            Assert.AreEqual(person.Email, "jimmyjohn@yahoo.com");
        }

        [TestMethod]
        public void SampleData_People_CreatesPeople()
        {
            //1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577
            var sampleApp = new SampleData("People.csv");
            var people = sampleApp.People;
            Assert.AreEqual(people.First().FirstName, "Priscilla");
            Assert.AreEqual(people.First().LastName, "Jenyns");
            Assert.AreEqual(people.First().StreetAddress, "7884 Corry Way");
            Assert.AreEqual(people.First().City, "Helena");
            Assert.AreEqual(people.First().State, "MT");
        }

        [TestMethod]
        public void SampleData_GetUniqueSortedListOfStatesGivenCsvRows_ReturnsSortedListOfStates()
        {
            var sampleApp = new SampleData("People.csv");
            string[] expected = {"AL","AZ","CA","DC","FL","GA","IN","KS","LA","MD","MN","MO","MT","NC","NE","NH","NV",
                "NY","OR","PA","SC","TN","TX","UT","VA","WA","WV" };
            var result = sampleApp.GetUniqueSortedListOfStatesGivenCsvRows();
            int i = 0;
            foreach (string item in expected)
            {
                Assert.AreEqual(expected[i], item);
                i++;
            }
        }

        [TestMethod]
        public void SampleData_GetAggregateSortedListOfStatesUsingCsvRows_ReturnsSortedListOfStates()
        {
            var sampleApp = new SampleData("People.csv");
            var expected = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";
            var result = sampleApp.GetAggregateSortedListOfStatesUsingCsvRows();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SampleData_FilterByEmailAddress_FiltersByEmail()
        {
            var sampleApp = new SampleData("People.csv");
            var emailTest = "pjenyns0@state.gov";
            IEnumerable<(string fname, string lname)> result = sampleApp.FilterByEmailAddress(emailActual => emailActual == emailTest);
            Assert.IsTrue(result.Contains(("Priscilla", "Jenyns")));
        }

        [TestMethod]
        public void SampleData_GetAggregateListOfStatesGivenPeopleCollection_ReturnsListofPeople()
        {
            var sampleApp = new SampleData("People.csv");
            IEnumerable<IPerson> personList = sampleApp.People;
            var result = sampleApp.GetAggregateListOfStatesGivenPeopleCollection(personList);
            var expected = sampleApp.GetAggregateSortedListOfStatesUsingCsvRows();
            Assert.AreEqual(expected, result);  
        }

    }
}
