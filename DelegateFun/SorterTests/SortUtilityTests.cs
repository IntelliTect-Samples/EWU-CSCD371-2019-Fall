using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sorter.Tests
{
    class SortUtilityTests
    {
        [TestMethod]
        public void SortUtilityTestAscending()
        {
            int[] items = new int[] { 2, 4, 2, 3, 7, 9, 2, 3 };
            string expected = "";
            foreach (int item in items)
            {
                expected += item + ",";
            }


            SortUtility.Sort(items, delegate(int first, int second)
            {
                return first > second;
            });

            string result = "";
            foreach (int item in items)
            {
                result += item + ",";
            }

            Assert.AreEqual(expected, result);
        }
    }
}
