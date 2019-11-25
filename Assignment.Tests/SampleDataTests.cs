using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows()
        {
            ISampleData sut = new SampleData();

            var list = sut.CsvRows;

            Assert.IsFalse(list.Contains("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip"));
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows()
        {
            ISampleData sut = new SampleData();
            var expectedData = new List<string>
            {
                "AL",
                "AZ",
                "CA",
                "DC",
                "FL",
                "GA",
                "IN",
                "KS",
                "LA",
                "MD",
                "MN",
                "MO",
                "MT",
                "NC",
                "NE",
                "NH",
                "NV",
                "NY",
                "OR",
                "PA",
                "SC",
                "TN",
                "TX",
                "UT",
                "VA",
                "WA",
                "WV",
            };


            var list = sut.GetUniqueSortedListOfStatesGivenCsvRows();

            Assert.IsTrue(list.SequenceEqual(expectedData));
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows()
        {
            ISampleData sut = new SampleData();
            var expectedData =
                "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV";

            var list = sut.GetAggregateSortedListOfStatesUsingCsvRows();

            Assert.AreEqual(expectedData, list);
        }

        [TestMethod]
        public void People()
        {
            ISampleData sut = new SampleData();

            var list = sut.People;

            foreach (var person in list)
            {
                Assert.IsTrue(person is Person);
            }
        }

        [TestMethod]
        public void FilterByEmailAddress()
        {
            ISampleData sut = new SampleData();

            var list = sut.FilterByEmailAddress(e => e == "vdeeb@japanpost.jp");

            Assert.IsTrue(list.Count() == 1);
            Assert.AreEqual("Vince", list.First().FirstName);
            Assert.AreEqual("Dee", list.First().LastName);

        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection()
        {
            ISampleData sut = new SampleData();
            var expectedData =
                "MT, FL, CA, GA, TX, VA, WA, PA, TN, NC, DC, NE, NV, WV, MD, AZ, NY, KS, LA, MN, UT, NH, OR, MO, SC, IN, AL";

            var list = sut.GetAggregateListOfStatesGivenPeopleCollection(sut.People);

            Assert.AreEqual(expectedData,list);
        }
    }
}
