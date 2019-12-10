using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingList;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass()]
    public class ItemVisibilityConverterTests
    {
        [TestMethod()]
        public void ItemVisibilityConverterObjectIsItem()
        {
            //Arrange
            Item item = new Item("Test Item");
            ItemVisibilityConverter itemVisibilityConverter = new ItemVisibilityConverter();

            //Act
            var result = itemVisibilityConverter.Convert(item, null, null, null);

            //Assert
            Assert.AreEqual(result.ToString(), "Visible");
        }

        [TestMethod]
        public void ItemVisibilityConverterObjectIsNotItem()
        {
            //Arrange
            int[] array = new int[5];
            ItemVisibilityConverter itemVisibilityConverter = new ItemVisibilityConverter();

            //Act
            var result = itemVisibilityConverter.Convert(array, null, null, null);

            //Assert
            Assert.AreEqual(result.ToString(), "Hidden");
        }
    }
}