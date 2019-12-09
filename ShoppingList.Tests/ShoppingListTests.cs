using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable CS8602

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void MainWindowViewModel_OnAddItem()
        {
            var model = new MainWindowViewModel();
            model.NewItemName = "test";
            int initialCount = model.Items.Count;
            model.AddItem.Execute(null);
            Assert.AreEqual(initialCount + 1, model.Items.Count);
        }
    }
}
