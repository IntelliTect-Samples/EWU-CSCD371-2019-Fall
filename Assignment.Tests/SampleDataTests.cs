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
    }
}
