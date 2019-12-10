using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingList.Tests
{

    [TestClass]
    public class MainWindowViewModelTests
    {

        [TestMethod]
        public void AddItem_GivenCorrectInput_AddsToList()
        {
            var vm = new MainWindowViewModel();

            var startingLength = vm.Items.Count;
            vm.NewName = "Test Item";
            vm.AddItemCommand.Execute(null);

            Assert.IsFalse(startingLength == vm.Items.Count);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void AddItem_GivenInvalidInput_ListRetainsOriginalSize(string name)
        {
            var vm = new MainWindowViewModel();

            var startingLength = vm.Items.Count;
            vm.NewName = name;
            vm.AddItemCommand.Execute(null);

            Assert.IsTrue(startingLength == vm.Items.Count);
        }

        [TestMethod]
        public void AddItem_ProperlyHandlesAmounts()
        {
            var vm = new MainWindowViewModel();
            vm.Items.Clear();

            vm.NewName = "Item 2";
            vm.AddItemCommand.Execute(null);

            vm.NewName   = "Item 1";
            vm.NewAmount = 3;
            vm.AddItemCommand.Execute(null);

            Assert.AreEqual(1, vm.Items[0].Amount);
            Assert.AreEqual(4, vm.Items[1].Amount);
        }

        [TestMethod]
        public void SelectedItem_CorrectlyUpdatesRelatedProperties()
        {
            var vm = new MainWindowViewModel();

            var item = new Item {Name = "Test", Amount = 5};
            vm.SelectedItem = item;

            // Reversed
            Assert.AreEqual("Test", vm.NewName);
            Assert.IsTrue(vm.NewAmount == 4);
        }

        [TestMethod]
        public void RemoveItem_CorrectlyRemovesItem()
        {
            var vm = new MainWindowViewModel();

            var startingLength = vm.Items.Count;
            vm.SelectedIndex = 0;
            vm.RemoveItemCommand.Execute(null);

            Assert.IsFalse(startingLength == vm.Items.Count);
        }

        [TestMethod]
        public void Item_GetAmountString_PrintsCorrectly()
        {
            var vm = new MainWindowViewModel();

            var item = new Item {Name = "Test", Amount = 5};
            Assert.AreEqual($"x {item.Amount}", item.GetAmountString);
        }

        [TestMethod]
        public void AddItem_EditExistingItem_CorrectlyEditsItem()
        {
            var vm = new MainWindowViewModel();

            var originalSize = vm.Items.Count;
            vm.SelectedItem  = vm.Items[0]; // Apples, 3
            vm.SelectedIndex = 0;

            vm.NewName   = "Edit";
            vm.NewAmount = 10; // = 11
            vm.AddItemCommand.Execute(null);

            // Reversed
            Assert.AreEqual("Edit", vm.Items[0].Name);
            Assert.AreEqual(11, vm.Items[0].Amount);
            Assert.AreEqual(originalSize, vm.Items.Count);
        }

        [TestMethod]
        public void SelectedItem_Get_ReturnsCorrectly()
        {
            var vm = new MainWindowViewModel();

            vm.SelectedItem = vm.Items[0]; // Apples, 3

            Assert.AreEqual("Apples", vm.SelectedItem.Name);
            Assert.AreEqual(3, vm.SelectedItem.Amount);
        }

    }

}
