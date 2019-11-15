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
        public void SortUtility_SortAscending_UsingAnAnonymousMethod()
        {
            int[] ints = { 0, 2, 1, 5, 19, 34, 5, 6 };
            int[] intsOrdered = { 0, 1, 2, 5, 5, 6, 19, 34 };

            SortUtility sort = new SortUtility();

            SortFunc sorter = delegate (int first, int second) { return first > second; };

            ints = sort.Sort(ints, sorter);

            Assert.IsTrue(ints.SequenceEqual(intsOrdered));
        }

        [TestMethod]
        public void SortUtility_SortAscending_UsingALambdaExpresion()
        {
            int[] ints = { 0, 2, 1, 5, 19, 34, 5, 6 };
            int[] intsOrdered = { 0, 1, 2, 5, 5, 6, 19, 34 };

            SortUtility sort = new SortUtility();

            ints = sort.Sort(ints, (first, second) => { return first > second; });

            Assert.IsTrue(ints.SequenceEqual(intsOrdered));
        }

        [TestMethod]
        public void SortUtility_SortAscending_UsingALambdaStatement()
        {
            int[] ints = { 0, 2, 1, 5, 19, 34, 5, 6 };
            int[] intsOrdered = { 0, 1, 2, 5, 5, 6, 19, 34 };

            SortUtility sort = new SortUtility();

            ints = sort.Sort(ints, ((int first, int second) => { return first > second; }));

            Assert.IsTrue(ints.SequenceEqual(intsOrdered));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_SortAscending_PassingNull()
        {
            SortUtility sort = new SortUtility();
            sort.Sort(null, ((int num1, int num2) => num1 < num2));
        }


    }
}
