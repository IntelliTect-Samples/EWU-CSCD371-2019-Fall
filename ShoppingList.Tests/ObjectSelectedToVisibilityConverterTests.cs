using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Data;
using System.Windows;

namespace ShoppingList.Tests
{
    [TestClass]
    public class ObjectSelectedToVisibilityConverterTests
    {
        [TestMethod]
        public void Convert_NullValue_ReturnsCollapsedVisibility()
        {
            //Arrange
            ObjectSelectedToVisibilityConverter converter = new ObjectSelectedToVisibilityConverter();
            //Act
            object visibility = converter.Convert(null!, null!, null!, null!);
            //Assert
            Assert.AreEqual(Visibility.Collapsed,visibility);
        }

        [TestMethod]
        public void Convert_ShoppingItem_ReturnsVisibleVisibility()
        {
            //Arrange
            ObjectSelectedToVisibilityConverter converter = new ObjectSelectedToVisibilityConverter();
            ShoppingItem apple = new ShoppingItem("apple");
            //Act
            object visibility = converter.Convert(apple, null!, null!, null!);
            //Assert
            Assert.AreEqual(Visibility.Visible, visibility);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ConvertBack_NormalOperations_ThrowsException()
        {
            //Arrange
            ObjectSelectedToVisibilityConverter converter = new ObjectSelectedToVisibilityConverter();
            //Act
            converter.ConvertBack(null!, null!, null!, null!);
            //Assert
        }
    }
}
