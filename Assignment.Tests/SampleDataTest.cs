using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTest
    {
        [TestMethod]
        public void CsvRowsIsEnumerable()
        {
            //Arrange
            SampleData sData = new SampleData();
            IEnumerable<string> collection = sData.CsvRows;
            List<string> enumerated = new List<string>();

            //Act
            foreach (string s in collection)
            {
                enumerated.Add(s);
            }

            //Assert
            Assert.AreEqual(collection.Count(), enumerated.Count());
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsDistinctListOfStates()
        {
            //Arrange
            SampleData sData = new SampleData();
            IEnumerable<string> states;

            //Act
            states = sData.GetUniqueSortedListOfStatesGivenCsvRows();

            //Assert
            foreach (string s in states)
            {
                int count = 0;
                foreach (string b in states)
                {
                    if (b == s)
                        count++;
                }

                Assert.AreEqual(1, count);
            }
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsSortedList()
        {
            //Arrange
            SampleData sData = new SampleData();
            string[] states;

            //Act
            states = sData.GetUniqueSortedListOfStatesGivenCsvRows().ToArray();

            //Assert
            for(int i = 1; i < states.Length; i++)
            {
                Assert.IsTrue(states[i].CompareTo(states[i - 1]) > 0);
            }
        }
    }
}
