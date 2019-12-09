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
        public void SelectedListItem_Setter_RemovesCurrentSelectedBlankItemFromShoppingItems()
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
        public void DeleteItem_RemovesItemFromList()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            viewModel.AddItemCommand.Execute(null);
            viewModel.SelectedListItem!.Text = "item 1";

            viewModel.DeleteItemCommand.Execute(null);

            Assert.IsNull(viewModel.SelectedListItem);
            Assert.AreEqual<int>(0, viewModel.ShoppingItems.Count);
        }

        [TestMethod]
        public void MoveUp_ShiftsSelectedItemTowardStartOfList()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            viewModel.AddItemCommand.Execute(null);
            viewModel.SelectedListItem!.Text = "item 1";
            viewModel.AddItemCommand.Execute(null);
            viewModel.SelectedListItem!.Text = "item 2";
            Item expected = viewModel.SelectedListItem;

            viewModel.MoveUpCommand.Execute(null);

            Assert.AreEqual<Item>(expected, viewModel.ShoppingItems[0]); // ref comparison is fine
        }

        [TestMethod]
        public void MoveDown_ShiftsSelectedItemTowardEndOfList()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            viewModel.AddItemCommand.Execute(null);
            viewModel.SelectedListItem!.Text = "item 1";
            viewModel.AddItemCommand.Execute(null);
            viewModel.SelectedListItem!.Text = "item 2";
            Item expected = viewModel.SelectedListItem;
            viewModel.SelectedListItem = viewModel.ShoppingItems[0];

            viewModel.MoveDownCommand.Execute(null);

            Assert.AreEqual<Item>(expected, viewModel.ShoppingItems[0]); // ref comparison is fine
        }
    }
}