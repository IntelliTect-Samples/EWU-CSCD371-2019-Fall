using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTest
    {
        [TestMethod]
        public void CsvRowsIsEnumerable()
        {
            //Arrange
            SampleData sData = new SampleData();
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
    }
}
