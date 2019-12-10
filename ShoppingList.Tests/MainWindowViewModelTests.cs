using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        #pragma warning disable CA1707 // Identifiers should not contain underscores... To allow Underscores in the name

        [DataTestMethod]
        [DataRow("Test")]
        [DataRow("Apple")]
        [DataRow("abc")]
        [DataRow("efg")]

        public void OnAddMethod_AddsToList(string myTests)
        {
            var window = new MainWindowViewModel();
            int currentCount = window.MyShoppingList.Count;
            window.NewName = myTests;

            if (window.AddItem != null)
                window.AddItem.Execute("");

            Assert.AreEqual(currentCount + 1, window.MyShoppingList.Count);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void OnAddMethod_DoesntAddToList(string myTests)
        {
            var window = new MainWindowViewModel();
            int currentCount = window.MyShoppingList.Count;
            window.NewName = myTests;
            
            if (window.AddItem != null)
                window.AddItem.Execute("");

            Assert.AreEqual(currentCount, window.MyShoppingList.Count);
        }

        [TestMethod]
        public void SelectedShopItem_IsNullBeforeAdding()
        {
            var window = new MainWindowViewModel();

            Assert.IsNull(window.SelectedShopItem);
        }

        [TestMethod]
        public void SelectedShopItem_NotNull()
        {
            var window = new MainWindowViewModel();
            window.NewName = "test";

            if(window.AddItem != null)
                 window.AddItem.Execute("");

            if(window.SelectedShopItem != null)
                Assert.IsTrue(window.SelectedShopItem.Name == "test");
        }
    }
}
