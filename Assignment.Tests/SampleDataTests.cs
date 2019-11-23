using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        private string? _FileName;
        private string[]? _TestString;

        [TestInitialize]
        public void TestInitialize()
        {
            _FileName = Path.GetTempFileName();
            _ = new FileInfo(_FileName)
            {
                Attributes = FileAttributes.Temporary
            };

            _TestString = new string[]
            {
                "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577",
                "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Tampa,FL,71961",
                "3,Chadd,Stennine,cstennine2@wired.com,94148 Kings Terrace,Long Beach,CA,59721",
                "4,Fremont,Pallaske,fpallaske3@umich.edu,16958 Forster Crossing,Atlanta,GA,10687",
                "5,Melisa,Kerslake,mkerslake4@dion.ne.jp,283 Pawling Parkway,Dallas,TX,88632"
            };

            using StreamWriter sw = new StreamWriter(_FileName);
            foreach (string line in _TestString)
            {
                sw.WriteLine(line);
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(_FileName))
                File.Delete(_FileName);
        }

        [TestMethod]
        public void CsvRows_ReadsAllButFirstLine_ReturnsLines()
        {
            SampleData sampleData = new SampleData(_FileName!);

            IEnumerable<string> list = sampleData.CsvRows;

            var elementsInFile = list.Zip(_TestString.Skip(1), (first, second) => (first, second));

            foreach (var (expected, actual) in elementsInFile)
            {
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
