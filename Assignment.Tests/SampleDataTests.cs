using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        [DataRow(@".\People.csv")]
        public void SampleData_CsvRows_ReturnsCollection(string fileName)
        {
            //Organize
            SampleData sampleData = new SampleData();
            List<String> testList = new List<String>();

            //Act
            IEnumerable<string> result = sampleData.CsvRows;

            using (var fileReader = new StreamReader(@"..\..\..\..\Assignment\People.csv"))
            {
                for(string? s = fileReader.ReadLine(); !fileReader.EndOfStream; s = fileReader.ReadLine())
                {
                    testList.Add(s!);
                }
            }

            //Assert
            CollectionAssert.AreEqual(testList, result.ToList());
        }
    }
}
