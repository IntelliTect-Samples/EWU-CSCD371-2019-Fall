using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SampleData_CsvConstructorBadFile_ThrowsException()
        {
            SampleData _ = new SampleData(null!);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void SampleData_CsvGetFromNonExistentFile_ThrowsException()
        {
            SampleData sample = new SampleData("BadFile.csv");

            IEnumerable<string> _ = sample.CsvRows;
        }

        [TestMethod]
        public void SampleData_CsvGet_GetsValues()
        {
            SampleData sample = new SampleData("SpokaneAddresses.csv");

            IEnumerable<string> values = sample.CsvRows;

            Assert.AreEqual(5, values.Count());
            Assert.IsTrue(values.Contains("1,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022"));
            Assert.IsTrue(values.Contains("5,Antonia,Rowland,arowland@stanford.edu,456 Pepper Wood Court,Spokane,WA,99021"));
        }


        [TestMethod]
        public void SampleData_UniqueList()
        {
            SampleData sample = new SampleData("SpokaneAddresses.csv");
            IEnumerable<string> value = sample.GetUniqueSortedListOfStatesGivenCsvRows();

            //since all addresses are from WA we should have only 1 to have unique.
            Assert.AreEqual(1, value.Count());

        }

        [TestMethod]
        public void SampleData_SortedList()
        {
            SampleData sample = new SampleData("TestAddresses.csv");
            IEnumerable<string> unsortedRows = sample.CsvRows;
            IEnumerable<string> sortedRows = unsortedRows.OrderBy(row => row.Split(',')[(int)Assignment.SampleData.Column.State]);
            IEnumerable<string> value = sample.GetUniqueSortedListOfStatesGivenCsvRows();

            //check that the first and last are in the right space.
            Assert.IsTrue(value.Count() <= unsortedRows.Count());
            Assert.AreEqual(sortedRows.ElementAt(0).Split(',')[(int)Assignment.SampleData.Column.State], value.ElementAt(0));
            Assert.AreEqual(sortedRows.ElementAt(sortedRows.Count() - 1).Split(',')[(int)Assignment.SampleData.Column.State], value.ElementAt(value.Count() - 1));
        }

        [TestMethod]
        public void SampleData_GetAggregateStringFromCsv()
        {
            SampleData sample = new SampleData("TestAddresses.csv");
            string expected = "AL,AZ,WA,WY";

            string value = sample.GetAggregateSortedListOfStatesUsingCsvRows();

            Assert.IsNotNull(value);

            Assert.AreEqual(expected, value);

        }

        [TestMethod]
        public void SampleData_GetAggregateStringFromPeople()
        {
            SampleData sample = new SampleData("TestAddresses.csv");
            IEnumerable<IPerson> people = sample.People;
            string expected = "AL,AZ,WA,WY";

            string value = sample.GetAggregateListOfStatesGivenPeopleCollection(people);

            Assert.IsNotNull(value);

            Assert.AreEqual(expected, value);

        }

        [TestMethod]
        public void SampleData_People_ReturnsListOfPeople()
        {
            SampleData sample = new SampleData("TestAddresses.csv");
            IEnumerable<IPerson> people = sample.People;
            string[] names = { "Joly", "Fayette", "Phillida", "Antonia", "Scott" };

            for (int i = 0; i < people.Count(); i++)
            {
                Assert.AreEqual(names[i], people.ElementAt(i).FirstName);
            }
        }

    }
}
