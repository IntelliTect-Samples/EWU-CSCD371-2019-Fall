using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void SampleData_ReturnUniqueSorted_WithHardCodedList()
        {

        }

        [TestMethod]
        public void SampleData_ReturnUniqueSorted_WithPeopleCsv()
        {

        }

        [TestMethod]
        public void GetAggregateListWithHardCodedFile()
        {
            SampleData sampleData = new SampleData("TestPeople.csv");
            string aggregateList = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            string expectedList = "WA,WA,WA,WA";

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
        public void SampleData_ReturnPeopleFromPeopleCsv()
        {

        }

        [TestMethod]
        public void SampleData_ThrowException_WithNullFilter()
        {

        }

        [TestMethod]
        public void SampleData_ThrowException_WithNullPeople()
        {

        }

        [TestMethod]
        public void SampleData_ReturnAggregateList_WithListOfPeople()
        {

        }
    }
}
