using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void MainWindowViewModel_OnAddItem()
        {
            var sut = new MainWindowViewModel();

            sut.AddItemCommand.Execute(new Item());

            Assert.AreEqual(1, sut.Items.Count);
        }
    }
}
