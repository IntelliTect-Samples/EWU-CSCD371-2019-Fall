using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static Sorter.SortUtility;

#pragma warning disable CA1707

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        public void SortUtility_SortDescending_UsingAnAnonymousMethod()
        {
            int[] ints = { 0, 2, 1, 5, 19, 34, 5, 6 };
            int[] intsOrdered = { 34, 19, 6, 5, 5, 2, 1, 0 };

            SortFunc sorter = delegate (int first, int second) { return first < second; };

            ints = SortUtility.Sort(ints, sorter);

            Assert.IsTrue(ints.SequenceEqual(intsOrdered));
        }

        [TestMethod]
        public void SortUtility_SortAlphabetically_UsingALambdaExpresion()
        {
            int[] ints = { 0, 2, 1, 5, 19, 34, 5, 6 };
            int[] intsOrdered = { 0, 1, 2, 5, 5, 6, 19, 34 };

            ints = SortUtility.Sort(ints, (first, second) => { return first > second; });

            Assert.IsTrue(ints.SequenceEqual(intsOrdered));
        }

        [TestMethod]
        public void SortUtility_SortAscending_UsingALambdaStatement()
        {
            int[] ints = { 0, 2, 1, 5, 19, 34, 5, 6 };
            int[] intsOrdered = { 0, 1, 2, 5, 5, 6, 19, 34 };

            ints = SortUtility.Sort(ints, ((int first, int second) => { return first > second; }));

            Assert.IsTrue(ints.SequenceEqual(intsOrdered));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_SortAscending_PassingNull()
        {
            SortUtility.Sort(null, ((int num1, int num2) => num1 < num2));
        }


    }
}
