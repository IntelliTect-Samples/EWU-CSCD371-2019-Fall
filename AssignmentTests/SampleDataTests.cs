using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace Assignment.Tests {
    [TestClass]
    public class SampleDataTests {
        [TestMethod]
        public void CsvRows_IsCorrect() {
            //Arrange
            string[] expected = File.ReadAllLines("People.csv");
            string expectedString = "";
            for (int i = 1; i < expected.Length; i++) {
                expectedString += expected[i] + " ";
            }
            SampleData sampleData = new SampleData();

            //Act
            IEnumerable<string> actual = sampleData.CsvRows;
            string actualString = "";
            foreach (string s in actual) {
                actualString += s + " ";
            }

            //Assert
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_IsCorrect() {
            //Arrange
            SampleData sampleData = new SampleData();

            //Act
            IEnumerable<string> actual = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            string actualString = "";
            foreach (string s in actual) {
                actualString += s + " ";
            }

            //Assert
            Assert.AreEqual("CA FL GA MT TX ", actualString);
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_IsCorrect() {
            //Arrange
            SampleData sampleData = new SampleData();

            //Assert
            Assert.AreEqual("CA,FL,GA,MT,TX", sampleData.GetAggregateSortedListOfStatesUsingCsvRows());
        }

        [TestMethod]
        public void People_IsCorrect() {
            //Arrange
            SampleData sampleData = new SampleData();

            //Act
            sampleData.People.GetEnumerator().MoveNext();
            int count = 0;
            foreach (Person person in sampleData.People) {
                count++;
            }

            //Assert
            Assert.AreEqual(5, count);
        }
    }
}


