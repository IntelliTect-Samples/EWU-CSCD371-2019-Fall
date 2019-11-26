using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            Assert.AreEqual("AL AZ CA DC FL GA IN KS LA MD MN MO MT NC NE NH NV NY OR PA SC TN TX UT VA WA WV ", actualString);
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_IsCorrect() {
            //Arrange
            SampleData sampleData = new SampleData();

            //Assert
            Assert.AreEqual("AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV", sampleData.GetAggregateSortedListOfStatesUsingCsvRows());
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
            Assert.AreEqual(50, count);
        }

        [TestMethod]
        public void FilterByEmailAddress_IsCorrect() {
            //Arrange
            SampleData sampleData = new SampleData();
            (string, string) expectedPriscilla = ("Priscilla", "Jenyns");
            (string, string) expectedFremont = ("Fremont", "Pallaske");
            (string, string) expectedMelisa = ("Melisa", "Kerslake");
            (string, string) actualPriscillaString = ("", "");
            (string, string) actualFremontString = ("", "");
            (string, string) actualMelisaString = ("", "");

            //Act
            IEnumerable<(string, string)> actualPriscilla = sampleData.FilterByEmailAddress("pjenyns0@state.gov");
            IEnumerable<(string, string)> actualFremont = sampleData.FilterByEmailAddress("fpallaske3@umich.edu");
            IEnumerable<(string, string)> actualMelisa = sampleData.FilterByEmailAddress("mkerslake4@dion.ne.jp");
            foreach ((string, string) name in actualPriscilla) {
                actualPriscillaString = name;
            }
            foreach ((string, string) name in actualFremont) {
                actualFremontString = name;
            }
            foreach ((string, string) name in actualMelisa) {
                actualMelisaString = name;
            }

            //Assert
            Assert.AreEqual(expectedPriscilla, actualPriscillaString);
            Assert.AreEqual(expectedFremont, actualFremontString);
            Assert.AreEqual(expectedMelisa, actualMelisaString);
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_IsCorrect() {
            //Arrange
            SampleData sampleData = new SampleData();
            IEnumerable<IPerson> people = sampleData.People;

            //Act

            //Assert
            Assert.AreEqual("AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV", sampleData.GetAggregateListOfStatesGivenPeopleCollection(people));
        }
    }
}


