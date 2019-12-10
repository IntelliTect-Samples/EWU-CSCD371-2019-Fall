using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingList;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass()]
    public class ItemTests
    {
        [TestMethod()]
        public void CreateItemGoodString()
        {
            //Arrange
            String name = "Test Item";

            //Act
            Item item = new Item(name);

            //Assert
            Assert.IsNotNull(item);
            Assert.AreEqual("Test Item", item.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateItemNullString()
        {
            //Arrange

            //Act
            Item item = new Item(null);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateItemEmptyString()
        {
            //Arrange

            //Act
            Item item = new Item("");

            //Assert
        }
    }
}