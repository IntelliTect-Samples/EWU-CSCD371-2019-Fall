using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [DataTestMethod]
        [DataRow("milk")]
        [DataRow("cheese")]
        [DataRow("eggs")]
        [DataRow("bread")]
        public void AddItem_CorrectInput_Pass(string itemName)
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();

            int initialLength = viewModel.Items.Count;
            viewModel.NewItemName = itemName;
            viewModel.AddItemCommand.Execute(null);
            int newLength = viewModel.Items.Count;

            Assert.AreNotEqual<int>(initialLength, newLength);
        }

        [DataTestMethod]
        [DataRow("  ")]
        [DataRow("")]
        [DataRow("\n")]
        public void AddItem_InvalidInput_Pass(string itemName)
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();

            int initialLength = viewModel.Items.Count;
            viewModel.NewItemName = itemName;
            viewModel.AddItemCommand.Execute(null);
            int newLength = viewModel.Items.Count;

            Assert.AreEqual<int>(initialLength, newLength);
        }
    }
}
