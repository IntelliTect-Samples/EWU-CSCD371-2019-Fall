using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void SelectedListItem_AddItemCommand_UpdatesSelectedListItem()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            Item startItem = viewModel.SelectedListItem!;

            viewModel.AddItemCommand.Execute(null);
            Item addedItem = viewModel.SelectedListItem!;

            Assert.AreNotEqual<Item>(addedItem, startItem); // ref comparison fine
        }

        [TestMethod]
        public void SelectedListItem_Set_RemovesCurrentSelectedBlankItemFromShoppingItems()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            viewModel.AddItemCommand.Execute(null);
            viewModel.SelectedListItem!.Text = "item 1";
            Item startItem = viewModel.SelectedListItem;
            int startCount = viewModel.ShoppingItems.Count;
            viewModel.AddItemCommand.Execute(null);
            viewModel.SelectedListItem!.Text = "";

            viewModel.SelectedListItem = null;

            Assert.AreEqual<int>(startCount, viewModel.ShoppingItems.Count);
            CollectionAssert.AreEqual(new List<Item>() { startItem }, viewModel.ShoppingItems);
        }

        [TestMethod]
        public void Deselect_SelectedListItemNulled()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            viewModel.AddItemCommand.Execute(null);
            Item startItem = viewModel.SelectedListItem!;

            viewModel.DeselectCommand.Execute(null);

            Assert.IsNotNull(startItem);
            Assert.IsNull(viewModel.SelectedListItem);
        }

        [TestMethod]
        public void DeleteItem()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            viewModel.AddItemCommand.Execute(null);
            viewModel.SelectedListItem!.Text = "item 1";

            viewModel.DeleteItemCommand.Execute(null);

            Assert.IsNull(viewModel.SelectedListItem);
            Assert.AreEqual<int>(0, viewModel.ShoppingItems.Count);
        }
    }
}