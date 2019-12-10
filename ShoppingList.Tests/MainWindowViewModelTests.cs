using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void OnAddItem_ValidItem_AddsToList()
        {
            // Arrange
            MainWindowViewModel sut = new MainWindowViewModel();
            string testString = "TestString";
            sut.NewName = testString;

            // Act
            sut.AddItemCommand.Execute(testString);

            // Assert
            Assert.AreEqual(1, sut.ShoppingList.Count);
        }

        [DataTestMethod]
        [DataRow(" ")]
        [DataRow("")]
        [DataRow(null)]
        [DataRow("                                                      ")]
        public void OnAddItem_InvalidItem_DoesntAddToList(string item)
        {
            // Arrange
            MainWindowViewModel sut = new MainWindowViewModel();
            string testString = item;
            sut.NewName = testString;

            // Act
            sut.AddItemCommand.Execute(testString);

            // Assert
            Assert.AreEqual(0, sut.ShoppingList.Count);
        }
    }
}
