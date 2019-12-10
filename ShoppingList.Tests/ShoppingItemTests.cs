using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingList.Tests
{
    [TestClass]
    public class ShoppingItemTests
    {
        [TestMethod]
        public void Constructor_ValidName_Success()
        {
            //Arrange
            ShoppingItem shoppingItem;
            //Act
            shoppingItem = new ShoppingItem("test");
            //Assert
            Assert.AreEqual<string>("test", shoppingItem.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullName_ThrowsException()
        {
            //Arrange
            //Act
            _ = new ShoppingItem(null!);
            //Assert
        }

        [TestMethod]
        public void Set_ValidName_ReturnsCorrectName()
        {
            //Arrange
            ShoppingItem shoppingItem = new ShoppingItem("first")
            {
                //Act
                Name = "second"
            };
            //Assert
            Assert.AreEqual<string>("second", shoppingItem.Name);
        }
    }
}
