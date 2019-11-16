using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {

        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingALambdaStatement()
        {

        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingALambdaExpression()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_ShouldSortAscending_PassingNull()
        {
            SortUtility sortUtility = new SortUtility();

            sortUtility.Sort(null, (int first, int second) => { return first < second; });
        }
    }
}
