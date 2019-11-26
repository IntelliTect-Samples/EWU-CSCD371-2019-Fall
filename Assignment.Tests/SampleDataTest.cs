using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTest
    {
        private readonly SampleData sData = new SampleData();

        [TestMethod]
        public void CsvRowsIsEnumerable()
        {
            //Arrange
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
        public void CsvRows_SkipsFirstRow()
        {
            //Arrange
            IEnumerable<string> list;

            //Act
            list = sData.CsvRows;

            //Assert
            Assert.AreNotEqual("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip", list.First());
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsDistinctList()
        {
            //Arrange
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
            string[] states;

            //Act
            states = sData.GetUniqueSortedListOfStatesGivenCsvRows().ToArray();

            //Assert
            for(int i = 1; i < states.Length; i++)
            {
                Assert.IsTrue(states[i].CompareTo(states[i - 1]) > 0);
            }
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsCommaSepString()
        {
            //Arrange
            string list;

            //Act
            list = sData.GetAggregateSortedListOfStatesUsingCsvRows();

            //Assert
            Assert.AreEqual("AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV", list);
        }

        [TestMethod]
        public void People_ReturnsIEnumerableOfInstantiatedPeople()
        {
            //Arrange
            IEnumerable<IPerson> people;
            
            //Act
            people = sData.People;

            //Assert
            Assert.IsNotNull(people);
            Assert.AreEqual(50, people.Count());
            Assert.IsNotNull(people.First().Address, people.First().EmailAddress, people.First().FirstName, people.First().LastName);
        }

        [TestMethod]
        public void FilterByEmailAddress_ReturnsCorrectNames()
        {
            //Arrange
            IEnumerable<(string first, string last)> people;
            List<(string first, string last)> peoplePrePop = new List<(string first, string last)>();
            (string first, string last)[] names;
            (string first, string last)[] namesPrePop;

            //Act
            peoplePrePop.Add(("Adrea", "Lay"));
            people = sData.FilterByEmailAddress(email => email.Equals("alayz@spotify.com"));
            names = people.ToArray();
            namesPrePop = peoplePrePop.ToArray();

            //Assert
            try
            {
                for (int i = 0; i < names.Length; i++)
                {
                    Assert.AreEqual(names[i], namesPrePop[i]);
                }
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Fail("More matches to email than expected.");
            }
            
        }
    }
}
