using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_PassingNull_ThrowException()
        {
            var sut = new Item(null!);
        }

        [TestMethod]
        public void Constructor_PassingValidString_CreatesItemSuccessfully()
        {
            var sut = new Item("Valid Item");
        }
    }
}
