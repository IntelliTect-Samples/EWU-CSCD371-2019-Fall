using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment8.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_HardCodedSpokane()
        {
            string testFile = Path.GetTempFileName();

            using (StreamWriter sw = File.CreateText(testFile))
            {
                sw.WriteLine("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip");
                sw.WriteLine("8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022");
                sw.WriteLine("15,Phillida,Chastagnier,pchastagniere@reference.com,1 Rutledge Point,Spokane,WA,99021");
                sw.WriteLine("19,Fayette,Dougherty,fdoughertyi@stanford.edu,6487 Pepper Wood Court,Spokane,WA,99021");
            }

            SampleData sampleData = new SampleData(testFile);
            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            Assert.AreEqual(1, states.Count());
            Assert.IsTrue(states.Contains("WA"));

            File.Delete(testFile);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGxivenCsvRows_AllDistinctUingLINQ()
        {
            SampleData sampleData = new SampleData("People.csv");
            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            string[] hold = { "MT", "FL", "CA", "GA", "TX", "VA", "WA", "PA", "TN", "NC", "DC", "NE", "NV", "WV", "MD", "AZ", "NY", "KS", "LA", "MN", "UT", "NH", "OR", "MO", "SC", "IN", "AL" };
            List<string> statesExpected = new List<string>();
            for (int i = 0; i < hold.Length; i++)
            {
                statesExpected.Add(hold[i]);
            }
            statesExpected.Sort();
            Assert.IsTrue(states.SequenceEqual(statesExpected));
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_AreAggregated()
        {
            SampleData sampleData = new SampleData("People.csv");
            string states = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            string result= "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";

            Assert.AreEqual(result, states);
        }

        [TestMethod]
        public void People_CollectionReturned()
        {
            string testFile = Path.GetTempFileName();

            using (StreamWriter sw = File.CreateText(testFile))
            {
                sw.WriteLine("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip");
                sw.WriteLine("8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022");
                sw.WriteLine("15,Phillida,Chastagnier,pchastagniere@reference.com,1 Rutledge Point,Spokane,WA,99021");
                sw.WriteLine("19,Fayette,Dougherty,fdoughertyi@stanford.edu,6487 Pepper Wood Court,Spokane,WA,99021");
            }

            SampleData sampleData = new SampleData(testFile);

            IEnumerable<IPerson> people = sampleData.People;

            Assert.IsTrue(people.ToArray().Length == 3);
            File.Delete(testFile);
        }

        [TestMethod]
        public void EmailFilter_Test()
        {
            string testFile = Path.GetTempFileName();

            using (StreamWriter sw = File.CreateText(testFile))
            {
                sw.WriteLine("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip");
                sw.WriteLine("8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022");
                sw.WriteLine("15,Phillida,Chastagnier,pchastagniere@reference.com,1 Rutledge Point,Spokane,WA,99021");
            }

            SampleData sampleData = new SampleData(testFile);

            IEnumerable<(string, string)> person = sampleData.FilterByEmailAddress(email => email.StartsWith("j"));

            Assert.AreEqual(1,person.Count());
            File.Delete(testFile);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAggregateListOfStatesGivenPeopleCollection_Null()
        {
            SampleData sampleData = new SampleData("People.csv");
            sampleData.GetAggregateListOfStatesGivenPeopleCollection(null);
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_ListCorrect()
        {
            SampleData sampleData = new SampleData("People.csv");
            IEnumerable<IPerson> people = sampleData.People;
            string toTest = sampleData.GetAggregateListOfStatesGivenPeopleCollection(people);
            string result = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";
            Assert.AreEqual(result, toTest);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SampleDataConstructor_Null()
        {
            _ = new SampleData(null);
        }
    }
}
