using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void AddItem_ValidInput_AddsItems()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel
            {
                NewItem = "apple"
            };
            viewModel.AddItem.Execute(null);
             Assert.AreEqual(viewModel.ItemsList.ElementAt(0).Name, "~apple");
        }

        [DataRow(" ")]
        [DataRow(null)]
        [TestMethod]
        public void AddItem_InvalidInput_DoesntAddItems(string value)
        {
            MainWindowViewModel viewModel = new MainWindowViewModel
            {
                NewItem = value
            };
            viewModel.AddItem.Execute(null);
            Assert.AreEqual(viewModel.ItemsList.Count, 0);
        }

        [TestMethod]
        public void DeleteItem_ValidInput_RemovesItem()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            ShoppingItem item = new ShoppingItem("Apple");
            viewModel.ItemsList.Add(item);

            viewModel.SelectedItem = item;
            viewModel.DeleteItem.Execute(item);
            Assert.AreEqual(0, viewModel.ItemsList.Count);
        }

        [TestMethod]
        public void DeleteItem_ValidInput_SelectedItemIsNull()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            ShoppingItem item = new ShoppingItem("Apple");
            viewModel.ItemsList.Add(item);

            viewModel.SelectedItem = item;
            viewModel.DeleteItem.Execute(item);
            Assert.IsNull(viewModel.SelectedItem);
        }

        [TestMethod]
        public void DeleteItem_ValidInput_DoesntRemoveUnselectedItem()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            ShoppingItem unSelected = new ShoppingItem("Apple");
            ShoppingItem selected = new ShoppingItem("Banana");
            viewModel.ItemsList.Add(unSelected);

            viewModel.SelectedItem = selected;
            viewModel.DeleteItem.Execute(unSelected);
            Assert.AreEqual(1, viewModel.ItemsList.Count);
        }
    }
}
