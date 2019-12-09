using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void AddItemCommand_AddsItem()
        {
            MainWindowViewModel sut = new MainWindowViewModel();
            int initialCount = sut.Items.Count;

            sut.AddItemCommand.Execute(null);

            Assert.AreEqual<int>(initialCount + 1, sut.Items.Count);
            Assert.AreEqual<string>("New Item", sut.Items[0].Name);
        }
    }
}
