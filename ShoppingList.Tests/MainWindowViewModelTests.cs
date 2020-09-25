using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void AddItemCommand_IncreasesCount()
        {
            var sut = new MainWindowViewModel();
            int expected = sut.ShoppingList.Count + 1;

            sut.AddListItemCommand.Execute(new Item());

            Assert.AreEqual(expected, sut.ShoppingList.Count);

        }

        [TestMethod]
        public void DeleteItemCommand_DecreasesCount()
        {
            var sut = new MainWindowViewModel();
            int expected = sut.ShoppingList.Count;
            Item item = new Item();
            sut.AddListItemCommand.Execute(item);

            sut.DeleteListItemCommand.Execute(item);

            Assert.AreEqual(expected, sut.ShoppingList.Count);

        }

        [TestMethod]
        public void DeleteItemCommand_ListDoesNotContainItem()
        {
            var sut = new MainWindowViewModel();
            int expected = sut.ShoppingList.Count;
            Item item = new Item();
            sut.AddListItemCommand.Execute(item);

            sut.DeleteListItemCommand.Execute(item);

            CollectionAssert.DoesNotContain(sut.ShoppingList, item);

        }
    }
}
