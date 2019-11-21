using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Tests
{
    [TestClass()]
    public class SampleDataTests
    {
        [TestMethod()]
        public void SampleDataTest()
        {
            SampleData data = new SampleData("People.csv");

            Console.WriteLine(data.CsvRows);
        }
    }
}