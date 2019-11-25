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
        public void GetUniqueSortedListOfStates()
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
    }
}
