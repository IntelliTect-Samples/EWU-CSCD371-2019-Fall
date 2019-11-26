using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void GetUniqueSortedListWithHardCodedFile()
        {
            SampleData sampleData = new SampleData("../../../../Assignment/TestPeople.csv");
            IEnumerable<string> uniqueList = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            foreach (string line in uniqueList)
            {
                Assert.AreEqual("WA", line);
            }
        }

        [TestMethod]
        public void GetUniqueSortedListWithCsvFile()
        {
            SampleData sampleData = new SampleData();
            IEnumerable<string> uniqueList = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            string[] expectedList = {"AL","AZ","CA","DC","FL","GA","IN","KS","LA","MD","MN","MO","MT","NC","NE","NH","NV",
                "NY","OR","PA","SC","TN","TX","UT","VA","WA","WV" };

            int count = 0;
            foreach (string line in uniqueList)
            {
                Assert.AreEqual(expectedList[count], line);
                count++;
            }
        }

        [TestMethod]
        public void GetAggregateListWithHardCodedFile()
        {
            SampleData sampleData = new SampleData("../../../../Assignment/TestPeople.csv");
            string aggregateList = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            string expectedList = "WA";

            Assert.AreEqual(expectedList, aggregateList);
        }

        [TestMethod]
        public void GetAggregateListWithCsvFile()
        {
            SampleData sampleData = new SampleData();
            string aggregateList = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            string expectedList = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";

            Assert.AreEqual(expectedList, aggregateList);
        }

        [TestMethod]
        public void GetPeopleFromPeopleCsv()
        {
            SampleData sampleData = new SampleData();
            IEnumerable<IPerson> people = sampleData.People;
            int count = 0;
            foreach(Person person in people)
            {
                count++;
            }

            Assert.AreEqual(50, count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterByEmailAddressThrowsException()
        {
            SampleData sampleData = new SampleData();
            sampleData.FilterByEmailAddress(null);
        }

        [TestMethod]
        public void FilterByEmailAddressGoesWell()
        {
            SampleData sampleData = new SampleData();
            string testEmail = "atoall@fema.gov";
            IEnumerable<(string first, string last)> person = sampleData.FilterByEmailAddress(email => email == testEmail); //Should not work!

            Assert.IsTrue(person.Contains(("Amelia", "Toal")));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAggregateListOfStatesGivenPeopleCollectionThrowsException()
        {
            SampleData sampleData = new SampleData();
            sampleData.GetAggregateListOfStatesGivenPeopleCollection(null);
        }

        [TestMethod]
        public void GetAggregateListOfStatesWithPeopleGiven()
        {
            SampleData sampleData = new SampleData();
            string expectedList = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            string aggregateList = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);

            Assert.AreEqual(expectedList, aggregateList);
        }
    }
}
