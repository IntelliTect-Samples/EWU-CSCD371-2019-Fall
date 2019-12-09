using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {

        [TestMethod]
        public void Constructor_SetsDefaultSelectedItem()
        {
            var viewmodel = new MainWindowViewModel();

            Assert.AreEqual(viewmodel.ShoppingList.First(), viewmodel.SelectedItem);
        }

        [TestMethod]
        public void AddItemCommand_AddsItem()
        {
            var viewmodel = new MainWindowViewModel();
            int expectedCount = viewmodel.ShoppingList.Count;
            viewmodel.Text = "TestItem";

            viewmodel.AddNewItemCommand.Execute(null);

            Assert.AreEqual(expectedCount + 1, viewmodel.ShoppingList.Count);
        }

        [TestMethod]
        public void AddItemCommand_AddsItemWithCorrectName()
        {
            var viewmodel = new MainWindowViewModel();
            string expectedText = "TestItem";
            viewmodel.Text = expectedText;

            viewmodel.AddNewItemCommand.Execute(null);

            Assert.AreEqual(expectedText, viewmodel.ShoppingList.Last().Name);
        }

        [TestMethod]
        public void EditsSelectedItem_ChangesItemInList()
        {
            var viewmodel = new MainWindowViewModel();
            string expectedNewName = "NewName";
            viewmodel.SelectedItem = viewmodel.ShoppingList.Last();

            viewmodel.SelectedItem.Name = expectedNewName;

            Assert.AreEqual(expectedNewName, viewmodel.ShoppingList.Last().Name);
        }
    }
}
