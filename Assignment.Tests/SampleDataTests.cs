using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

// For some reason, adding a nowarn property
// to the csproj file does not stop the warnings...
#pragma warning disable CA1062
#pragma warning disable CA1707

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        public string FileName = string.Empty;
        public string[] Rows = new string[0];

        [TestInitialize]
        public void TestInitialize()
        {
            FileName = Path.GetTempFileName();
            Rows = new string[]
            {
                "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip",
                "4,Fremont,Pallaske,fpallaske3@umich.edu,16958 Forster Crossing,Atlanta,GA,10687",
                "5,Melisa,Kerslake,mkerslake4@dion.ne.jp,283 Pawling Parkway,Dallas,TX,88632",
                "6,Darline,Brauner,dbrauner5@biglobe.ne.jp,33 Menomonie Trail,Atlanta,GA,10687",
            };

            using (var sw = new StreamWriter(@FileName))
                foreach (string row in Rows)
                    sw.WriteLine(row);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(@FileName))
                File.Delete(@FileName);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void SampleDataConstructor_ThrowsExceptionOnNullOrEmptyFileName(string? FileName)
        {
            Assert.ThrowsException<ArgumentNullException>(
                    () => new SampleData(FileName));
        }

        [TestMethod]
        public void SampleData_CsvRows_Enumerates()
        {
            var sut = new SampleData(FileName);

            var pairs = Rows.Skip(1).Zip(sut.CsvRows, (row, sutRow) => (row, sutRow));

            foreach (var (expected, actual) in pairs)
                Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(new string[] {"7884 Corry Way","Helena","MT","70577"})]
        [DataRow(new string[] {"2646 Hazelcrest Road","San Francisco","CA","40486"})]
        [DataRow(new string[] {"90 Birchwood Street","Las Vegas","NV","36230"})]
        public void SampleData_ParseAddress_Success(string[] data)
        {
            var expected = new Address()
            {
                StreetAddress = data[0],
                City = data[1],
                State = data[2],
                Zip = data[3],
            };

            Address sut = SampleData.ParseAddress(data);

            Assert.IsTrue(expected.Equals(sut));
        }

        [DataTestMethod]
        [DataRow(new string[] {"id","Kevin","Durant","email","7884 Corry Way","Helena","MT","70577"})]
        [DataRow(new string[] {"id","Kevin","Durant","email","2646 Hazelcrest Road","San Francisco","CA","40486"})]
        [DataRow(new string[] {"id","Kevin","Durant","email","90 Birchwood Street","Las Vegas","NV","36230"})]
        public void SampleData_ParsePerson_Success(string[] data)
        {
            var expected = new Person()
            {
                FirstName = data[1],
                LastName = data[2],
                Address = new Address()
                {
                    StreetAddress = data[4],
                    City = data[5],
                    State = data[6],
                    Zip = data[7]
                }
            };

            Person sut = SampleData.ParsePerson(string.Join(',', data));

            Assert.IsTrue(sut.Equals(expected));
        }

        [TestMethod]
        public void SampleData_ParseAddress_ThrowsExceptionOnNullData()
        {
            Assert.ThrowsException<ArgumentNullException>(
                    () => SampleData.ParseAddress(null));
        }

        [TestMethod]
        public void SampleData_ParseAddress_ThrowsExceptionOnNotEnoughData()
        {
            Assert.ThrowsException<ArgumentException>(
                    () => SampleData.ParseAddress(new string[] {"", "", ""}));
        }

        [TestMethod]
        public void SampleDataPeople_ReturnsPeopleFromFile()
        {
            var expectedPeople = new Person[]
            {
                SampleData.ParsePerson(Rows[1]),
                SampleData.ParsePerson(Rows[2]),
                SampleData.ParsePerson(Rows[3]),
            };

            var sut = new SampleData(FileName);

            var pairs = expectedPeople.Zip(sut.People, (expected, person) => (expected, person));

            foreach (var (expected, actual) in pairs)
                Assert.IsTrue(expected.Equals(actual),
                        $"E: {expected.ToString()} A: {actual.ToString()}");
        }

        [TestMethod]
        public void FilterByEmailAddress_GetsAllPeopleFromTautology()
        {
            var expectedTuples = new (string, string)[]
            {
                ("Fremont", "Pallaske"),
                ("Melisa", "Kerslake"),
                ("Darline", "Brauner"),
            };

            var sut = new SampleData(FileName);

            var pairs = expectedTuples.Zip(sut.FilterByEmailAddress((email) => true), (e, p) => (e, p));

            foreach (var (expected, actual) in pairs)
                Assert.IsTrue(expected.Equals(actual),
                        $"E: {expected.ToString()} A: {actual.ToString()}");
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_Success()
        {
            var sut = new SampleData(@FileName);

            Assert.AreEqual(
                sut.GetAggregateListOfStatesGivenPeopleCollection(sut.People),
                "GA, TX");
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_Success()
        {
            var sut = new SampleData(@FileName);

            Assert.AreEqual(
                sut.GetAggregateSortedListOfStatesUsingCsvRows(),
                "GA, TX");
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_Success()
        {
            var expected = new List<string>()
            {
                "GA", "TX"
            };

            var sut = new SampleData(@FileName);

            var pairs = expected.Zip(sut.GetUniqueSortedListOfStatesGivenCsvRows(), (e, a) => (e, a));

            foreach (var (e, a) in pairs)
                Assert.IsTrue(e.Equals(a),
                        $"E: {e.ToString()} A: {a.ToString()}");
        }
    }
}
