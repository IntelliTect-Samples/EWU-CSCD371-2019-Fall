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
        private MainWindowViewModel ViewModel { get; set; }
        [TestInitialize]
        public void SetUp()
        {
            ViewModel = new MainWindowViewModel();
        }
        [TestMethod]
        public void Constructor_SetsDefaultSelectedPerson()
        {
            Assert.AreEqual(ViewModel.Items.First(), ViewModel.SelectedItem);
        }
        [TestMethod]
        public void ValueConverter_IsVisible()
        {
            Item item = new Item("Apple");
            var converter = new VisibilityConverter();

            string visibility = (string)converter.Convert(item,null,null,null);

            Assert.AreEqual("Visible",visibility);
        }

        [TestMethod]
        public void AddPersonCommand_AddsPerson()
        {
            int initialCount = ViewModel.Items.Count;
            ViewModel.NewItem = "Toast";

            ViewModel.AddItemCommand.Execute(null);

            Assert.AreEqual(initialCount + 1, ViewModel.Items.Count);
        }

        [TestMethod]
        public void AddPersonCommand_NotNull()
        {
            int initialCount = ViewModel.Items.Count;

            ViewModel.AddItemCommand.Execute("");

            Assert.AreEqual(initialCount, ViewModel.Items.Count);
        }
        [TestMethod]
        public void ChangeNameCommand_NameIsChanged()
        {
            string initialName = ViewModel.SelectedItem.Name;
            ViewModel.SelectedItem.Name = "Chee";

            ViewModel.ChangeNameCommand.Execute(null);
            ViewModel.SelectedItem = ViewModel.Items.First();

            Assert.AreNotEqual(initialName, ViewModel.SelectedItem.Name);
        }
    }
}
