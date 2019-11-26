using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            string[] expectedList = {"AL","AZ","CA","CA","CA","CA","CA","DC","DC","DC","FL","FL","GA","GA","GA","IN","KS","LA","LA","MD","MD","MN","MO","MT","NC","NC","NC","NE","NH","NV","NV","NY","NY","OR","PA","PA","SC","TN","TX","TX","TX","TX","TX","UT","VA","VA","WA","WA","WA","WV"};

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
            string expectedList = "WA,WA,WA,WA";

            Assert.AreEqual(expectedList, aggregateList);
        }

        [TestMethod]
        public void GetAggregateListWithCsvFile()
        {
            SampleData sampleData = new SampleData();
            string aggregateList = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            string expectedList = "AL,AZ,CA,CA,CA,CA,CA,DC,DC,DC,FL,FL,GA,GA,GA,IN,KS,LA,LA,MD,MD,MN,MO,MT,NC,NC,NC,NE,NH,NV,NV,NY,NY,OR,PA,PA,SC,TN,TX,TX,TX,TX,TX,UT,VA,VA,WA,WA,WA,WV";

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
            sampleData.FilterByEmailAddress(null); //Should not work!
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

        }
    }
}
