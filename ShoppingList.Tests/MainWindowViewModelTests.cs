using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ShoppingList.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void OnAddShoppingItem_AddsItemToList()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();

            viewModel.NewShoppingItem = "Mango";
            int shoppingListSize = viewModel.ShoppingList.Count;

            ICommand addItemCommand = viewModel.AddShoppingItemCommand;
            addItemCommand.Execute(viewModel.NewShoppingItem);

            Assert.AreEqual(shoppingListSize + 1, viewModel.ShoppingList.Count);
            Assert.AreEqual("Mango", viewModel.ShoppingList[viewModel.ShoppingList.Count - 1].ItemName);
        }

        [TestMethod]
        [DataRow("\n")]
        [DataRow("  ")]
        [DataRow(" ")]
        public void OnAddShopingItem_DoesntAddEmptyItem(string inputString)
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();

            viewModel.NewShoppingItem = inputString;
            int shoppingListSize = viewModel.ShoppingList.Count;

            viewModel.AddShoppingItemCommand.Execute(viewModel.NewShoppingItem);

            Assert.AreNotEqual(shoppingListSize + 1, viewModel.ShoppingList.Count);
            Assert.AreNotEqual(inputString, viewModel.ShoppingList[viewModel.ShoppingList.Count - 1].ItemName);
        }

        [TestMethod]
        public void MainWindowViewModel_Constructor_SetsSelectedItem()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();

            Assert.AreEqual(viewModel.ShoppingList.First(), viewModel.SelectedItem);
        }
    }
}
