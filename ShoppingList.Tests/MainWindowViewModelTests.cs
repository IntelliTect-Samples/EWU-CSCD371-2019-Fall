using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass()]
    public class MainWindowViewModelTests
    {
        [TestMethod()]
        public void ShoppingListAddItem()
        {
            //Arrange
            ObservableCollection<Item> list = new ObservableCollection<Item>();
            Item item = new Item("Test Item");
            int beforeSize = list.Count;

            //Act
            list.Add(item);

            //Assert
            Assert.AreNotEqual(beforeSize, list.Count);
            Assert.IsTrue(list.Contains(item));
        }

        [TestMethod]
        public void ShoppingListAddNullItem()
        {
            //Arrange
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            string itemName = null!;
            mainWindowViewModel.TextToAdd = itemName;

            //Act
            mainWindowViewModel.AddItemCommand.Execute(itemName);

            //Assert
            Assert.AreEqual(mainWindowViewModel.ShoppingList.Count, 0);
        }

        [TestMethod]
        public void AddItemEmptyText()
        {
            //Arrange
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            string itemName = "";
            mainWindowViewModel.TextToAdd = itemName;

            //Act
            mainWindowViewModel.AddItemCommand.Execute(itemName);

            //Assert
            Assert.AreEqual(mainWindowViewModel.ShoppingList.Count, 0);
        }

        [TestMethod]
        public void AddItemGoodName()
        {
            //Arrange
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            string itemName = "Test Item";
            mainWindowViewModel.TextToAdd = itemName;

            //Act
            mainWindowViewModel.AddItemCommand.Execute(itemName);

            //Assert
            Assert.AreEqual(mainWindowViewModel.ShoppingList.Count, 1);
        }

        [TestMethod]
        public void DeleteItemNotNull()
        {
            //Arrange
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Item item = new Item("Test Item");
            mainWindowViewModel.ShoppingList.Add(item);
            mainWindowViewModel.SelectedItem = item;

            //Act
            mainWindowViewModel.DeleteItemCommand.Execute(mainWindowViewModel.SelectedItem);

            //Assert
            Assert.AreEqual(mainWindowViewModel.ShoppingList.Count, 0);
        }

        [TestMethod]
        public void DeleteItemNull()
        {
            //Arrange
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Item item = new Item("Test Item");
            mainWindowViewModel.ShoppingList.Add(item);
            mainWindowViewModel.SelectedItem = null;

            //Act
            mainWindowViewModel.DeleteItemCommand.Execute(mainWindowViewModel.SelectedItem);

            //Assert
            Assert.AreEqual(mainWindowViewModel.ShoppingList.Count, 1);
        }
    }
}