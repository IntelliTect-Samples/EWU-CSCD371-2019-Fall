using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace ShoppingList.Test
{
    [TestClass]
    public class MainWindowViewModel
    {
        [TestMethod]
        public void TestMethod()
        {
            ObservableCollection<Item> items = new ObservableCollection<Item>();
            Item item = new Item("Another item", 12);
            items.Add(item);

            Assert.AreEqual(items.Count, 1);
        }
    }
}
