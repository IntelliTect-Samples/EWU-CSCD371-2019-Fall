using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void SampleDataConstructor_ThrowsExceptionOnNullOrEmptyFileName(string? fileName)
        {
            Assert.ThrowsException<ArgumentNullException>(
                    () => new SampleData(fileName));
        }

        [TestMethod]
        public void SampleData_CsvRows_Enumerates()
        {
            var rows = new string[]
            {
                "Row,number,one",
                "Row,number,two",
                "Row,number,three",
            };
            var fileName = Path.GetTempFileName();

            using (var sw = new StreamWriter(@fileName))
                foreach (string row in rows)
                    sw.WriteLine(row);

            var sut = new SampleData(fileName);

            var pairs = rows.Zip(sut.CsvRows, (row, sutRow) => (row, sutRow));

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
    }
}
